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
        //Used to change settings on pilotcam

        public CoPilotView(ICamera camera)
        {
            InitializeComponent();

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
            formGraphics.FillRectangle(Brush, new Rectangle(1075, 620, 80, 30));
            Brush.Dispose();
            formGraphics.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (camera != null)
            {
                camera.Dispose();
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
            if (depth > 600 && depth <= 1200)
            {
                depthTrackBar1.Minimum = -1200;
            }
            else if (depth > 1200)
            {
                depthTrackBar1.Minimum = -3000;
            }
            depthTrackBar1.Value = (int)depth * -1;
            lblTextValueDepth.Text = depth.ToString();
            lblTextDepth.Text = "cm: ";
        }

        public void SetLaserDistanceMeasured(double distance)
        {
            lblTextDistance.Text = distance.ToString();
            if (distance > 0) { }//Add warning light when laser in use
        }

        public void setSensorState(bool sensorstate)
        {
            if (sensorstate)
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
            //this.camera.displayCameraProperties(IntPtr.Zero);
        }

        public ICamera GetCamera()
        {
            return this.camera;
        }
    }
}

