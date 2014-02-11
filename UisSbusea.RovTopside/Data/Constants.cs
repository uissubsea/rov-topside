using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UisSubsea.RovTopside.Data
{
    class Constants
    {
        public const byte StartByte = 255;
        public const byte StopByte = 251;
        public const int BaudRate = 56000;
        public const int RovStatePacketSize = 5; //start and stop byte included
        public const int JoystickStatePacketSize = 8; //start and stop byte included
        public static Size DesiredResolution = new Size(1280, 720);
        public const int NumberOfJoysticksNeeded = 3;
        public const int NumberOfCamerasNeeded = 3;
    }
}
