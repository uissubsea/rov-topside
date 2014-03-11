using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    class ManipulatorRightPacketBuilder : PacketBuilder, ICameraTilt
    {
        public ManipulatorRightPacketBuilder(Joystick joystick): base(joystick) {}

        public override byte[] BuildJoystickStatePacket()
        {       
            return new byte[]
            {
                Roll(),
                Pitch(),
                Yaw(),
                ButtonsPressed(),
                CameraTilt(),
            };
        }

        public byte CameraTilt()
        {
            byte cameraTilt = (byte)0;

            return cameraTilt;
        }
    }
}
