using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UisSubsea.RovTopside.Data;

namespace UisSubsea.RovTopside.Data
{
    /// <summary>
    /// This class is able to build a packet
    /// containing the state of the co-pilots right joystick.
    /// 
    /// It extends the basic functionality in PacketBuilder
    /// to fit the needs of the co-pilot.
    /// </summary>

    public class ManipulatorRightPacketBuilder : PacketBuilder
    {
        private IJoystick joystick;
        private int waterSample = 10;
        private int basketOut = 8;
        private int basketInn = 9;

        public ManipulatorRightPacketBuilder(Joystick joystick) : base(joystick) { this.joystick = joystick; }

        public override byte[] BuildJoystickStatePacket()
        {       
            return new byte[]
            {
                Roll(),
                Pitch(),
                Yaw(),
                ButtonsPressed(),
                HatPov(),
            };
        }
        public override byte ButtonsPressed()
        {
            int buttons = 0;
            bool[] buttonsPressed = joystick.Buttons();

            if (buttonsPressed[waterSample])
            {
                int currentButton = (1 << 0);
                buttons |= currentButton;
            }

            if (buttonsPressed[basketInn])
            {
                int currentButton = (1 << 1);
                buttons |= currentButton;
            }

            if (buttonsPressed[basketOut])
            {
                int currentButton = (1 << 2);
                buttons |= currentButton;
            }
            return (byte)buttons;
        }
    }
}
