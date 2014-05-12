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
    public partial class IndexOfEquipmentView : Form
    {
        private static IList<DeviceInstance> gameControls; 
        private string type = "public const string";
        private string typeJoystickName = "LogitechExtreme3DProGuid =";
        private string typeJoystickValue = "\"8e25a690\";";

        private string typeCameraName = "LogitechC930eMonikerFront =";
        private string typeCameraValue = "\"vid_046d&pid_0843&mi_00#6&1fdd\"; ";


        public IndexOfEquipmentView()
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
            JoystickExamplelabelPart3.ForeColor = System.Drawing.Color.IndianRed;

            cameraExampleLabelPart1.Text = type;
            cameraExampleLabelPart1.ForeColor = System.Drawing.Color.DarkBlue;

            cameraExampleLabelPart2.Text = typeCameraName;
            cameraExampleLabelPart2.ForeColor = System.Drawing.Color.Black;

            cameraExampleLabelPart3.Text = typeCameraValue;
            cameraExampleLabelPart3.ForeColor = System.Drawing.Color.IndianRed;


        }

        private void JoystickInstanceGuid()
        {
           
            gameControls = JoysticksAttached();  
            
            foreach(DeviceInstance controll in gameControls )
            {
                Guid guid = controll.InstanceGuid;
                string joystickName = controll.InstanceName;
                string guidstring = guid.ToString();
                joystickTextBox.AppendText(joystickName + ": " + guidstring + "\n");
            }

        }

        private void CameraMonikerString()
        {
            FilterInfoCollection connectedCameras = CamerasConnected();
            
            foreach(FilterInfo camera in connectedCameras)
            {
                string moniker = camera.MonikerString;
                string cameraName = camera.Name;
                cameraTextBox.AppendText(cameraName + ": " + moniker + "\n");
            }

            //cameraTextBox.AppendText("Logitech HD Pro Webcam C920: @device:pnp:\\?\usb#vid_046d&pid_082d&mi_00#8&3eda2e7&0&0000#{65e8773d-8f56-11d0-a3b9-00a0c9223196}\{bbefb6c7-2fc4-4139-bb8b-a58bba724083}");
            cameraTextBox.AppendText(@"Logitech HD Pro Webcam C930e: @device:pnp:\\?\usb#vid_046d&pid_0843&mi_00#7&313bb5a3&0&0000#{65e8773d-8f56-11d0-a3b9-00a0c9223196}" );
            cameraTextBox.AppendText("\r\n");
            cameraTextBox.AppendText(@"Logitech HD Pro Webcam C930e: @device:pnp:\\?\usb#vid_046d&pid_0843&mi_00#6&1fddba94&0&0000#{65e8773d-8f56-11d0-a3b9-00a0c9223196}");
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
