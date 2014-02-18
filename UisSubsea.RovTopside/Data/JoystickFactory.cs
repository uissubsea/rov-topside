﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;


namespace UisSubsea.RovTopside.Data
{
    public class JoystickFactory
    {

        private static Joystick mainController;
        private static Joystick manipulatorLeft;
        private static Joystick manipulatorRight;
        private static IList<DeviceInstance> gameControls;

        public static Joystick getMainController(IntPtr windowHandle)
        {
            if (JoystickFactory.mainController != null)
                return mainController;
            else
                return JoystickFactory.mainController = new Joystick(
                    windowHandle,getJoystickIndex(Constants.LogitechExtreme3DProGuid), 
                    JoystickType.MainController);
        }

        public static Joystick getManipulatorLeft(IntPtr windowHandle)
        {
            if (JoystickFactory.manipulatorLeft != null)
                return manipulatorLeft;
            else
                return JoystickFactory.manipulatorLeft = new Joystick(
                    windowHandle, getJoystickIndex(Constants.LogitechAttack3Guid), 
                    JoystickType.ManipulatorLeft);
        }

        public static Joystick getManipulatorRight(IntPtr windowHandle)
        {
            if (JoystickFactory.manipulatorRight != null)
                return manipulatorRight;
            else
                return JoystickFactory.manipulatorRight = new Joystick(
                    windowHandle,getJoystickIndex(Constants.thrustMasterGuid),
                    JoystickType.ManipulatorRight);
        }

        private static int getJoystickIndex(String JoystickInstanceGuid)
        {
            gameControls = Joystick.JoysticksAttached();
            for (int i=0; i<gameControls.Count; i++)
            {
                Guid guid = gameControls[i].InstanceGuid;
                string guidString = guid.ToString();
                String instanceGuid = guidString.Substring(0, JoystickInstanceGuid.Length);
                if (instanceGuid.Equals(JoystickInstanceGuid))
                    return i;
            }
            return -1;
        }
           
    }
}
