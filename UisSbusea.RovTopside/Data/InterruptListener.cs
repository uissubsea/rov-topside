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
        private PacketBuilder packetBuilder;
        private JoystickStateHolder holder;

        public EventHandler JoystickStateChanged;

        public InterruptListener(WaitHandle handle, PacketBuilder pb, JoystickStateHolder holder)
        {
            this.handle = handle;
            this.packetBuilder = pb;
            this.holder = holder;
        }

        public void Listen()
        {
            while(true)
            {
                handle.WaitOne();
                //update state of joystick in joystick state class
                byte[] packet = packetBuilder.BuildJoystickStatePacket();
                switch(packetBuilder.Type)
                {
                    case (JoystickType.MainController):
                        holder.Main = packet;
                        OnJoystickStateChanged(new EventArgs());
                        break;
                    case (JoystickType.ManipulatorLeft):
                        holder.ManipulatorLeft = packet;
                        break;
                    case (JoystickType.ManipulatorRight):
                        holder.ManipulatorRight = packet;
                        break;
                }                 
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
