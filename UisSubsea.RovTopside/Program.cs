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
using UisSubsea.RovTopside.StressTest;


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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DialogResult result;
            using (var chooser = new ProgramChooser())
            {
                result = chooser.ShowDialog();
                if (result == DialogResult.OK)
                {
                    switch (chooser.Program)
                    {
                        case "ROV Control System":
                            launchControlSystem();
                            break;
                        case "Joystick Tester":
                            launchJoystickTester();
                            break;
                        case "Camera Tester":
                            launchCameraTester();
                            break;
                        case "Stress Test":
                            launchStressTest();
                            break;
                        default:
                            return;
                    }
                }
            }
        }

        private static void launchControlSystem()
        {
            Application.ApplicationExit += Application_ApplicationExit;

            string[] ports = SerialPort.GetPortNames();
            if (!ports.Contains("COM1"))
            {
                MessageBox.Show("Make sure USART is connected");
                return;
            }

            if (Joystick.JoysticksAttached().Count < 3)
            {
                MessageBox.Show("Make sure all joysticks are connected");
                return;
            }

            if (Camera.CamerasConnected().Count < 3)
            {
                MessageBox.Show("Make sure all cameras are connected");
                return;
            }

            MainController main = new MainController();
            Application.Run(main.pilotView);
        }

        private static void launchJoystickTester()
        {
            string[] ports = SerialPort.GetPortNames();
            if (!ports.Contains("COM1"))
            {
                MessageBox.Show("Make sure USART is connected");
                return;
            }
<<<<<<< HEAD

            if (Joystick.JoysticksAttached().Count == 0)
            {
                MessageBox.Show("Make sure a joystick is connected");
                return;
            }

            Application.Run(new JoystickTracker());
        }

        private static void launchCameraTester()
        {
            if (Camera.CamerasConnected().Count == 0)
            {
                MessageBox.Show("Make sure a camera is connected");
                return;
            }

<<<<<<< HEAD
            main = new MainController();
            Application.Run(main.pilotView);
            //Application.Run(new CameraTesterView());
=======
=======

            if (Joystick.JoysticksAttached().Count == 0)
            {
                MessageBox.Show("Make sure a joystick is connected");
                return;
            }

            Application.Run(new JoystickTracker());
        }

        private static void launchCameraTester()
        {
            if (Camera.CamerasConnected().Count == 0)
            {
                MessageBox.Show("Make sure a camera is connected");
                return;
            }

>>>>>>> 3ace367433479a23a6709c6e47a067c5941248d2
            Application.Run(new CameraTesterView());
>>>>>>> 3ace367433479a23a6709c6e47a067c5941248d2
        }

        private static void launchStressTest()
        {
            string[] ports = SerialPort.GetPortNames();
            if (!ports.Contains("COM1"))
            {
                MessageBox.Show("Make sure USART is connected");
                return;
            }

            StressTestMain stressTest = new StressTestMain();
            System.Diagnostics.Process.Start(stressTest.Path() + "\\UisSubsea.RovTopside.StressTest.exe");

            return;
        }

        private static void launchStressTest()
        {
            string[] ports = SerialPort.GetPortNames();
            if (!ports.Contains("COM1"))
            {
                MessageBox.Show("Make sure USART is connected");
                return;
            }

            StressTestMain stressTest = new StressTestMain();
            System.Diagnostics.Process.Start(stressTest.Path() + "\\UisSubsea.RovTopside.StressTest.exe");

            return;
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            CameraFactory.DisposeAll();
            //JoystickFactory.DisposeAll();
        }
    }
}
