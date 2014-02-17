using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    public class JoystickFactory
    {

        private static Joystick mainController;
        private static Joystick manipulatorLeft;
        private static Joystick manipulatorRight;

        public static Joystick getMainController(IntPtr windowHandle)
        {
            if (JoystickFactory.mainController != null)
                return mainController;
            else
                return JoystickFactory.mainController = new Joystick(
                    windowHandle, 0, 250, JoystickType.MainController);
        }

        public static Joystick getManipulatorLeft(IntPtr windowHandle)
        {
            if (JoystickFactory.manipulatorLeft != null)
                return manipulatorLeft;
            else
                return JoystickFactory.manipulatorLeft = new Joystick(
                    windowHandle, 0, 250, JoystickType.ManipulatorLeft);
        }

        public static Joystick getManipulatorRight(IntPtr windowHandle)
        {
            if (JoystickFactory.manipulatorRight != null)
                return manipulatorRight;
            else
                return JoystickFactory.manipulatorRight = new Joystick(
                    windowHandle, 0, 250, JoystickType.ManipulatorRight);
        }

    }
}
