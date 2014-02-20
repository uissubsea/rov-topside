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
using System.Diagnostics;
using System.Threading;

namespace UisSubsea.RovTopside.Presentation
{
    public partial class CoPilotView : Form
    {
        private Camera camera1, camera2, camera3;
        private Size hd, smallCamView;
        private Boolean fullScreen;
        private System.Drawing.SolidBrush Brush;
        private int numberOfCamera;
        private ICollection<PictureBox> canvas; 
        private Boolean camera1off, camera2off, camera3off;
        //If there is water leak in controllbox
        private Boolean leak;
        //Pilot
        private PictureBox pictureboxVideo;
      

        public CoPilotView(PictureBox pb)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; 
            this.FormClosing += Form1_FormClosing;

            //Set reselution on the camera
            hd = Constants.DesiredResolution;
            smallCamView = Constants.SmallCamView;
            camera1off = false;
            camera2off = false;
            camera3off = true;

            //Test
            canvas = new List<PictureBox>();
            pictureboxVideo = pb;
          
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
            numberOfCamera = Camera.CamerasConnected().Count;
            canvas.Add(pictureBox1);
            canvas.Add(pictureboxVideo);
            
            if(numberOfCamera == 3)
            {
                camera1 = CameraFactory.CreateMainCamera(canvas);//(pictureBox1);
                camera2 = CameraFactory.CreateManipulatorCamera(pictureBox2);
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
        public void fullScreenView()
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
        public void exitFullScreen()
        {
            this.Close();         
        }
        public void changePrecisionView()
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

            if (camera1.Canvas == pictureBox1)
            {
                camera1.Canvas = pictureBox2;
                setDesireResolution(camera1, smallCamView);
                camera2.Canvas = pictureBox1;
                setDesireResolution(camera2, hd);

            }
            else if (camera1.Canvas == pictureBox2)
            {
                camera2.Canvas = pictureBox2;
                setDesireResolution(camera2, smallCamView);
                camera1.Canvas = pictureBox1;
                setDesireResolution(camera1, hd);

            }
                   
        }
        public void changeView()
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
        public void changeToReversCam()
        {
            if (camera3off == true)
            {

                if (camera1.Canvas == pictureBox1)
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
                    setDesireResolution(camera1, smallCamView);
                    camera2.Canvas = pictureBox1;
                    setDesireResolution(camera2,hd);
               
                }
                else  if(camera1.Canvas==pictureBox2)
                {
                    camera2.Canvas = pictureBox2;
                    setDesireResolution(camera2, smallCamView);
                    camera1.Canvas = pictureBox1;
                    setDesireResolution(camera1, hd);
                              
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

                        camera3 = CameraFactory.CreateRearCamera(pictureBox1);//new Camera(2, hd, pictureBox1);
                        camera3.Start();
                        camera3off = false;
                        pictureBox2.Visible = false;
                       
                    }              
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        public void setDesireResolution(Camera camera, Size Resolution)
        {
            for (int i = 0; i < camera.Instance.VideoCapabilities.Length; i++)
            {
                Size res = camera.Instance.VideoCapabilities[i].FrameSize;
                if (res.Width == Resolution.Width && res.Height == Resolution.Height)
                    camera.Instance.VideoResolution = camera.Instance.VideoCapabilities[i];
            }
        }
                  
        }
    }

