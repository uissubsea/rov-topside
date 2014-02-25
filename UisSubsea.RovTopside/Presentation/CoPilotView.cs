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

namespace UisSubsea.RovTopside.Presentation
{
    public partial class CoPilotView : Form, IGaugeHandler
    {
        private Camera camera1;
        private Boolean fullScreen;
        private System.Drawing.SolidBrush Brush;
        //If there is water leak in controllbox
        private Boolean leak;


        public CoPilotView()
        {
            InitializeComponent();
            aGauge2.Value = 45;    
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
            formGraphics.FillRectangle(Brush, new Rectangle(1100, 550, 100, 30));
            Brush.Dispose();
            formGraphics.Dispose();
        }

        private void CoPilotView_Load(object sender, EventArgs e)
        {
            camera1 = CameraFactory.CreateManipulatorCamera();
            camera1.Canvas = pictureBox1;
            camera1.Start();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (camera1 != null)
            {
                camera1.Stop();
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
        public void heading(int heading)
        {
            aGauge1.Value = heading;
            aGauge1.Scale(new SizeF(new PointF(0,5f)));
        }
        public void cameraTilt(int tilt)
        {
            aGauge2.Value = tilt;
        }
        

    }
}

