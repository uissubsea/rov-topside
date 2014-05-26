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
    /// <summary>
    /// The form that displays the pilots camera and overlay.
    /// </summary>

    public partial class PilotView : Form, IPilotViewHandler, IView
    {
        private const char degreeSymbol = (char)176;

        // Font and brushed for overlay drawing.
        private Font font;
        private Brush redBrush;
        private Brush greenBrush;

        // Points for overlay drawing.
        private PointF pointDepth;
        private PointF pointFocus;
        private PointF pointHeading;
        private PointF pointStopwatch;
        private PointF pointFrontCameraAngle;
        private PointF pointRearCameraAngle;
        private PointF pointHalveGain;
        private Rectangle boundsVerticalLeverIsNeutral;    

        private bool verticalLeverIsNeutral = false;
        private bool halveGain = false;
        private int focus = -1;
        private bool autofocus = true;
        private int heading;
        private int frontCameraAngle;
        private int rearCameraAngle;
        private double depth;

        private ICamera camera;
        private System.Diagnostics.Stopwatch stopwatch;
        
        // A member to keep track of whether the window is fullscreen or not.
        private bool fullScreen = false;

        public PilotView(ICamera camera)
        {
            InitializeComponent();

            font = new Font("Arial", 18);
            redBrush = new SolidBrush(Color.Red);

            //Top right
            pointStopwatch = new PointF(1100.0f, 30.0f);

            //Bottom left
            pointFocus = new PointF(30.0f, 660.0f);

            //Bottomright
            pointFrontCameraAngle = new PointF(1100.0f, 620.0f);
            pointRearCameraAngle = new PointF(1100.0f, 660.0f);

            //Top left
            pointHeading = new PointF(30.0f, 30.0f);
            pointDepth = new PointF(30.0f, 70.0f);
            pointHalveGain = new PointF(30.0f, 110.0f);
            boundsVerticalLeverIsNeutral = new Rectangle(30, 150, 20, 20);
            greenBrush = new SolidBrush(Color.Green);
            stopwatch = new System.Diagnostics.Stopwatch();

            // Subscribe to the picturebox paint event so that we can draw the overlay.
            pictureBoxVideo.Paint += new PaintEventHandler(PaintOverlay);

            // Subscribe to the cameras focus changed event
            camera.FocusChanged += Focus_Changed;

            this.camera = camera;
            this.camera.Canvas = pictureBoxVideo;
            this.camera.Start();
        }

        private void Focus_Changed(object sender, FocusChangedEventArgs e)
        {
            SetFocus(e.Focus);
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
            Graphics g = args.Graphics;

            g.DrawString("DPT: " + depth + " cm", font, redBrush, pointDepth);

            if (focus != -1)
                g.DrawString("MF: " + focus.ToString(), font, redBrush, pointFocus);
            else
                g.DrawString("AF", font, redBrush, pointFocus);
            
            g.DrawString("HDG: " + heading + degreeSymbol, font, redBrush, pointHeading);

            TimeSpan span = stopwatch.Elapsed;
            string stopwatchstring = string.Format("{0}:{1}", Math.Floor(span.TotalMinutes), span.ToString("ss"));

            g.DrawString("CAM1: " + frontCameraAngle + degreeSymbol, font, redBrush, pointFrontCameraAngle);
            g.DrawString("CAM2: " + rearCameraAngle + degreeSymbol, font, redBrush, pointRearCameraAngle);

            g.DrawString(stopwatchstring, font, redBrush, pointStopwatch);

            if (verticalLeverIsNeutral)
                g.FillEllipse(greenBrush, boundsVerticalLeverIsNeutral);

            g.DrawString("GAIN: " + (halveGain == true ? "HALF" : "FULL"), font, redBrush, pointHalveGain);
        }

        private void PilotView_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Is this really necessary?
            if (camera != null)
                camera.Dispose();

            Application.Exit();
        }

        public void SetHeading(int heading)
        {
            this.heading = heading;
            this.Invoke(new MethodInvoker(delegate { this.Refresh(); }));
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

        public void ToggleGain()
        {
            halveGain = !halveGain;
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

        public void SetFocus(int focus)
        {
            this.focus = focus;
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
