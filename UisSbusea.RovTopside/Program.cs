using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UisSubsea.RovTopside.Presentation;
using System.IO.Ports;
using UisSubsea.RovTopside.Data;

namespace UisSubsea.RovTopside
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] ports = SerialPort.GetPortNames();
           /* if (!ports.Contains("COM1") || Joystick.GetNumberOfJoysticks() == 0 
                || Camera.CamerasConnected().Count < 1)
            {
                MessageBox.Show("Make sure all neccessary devices are connected");
                return;
            }     */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CoPilotView());
        }
    }
}
