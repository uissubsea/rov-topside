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
        ICamera camera;

        public CameraTesterView()
        {
            InitializeComponent();

            camera = new Camera(1, new Size(1280, 720));

            camera.Instance.VideoSourceError += new AForge.Video.VideoSourceErrorEventHandler(CameraTesterView_VideoSourceError);

            camera.Canvas = videoCanvas;
            camera.Start();

            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblFrameRateReceived.Text = camera.Instance.FramesReceived.ToString() + " fps";
            lblBitRate.Text = ((camera.Instance.BytesReceived / 1000000.0)*8).ToString() + " Mb/s";
        }

        private void CameraTesterView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (camera.Instance.IsRunning)
                camera.Stop();

            timer.Stop();
        }

        private void CameraTesterView_VideoSourceError(object sender, AForge.Video.VideoSourceErrorEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }
    }
}
