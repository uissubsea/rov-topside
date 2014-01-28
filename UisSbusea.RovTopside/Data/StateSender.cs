using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace UisSubsea.RovTopside.Data
{
    class StateSender : IDisposable
    {

        private PacketBuilder packetBuilder;
        private SerialPort port;

        private const byte startByte = 255;
        private const byte stopByte = 251;

        public StateSender(PacketBuilder pb)
        {
            this.packetBuilder = pb;
            port = SerialPortSingleton.Instance;

            if (!port.IsOpen)
                port.Open();
        }

        public byte[] WriteState() 
        {
            byte[] state = packetBuilder.BuildJoystickStatePacket();
            byte[] complete = new byte[state.Length + 2];
            state.CopyTo(complete, 1);
            complete[0] = startByte;
            complete[state.Length+1] = stopByte;
            
            port.Write(complete, 0, complete.Length);
            return complete;
        }

        public void Dispose()
        {
            if (port != null)
                port.Dispose();
        }

    }
}
