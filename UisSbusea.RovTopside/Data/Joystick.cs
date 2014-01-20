using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.DirectX.DirectInput;

namespace UisSubsea.RovTopside.Data
{
    public class Joystick : IJoystick
    {
        private Device joystick;
        private InputRange range;

        public Joystick(IntPtr windowHandle)
        {
            range = new InputRange(-100, 100);
            createJoystick();
            configureJoystick(windowHandle);
        }

        public Joystick(IntPtr windowHandle, int rangeFrom, int rangeTo)
        {
            range = new InputRange(rangeFrom, rangeTo);
            createJoystick();
            configureJoystick(windowHandle);
        }

        public JoystickState State()
        {
            return joystick.CurrentJoystickState;
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
            return State().Rz;
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
            int throttle = State().GetSlider()[0];
            //Invert the throttle value.
            //By default it will go from range.Max to range.Min
            //We want it to go the other way.
            return -(throttle - range.Max);
        }

        public int PointOfView()
        {
            //Capture point-of-view hat
            int pov = State().GetPointOfView()[0];

            //Convert to degrees if hat is not in center
            if (pov != -1)
                pov /= 100;

            return pov;
        }

        public byte[] Buttons()
        {
            //Capture Buttons.
            byte[] buttons = State().GetButtons();
            if (buttons != null)
                return buttons;
            else
                return new byte[128];
        }

        private void createJoystick()
        {
            //create joystick device.
            foreach (
                DeviceInstance di in
                Manager.GetDevices(
                    DeviceClass.GameControl,
                    EnumDevicesFlags.AttachedOnly))
            {
                joystick = new Device(di.InstanceGuid);
                break;
            }

            if (joystick == null)
            {
                //Throw exception if joystick not found.
                throw new Exception("No joystick found.");
            }

        }

        private void configureJoystick(IntPtr windowHandle)
        {
            //Set joystick axis ranges.
            foreach (DeviceObjectInstance doi in joystick.Objects)
            {
                if ((doi.ObjectId & (int)DeviceObjectTypeFlags.Axis) != 0)
                {
                    joystick.Properties.SetRange(
                        ParameterHow.ById,
                        doi.ObjectId,
                        range);
                }
            }

            //Set joystick axis mode absolute.
            joystick.Properties.AxisModeAbsolute = true;

            /*We can interact with the joystick even if the window
             * is not in focus or in the background (Background flag). We also let other
             * applications interact with the joystick at the same time
             * if they need to (NonExclusive flag).
             */
            joystick.SetCooperativeLevel(
                windowHandle,
                CooperativeLevelFlags.NonExclusive |
                CooperativeLevelFlags.Background);
        }
    }
}
