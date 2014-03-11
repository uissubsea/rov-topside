using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UisSubsea.RovTopside.Logic;

namespace UisSubsea.RovTopside.Data
{
    public class MainPacketBuilder : PacketBuilder, ICameraTilt
    {
        private IJoystick joystick;
        private bool reverse;
        private bool halveAmplitude;

        public MainPacketBuilder(IJoystick joystick)
            : base(joystick)
        {
            this.joystick = joystick;
        }

        public void ToggleReverse()
        {
            if (joystickIsInNeutral())
            {
                reverse = !reverse;
            }
        }

        public void ToggleGain()
        {
            halveAmplitude = !halveAmplitude;
        }

        public override byte[] BuildJoystickStatePacket()
        {
            if (joystick.Buttons()[PilotButton.Reverse])
                ToggleReverse();

            if (joystick.Buttons()[PilotButton.Gain])
                ToggleGain();

            if (reverse)
            {
                if (halveAmplitude)
                    return buildReverseHalfGainPacket();
                else
                    return buildReversePacket();
            }
            else
            {
                if (halveAmplitude)
                    return buildHalfGainPacket();
                else
                    return buildPacket();
            }
        }

        private byte[] buildHalfGainPacket()
        {
            return new byte[]
            {
                halveAxisAmplitude(Roll()),
                halveAxisAmplitude(Pitch()),
                halveAxisAmplitude(Yaw()),
                halveAxisAmplitude(Throttle()),
                ButtonsPressed(),
                CameraTilt(),
            };
        }

        private byte[] buildReverseHalfGainPacket()
        {
            return new byte[]
            {
                halveAxisAmplitude(reverseRoll()),
                halveAxisAmplitude(reversePitch()),
                halveAxisAmplitude(Yaw()),
                halveAxisAmplitude(Throttle()),
                ButtonsPressed(),
                CameraTilt(),
            };
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
                CameraTilt(),
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
                CameraTilt(),
            };
        }

        private bool joystickIsInNeutral()
        {
            return (joystick.Pitch() == 125 && joystick.Roll() == 125);
        }

        private byte reversePitch()
        {
            return reverseAxisAmplitude((byte)joystick.Pitch());
        }

        private byte reverseRoll()
        {
            return reverseAxisAmplitude((byte)joystick.Roll());
        }

        private byte reverseAxisAmplitude(byte axisPosition)
        {
            int amplitude = axisPosition - 125;

            //If true, the stick is pulled backwards or pushed right
            bool aimplitudeIsNegative = (amplitude > 0);

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

        private byte halveAxisAmplitude(byte axisPosition)
        {
            int amplitude = axisPosition - 125;
            return (byte)(125 + (amplitude / 2));
        }

        public byte CameraTilt()
        {
            byte cameraTilt = (byte)0;

            if (!reverse)
            {
                if (HatPov() == (byte)PointOfView.Up)
                    cameraTilt = (byte)(1 << 3);
                else if (HatPov() == (byte)PointOfView.Down)
                    cameraTilt = (byte)(1 << 4);
                else if (HatPov() == (byte)PointOfView.Left || HatPov() == (byte)PointOfView.Right)
                    cameraTilt = (byte)(3 << 3);
            }
            else
            {
                if (HatPov() == (byte)PointOfView.Up)
                    cameraTilt = (byte)(1 << 0);
                else if (HatPov() == (byte)PointOfView.Down)
                    cameraTilt = (byte)(1 << 1);
                else if (HatPov() == (byte)PointOfView.Left || HatPov() == (byte)PointOfView.Right)
                    cameraTilt = (byte)(3 << 0);
            }

            return cameraTilt;
        }
    }
}

