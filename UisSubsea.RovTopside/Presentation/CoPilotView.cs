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
    public partial class CoPilotView : Form, ICoPilotViewHandler, IView
    {
        private ICamera camera;
        private Boolean fullScreen;
        private System.Drawing.SolidBrush Brush;
        //If there is water leak in controllbox
        private Boolean leak;

        public CoPilotView(ICamera camera)
        {
            InitializeComponent();
           // SetDepth(435);
            SetHeading(90);
            this.camera = camera;
            this.camera.Canvas = videoPictureBox;
            this.camera.Start();
        }

        //Wil change color when there is a leak on the ROV. 
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

        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("CO-PILOT VIEW CLOSED");
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

        //UI updates
        public void SetHeading(int heading)
        {
            //headingIndicatorInstrumentControl1.
            headingIndicatorInstrumentControl1.SetHeadingIndicatorParameters((int)heading);
            headingLabelText.Text = heading.ToString();
            /*this.Invoke(new Action(() =>{
            this.Invoke(new Action(() => headingIndicatorInstrumentControl1.SetHeadingIndicatorParameters((int)heading)));         
            headingLabelText.Text = heading.ToString();
            }));*/

        }

        public void SetFrontCameraAngle(int angle)
        {
            this.Invoke(new Action(() =>frontCamGauge.Value = angle));
        }

        public void SetRearCameraAngle(int angle)
        {
            this.Invoke(new Action(() => rearCamGauge.Value = angle));
        }

        public void SetDepth(double depth)
        {
  
            //this.Invoke(new Action(() => headingIndicatorInstrumentControl1.SetHeadingIndicatorParameters( (int)depth)));
            altimeterInstrumentControl1.SetAlimeterParameters((int)depth);
        }

        public void SetLaserDistanceMeasured(double distance)
        {
            laserDistanceLabel.Text = distance.ToString();
            if (distance > 0) { }//Add warning light when laser in use
          
        }
        
        public void setSensorState(bool sensorstate)
        {
            if (sensorstate)
            {
                this.Invoke(new Action(() => leak = false));
                Invalidate();

            }
            else
            {
                this.Invoke(new Action(() =>leak = true));
                Invalidate();
            }
        }

        //Get called from CamController
        public void SetCamera(ICamera camera)
        {
                    this.camera.Stop();
                    this.camera = camera;
                    this.camera.Canvas = videoPictureBox;
                    this.camera.Start();
           
        }

        //getcamera
        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            camera.DisplayCameraProperties();
        }

        public ICamera GetCamera()
        {
            return this.camera;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            altimeterInstrumentControl1.SetAlimeterParameters(trackBar1.Value);
        }
      
    }
}

