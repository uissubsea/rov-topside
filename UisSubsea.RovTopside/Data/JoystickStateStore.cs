using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    public class JoystickStateStore
    {

        private byte[] main;
        private byte[] manipulatorLeft;
        private byte[] manipulatorRight;
        private byte[] cameraTilt;

        public JoystickStateStore()
        {
            main = new byte[0];
            manipulatorLeft = new byte[0];
            manipulatorRight = new byte[0];
            cameraTilt = new byte[0];
        }

        public byte[] Main
        {
            get
            {
                return main;
            }
            set
            {
                main = value;
            }
        }

        public byte[] ManipulatorLeft
        {
            get
            {
                return manipulatorLeft;
            }
            set
            {
                manipulatorLeft = value;
            }
        }

        public byte[] ManipulatorRight
        {
            get
            {
                return manipulatorRight;
            }
            set
            {
                manipulatorRight = value;
            }
        }

        public byte[] CameraTilit
        {
            get
            {
                return cameraTilt;
            }
            set
            {
                cameraTilt = value;
            }
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
                    manipulatorRight = statePacket;
                    break;
            }
        }
    }
}
