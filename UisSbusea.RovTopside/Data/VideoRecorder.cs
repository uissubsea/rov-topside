using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using AForge.Video.FFMPEG;
using System.Threading;

namespace UisSubsea.RovTopside.Data
{
    public class VideoRecorder
    {

        Queue<Bitmap> frameBuffer;
        private VideoFileWriter writer;

        public VideoRecorder(Queue<Bitmap> frameBuffer)
        {
            this.frameBuffer = frameBuffer;
            this.writer = new VideoFileWriter();
            string filepath = Environment.CurrentDirectory;
            String name = Guid.NewGuid().ToString() + ".avi";
            string filename = System.IO.Path.Combine(filepath, name);
            writer.Open(filename, 1280, 720, 24, VideoCodec.MPEG2, 10000000);
        }

        public void Record()
        {
            while(true)
            {
                try
                {
                    if (frameBuffer.Count > 0)
                        writeFrame(frameBuffer.Dequeue());
                }
                catch (ThreadAbortException)
                {
                    writer.Close();
                }         
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
                    //Not yet implemented
                }
            }
        }
    }
}
