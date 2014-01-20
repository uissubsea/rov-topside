using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    public class JoystickFactory
    {

        private static Joystick js;

        public static Joystick getJoystick(IntPtr windowHandle)
        {
            if (JoystickFactory.js != null)
                return js;
            else
                return JoystickFactory.js = new Joystick(windowHandle);
        }

    }
}
