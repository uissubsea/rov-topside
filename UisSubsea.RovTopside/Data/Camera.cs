﻿using System;
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
        private PictureBox canvas;
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
            this.canvas = canvas;
            setSingleCanvasEventHandler();
        }

        public Camera(int index, Size desiredResolution, ICollection<PictureBox> canvases)
        {
            initializeCamera(index, desiredResolution);
            this.canvases = canvases;
            setMultipleCanvasEventHandler();
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

                if (!handleEvents)
                    setSingleCanvasEventHandler();

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

        public void AddCanvas(PictureBox canvas)
        {
            this.canvases.Add(canvas);
        }

        public Boolean RemoveCanvas(PictureBox canvas)
        {
            return this.canvases.Remove(canvas);
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

        private void singleCanvas_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap nextFrame = (Bitmap)eventArgs.Frame.Clone();

            recordFrame((Bitmap)nextFrame.Clone());

            setNewFrame(this.canvas, nextFrame);
        }

        private void multipleCanvas_NewFrame(object sender, NewFrameEventArgs eventArgs)
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

        private void setSingleCanvasEventHandler()
        {
            handleEvents = true;
            this.camera.NewFrame += new NewFrameEventHandler(singleCanvas_NewFrame);
        }

        private void setMultipleCanvasEventHandler()
        {
            handleEvents = true;
            this.camera.NewFrame += new NewFrameEventHandler(multipleCanvas_NewFrame);
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