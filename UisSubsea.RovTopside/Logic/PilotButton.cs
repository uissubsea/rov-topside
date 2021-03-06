﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Logic
{
    /// <summary>
    /// This class defines which joystick buttons
    /// will be used for pilot top side actions.
    /// </summary>

    public static class PilotButton
    {
        public const int ChangeCamera = 2;
        public const int ToggleStopwatch = 4;
        public const int Reverse = 1;
        public const int CameraAutofocus = 0;
        public const int ToggleGain = 10;
    }
}
