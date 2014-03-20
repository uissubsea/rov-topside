using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;


namespace UisSubsea.RovTopside.Data
{
    /// <summary>
    /// This class provides static methods to
    /// retrieve an instance of each of the joysticks
    /// connected.
    /// 
    /// It is implemented using a singleton pattern
    /// because it does not make sense to have more
    /// than one instance of each joystick.
    /// </summary>

    public class JoystickFactory
    {
        private static Joystick mainController;
        private static Joystick manipulatorLeft;
        private static Joystick manipulatorRight;
        
        private static IList<DeviceInstance> gameControls;

        public static Joystick GetMainController(IntPtr windowHandle)
        {
            if (JoystickFactory.mainController != null)
                return mainController;
            else
                return JoystickFactory.mainController = new Joystick(
                    windowHandle,getJoystickIndex(Constants.LogitechExtreme3DProGuid), 
                    JoystickType.MainController);
        }

        public static Joystick GetManipulatorLeft(IntPtr windowHandle)
        {
            if (JoystickFactory.manipulatorLeft != null)
                return manipulatorLeft;
            else
                return JoystickFactory.manipulatorLeft = new Joystick(
                    windowHandle, getJoystickIndex(Constants.LogitechAttack3Guid), 
                    JoystickType.ManipulatorLeft);
        }

        public static Joystick GetManipulatorRight(IntPtr windowHandle)
        {
            if (JoystickFactory.manipulatorRight != null)
                return manipulatorRight;
            else
                return JoystickFactory.manipulatorRight = new Joystick(
                    windowHandle,getJoystickIndex(Constants.Logitechextreme3DProManipulatorGuid),
                    JoystickType.ManipulatorRight);
        }

        /// <summary>
        /// This is a clean up method that should be called
        /// on application exit.
        /// </summary>
        public static void DisposeAll()
        {
            if (JoystickFactory.mainController != null)
                JoystickFactory.mainController.Unacquire();
            if (JoystickFactory.manipulatorLeft != null)
                JoystickFactory.manipulatorLeft.Unacquire();
            if (JoystickFactory.manipulatorRight != null)
                JoystickFactory.manipulatorRight.Unacquire();
        }

        /// <summary>
        /// This method searches through the connected joysticks and
        /// recognizes which index should be used to retrieve the joystick
        /// corresponding to the ID.
        /// </summary>
        /// <param name="cameraMoniker">The joystick identifier</param>
        /// <returns>The index where the joystick is located.</returns>
        private static int getJoystickIndex(string JoystickInstanceGuid)
        {
            gameControls = Joystick.JoysticksAttached();
            for (int i=0; i<gameControls.Count; i++)
            {
                Guid guid = gameControls[i].InstanceGuid;
                string guidstring = guid.ToString();
                string instanceGuid = guidstring.Substring(0, JoystickInstanceGuid.Length);

                if (instanceGuid.Equals(JoystickInstanceGuid))
                {
                    System.Diagnostics.Debug.WriteLine(i);
                    return i;  
                }                                              
            }
            // Not found.
            return -1;
        }           
    }
}
