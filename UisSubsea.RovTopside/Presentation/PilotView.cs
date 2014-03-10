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
using System.Threading;
using UisSubsea.RovTopside.Logic;

namespace UisSubsea.RovTopside.Presentation
{
    public partial class PilotView : Form, IPilotViewHandler, IView
    {
        private Font font;
        private Brush redBrush;
        private Brush greenBrush;
        private PointF pointDepth;
        private PointF pointFocusValue;
        private PointF pointAutoFocus;
        private PointF pointHeading;
        private PointF pointStopwatch;
        private Rectangle boundsVerticalLeverIsNeutral;
        private string lastPacketReceived = "0";
        private bool fullScreen = false;
        private bool verticalLeverIsNeutral = false;
        private ICamera camera;
        private int focus;
        private bool autofocus = true;
        private System.Diagnostics.Stopwatch stopwatch;
        private int heading;
        private int frontCameraAngle;
        private int rearCameraAngle;
        private double depth;

        public PilotView(ICamera camera)
        {
            InitializeComponent();

            font = new Font("Arial", 18);
            redBrush = new SolidBrush(Color.Red);
            //Top right
            pointDepth = new PointF(1200.0f, 30.0f);

            //Bottom left
            pointAutoFocus = new PointF(30.0f, 650.0f);
            pointFocusValue = new PointF(30.0f, 690.0f);

            //Top left
            pointHeading = new PointF(30.0f, 30.0f);
            pointStopwatch = new PointF(30.0f, 70.0f);
            boundsVerticalLeverIsNeutral = new Rectangle(30, 110, 20, 20);
            greenBrush = new SolidBrush(Color.Green);
            stopwatch = new System.Diagnostics.Stopwatch();

            pictureBoxVideo.Paint += new PaintEventHandler(PaintOverlay);

            this.camera = camera;
            this.camera.Canvas = pictureBoxVideo;
            this.camera.Start();
        }

        private void toggleStopWatch()
        {
            if (stopwatch.IsRunning)
                stopwatch.Stop();
            else
                stopwatch.Start();
        }

        private void PaintOverlay(object sender, PaintEventArgs args)
        {
            args.Graphics.DrawString("Depth: " + depth, font, redBrush, pointDepth);
            args.Graphics.DrawString("Autofocus: " + autofocus.ToString(), font, redBrush, pointAutoFocus);
            args.Graphics.DrawString("Focus value: " + focus.ToString(), font, redBrush, pointFocusValue);
            args.Graphics.DrawString("Heading: " + heading, font, redBrush, pointHeading);

            TimeSpan span = stopwatch.Elapsed;
            string stopwatchstring = string.Format("{0}:{1}", Math.Floor(span.TotalMinutes), span.ToString("ss"));
            args.Graphics.DrawString("Timer: " + stopwatchstring, font, redBrush, pointStopwatch);

            if (verticalLeverIsNeutral)
                args.Graphics.FillEllipse(greenBrush, boundsVerticalLeverIsNeutral);
        }

        private void PilotView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (camera != null)
                camera.Dispose();

            Application.Exit();
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

        public void SetHeading(int heading)
        {
            this.heading = heading;
        }

        public void SetFrontCameraAngle(int angle)
        {
            frontCameraAngle = angle;
        }

        public void SetRearCameraAngle(int angle)
        {
            rearCameraAngle = angle;
        }

        public void SetDepth(double depth)
        {
            this.depth = depth;
        }

        public void VerticalLeverIsNeutral(bool isNeutral)
        {
            this.verticalLeverIsNeutral = isNeutral;
        }

        public void ToggleStopwatch()
        {
            toggleStopWatch();
        }

        public ICamera GetCamera()
        {
            return this.camera;
        }

        public void SetCamera(ICamera camera)
        {
            this.camera.Stop();
            this.camera = camera;
            this.camera.Canvas = pictureBoxVideo;
            this.camera.Start();
        }
    }
}
