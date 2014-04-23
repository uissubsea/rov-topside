using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video.DirectShow;
using AForge.Video.FFMPEG;
using AForge.Video;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;
using UisSubsea.RovTopside.Logic;
using System.IO;

namespace UisSubsea.RovTopside.Data
{
    /// <summary>
    /// This class creates an instance of a VideoCaptureDevice.
    /// It is able to display the camera frames on a canvas,
    /// take snapshots and record video. 
    /// 
    /// If you don't want this 
    /// class to handle new frame events, you can use the constructor
    /// that doesn't take a PictureBox. Then you would want to get the 
    /// camera instance and add your own event handler.
    /// </summary>

    public class Camera : IDisposable, ICamera
    {
        public event EventHandler<FocusChangedEventArgs> FocusChanged;

        // This string is used to identify and compare camera objects.
        // It will be unique for each camera.
        private string cameraMoniker;
        private VideoCaptureDevice camera;
        private PictureBox canvas;
        private Queue<Bitmap> frameBuffer;
        private Thread videoRecorder;
        private bool handleEvents;
        private bool snapshot;
        private bool isRecording;

        public Camera(int index, Size desiredResolution)
        {
            initializeCamera(index, desiredResolution);
        }

        public Camera(int index, Size desiredResolution, PictureBox canvas)
        {
            initializeCamera(index, desiredResolution);
            this.canvas = canvas;
            setEventHandler();
        }

        public PictureBox Canvas
        {
            get
            {
                return canvas;
            }
            set
            {
                setCanvas(value);
            }
        }

        public static FilterInfoCollection CamerasConnected()
        {
            return new FilterInfoCollection(FilterCategory.VideoInputDevice);
        }

        // Recording happens in a background thread to prevent the video feed from stuttering.
        public void ToggleRecording()
        {
            if (!isRecording)
            {
                frameBuffer = new Queue<Bitmap>();
                videoRecorder = new Thread(new VideoRecorder(frameBuffer, camera.VideoResolution.FrameSize).Record);
                videoRecorder.IsBackground = true;
                videoRecorder.Start();
                isRecording = true;
            }
            else
            {
                isRecording = false;
                frameBuffer.Clear();
                frameBuffer = null;
                videoRecorder.Abort();

                // This was needed to prevent cross threading
                // bug when changing camera while recording
                while (videoRecorder.IsAlive) { }
            }
        }

        public void Snapshot()
        {
            snapshot = true;
        }

        private void saveSnapshot(Bitmap image)
        {
            snapshot = false;

            string filepath = getFilePath("snapshots");
            string name = Guid.NewGuid().ToString() + ".bmp";
            string filename = Path.Combine(filepath, name);
            image.Save(filename, ImageFormat.Bmp);
            image.Dispose();
        }

        private string getFilePath(string foldername)
        {
            string drivepath = String.Empty;
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Search for removable drives.
            foreach (DriveInfo drive in drives)
            {
                if (drive.DriveType == DriveType.Removable)
                {
                    drivepath = drive.ToString();
                    break;
                }
            }

            // No removable drives found. Save to current directory
            if (drivepath.Equals(String.Empty))
                drivepath = Environment.CurrentDirectory;

            string filepath = drivepath + "\\" + foldername + "\\";
            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(Path.GetDirectoryName(filepath));

            return filepath;
        }

        public void Dispose()
        {
            //Stop and free the camera object 
            if (camera != null)
            {
                if (camera.IsRunning)
                    this.Stop();
                camera = null;
            }
            if (isRecording)
                ToggleRecording();
        }

        public VideoCaptureDevice Instance
        {
            get
            {
                return this.camera;
            }
        }

        public bool IsRecording
        {
            get
            {
                return isRecording;
            }
        }

        public void Start()
        {
            camera.Start();
        }

        public void Stop()
        {
            removeEventHandler();
            camera.SignalToStop();
            camera.WaitForStop();
            canvas = null;
        }

