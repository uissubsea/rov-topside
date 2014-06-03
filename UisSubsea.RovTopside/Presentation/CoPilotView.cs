using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UisSubsea.RovTopside.Data;
using System.Diagnostics;
using System.Threading;
using UisSubsea.RovTopside.Logic;

namespace UisSubsea.RovTopside.Presentation
{
    /// <summary>
    /// The form that displays the co-pilots instruments and camera.
    /// </summary>

    public partial class CoPilotView : Form, ICoPilotViewHandler, IView
    {
        private ICamera camera;
        private bool fullScreen;
        private bool leak;
        private bool laserActive;

        public CoPilotView(ICamera camera)
        {       
            InitializeComponent();
            setFullScreen(Constants.CoPilotScreen);
            this.camera = camera;
            this.camera.Canvas = videoPictureBox;
            this.camera.Start();
        }
 
        protected override void OnPaint(PaintEventArgs e)
        {          
            base.OnPaint(e);
            if (!leak)
                SensorAlarmLabel.BackColor = System.Drawing.Color.Green;
            
            else
                SensorAlarmLabel.BackColor = System.Drawing.Color.Red;                
        }

        private void CoPilotView_FormClosing(object sender, FormClosedEventArgs e)
        {         
            Application.Exit();
        }
       
        private void setFullScreen(int screen)
        {
            Screen[] sc;
            sc = Screen.AllScreens;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[screen].Bounds.Left, sc[screen].Bounds.Top);
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            
        }

        public void LaserStatus()
        {
            if (!laserActive)
            {
                LaserLabel.BackColor = System.Drawing.Color.Red;
                LaserLabel.Text = "Laser On";
                laserActive = true;
            }
            else
            {
                LaserLabel.BackColor = System.Drawing.Color.Green;
                LaserLabel.Text = "Laser off";
                laserActive = false;
            }
        }
        public void SetHeading(int heading)
        {
            this.Invoke(new MethodInvoker(delegate {
            headingIndicatorInstrumentControl.SetHeadingIndicatorParameters((int)heading);         
            headingLabelText.Text = heading.ToString();
            }));
        }

        public void SetFrontCameraAngle(int angle)
        {
            this.Invoke(new MethodInvoker(delegate {frontCamGauge.Value = angle;}));
        }

        public void SetRearCameraAngle(int angle)
        {
            this.Invoke(new MethodInvoker(delegate(){rearCamGauge.Value = angle;}));
        }

        /*
         * Because we get 1 byte(0-250) for the value of the depth. 
         * We need to multiple with 3 () to convert from 
         * byte to actuale depth in cm.
         * */

        public void SetDistanceToBottom(int distance)
        {
            this.Invoke(new MethodInvoker(delegate() { altimeterInstrumentControl.SetAlimeterParameters((int)distance); }));
        }

        /* Set the distiance ahead the ROV. Because we get 1 byte(0-250) for the value of the distance. 
         * We need to multiple with 2 () to convert from 
         * byte to actuale depth in cm.
         * */
        
        //Set the state of the sensordata we get from the ROV.
        public void SomethingIsWrong(bool sensorstate)
        {
            leak = sensorstate;
        }

        //Get called from CamController
        public void SetCamera(ICamera camera)
        {
            this.camera.Stop();                 
            this.camera = camera;       
            this.camera.Canvas = videoPictureBox;
            this.camera.Start();                        
        }

        public ICamera GetCamera()
        {
            return this.camera;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    
        
    }
}

