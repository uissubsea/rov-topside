using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace UisSubsea.RovTopside.Data
{
    /// <summary>
    /// A singleton pattern is used with the serial port
    /// because we will never use more than one port for
    /// communication. The com port name is hardcoded
    /// to make it easier to use. When you plug in your
    /// MCU (Micro Control Unit), go to device manager
    /// and make sure that the name is set to COM1.
    /// </summary>

    public class SerialPortSingleton
    {
        private static SerialPort instance;

        /**
         * This must be equal to the port name of the connected
         * super node
         * */
        private const string portName = "COM1";

        /**
         * Make sure that this is equal to the baud rate of the
         * connected super node, or else you wil experience errors
         * in communication data!
         * */
        private const int baudRate = 56000;

        private SerialPortSingleton() { }

        public static SerialPort Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
                }
                return instance;
            }
        }
    }
}
