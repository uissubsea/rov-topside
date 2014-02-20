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

namespace UisSubsea.RovTopside.Data
{
    public class Camera : IDisposable
    {
        private VideoCaptureDevice camera;
        private ICollection<PictureBox> canvases;
        private Boolean isRecording;
        private Queue<Bitmap> frameBuffer;
        private Thread videoRecorder;
        private Boolean handleEvents;

        public Camera(int index, Size desiredResolution)
        {
            initializeCamera(index, desiredResolution);
        }

        public Camera(int index, Size desiredResolution, PictureBox canvas)
        {
            initializeCamera(index, desiredResolution);
            this.canvases.Add(canvas);
        }

        public Camera(int index, Size desiredResolution, ICollection<PictureBox> canvases)
        {
            initializeCamera(index, desiredResolution);
            this.canvases = canvases;
            setEventHandler();
        }

        public static FilterInfoCollection CamerasConnected()
        {
            return new FilterInfoCollection(FilterCategory.VideoInputDevice);
        }

        public void ToggleRecording()
        {
            if(!isRecording)
            { 
                frameBuffer = new Queue<Bitmap>();
                videoRecorder = new Thread(new VideoRecorder(frameBuffer).Record);
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
            string filepath = Environment.CurrentDirectory;

            foreach (PictureBox canvas in canvases)
            {
                Bitmap current = (Bitmap)canvas.Image.Clone();
                String name = Guid.NewGuid().ToString() + ".jpg";
                string filename = System.IO.Path.Combine(filepath, name);
                current.Save(filename, ImageFormat.Jpeg);
                current.Dispose();
            }
            
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
            camera.SignalToStop();
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

        public void AddCanvas(PictureBox canvas)
        {
            this.canvases.Add(canvas);

            // Start handeling new frames if we are
            // not already doing
            if (!handleEvents)
                setEventHandler();
        }

        public Boolean RemoveCanvas(PictureBox canvas)
        {
            // Stop handeling new frames if we remove all
            // canvases
            if (canvases.Count == 1 && handleEvents)
                removeEventHandler();

            return this.canvases.Remove(canvas);
        }

        public Boolean CanvasesContains(PictureBox canvas)
        {
            return canvases.Contains(canvas);
        }

        public Boolean SetResolution(Size desiredResolution)
        {
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
                SetResolution(desiredResolution);
            }
        }

        private void camera_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap nextFrame = (Bitmap)eventArgs.Frame.Clone();

            recordFrame((Bitmap)nextFrame.Clone());

            foreach (PictureBox pb in this.canvases)
            {
                setNewFrame(pb, (Bitmap)nextFrame.Clone());
            }        
        }

        private void recordFrame(Bitmap frame)
        {
            if (isRecording)
                frameBuffer.Enqueue(frame);
        }

        private void setEventHandler()
        {
            handleEvents = true;
            this.camera.NewFrame += new NewFrameEventHandler(camera_NewFrame);
        }

        private void removeEventHandler()
        {
            handleEvents = false;
            this.camera.NewFrame -= camera_NewFrame;
        }

        private void setNewFrame(PictureBox canvas, Bitmap frame)
        {
            if (canvas.Image != null)
            {
                try
                {
                    if (canvas.InvokeRequired)
                    {
                        canvas.Invoke(new MethodInvoker(delegate() { canvas.Image.Dispose(); }));
                    }
                }
                catch (ObjectDisposedException) { }

            }
            canvas.Image = frame;
        }
    }
}
