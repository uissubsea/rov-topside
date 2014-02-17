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
        private Camera camera1, camera2, camera3;
        private Size hd;
        private Size smallCamView;
        private Boolean fullScreen;
        private System.Drawing.SolidBrush Brush;
        private int numberOfCamera;
        private ICollection<PictureBox> canvas;
        //If there is water leak in controllbox
        private Boolean leak;
        private Boolean camera1off, camera2off, camera3off;

        public CoPilotView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; 
            this.FormClosing += Form1_FormClosing;
            activateTimer();
            //Set reselution on the camera
            hd = new Size(1280, 720);
            smallCamView = new Size(640, 360);
            camera1off = false;
            camera2off = false;
            camera3off = true;

            //Test
            canvas = new List<PictureBox>();
            canvas.Add(pictureBox1);
            canvas.Add(pictureBox2);
          
        }
        //Timer left in competition
        public void activateTimer()
        {
            lblTimer.Text = "15:00";
        }
        //Wil change color when there is a leak on the ROV. 
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if(!leak)
            {
                Brush = new System.Drawing.SolidBrush(Color.Green);
            }
            else Brush = new System.Drawing.SolidBrush(Color.Red);

            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(Brush, new Rectangle(1738,550, 100, 30));
            Brush.Dispose();
            formGraphics.Dispose();

        }

        private void CoPilotView_Load(object sender, EventArgs e)
        {
            //camera = new Camera(0, hd, canvas);
           // camera.Start();

            numberOfCamera = Camera.CamerasConnected().Count;
            if(numberOfCamera == 3)
            { 
                camera1 = new Camera(0, hd, pictureBox1);
                camera2 = new Camera(1, hd, pictureBox2);
                camera1.Start();
                camera2.Start();
            }
               
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (camera1 != null)           
                camera1.Dispose();     
            
            if (camera2 != null)            
                camera2.Dispose();
            
            if (camera3 != null)
                camera3.Dispose();            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            //Fullscreen
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
            //switch between which camera to show in picturebox1 and picturebox2
            if (keyData == Keys.F1)
            {
                if (camera3off == false)
                {
                    camera3.Stop();
                    camera3off = true;
                }
                 if (camera1off == true)
                 {
                     camera1.Start();
                    camera1off = false;
                 }
                 if (camera2off == true)
                 {
                     camera2.Start();
                     camera2off = false;
                 }
                    

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
            //Switch between one camera. 
            if (keyData == Keys.F2)
            {
                if(camera3off==false)
                {                        
                   camera3.Stop();
                   camera3off = true;
                }
               
                 if (camera1off == true)
                 {
                     camera1.Start();
                     camera1off = false;
                 }                

                 if (camera2off == true)
                 {
                     camera2.Start();
                     camera2off = false;
                 }

                    if (camera2.Canvas == pictureBox1)
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
            if(keyData == Keys.F3)
            {
                  if(camera3off== true)
                    { 
                        
                        if(camera1.Canvas == pictureBox1)
                        {
                            camera1.Stop();
                            camera1off = true;
                        }
                        else if (camera2.Canvas == pictureBox1)
                        {
                            camera2.Stop();
                            camera2off = true;
                        }
                        
                        camera3 = new Camera(2, hd, pictureBox1);
                        camera3.Start();
                        camera3off = false;
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
