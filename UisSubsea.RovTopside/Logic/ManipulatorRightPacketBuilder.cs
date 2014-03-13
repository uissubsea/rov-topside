using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UisSubsea.RovTopside.Data;

namespace UisSubsea.RovTopside.Data
{
    class ManipulatorRightPacketBuilder : PacketBuilder
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
                buttonsPressed(),
                HatPov(),
            };
        }
        private  byte buttonsPressed()
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
