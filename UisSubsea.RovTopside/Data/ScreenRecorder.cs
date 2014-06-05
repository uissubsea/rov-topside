using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using AForge.Video.FFMPEG;
using System.Drawing;
using System.IO;

namespace UisSubsea.RovTopside.Data
{
    public class ScreenRecorder
    {
        private Control control;
        private Queue<Bitmap> frameBuffer;
        private Thread videoRecorder;
        private System.Threading.Timer timer;
        private bool isRecording;

        public ScreenRecorder(Control control)
        {
            this.control = control;
            Size resolution = new Size(control.Width, control.Height);
            frameBuffer = new Queue<Bitmap>();
        }

        public void Record()
        {
            
        }

        public void Stop()
        {
            
        }

        public void ToggleRecording()
        {
            if (!isRecording)
            {        
                frameBuffer = new Queue<Bitmap>();
                videoRecorder = new Thread(new VideoRecorder(frameBuffer,
                    new Size(control.Width, control.Height)).Record);
                videoRecorder.IsBackground = true;
                videoRecorder.Start();
                isRecording = true;
                timer = new System.Threading.Timer(RecordControl, null, 10, Timeout.Infinite);
            }
            else
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                isRecording = false;  
                videoRecorder.Abort();

                while (frameBuffer.Count > 0) { }
                frameBuffer.Clear();
                frameBuffer = null;
            }
        }

        private void RecordControl(Object state)
        {
            if(isRecording)
            {
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();

                Rectangle sourceRect = control.ClientRectangle;
                Bitmap tmp = new Bitmap(sourceRect.Width, sourceRect.Height);
                control.Invoke(new MethodInvoker(delegate
                {
                    control.DrawToBitmap(tmp, sourceRect);
                }));
                if(frameBuffer != null)
                    frameBuffer.Enqueue(tmp);
                GC.Collect();
                timer.Change((long)Math.Max(0, 10 - watch.ElapsedMilliseconds), Timeout.Infinite);
            }
        }

        /*private void RunInBackgroundThread(ThreadStart methodToRun)
        {
            worker = new Thread(methodToRun);
            worker.IsBackground = true;
            worker.Start();
        }*/
    }
}
