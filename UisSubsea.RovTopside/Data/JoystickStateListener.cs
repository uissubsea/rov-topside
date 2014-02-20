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
        private JoystickStateHolder holder;

        public EventHandler JoystickStateChanged;

        public JoystickStateListener(Joystick js, PacketBuilder pb, JoystickStateHolder holder)
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
                //update state of joystick in joystick state class
                byte[] packet = packetBuilder.BuildJoystickStatePacket();
                OnJoystickStateChanged(new EventArgs());
                switch(joystick.Type)
                {
                    case (JoystickType.MainController):
                        holder.Main = packet;
                        OnJoystickStateChanged(new EventArgs());
                        break;
                    case (JoystickType.ManipulatorLeft):
                        holder.ManipulatorLeft = packet;
                        OnJoystickStateChanged(new EventArgs());
                        break;
                    case (JoystickType.ManipulatorRight):
                        holder.ManipulatorRight = packet;
                        OnJoystickStateChanged(new EventArgs());
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
