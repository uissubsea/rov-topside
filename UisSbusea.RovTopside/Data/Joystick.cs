using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;

namespace UisSubsea.RovTopside.Data
{
    public class Joystick : IJoystick
    {

        public SharpDX.DirectInput.Joystick joystick;
        private InputRange range;
        private static IList<DeviceInstance> gameControls;

        private JoystickType type;

        public Joystick(IntPtr windowHandle)
        {
            range = new InputRange(0, 250);
            type = JoystickType.MainController;
            createJoystick();
            configureJoystick(windowHandle);
        }

        public Joystick(IntPtr windowHandle, int rangeFrom, int rangeTo, JoystickType type) {
            range = new InputRange(rangeFrom, rangeTo);
            this.type = type;
            createJoystick();
            configureJoystick(windowHandle);
        }

        public Joystick(IntPtr windowHandle, int rangeFrom, int rangeTo)
        {
            range = new InputRange(rangeFrom, rangeTo);
            type = JoystickType.MainController;
            createJoystick();
            configureJoystick(windowHandle);
        }

        public JoystickState State()
        {               
            return joystick.GetCurrentState();          
        }

        public int Roll()
        {
            return State().X;
        }

        public int Pitch()
        {
            return State().Y;
        }

        public int Yaw()
        {
            return State().RotationZ;
        }

        public void Acquire()
        {
            //Acquire device for capturing.
            joystick.Acquire();
        }

        public void Unacquire()
        {
            //Unacquire device for capturing.
            joystick.Unacquire();
        }

        public int Throttle()
        {
            //Capture throttle
            int throttle = State().Sliders[0];
            //Invert the throttle value.
            //By default it will go from range.Max to range.Min
            //We want it to go the other way.
            return - (throttle - range.Maximum);
        }

        public int PointOfView()
        {
            //Capture point-of-view hat
            int pov = State().PointOfViewControllers[0];

            //Convert to degrees if hat is not in center
            if (pov != -1)
                pov /= 100;

            return pov;
        }

        public bool[] Buttons()
        {
            //Capture Buttons.
            bool[] buttons = State().Buttons;
            if (buttons != null)
                return buttons;
            else
                return new bool[128];
        }

        private void createJoystick()
        {
            DirectInput directInput = new DirectInput();
            Guid guid = Guid.Empty;

            //Create joystick device.
            //This process is called Direct Input Device Enumeration
            //IList<DeviceInstance> 
                gameControls = directInput.GetDevices(
                DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly);

            switch(this.type)
            {
                case JoystickType.MainController:
                    if (gameControls.Count >= 1)
                        guid = gameControls[0].InstanceGuid;
                    break;
                case JoystickType.ManipulatorLeft:
                    if (gameControls.Count >= 2)
                        guid = gameControls[1].InstanceGuid;
                    break;
                case JoystickType.ManipulatorRight:
                    if (gameControls.Count >= 3)
                        guid = gameControls[2].InstanceGuid;
                    break;
            }

            if(guid != Guid.Empty)
                joystick = new SharpDX.DirectInput.Joystick(directInput, guid);

            if (joystick == null)
            {
                //Throw exception if joystick not found.
                throw new Exception("No joystick found.");
            }

        }
        public static int getNumberOfJoysticks()
        {
            return gameControls.Count;
        }

        private void configureJoystick(IntPtr windowHandle)
        {
            //Set joystick axis ranges.
            foreach (DeviceObjectInstance doi in joystick.GetObjects())
            {
                if (((int)doi.ObjectId & (int)DeviceObjectTypeFlags.Axis) != 0)
                {
                    var ir = joystick.GetObjectPropertiesById(doi.ObjectId);
                    ir.Range = range;
                }
            }

            joystick.Properties.DeadZone = 2000;

            //Set joystick axis mode absolute.
            joystick.Properties.AxisMode = DeviceAxisMode.Absolute;

            /*We can interact with the joystick even if the window
             * is not in focus or in the background (Background flag). We also let other
             * applications interact with the joystick at the same time
             * if they need to (NonExclusive flag).
             */
            joystick.SetCooperativeLevel(
                windowHandle,
                CooperativeLevel.NonExclusive |
                CooperativeLevel.Background);
        }

        public JoystickType Type
        {
            get
            {
                return this.type;
            }
        }
    }
}
