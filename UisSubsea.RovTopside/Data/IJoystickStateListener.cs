using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    public interface IJoystickStateListener
    {
        void Listen();

        IJoystick Joystick
        {
            get;
        }

        event EventHandler JoystickStateChanged;
    }
}
