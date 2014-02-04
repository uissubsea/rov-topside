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
        private int negativePitch, negativeRoll;

        private int checkValueRoll = 0;
        private int checkValuePitch = 0;
        private Boolean reverse;

        private byte roll, pitch;

        public MainPacketBuilder(IJoystick joystick)
            : base(joystick)
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
            if (reverse)
            {
                roll = TransformRollToOpposite();
                pitch = TransformPitchToOpposite();
                return new byte[]
               {
                   roll,
                   pitch,
                   Yaw(),
                   Throttle(),
                   ButtonsPressed(),
                   HatPov(),
               };
            }
            else
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
        }

        private Boolean joystickIsInNeutral()
        {
            if (joystick.Pitch() == 125 && joystick.Roll() == 125)
                return true;
            else
                return false;
        }

        private byte TransformPitchToOpposite()
        {
            int temp = joystick.Pitch();

            checkValuePitch = temp - 125;
            if (checkValuePitch > 0)
            {
                negativePitch = 125 - checkValuePitch;
            }
            else
            {
                checkValuePitch *= -1;
                negativePitch = 125 + checkValuePitch;
                checkValuePitch = 0;
            }

            return (byte)negativePitch;
        }
        private byte TransformRollToOpposite()
        {
            int temp = joystick.Roll();

            checkValueRoll = temp - 125;
            if (checkValueRoll > 0)
            {
                negativeRoll = 125 - checkValueRoll;
            }
            else
            {
                checkValueRoll *= -1;
                negativeRoll = 125 + checkValueRoll;
                checkValueRoll = 0;
            }

            return (byte)negativeRoll;

        }
    }
}

