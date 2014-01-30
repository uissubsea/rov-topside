using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    class MainPacketBuilder : PacketBuilder
    {
        public MainPacketBuilder(Joystick joystick): base(joystick){}
       
        public override byte[] BuildJoystickStatePacket()
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
    }

