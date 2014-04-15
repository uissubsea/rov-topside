using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using SharpDX.DirectInput;



namespace UisSubsea.RovTopside.IndexOfEquipment
{
    public partial class Form1 : Form
    {
        private static IList<DeviceInstance> gameControls; 
        private string type = "public const string";
        private string typeJoystickName = "LogitechExtreme3DProGuid =";
        private string typeJoystickValue = "\"8e25a690\";";

        private string typeCameraName = "LogitechC930eMonikerFront =";
        private string typeCameraValue = "\"vid_046d&pid_0843&mi_00#6&1fdd\"; ";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddTextExampleLabels();
            JoystickInstanceGuid();
            CameraMonikerString();

        }

        private void AddTextExampleLabels()
        {
            joystickExampleLabelPart1.Text = type;
            joystickExampleLabelPart1.ForeColor = System.Drawing.Color.DarkBlue;

            joystickExampleLabelPart2.Text = typeJoystickName;
            joystickExampleLabelPart2.ForeColor = System.Drawing.Color.Black;

            JoystickExamplelabelPart3.Text = typeJoystickValue;
            JoystickExamplelabelPart3.ForeColor = System.Drawing.Color.DarkOrange;

            cameraExampleLabelPart1.Text = type;
            cameraExampleLabelPart1.ForeColor = System.Drawing.Color.DarkBlue;

            cameraExampleLabelPart2.Text = typeCameraName;
            cameraExampleLabelPart2.ForeColor = System.Drawing.Color.Black;

            cameraExampleLabelPart3.Text = typeCameraValue;
            cameraExampleLabelPart3.ForeColor = System.Drawing.Color.DarkOrange;


        }

        private void JoystickInstanceGuid()
        {
           
            gameControls = JoysticksAttached();  
            
            foreach(DeviceInstance controll in gameControls )
            {
                Guid guid = controll.InstanceGuid;
                string guidstring = guid.ToString();
                joystickTextBox.AppendText(guidstring + "\n");
            }
        }

        private void CameraMonikerString()
        {
            FilterInfoCollection connectedCameras = CamerasConnected();
            
            foreach(FilterInfo camera in connectedCameras)
            {
                string moniker = camera.MonikerString;
                cameraTextBox.AppendText(moniker + "\n");
            }
        }

        public static IList<DeviceInstance> JoysticksAttached()
        {
            return new DirectInput().GetDevices(
            DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly);
        }
        
        public static FilterInfoCollection CamerasConnected()
        {
            return new FilterInfoCollection(FilterCategory.VideoInputDevice);
        }
    }
}
