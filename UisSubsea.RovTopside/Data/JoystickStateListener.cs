using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace UisSubsea.RovTopside.Data
{
    public class JoystickStateListener
    {
        private WaitHandle handle;
        private Joystick joystick;
        private PacketBuilder packetBuilder;
        private JoystickStateStore holder;

        public EventHandler JoystickStateChanged;

        public JoystickStateListener(Joystick js, PacketBuilder pb, JoystickStateStore holder)
        {
            this.joystick = js;
            this.handle = js.WaitHandle;
            this.packetBuilder = pb;
            this.holder = holder;
        }

        public void Listen()
        {
            while(true)
            {
                handle.WaitOne();
               
                byte[] packet = packetBuilder.BuildJoystickStatePacket();

                holder.StoreState(packet, joystick.Type);

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
      
        public Joystick Joystick
        {
            get
            {
                return this.joystick;
            }
        }
    }
}
