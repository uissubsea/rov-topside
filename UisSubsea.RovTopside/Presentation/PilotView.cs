﻿using System;
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
        private PointF pointRecordingText;
        private PointF pointFocusValue;
        private PointF pointAutoFocus;
        private PointF pointDataReceived;
        private PointF pointStopwatch;
        private Rectangle boundsVerticalLeverIsNeutral;
        private string overlayText = "Not recording";
        private string lastPacketReceived = "0";
        private Boolean fullScreen = false;
        private Boolean verticalLeverIsNeutral = false;
        private ICamera camera;
        private int focus;
        private Boolean autofocus = true;
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
            pointRecordingText = new PointF(30.0f, 30.0f);
            pointAutoFocus = new PointF(30.0f, 70.0f);
            pointFocusValue = new PointF(30.0f, 110.0f);
            pointDataReceived = new PointF(30.0f, 150.0f);
            pointStopwatch = new PointF(30.0f, 190.0f);
            boundsVerticalLeverIsNeutral = new Rectangle(30, 230, 20, 20);
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
            args.Graphics.DrawString(overlayText, font, redBrush, pointRecordingText);
            args.Graphics.DrawString("Autofocus: " + autofocus.ToString(), font, redBrush, pointAutoFocus);
            args.Graphics.DrawString("Focus value: " + focus.ToString(), font, redBrush, pointFocusValue);
            args.Graphics.DrawString("ROV state: " + lastPacketReceived, font, redBrush, pointDataReceived);

            TimeSpan span = stopwatch.Elapsed;
            String stopwatchString = string.Format("{0}:{1}", Math.Floor(span.TotalMinutes), span.ToString("ss"));
            args.Graphics.DrawString("Timer: " + stopwatchString, font, redBrush, pointStopwatch);

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
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                    {
                        this.heading = heading;
                    }));
                return;
            }
            this.heading = heading;
        }

        public void SetFrontCameraAngle(int angle)
        {

            this.Invoke(new Action(() => this.frontCameraAngle = angle));
        }

        public void SetRearCameraAngle(int angle)
        {
            this.Invoke(new Action(() => this.rearCameraAngle = angle));
        }

        public void SetDepth(double depth)
        {
            this.Invoke(new Action(() => this.depth = depth));
        }

        public void VerticalLeverIsNeutral(bool isNeutral)
        {
            this.verticalLeverIsNeutral = isNeutral;
        }

        public void ToggleStopwatch()
        {
            this.Invoke(new Action(() => toggleStopWatch()));
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
