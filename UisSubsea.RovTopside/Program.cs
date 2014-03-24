using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UisSubsea.RovTopside.Presentation;
using System.IO.Ports;
using UisSubsea.RovTopside.Data;
using UisSubsea.RovTopside.Logic;
using AForge.Video.DirectShow;


namespace UisSubsea.RovTopside
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static MainController main;
        
        [STAThread]
        static void Main()
        {
            /*string[] ports = SerialPort.GetPortNames();
            if (!ports.Contains("COM1"))
            {
                MessageBox.Show("Make sure USART is connected");
                return;
            }

            if(Joystick.JoysticksAttached().Count < 3)
            {
                MessageBox.Show("Make sure all joysticks are connected");
                return;
            }

            if(Camera.CamerasConnected().Count < 3)
            {
                MessageBox.Show("Make sure all cameras are connected");
                return;
            }*/

            Application.ApplicationExit += Application_ApplicationExit;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);      

            //main = new MainController();
            //Application.Run(main.pilotView);
            Application.Run(new CameraTesterView());
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            CameraFactory.DisposeAll();
            JoystickFactory.DisposeAll();
        }
    }
}
