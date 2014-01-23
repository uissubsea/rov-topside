using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace UisSubsea.RovTopside.Data
{
    public class StateReceiver
    {
        private SerialPort serialport;
        private static int bufSize = 2048;
        private static Byte[] buffer;
       

        public StateReceiver(SerialPort port)
        {
          
            buffer = new Byte[bufSize];
    
            if (!port.IsOpen)
            {
                port.Open();
            }
                serialport.DataReceived += serialPort_DataReceived;
            
          
        }
        private static void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort port =  (SerialPort) sender;
            buffer = new Byte[port.BytesToRead];
            port.Read(buffer, 0, bufSize);
        }

        

        
    }
}
