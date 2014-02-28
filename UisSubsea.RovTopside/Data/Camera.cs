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

namespace UisSubsea.RovTopside.Data
{
    public class Camera : IDisposable, ICamera
    {
        private VideoCaptureDevice camera;
        private PictureBox canvas;
        private Boolean isRecording;
        private Queue<Bitmap> frameBuffer;
        private Thread videoRecorder;
        private Boolean handleEvents;
        private String cameraMoniker;
        private Boolean snapshot;

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
            }
        }

        public void Snapshot()
        {
            snapshot = true;
        }

        private void saveSnapshot(Bitmap image)
        {
            snapshot = false;

            string filepath = Environment.CurrentDirectory;

            //Bitmap current = currentFrame();
            String name = Guid.NewGuid().ToString() + ".jpg";
            string filename = System.IO.Path.Combine(filepath, name);
            image.Save(filename, ImageFormat.Jpeg);
            image.Dispose();
        }

        public void Dispose()
        {
            //Stop and free the webcam object 
            if (camera != null && camera.IsRunning)
            {
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

        public Boolean IsRecording
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
            canvas = null;
        }

        public void AutoFocus()
        {
            camera.SetCameraProperty(CameraControlProperty.Focus, 0, CameraControlFlags.Auto);
        }

        public void ManualFocus()
        {
            SetFocus(0);
        }

        public void SetFocus(int value)
        {
            camera.SetCameraProperty(CameraControlProperty.Focus, value, CameraControlFlags.Manual);
        }

        public Boolean SetResolution(Size desiredResolution)
        {
            if (IsRecording)
                return false;

            Boolean desiredResolutionExists = false;

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
            try
            {
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
            catch (Exception) { }
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

        public void CameraDisplayProperties()
        {
            camera.DisplayPropertyPage(IntPtr.Zero);
        }
    }
}
