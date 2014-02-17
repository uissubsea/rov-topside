using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace UisSubsea.RovTopside.Data
{
    public class StateReceiver : IDisposable
    {
        private static Byte[] buffer;
        private static SerialPort port;

        public event EventHandler<DataReceivedEventArgs> DataReceived;

        public StateReceiver()
        {
            port = SerialPortSingleton.Instance;

            if (!port.IsOpen)
            {
                port.Open();
            }
            port.DataReceived += port_DataReceived;
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort port = (SerialPort)sender;
            buffer = new Byte[port.BytesToRead];
            port.Read(buffer, 0, buffer.Length);
            DataReceivedEventArgs args = new DataReceivedEventArgs();
            args.Data = buffer;
            OnDataReceived(args);
        }

        protected virtual void OnDataReceived(DataReceivedEventArgs e)
        {
            EventHandler<DataReceivedEventArgs> handler = DataReceived;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void Dispose()
        {
            if (port != null)
                port.Dispose();
        }
    }
}
