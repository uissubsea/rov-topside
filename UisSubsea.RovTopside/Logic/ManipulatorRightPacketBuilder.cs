using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    class ManipulatorRightPacketBuilder : PacketBuilder
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
                HatPov(),
            };
        }
    }
}
