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
        private System.Drawing.SolidBrush Brush;
        private bool leak;

        public CoPilotView(ICamera camera)
        {
            InitializeComponent();
            this.camera = camera;
            this.camera.Canvas = videoPictureBox;
            this.camera.Start();
        }
 
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!leak)
            {
                Brush = new System.Drawing.SolidBrush(Color.Green);
            }
            else Brush = new System.Drawing.SolidBrush(Color.Red);

            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(Brush, new Rectangle(1095, 620, 50, 20));
            Brush.Dispose();
            formGraphics.Dispose();
        }

        private void CoPilotView_FormClosing(object sender, FormClosedEventArgs e)
        {         
            // Is this really needed?
            if (camera != null)
                camera.Dispose();

            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!fullScreen)
            {
                fullScreen = true;
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                fullScreen = false;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
            }
        }

        public void SetHeading(int heading)
        {
            this.Invoke(new MethodInvoker(delegate {
            headingIndicatorInstrumentControl1.SetHeadingIndicatorParameters((int)heading);         
            headingLabelText.Text = heading.ToString();
            }));
        }

        public void SetFrontCameraAngle(int angle)
        {
            this.Invoke(new MethodInvoker(delegate {frontCamGauge.Value = angle;}));
        }

        /*Because we 
         * get 1 byte(0-250) for the value of the camera angle. We need to 
         * divide with 1.39 (if total rotation of the camera is 180) to convert from 
         * byte to actuale degree of the camera.
         * */
        public void SetRearCameraAngle(int angle)
        {
            this.Invoke(new MethodInvoker(delegate(){rearCamGauge.Value = angle;}));
        }

        /*
         * Because we get 1 byte(0-250) for the value of the depth. 
         * We need to multiple with 3 () to convert from 
         * byte to actuale depth in cm.
         * */
        public void SetDepth(int depth)
        {
            this.Invoke(new MethodInvoker(delegate() { altimeterInstrumentControl1.SetAlimeterParameters((int)depth); }));
            //altimeterInstrumentControl1.SetAlimeterParameters((int)depth *3);
        }

        public void SetDistanceToBottom(int distance)
        {
            this.Invoke(new MethodInvoker(delegate() { distanceToBottomLabel.Text=distance.ToString(); }));
        }

        /* Set the distiance ahead the ROV. Because we get 1 byte(0-250) for the value of the distance. 
         * We need to multiple with 2 () to convert from 
         * byte to actuale depth in cm.
         * */
        public void SetLaserDistanceMeasured(int distance)
        {
            this.Invoke(new MethodInvoker(delegate() { laserDistanceLabel.Text = distance.ToString(); }));         
        }
        
        //Set the state of the sensordata we get from the ROV.
        public void setSensorState(bool sensorstate)
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
            else if (keyData == Keys.F11)
            {
                if (!fullScreen)
                {
                    fullScreen = true;
                    this.WindowState = FormWindowState.Normal;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    fullScreen = false;
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Normal;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

