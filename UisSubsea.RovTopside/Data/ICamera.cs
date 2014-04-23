using System;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.Drawing;

namespace UisSubsea.RovTopside.Data
{
    /// <summary>
    /// Camera interface.
    /// </summary>

    public interface ICamera
    {
        event EventHandler<FocusChangedEventArgs> FocusChanged;

        /// <summary>
        /// Enable autofocus on the camera.
        /// </summary>
        void AutoFocus();

        /// <summary>
        /// The canvas used to paint the camera frames.
        /// </summary>
        PictureBox Canvas { get; set; }

        /// <summary>
        /// Release all resources used by the camera.
        /// </summary>
        void Dispose();

        /// <summary>
        /// Returns whether the specific object is equal to the current object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Equals(object obj);

        /// <summary>
        /// The current instance of the underlying camera object.
        /// </summary>
        VideoCaptureDevice Instance { get; }

        /// <summary>
        /// Returns whether the camera is recording or not.
        /// </summary>
        bool IsRecording { get; }

        /// <summary>
        /// Enable manual focus on the camera.
        /// </summary>
        void ManualFocus();

        /// <summary>
        /// Set focus on the camera. This will enable manual focus.
        /// </summary>
        /// <param name="value">Focus value.</param>
        void SetFocus(int value);

        /// <summary>
        /// Set the desired resolution you want the camera
        /// frames to be in. If the camera does not support
        /// the desired resolution, nothing will happen.
        /// </summary>
        /// <param name="desiredResolution">The resolution you wish to set.</param>
        /// <returns>Returns whether the camera supports the
        /// desired resolution or not.</returns>
        bool SetResolution(Size desiredResolution);

        /// <summary>
        /// Save a snapshot of the current frame to disk.
        /// </summary>
        void Snapshot();

        /// <summary>
        /// Start the camera.
        /// </summary>
        void Start();

        /// <summary>
        /// Stop the camera.
        /// </summary>
        void Stop();

        /// <summary>
        /// Toggle video recording. If the camera is not already
        /// recording, it will start recording. If it is, it will stop.
        /// </summary>
        void ToggleRecording();

        /// <summary>
        /// Display a property page where the user can
        /// perform detailed settings provided by the camera driver.
        /// </summary>
        void DisplayCameraProperties();
    }
}
