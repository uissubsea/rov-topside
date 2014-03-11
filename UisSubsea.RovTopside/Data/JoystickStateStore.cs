using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    public class JoystickStateStore
    {
        public byte[] Main { get; private set; }
        public byte[] ManipulatorLeft { get; private set; }
        public byte[] ManipulatorRight { get; private set; }

        public JoystickStateStore()
        {
            Main = new byte[0];
            ManipulatorLeft = new byte[0];
            ManipulatorRight = new byte[0];
        }

        public void StoreState(byte[] statePacket, JoystickType type)
        {
            switch(type)
            {
                case(JoystickType.MainController) :
                    Main = statePacket;
                    break;
                case (JoystickType.ManipulatorLeft) : 
                    ManipulatorLeft = statePacket;
                    break;
                case (JoystickType.ManipulatorRight) :
                    ManipulatorRight = statePacket;
                    break;
            }
        }
    }
}
