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
    public partial class CoPilotView : Form, ICoPilotViewHandler
    {
        private Camera camera;
        private Boolean fullScreen;
        private System.Drawing.SolidBrush Brush;
        //If there is water leak in controllbox
        private Boolean leak;
        //Used to change settings on pilotcam


        public CoPilotView()
        {
            InitializeComponent();
            
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
            formGraphics.FillRectangle(Brush, new Rectangle(1075, 620, 100, 30));
            Brush.Dispose();
            formGraphics.Dispose();
        }

        private void CoPilotView_Load(object sender, EventArgs e)
        {
            camera = CameraFactory.GetManipulatorCamera();
            camera.Canvas = videoPictureBox;
            camera.Start();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (camera != null)
            {
                camera.Stop();
            }
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
            headingGauge.Value = heading;
        }
        public void SetFrontCameraAngle(int angle)
        { 
            frontCamGauge.Value = angle;
        }
        public void SetRearCameraAngle(int angle)
        {
            rearCamGauge.Value = angle;
        }
        public void SetDepth(double depth)
        {                      
          if(depth>6)
            {
                depthTrackBar1.Minimum = -120;
            }
            depthTrackBar1.Value =((int)depth * -1)/10;
            lblTextDepth.Text = depth.ToString();
        }
        public void SetLaserDistanceMeasured(double distance)
        {
            lblTextDistance.Text = distance.ToString();
            if (distance > 0) { }//Add warning light when laser in use
        }
        public void setSensorState(bool sensorstate)
        {
            if(sensorstate)
            {
                leak = false;
                Invalidate();

            }
            else
            {
                leak = true;
                Invalidate();
            }
        }
        //Get called from CamController
        public void setCamera(Camera camera)
        {
            this.camera.Dispose();
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
            //this.camera.displayCameraProperties(IntPtr.Zero);
        }

    }
}

