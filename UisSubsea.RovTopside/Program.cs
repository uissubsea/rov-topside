using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UisSubsea.RovTopside.Presentation;
using System.IO.Ports;
using UisSubsea.RovTopside.Data;
using UisSubsea.RovTopside.Logic;

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
            }
                      
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);      

            MainController main = new MainController();
            Application.Run(main.pilotView);
            
            //createJoystick();
        }

       
        /*private static void createJoystick()
        {
            DirectInput directInput = new DirectInput();
            Guid guid = Guid.Empty;

            //Create joystick device.
            //This process is called Direct Input Device Enumeration
            //IList<DeviceInstance> 
            gameControls = directInput.GetDevices(
            DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly);

                    if (gameControls.Count >= 1)
                    {
                        guid = gameControls[0].ProductGuid;
                        Console.WriteLine("Joystick 1 verdi : " + gameControls[0].ProductGuid);

                    }
                        
                    if (gameControls.Count >= 2)
                    { 
                        guid = gameControls[1].ProductGuid;
                    Console.WriteLine("Joystick 2 verdi : " + gameControls[1].ProductGuid);

                    }
                       
                    if (gameControls.Count >= 3)
                    { 
                        guid = gameControls[2].ProductGuid;
                        Console.WriteLine("Joystick 3 verdi : " + gameControls[2].InstanceGuid);

                    }
                            
            }*/

    }
}
