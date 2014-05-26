using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace UisSubsea.RovTopside.Data
{
    public class JoystickMock : IJoystick
    {
        private Random r;
        private int[] pov = { -1, 0, 45, 90, 125, 180, 225, 270, 315 };
        private JoystickType type = JoystickType.MainController;

        public JoystickMock()
        {
             r = new Random();
        }
        
        public JoystickType Type
        {
            get
            {
                return this.type;
            }
        }

        public int Throttle()
        {
            return r.Next(0, 251);
        }

        public int Pitch()
        {
            return r.Next(0, 251);
        }

        public int Roll()
        {
            return r.Next(0, 251);
        }

        public int Yaw()
        {
            return r.Next(0, 251);
        }

        public bool[] Buttons()
        {
            bool[] buttons = new bool[7];
            for (int i = 0; i < 7; i++)
            {
                int rnd = r.Next(0, 2);
                if (rnd > 0)
                    buttons[i] = true;
                else
                    buttons[i] = false;
            }
            return buttons;
        }

        public int PointOfView()
        {
            int randomPos = r.Next(0, 9);
            return pov[randomPos];
        }

        public int Slider()
        {
            return r.Next(0, 251);
        }

        public void Acquire(WaitHandle handle) { }

        public void Unacquire() { }

        public WaitHandle WaitHandle
        {
            get { return null; }
        }
    }
}
