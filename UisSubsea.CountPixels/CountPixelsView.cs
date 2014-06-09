﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UisSubsea.CountPixels
{
    public partial class CountPixelsView : Form
    {
        private Boolean clicked;
        private Point point1, point2;
        private Graphics g;
        private Bitmap image;
        private int countClicks = 0;
        private int countPar = 0;
        int Xdistance, Ydistance; 
        float svar1, svar2;
        private Boolean empty;

        public CountPixelsView()
        {
            InitializeComponent();
            g = pictureBox.CreateGraphics();
            Informationlbl.Text = "Works best with HD picture or smaller pictures.";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox.MouseClick += new MouseEventHandler(pictureBox_MouseClick);
            this.Controls.Add(pictureBox);
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox.CreateGraphics();
            if (clicked == false)
            {
                clicked = true;
                point1 = e.Location;
                g.DrawEllipse(System.Drawing.Pens.Red, point1.X - 3, point1.Y - 3, 5, 5);
                countPar++;
                
            }
            else if (clicked == true)
            {
                clicked = false;
                point2 = e.Location;
                g.DrawEllipse(System.Drawing.Pens.Red, point2.X - 3, point2.Y - 3, 5, 5);
                Xdistance = Math.Abs(point1.X - point2.X);
                Ydistance = Math.Abs(point1.Y - point2.Y);
                countClicks++;
                textBox.AppendText("Attempt " + countClicks + ": " + "Number of pixels is: "+ " X: " +  + Xdistance  + " Y:" + Ydistance + "\r\n");
                countPar++;
            }
            if(countPar == 2)
            {
                checkTextboxForText();
                if(!empty)
                    calculateFirstStep();                    
            }
            else if (countPar == 4)
            {
                if (!empty)
                calculateSecondStep();
                countPar = 0;
            }
        }

        private void checkTextboxForText()
        {
            if (string.IsNullOrEmpty(AvstandLasertxb.Text))
                empty = true;
            else
                empty = false;
        }

        private void calculateFirstStep()
        {
            float avstand;
            if(float.TryParse(AvstandLasertxb.Text, out avstand))
            {                                      
                svar1 = avstand / Xdistance;
                answertxt.AppendText("avstand per piksel: " + svar1 + "\r\n"); 
            }                    
        }

        private void calculateSecondStep()
        {

            svar2 = svar1 * Xdistance;     
            answertxt.AppendText("Total avstand: " + svar2 + "\r\n");                  
        }

        private void loadimagebtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            DialogResult result = openfile.ShowDialog();
            if (result == DialogResult.OK)
            {
                image = (Bitmap)Image.FromFile(openfile.FileName);
                pictureBox.Image = image;

            }
        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            textBox.Clear();
            answertxt.Clear();

            pictureBox.Image = image;
            countClicks = 0;
            countPar = 0;
        }

    }
}
