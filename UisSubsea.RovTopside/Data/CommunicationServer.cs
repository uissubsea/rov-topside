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
        private ICollection<byte> inputBuffer;
        private ICollection<byte> outputBuffer;
        private JoystickStateStore stateStore;

        public CommunicationServer(JoystickStateStore stateStore)
        {
            this.stateStore = stateStore;
            port = SerialPortSingleton.Instance;
            
            if (!port.IsOpen)
                port.Open();

            inputBuffer = new List<byte>(Constants.InputBufferSize);
            outputBuffer = new List<byte>(Constants.OutputBufferSize);
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
            clearInputBuffer();
        }

        private void sendJoystickState()
        {
            fillOutputBuffer();
            sendJoystickStatePacket();
            clearOutputBuffer();
        }

        private void fillOutputBuffer()
        {
            outputBuffer.Add(Constants.StartByte);

            foreach (byte b in stateStore.Main)
                outputBuffer.Add(b);
            foreach (byte b in stateStore.ManipulatorLeft)
                outputBuffer.Add(b);
            foreach (byte b in stateStore.ManipulatorRight)
                outputBuffer.Add(b);

            outputBuffer.Add(Constants.StopByte);
        }

        private void sendJoystickStatePacket()
        {
            byte[] stateArray = outputBuffer.ToArray();
            port.Write(stateArray, 0, stateArray.Length);
        }

        private void clearInputBuffer()
        {
            inputBuffer.Clear();
        }

        private void clearOutputBuffer()
        {
            outputBuffer.Clear();
        }

        private void invokePacketReceived()
        {
            DataReceivedEventArgs args = new DataReceivedEventArgs();
            args.Data = inputBuffer.ToArray();
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
                    inputBuffer.Add((byte)data);
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
