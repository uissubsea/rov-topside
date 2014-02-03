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

        private IList <PacketBuilder> packetBuilder;
        private SerialPort port;

        private const byte startByte = 255;
        private const byte stopByte = 251;

        public StateSender(IList <PacketBuilder> pb)
        {
            this.packetBuilder = pb;
            port = SerialPortSingleton.Instance;

            if (!port.IsOpen)
                port.Open();
        }

        public byte[] WriteState() 
        {
            
            List<byte> state = new List<byte>();
           
            state.Add(startByte);
           
            foreach( PacketBuilder builder in packetBuilder)
            {
                byte[] package = builder.BuildJoystickStatePacket();
                foreach (byte b in package)
                    state.Add(b);
            }
            
            state.Add(stopByte);
            byte[] finaleState = state.ToArray();
            port.Write(finaleState, 0, state.Count);
            return finaleState;
        }
      

        public void Dispose()
        {
            if (port != null)
                port.Dispose();
        }

    }
}
