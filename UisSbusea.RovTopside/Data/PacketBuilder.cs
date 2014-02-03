using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    /**
     * This class is responsible for packing
     * the state of the joystick before sending
     * it as a packet to the ROV's supernode.
     * */

    public abstract class PacketBuilder
    {

        [Flags]
        private enum pointOfView : byte
        {
            Center = 0,     //0000
            Right = 1 << 0, //0001
            Left = 1 << 1,  //0010
            Down = 1 << 2,  //0100
            Up = 1 << 3,    //1000

            UpAndRight = Up | Right,        //1001
            DownAndRight = Down | Right,    //0100
            DownAndLeft = Down | Left,      //0110
            UpAndLeft = Up | Left           //1010
        }

        private IJoystick joystick;

        public PacketBuilder(IJoystick joystick)
        {
            this.joystick = joystick;
        }

        public abstract byte[] BuildJoystickStatePacket();

        public byte ButtonsPressed()
        {
            int buttons = 0;
            bool[] buttonsPressed = joystick.Buttons();

            for (int i = 0; i < 7; i++)
            {
                if (buttonsPressed[i])
                {
                    int currentButton = (1 << i);
                    buttons |= currentButton;
                }
            }
            return (byte)buttons;
        }
       
        public byte HatPov()
        {
            int angle = joystick.PointOfView();
            switch (angle)
            {
                case 0:
                    return (byte)pointOfView.Up;
                case 45:
                    return (byte)pointOfView.UpAndRight;
                case 90:
                    return (byte)pointOfView.Right;
                case 135:
                    return (byte)pointOfView.DownAndRight;
                case 180:
                    return (byte)pointOfView.Down;
                case 225:
                    return (byte)pointOfView.DownAndLeft;
                case 270:
                    return (byte)pointOfView.Left;
                case 315:
                    return (byte)pointOfView.UpAndLeft;
                default:
                    return (byte)pointOfView.Center;
            }
        }

        public byte Roll()
        {
            int roll = joystick.Roll();
            if (isValid(roll))
                return (byte)roll;
            else return (byte)0;
        }

        public byte Pitch()
        {
            int pitch = joystick.Pitch();
            if (isValid(pitch))
                return (byte)pitch;
            else return (byte)0;
        }

        public byte Yaw()
        {
            int yaw = joystick.Yaw();
            if (isValid(yaw))
                return (byte)yaw;
            else return (byte)0;
        }

        public byte Throttle()
        {
            int throttle = joystick.Throttle();
            if (isValid(throttle))
                return (byte)throttle;
            else
                return (byte)0;
        }

        private Boolean isValid(int value)
        {
            if (value >= 0 && value <= 250)
                return true;
            else
                return false;
        }
    }
}