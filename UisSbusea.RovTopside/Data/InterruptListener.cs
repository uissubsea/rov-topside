using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace UisSubsea.RovTopside.Data
{
    public class InterruptListener
    {
        private WaitHandle handle;
        public event EventHandler JoystickStateChanged;

        public InterruptListener(WaitHandle handle)
        {
            this.handle = handle;
        }

        public void Listen()
        {
            while(true)
            {
                handle.WaitOne();
                OnJoystickStateChanged(new EventArgs());
            }
        }

        protected virtual void OnJoystickStateChanged(EventArgs e)
        {
            EventHandler handler = JoystickStateChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
