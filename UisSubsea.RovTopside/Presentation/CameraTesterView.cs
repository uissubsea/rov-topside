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
using UisSubsea.RovTopside.Logic;

namespace UisSubsea.RovTopside.Presentation
{
    public partial class CameraTesterView : Form
    {
        private ICamera camera;
        private bool recording = false;
        private bool snapshot = false;
        private Font font;
        private Brush redBrush;
        private PointF pointRecordingLabel;
        private PointF pointSnapshotLabel;
        private int snapshotTimeCounter = 0;
        private ScreenRecorder screenRecorder;

        public CameraTesterView(int cameraIndex)
        {
            InitializeComponent();

            font = new Font("Arial", 18);
            redBrush = new SolidBrush(Color.Red);
            pointRecordingLabel = new PointF(50.0f, 50.0f);
            pointSnapshotLabel = new PointF(50.0f, 90.0f);

            camera = new Camera(cameraIndex, new Size(1280, 720));
            screenRecorder = new ScreenRecorder(videoCanvas);

            camera.Instance.VideoSourceError += new AForge.Video.VideoSourceErrorEventHandler(CameraTesterView_VideoSourceError);
            videoCanvas.Paint += new PaintEventHandler(PaintOverlay);

            camera.Canvas = videoCanvas;
            camera.Start();

            timer.Start();
        }

        private void PaintOverlay(object sender, PaintEventArgs args)
        {
            Graphics g = args.Graphics;

            if(recording)
                g.DrawString("REC", font, redBrush, pointRecordingLabel);

            if (snapshot)
                g.DrawString("SNAPSHOT", font, redBrush, pointSnapshotLabel);
        }

        private void timer_Tick(object sender, EventArgs e)
        {           
            if (snapshotTimeCounter == 1)
            {
                snapshotTimeCounter = 0;
                snapshot = false;
            }

            if (snapshot)
                snapshotTimeCounter++;

            lblFrameRateReceived.Text = camera.Instance.FramesReceived.ToString() + " fps";
            lblBitRate.Text = ((camera.Instance.BytesReceived / 1000000.0)*8).ToString() + " Mbit/s";
        }

        private void CameraTesterView_FormClosing(object sender, FormClosingEventArgs e)
        {
            camera.Dispose();
            timer.Stop();
        }

        private void CameraTesterView_VideoSourceError(object sender, AForge.Video.VideoSourceErrorEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void btnCameraProperties_Click(object sender, EventArgs e)
        {
            camera.DisplayCameraProperties();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.V) 
            {
                recording = !recording;
                screenRecorder.ToggleRecording();
            }
            if (keyData == Keys.S)
            {
                camera.Snapshot();
                snapshot = true;
            }
            if (keyData == Keys.Space)
                camera.DisplayCameraProperties();

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
