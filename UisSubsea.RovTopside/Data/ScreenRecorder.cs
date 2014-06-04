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
        private Thread worker;
        private VideoFileWriter writer;
        bool recording;

        public ScreenRecorder(Control control)
        {
            this.control = control;
            Size resolution = new Size(control.Width, control.Height);
            this.writer = new VideoFileWriter();
            string filepath = Environment.CurrentDirectory + "\\videos\\";

            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(Path.GetDirectoryName(filepath));

            string name = Guid.NewGuid().ToString() + ".avi";
            string filename = Path.Combine(filepath, name);
            
            if (!writer.IsOpen)
                writer.Open(filename, resolution.Width, resolution.Height, 24, VideoCodec.MPEG2, 10000000);
        }

        public void Record()
        {
            RunInBackgroundThread(RecordControl);
        }

        public void Stop()
        {
            worker.Abort();
        }

        public void ToggleRecording()
        {
            if (!recording)
                Record();
            else
                Stop();

            recording = !recording;
        }

        private void RecordControl()
        {           
            while(true)
            {
                try
                {
                    Rectangle sourceRect = control.ClientRectangle;
                    using (Bitmap tmp = new Bitmap(sourceRect.Width, sourceRect.Height))
                    {
                        control.Invoke(new MethodInvoker(delegate 
                        { 
                            control.DrawToBitmap(tmp, sourceRect); 
                        }));
                        writer.WriteVideoFrame(tmp);
                    }
                    Thread.Sleep(30);
                }
                catch (ThreadAbortException)
                {
                    writer.Close();
                }
            }
        }

        private void RunInBackgroundThread(ThreadStart methodToRun)
        {
            worker = new Thread(methodToRun);
            worker.IsBackground = true;
            worker.Start();
        }
    }
}
