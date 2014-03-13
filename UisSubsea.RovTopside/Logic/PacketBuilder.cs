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
        public enum PointOfView : byte
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
  
        public byte HatPov()
        {
            int angle = joystick.PointOfView();
            switch (angle)
            {
                case 0:
                    return (byte)PointOfView.Up;
                case 45:
                    return (byte)PointOfView.UpAndRight;
                case 90:
                    return (byte)PointOfView.Right;
                case 135:
                    return (byte)PointOfView.DownAndRight;
                case 180:
                    return (byte)PointOfView.Down;
                case 225:
                    return (byte)PointOfView.DownAndLeft;
                case 270:
                    return (byte)PointOfView.Left;
                case 315:
                    return (byte)PointOfView.UpAndLeft;
                default:
                    return (byte)PointOfView.Center;
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

        private bool isValid(int value)
        {
            if (value >= 0 && value <= 250)
                return true;
            else
                return false;
        }

        public JoystickType Type
        {
            get
            {
                return joystick.Type;
            }
        }
    }
}