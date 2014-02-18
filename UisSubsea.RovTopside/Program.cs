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
        //private static IList<DeviceInstance> gameControls;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] ports = SerialPort.GetPortNames();
           /* if (!ports.Contains("COM1") || Joystick.JoysticksAttached().Count == 0 
                || Camera.CamerasConnected().Count < 1)
            {
                MessageBox.Show("Make sure all neccessary devices are connected");
                return;
            }     
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PilotView());
            

            
            
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
                        guid = gameControls[0].InstanceGuid;
                        Console.WriteLine("Joystick 1 verdi : " + gameControls[0].InstanceGuid);

                    }
                        
                    if (gameControls.Count >= 2)
                    { 
                        guid = gameControls[1].InstanceGuid;
                    Console.WriteLine("Joystick 2 verdi : " + gameControls[1].InstanceGuid);

                    }
                       
                    if (gameControls.Count >= 3)
                    { 
                        guid = gameControls[2].InstanceGuid;
                        Console.WriteLine("Joystick 3 verdi : " + gameControls[2].InstanceGuid);

                    }
                            
            }*/

    }
}
