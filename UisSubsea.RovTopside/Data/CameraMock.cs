using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.Drawing;

namespace UisSubsea.RovTopside.Data
{
    public class CameraMock : ICamera
    {
        public event EventHandler<FocusChangedEventArgs> FocusChanged;

        private PictureBox canvas;
        private bool isRecording;

        public void AutoFocus() { }

        public PictureBox Canvas
        {
            get
            {
                return canvas;
            }
            set
            {
                canvas = value;
            }
        }

        public void Dispose() { }

        public VideoCaptureDevice Instance
        {
            get { return null; }
        }

        public bool IsRecording
        {
            get { return isRecording; }
        }

        public void ManualFocus() { }

        public void SetFocus(int value) { }

        public bool SetResolution(Size desiredResolution)
        {
            return true;
        }

        public void Snapshot() { }

        public void Start() { }

        public void Stop() { }

        public void ToggleRecording() { }

        public void DisplayCameraProperties() { }
    }
}
