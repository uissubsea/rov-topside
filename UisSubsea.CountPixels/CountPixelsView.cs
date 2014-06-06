using System;
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

            }
            else if (clicked == true)
            {
                clicked = false;
                point2 = e.Location;
                g.DrawEllipse(System.Drawing.Pens.Red, point2.X - 3, point2.Y - 3, 5, 5);
                int distance = Math.Abs(point1.X - point2.X);
                countClicks++;
                textBox.AppendText("Attempt " + countClicks + ": " + "Number of pixels is: " + distance + "\r\n");

            }
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
            pictureBox.Image = image;
            countClicks = 1;
        }

    }
}
