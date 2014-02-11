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

namespace UisSubsea.RovTopside.Presentation
{
    public partial class CoPilotView : Form
    {
        private Camera camera1, camera2;
        private Size hd;
        public CoPilotView()
        {
            InitializeComponent();
            hd = new Size(1280, 720);
            this.FormClosing += Form1_FormClosing;
        }

        private void CoPilotView_Load(object sender, EventArgs e)
        {
            camera1 = new Camera(0, hd, pictureBox1);
            camera2 = new Camera(1, hd, pictureBox2);
            camera1.Start();
            camera2.Start();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (camera1 != null || camera2 != null)
            {
                camera1.Dispose();
                camera2.Dispose();
            }
        }
    }
}
