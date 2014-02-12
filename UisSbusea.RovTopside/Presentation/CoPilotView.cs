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
        private Size smallCamView;
        private Boolean fullScreen;

        public CoPilotView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            hd = new Size(1280, 720);
            smallCamView = new Size(640, 360);
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
            if (keyData == Keys.F1)
            {
                if (pictureBox2.Visible == false)
                    pictureBox2.Visible = true;
                if (camera1.Canvas==pictureBox1)
                {
                    camera1.Canvas = pictureBox2;
                    camera2.Canvas = pictureBox1;
                }
                else  if(camera1.Canvas==pictureBox2)
                {
                    camera1.Canvas = pictureBox1;
                    camera2.Canvas = pictureBox2;
                }
        
            }
               
            if (keyData == Keys.F2)
            {
                    if(camera2.Canvas == pictureBox1)
                    {
                        camera2.Canvas = pictureBox2;
                        camera1.Canvas = pictureBox1;
                        pictureBox2.Visible = false;
                    }
                    else
                    {
                        camera1.Canvas = pictureBox2;
                        camera2.Canvas = pictureBox1;
                        pictureBox2.Visible = false;
                    } 
            }        
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void aGauge1_ValueInRangeChanged(object sender, ValueInRangeChangedEventArgs e)
        {

        }
    }
}
