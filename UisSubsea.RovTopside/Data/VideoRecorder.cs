using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using AForge.Video.FFMPEG;
using System.Threading;
using System.IO;

namespace UisSubsea.RovTopside.Data
{
    public class VideoRecorder
    {
        /// <summary>
        /// This class handles video recording. 
        /// It takes all frames in the frame buffer and record
        /// it to disk using MPEG2 codec with a 10Mb/s bit rate.
        /// </summary>

        private Queue<Bitmap> frameBuffer;
        private VideoFileWriter writer;

        public VideoRecorder(Queue<Bitmap> frameBuffer, Size resolution)
        {
            this.frameBuffer = frameBuffer;
            this.writer = new VideoFileWriter();

            string filepath = Environment.CurrentDirectory + "\\videos\\";

            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(Path.GetDirectoryName(filepath));

            string name = Guid.NewGuid().ToString() + ".avi";
            string filename = Path.Combine(filepath, name);
            try
            {
                if (!writer.IsOpen)
                    writer.Open(filename, resolution.Width, resolution.Height, 24, VideoCodec.MPEG2, 10000000);
            }
            catch (AccessViolationException)
            {

            }
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
