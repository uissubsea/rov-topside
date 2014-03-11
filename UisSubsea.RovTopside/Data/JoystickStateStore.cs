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
        private byte cameraTilt;

        public JoystickStateStore()
        {
            main = new byte[0];
            manipulatorLeft = new byte[0];
            manipulatorRight = new byte[0];
            cameraTilt = (byte)0;
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

        public byte CameraTilt
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
                    storeMainController(statePacket);
                    break;
                case (JoystickType.ManipulatorLeft) : 
                    ManipulatorLeft = statePacket;
                    break;
                case (JoystickType.ManipulatorRight) :
                    storeManipulatorRight(statePacket);
                    break;
            }
        }

        private void storeMainController(byte[] state)
        {
            byte[] main = new byte[(state.Length - 1)];

            // Copy all elements but the last
            for (int i = 0; i < (state.Length - 1); i++)
                main[i] = state[i];

            // Assign the newly created array to Main
            Main = main;

            // The camera tilt byte is the last byte
            CameraTilt |= state[state.Length-1];
        }

        private void storeManipulatorRight(byte[] state)
        {
            byte[] manipulatorRight = new byte[(state.Length - 1)];

            // Copy all elements but the last
            for (int i = 0; i < (state.Length - 1); i++)
                manipulatorRight[i] = state[i];

            // Assign the newly created array to Main
            ManipulatorRight = manipulatorRight;

            // The camera tilt byte is the last byte
            CameraTilt |= state[state.Length - 1];
        }
    }
}
