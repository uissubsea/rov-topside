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
using System.Diagnostics;

namespace UisSubsea.RovTopside.Presentation
{
    /// <summary>
    /// The form that displays the pilots camera and overlay.
    /// </summary>

    public partial class PilotView : Form, IPilotViewHandler, IView
    {         
        private int throttle = 25;
        private bool halveGain = false;
        private int focus = -1;
        private int heading;
        private int frontCameraAngle;
        private int rearCameraAngle;
        private int altitude;

        private ICamera camera;
        private Stopwatch stopwatch;
        private IHeadUpDisplay hud;

        public PilotView(ICamera camera, IHeadUpDisplay hud)
        {
            InitializeComponent();
            
            this.hud = hud;

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
           
            hud.SetFocus(g, focus);
            hud.SetHeading(g, heading);
            hud.SetThrottle(g, throttle);
            hud.SetAltitude(g, altitude);
            hud.SetElapsedTime(g, stopwatch);
            hud.SetFrontCameraAngle(g, frontCameraAngle);
            hud.SetRearCameraAngle(g, rearCameraAngle);
            hud.SetGain(g, halveGain);         
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

        public void SetAltitude(int altitude)
        {
            this.altitude = altitude;
        }

        public void SetThrottle(int throttle)
        {
            this.throttle = throttle;
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

        public void SetFullScreen(int screen)
        {
            Screen[] sc;
            sc = Screen.AllScreens;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[screen].Bounds.Left, sc[screen].Bounds.Top);
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
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