        public void AutoFocus()
        {
            try
            {
                camera.SetCameraProperty(CameraControlProperty.Focus, 0, CameraControlFlags.Auto);
                FocusChangedEventArgs args = new FocusChangedEventArgs();
                args.Focus = -1;
                OnFocusChanged(args);
            }
            catch (Exception)
            {
                if (canvas != null)
                    setFrame(canvas, null);
            }

        }

        public void ManualFocus()
        {
            SetFocus(0);
        }

        public void SetFocus(int value)
        {
            try
            {
                camera.SetCameraProperty(CameraControlProperty.Focus, value, CameraControlFlags.Manual);
                FocusChangedEventArgs args = new FocusChangedEventArgs();
                args.Focus = value;
                OnFocusChanged(args);
            }
            catch (Exception)
            {
                if (canvas != null)
                    setFrame(canvas, null);
            }
        }

        public bool SetResolution(Size desiredResolution)
        {
            if (IsRecording)
                return false;

            bool desiredResolutionExists = false;

            try
            {
                //Loop through the cameras supported resolutions
                if (camera.VideoCapabilities.Length > 0)
                {
                    //Search for desired resolution
                    for (int i = 0; i < camera.VideoCapabilities.Length; i++)
                    {
                        Size res = camera.VideoCapabilities[i].FrameSize;
                        if (res.Width == desiredResolution.Width && res.Height == desiredResolution.Height)
                        {
                            camera.VideoResolution = camera.VideoCapabilities[i];
                            desiredResolutionExists = true;
                            break;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }

            return desiredResolutionExists;
        }

        public void DisplayCameraProperties()
        {
            camera.DisplayPropertyPage(IntPtr.Zero);
        }

        private void initializeCamera(int index, Size desiredResolution)
        {
            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //Check if atleast one video source is available
            if (videosources.Count > 0)
            {
                camera = new VideoCaptureDevice(videosources[index].MonikerString);
                cameraMoniker = videosources[index].MonikerString;
                SetResolution(desiredResolution);
            }
        }

        private void camera_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap nextFrame = (Bitmap)eventArgs.Frame.Clone();

            if (snapshot)
                saveSnapshot((Bitmap)nextFrame.Clone());

            if (isRecording)
                recordFrame((Bitmap)nextFrame.Clone());

            setNewFrame(canvas, nextFrame);
        }

        private void setNewFrame(PictureBox canvas, Bitmap frame)
        {
            // Invoke is required when updating a control on the GUI thread.
            if (canvas.InvokeRequired)
            {
                canvas.BeginInvoke(new MethodInvoker(delegate()
                {
                    setFrame(canvas, frame);
                }));
            }
            else
            {
                setFrame(canvas, frame);
            }
        }

        private void setFrame(PictureBox canvas, Bitmap frame)
        {
            if (canvas.Image != null)
                canvas.Image.Dispose();
            canvas.Image = frame;
        }

        private void recordFrame(Bitmap frame)
        {
            frameBuffer.Enqueue(frame);
        }

        private void setCanvas(PictureBox canvas)
        {
            if (handleEvents && canvas == null)
                removeEventHandler();

            this.canvas = canvas;

            if (!handleEvents)
                setEventHandler();
        }

        private void setEventHandler()
        {
            handleEvents = true;
            this.camera.NewFrame += new NewFrameEventHandler(camera_NewFrame);
        }

        private void removeEventHandler()
        {
            handleEvents = false;
            this.camera.NewFrame -= (NewFrameEventHandler)camera_NewFrame;
        }

        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            Camera cam = (Camera)obj;
            return (this.cameraMoniker.Equals(cam.cameraMoniker));
        }

        // Important to override GetHashCode() when overriding Equals().
        public override int GetHashCode()
        {
            return cameraMoniker.GetHashCode();
        }

        // This method is virtual to ensure that it can be overridden in a derived class.
        protected virtual void OnFocusChanged(FocusChangedEventArgs e)
        {
            EventHandler<FocusChangedEventArgs> handler = FocusChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
