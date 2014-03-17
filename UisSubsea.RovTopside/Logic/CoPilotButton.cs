using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Logic
{
    public static class CoPilotButton
    {
        /// <summary>
        /// This class defines which joystick buttons
        /// will be used for co-pilot top side actions.
        /// </summary>

        public const int ChangeCamera = 1;
        public const int ToggleRecording = 5;
        public const int Snapshot = 4;
        public const int IncreaseCameraFocus = 7;
        public const int DecreaseCameraFocus = 6;
        public const int CameraAutofocus = 0;
    }
}
