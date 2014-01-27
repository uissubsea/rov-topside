using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace UisSubsea.RovTopside.Data
{
    class SerialPortSingleton
    {
        private static SerialPort instance;
        private const string portName = "COM1";

        private SerialPortSingleton() { }

        public static SerialPort Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
                }
                return instance;
            }
        }
    }
}
