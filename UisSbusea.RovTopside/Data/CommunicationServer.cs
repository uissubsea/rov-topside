using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace UisSubsea.RovTopside.Data
{
    public class CommunicationServer
    {
        public event EventHandler<DataReceivedEventArgs> RovStateReceived;
        
        private SerialPort port;
        private List<byte> buffer;
        private JoystickStateHolder stateStore;

        public CommunicationServer(JoystickStateHolder stateStore)
        {
            this.stateStore = stateStore;
            port = SerialPortSingleton.Instance;
            
            if (!port.IsOpen)
                port.Open();

            buffer = new List<byte>(Constants.RovStatePacketSize);
        }

        public void Serve()
        {
            while(true)
            {
                try
                {
                    receiveRovState();
                    sendJoystickState();   
                } 
                catch (ThreadAbortException)
                {
                    SerialPortSingleton.Instance.Dispose();
                }                       
            }
        }

        private void receiveRovState()
        {
            waitForStartByte();
            bufferDataUntilStopByteReceived();
            invokePacketReceived();
            clearBuffer();
        }

        private void sendJoystickState()
        {
            List<byte> state = new List<byte>();

            state.Add(Constants.StartByte);

            foreach (byte b in stateStore.Main)
                state.Add(b);
            foreach (byte b in stateStore.ManipulatorLeft)
                state.Add(b);
            foreach (byte b in stateStore.ManipulatorRight)
                state.Add(b);

            state.Add(Constants.StopByte);

            byte[] stateArray = state.ToArray();
            port.Write(stateArray, 0, stateArray.Length);
            
        }

        private void clearBuffer()
        {
            buffer.Clear();
        }

        private void invokePacketReceived()
        {
            //invoke packet received event with array of bytes as arg
            DataReceivedEventArgs args = new DataReceivedEventArgs();
            args.Data = buffer.ToArray();
            OnRovStateReceived(args);
        }

        private void bufferDataUntilStopByteReceived()
        {
            Boolean stopByteReceived = false;
            while(!stopByteReceived)
            {
                int data = port.ReadByte();
                if ((byte)data == Constants.StopByte)
                    stopByteReceived = true;
                else
                    buffer.Add((byte)data);
            }
        }

        private void waitForStartByte()
        {
            Boolean startByteReceived = false;
            
            while(!startByteReceived)
            {   
                int data = port.ReadByte();
                if ((byte)data == Constants.StartByte)
                    startByteReceived = true;
            }
        }

        protected virtual void OnRovStateReceived(DataReceivedEventArgs e)
        {
            EventHandler<DataReceivedEventArgs> handler = RovStateReceived;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
