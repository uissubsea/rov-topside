using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace UisSubsea.RovTopside.Data
{
    /// <summary>
    /// This class handles all of the communication with the ROV.
    /// 
    /// The basics of the algorithm (this is an indefinite loop):
    /// 1. Receive the state of the ROV
    ///     - Wait for start byte
    ///     - Buffer data until stop byte is received
    /// 2. Send joystick positions
    /// 3. Signal that a packet is received
    /// 4. Clear the buffer
    /// 
    /// #2 comes before processing the data received to decrease the 
    /// time the ROV has to wait for data after it reports that it is
    /// ready to receive (it is ready to receive once it has sent a 
    /// packet of its state).
    /// </summary>

    public class CommunicationServer : ICommunicationServer
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

                    // Send joystick state before processing the
                    // data received to increase the ROV response time.
                    sendJoystickState();
                    raisePacketReceivedEvent();
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
        }

        private void sendJoystickState()
        {
            fillOutputBuffer();
            sendJoystickStatePacket();
            clearOutputBuffer();
        }

        private void raisePacketReceivedEvent()
        {
            invokePacketReceived();
            clearInputBuffer();
        }

        private void fillOutputBuffer()
        {
            outputBuffer.Add(Constants.StartByte);

            foreach (byte b in stateStore.Main)
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
            bool stopByteReceived = false;
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
            bool startByteReceived = false;
            
            while(!startByteReceived)
            {   
                int data = port.ReadByte();
                if ((byte)data == Constants.StartByte)
                    startByteReceived = true;
            }
        }

        // This method is virtual to ensure that it can be overridden in a derived class.
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
