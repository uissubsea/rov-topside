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

        public StateSender(String portName, PacketBuilder pb)
        {
            this.packetBuilder = pb;
            port = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
            port.Open();
        }

        public void WriteState() 
        {
            byte[] state = packetBuilder.BuildJoystickStatePacket();
            port.Write(state, 0, state.Length);
        }

        public void Dispose()
        {
            if (port != null)
                port.Dispose();
        }

    }
}
