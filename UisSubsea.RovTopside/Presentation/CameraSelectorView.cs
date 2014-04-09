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
using AForge.Video.DirectShow;

namespace UisSubsea.RovTopside.Presentation
{
    public partial class CameraSelectorView : Form
    {

        public int CameraIndex { get; private set; }
        private FilterInfoCollection camerasConnected;

        public CameraSelectorView()
        {
            InitializeComponent();

            camerasConnected = Camera.CamerasConnected();
            foreach (FilterInfo camera in camerasConnected)
                cmbCamerasConnected.Items.Add(camera.Name);
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            CameraIndex = cmbCamerasConnected.SelectedIndex;
            DialogResult = DialogResult.OK;
        }
    }
}
