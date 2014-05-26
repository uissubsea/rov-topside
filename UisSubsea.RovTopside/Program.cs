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
using UisSubsea.RovTopside.IndexOfEquipment;

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
            using (var chooser = new ProgramSelectorView())
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
                        case "Camera and Joystick ID":
                            launchIndexOfEquipment();
                            break;
                        case "Stress Test":
                            launchStressTest();
                            break;
                        case "ROV Control System Debug":
                            launchControlSystemDebug();
                            break;
                        default:
                            return;
                    }
                }
            }
        }

        private static void launchControlSystemDebug()
        {
            MainControllerDebug main = new MainControllerDebug();
            Application.Run(main.pilotView);
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

            using (var waitingView = new LoadingView())
            {
                var result = waitingView.ShowDialog();
                if (!(result == DialogResult.OK))
                {
                    MessageBox.Show("Something went wrong. Please try again.");
                    return;
                }
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

            if (Joystick.JoysticksAttached().Count == 0)
            {
                MessageBox.Show("Make sure a joystick is connected");
                return;
            }

            Application.Run(new JoystickTrackerView());
        }

        private static void launchCameraTester()
        {
            if (Camera.CamerasConnected().Count == 0)
            {
                MessageBox.Show("Make sure a camera is connected");
                return;
            }

            DialogResult result;
            using (var selector = new CameraSelectorView())
            {
                result = selector.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Application.Run(new CameraTesterView(selector.CameraIndex));
                }
            } 
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

        private static void launchIndexOfEquipment()
        {
            Application.Run(new IndexOfEquipmentView());
        } 

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            CameraFactory.DisposeAll();
            JoystickFactory.DisposeAll();
        }
    }
}