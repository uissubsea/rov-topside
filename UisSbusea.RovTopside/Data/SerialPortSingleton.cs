using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace UisSubsea.RovTopside.Data
{
    /**
     * A singleton pattern is used with the serial port
     * because we will never use more than one port for
     * communication. The com port name is hardcoded
     * to make it easier to use. When you plug in your
     * MCU (Micro Control Unit), go to device manager
     * and make sure that the name is set to COM1.
     * */

    public class SerialPortSingleton
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
