using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    public class MainPacketBuilder : PacketBuilder
    {
        private IJoystick joystick;
        private Boolean reverse;

        public MainPacketBuilder(IJoystick joystick) : base(joystick)
        {
            this.joystick = joystick;
        }

        public void ToggleReverse()
        {
            if (joystickIsInNeutral())
            {
                if (reverse)
                    reverse = false;
                else
                    reverse = true;
            }
        }

        public override byte[] BuildJoystickStatePacket()
        {
            if (joystick.Buttons()[9])
                ToggleReverse();

            if (reverse)
            {
                return buildReversePacket();
            }
            else
            {
                return buildPacket();
            }
        }

        private byte[] buildPacket()
        {
            return new byte[]
                {
                    Roll(),
                    Pitch(),
                    Yaw(),
                    Throttle(),
                    ButtonsPressed(),
                    HatPov(),
                 };
        }

        private byte[] buildReversePacket()
        {
            return new byte[]
               {
                   reverseRoll(),
                   reversePitch(),
                   Yaw(),
                   Throttle(),
                   ButtonsPressed(),
                   HatPov(),
               };
        }

        private Boolean joystickIsInNeutral()
        {
            if (joystick.Pitch() == 125 && joystick.Roll() == 125)
                return true;
            else
                return false;
        }

        private byte reversePitch()
        {
            return reverseStickAmplitude((byte)joystick.Pitch());
        }

        private byte reverseRoll()
        {
            return reverseStickAmplitude((byte)joystick.Roll());
        }

        private byte reverseStickAmplitude(byte axisPosition)
        {
            int amplitude = axisPosition - 125;

            //If true, the stick is pulled backwards or pushed right
            Boolean aimplitudeIsNegative = (amplitude > 0);

            if (aimplitudeIsNegative)
            {
                return (byte)(125 - amplitude);
            }
            else
            {
                amplitude *= -1;
                return (byte)(125 + amplitude);
            };
        }
    }
}

