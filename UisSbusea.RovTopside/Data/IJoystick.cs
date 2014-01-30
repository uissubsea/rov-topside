using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    public interface IJoystick
    {
        int Throttle();
        int Pitch();
        int Roll();
        int Yaw();
        bool[] Buttons();
        int PointOfView();
        JoystickType Type
        {
            get;
        }
    }
}