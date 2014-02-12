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

namespace UisSubsea.RovTopside.Data
{
    public class Camera : IDisposable
    {
        private VideoCaptureDevice camera;
        private PictureBox canvas;
        private List<PictureBox> canvases;
        private Boolean isRecording;
        private VideoFileWriter writer;

        public Camera(int index, Size desiredResolution)
        {
            initializeCamera(index, desiredResolution);
            writer = new VideoFileWriter();
        }

        public Camera(int index, Size desiredResolution, PictureBox canvas)
        {
            initializeCamera(index, desiredResolution);
            writer = new VideoFileWriter();
            this.canvas = canvas;
            this.camera.NewFrame += new NewFrameEventHandler(camera_NewFrame);
        }

        public Camera(int index, Size desiredResolution, List<PictureBox> canvases)
        {
            initializeCamera(index, desiredResolution);
            writer = new VideoFileWriter();
            this.canvas = canvas;
            this.camera.NewFrame += new NewFrameEventHandler(multipleCamera_NewFrame);
        }

        public static int NumberOfCamerasConnected()
        {
            return new FilterInfoCollection(FilterCategory.VideoInputDevice).Count;
        }

        public void ToggleRecording()
        {
            if (!isRecording)
            {
                string filepath = Environment.CurrentDirectory;
                String name = Guid.NewGuid().ToString() + ".avi";
                string filename = System.IO.Path.Combine(filepath, name);
                writer.Open(filename, 1280, 720, 24, VideoCodec.MPEG2, 10000000);
                isRecording = true;
            }
            else
            {
                isRecording = false;
                writer.Close();
            }
        }

        public void Snapshot()
        {
            Bitmap current = (Bitmap)canvas.Image.Clone();
            string filepath = Environment.CurrentDirectory;
            String name = Guid.NewGuid().ToString() + ".jpg";
            string filename = System.IO.Path.Combine(filepath, name);
            current.Save(filename, ImageFormat.Jpeg);
            current.Dispose();
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

        public PictureBox Canvas
        {
            get
            {
                return this.canvas;
            }
            set
            {
                this.canvas = value;
            }
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

        private void initializeCamera(int index, Size desiredResolution)
        {

            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //Check if atleast one video source is available
            if (videosources != null)
            {
                camera = new VideoCaptureDevice(videosources[index].MonikerString);
                //videoSource.SetCameraProperty(CameraControlProperty.Focus, 0, CameraControlFlags.Auto);

                try
                {
                    //Check if the video device provides a list of supported resolutions
                    if (camera.VideoCapabilities.Length > 0)
                    {
                        //Search for desired resolution
                        for (int i = 0; i < camera.VideoCapabilities.Length; i++)
                        {
                            Size res = camera.VideoCapabilities[i].FrameSize;
                            if (res.Width == desiredResolution.Width && res.Height == desiredResolution.Height)
                            {
                                camera.VideoResolution = camera.VideoCapabilities[i];
                                break;
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private void camera_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap nextFrame = (Bitmap)eventArgs.Frame.Clone();

            if (isRecording)
                writeFrame(nextFrame);

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
            canvas.Image = nextFrame;
        }

        private void multipleCamera_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap nextFrame = (Bitmap)eventArgs.Frame.Clone();

            if (isRecording)
                writeFrame(nextFrame);

            foreach (PictureBox pb in this.canvases)
            {
                if (pb.Image != null)
                {
                    try
                    {
                        if (pb.InvokeRequired)
                        {
                            pb.Invoke(new MethodInvoker(delegate() { pb.Image.Dispose(); }));
                        }
                    }
                    catch (ObjectDisposedException) { }

                }
                pb.Image = nextFrame;
            }        
        }

        private void writeFrame(Bitmap frame)
        {
            if (writer.IsOpen)
            {
                try
                {
                    writer.WriteVideoFrame(frame);
                }
                catch (AccessViolationException)
                {
                    MessageBox.Show("Access violation!");
                }
            }
        }
    }
}
