using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    public class JoystickStateListenerMock : IJoystickStateListener
    {
        public void Listen() { }

        public IJoystick Joystick
        {
            get { return new JoystickMock(); }
        }

        public event EventHandler JoystickStateChanged;
    }
}
