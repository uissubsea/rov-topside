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

        public ManipulatorRightPacketBuilder(IJoystick joystick) : base(joystick) { this.joystick = joystick; }

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
