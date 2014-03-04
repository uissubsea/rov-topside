using System;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.Drawing;

namespace UisSubsea.RovTopside.Logic
{
    public interface ICamera
    {
        void AutoFocus();
        PictureBox Canvas { get; set; }
        void Dispose();
        bool Equals(object obj);
        VideoCaptureDevice Instance { get; }
        bool IsRecording { get; }
        void ManualFocus();
        void SetFocus(int value);
        bool SetResolution(Size desiredResolution);
        void Snapshot();
        void Start();
        void Stop();
        void ToggleRecording();
        void CameraDisplayProperties();
    }
}
