using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    /// <summary>
    /// This class is able to build a packet
    /// containing the state of the co-pilots left joystick.
    /// 
    /// It extends the basic functionality in PacketBuilder
    /// to fit the needs of the co-pilot.
    /// </summary>
    public class ManipulatorLeftPacketBuilder : PacketBuilder
    {
        public  ManipulatorLeftPacketBuilder(Joystick joystick): base(joystick){}

        public override byte[] BuildJoystickStatePacket()
      {
            return new byte[] {
                Roll(),
                Pitch(),
                ButtonsPressed()
            };
        }
    }
}
