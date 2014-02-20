using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UisSubsea.MusselDetector
{
    public partial class MusselDetectorView : Form
    {

        private ImageAnalyzer detector;

        public MusselDetectorView()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "jpg files (*.jpg)|*.jpg";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // Create a new Bitmap object from the picture file on disk,
                    // and assign that to the PictureBox.Image property
                    pictureBox1.Image = new Bitmap(dlg.FileName);
                }
            }
        }

        private void btnDetectShells_Click(object sender, EventArgs e)
        {
            detector = new ImageAnalyzer((Bitmap)pictureBox1.Image);
            detector.applyGrayscale();
            detector.applySobelEdgeFilter();
            detector.markKnownForms();
            pictureBox1.Image = detector.getCurrentImage();
            int numberOfShellsDetected = detector.NumberOfShellsDetected;
            txtMussels.Text = numberOfShellsDetected.ToString();
            //MessageBox.Show("Number of circles detected: " + numberOfShellsDetected);
        }

        private void btnEstimate_Click(object sender, EventArgs e)
        {
            double length = Convert.ToDouble(txtLength.Text);
            double width = Convert.ToDouble(txtWidth.Text);
            double height = Convert.ToDouble(txtHeight.Text);
            int mussels = Convert.ToInt32(txtMussels.Text);

            double totalNumberOfMussels = estimateTotalNumberOfMussels(length,
                width, height, mussels);

            lblTotalNumberOfMussels.Text = totalNumberOfMussels.ToString();

            MessageBox.Show("Total number of mussels: " + totalNumberOfMussels);
        }

        private double estimateTotalNumberOfMussels(double length, double width,
            double height, int mussels)
        {
            double twoSides = length * height * 2;
            double front = width * height;
            double back = width * height;
            double top = length * width;

            double totalSurfaceArea = twoSides + front + back + top;

            double numberOfMussels = (mussels * 4) * totalSurfaceArea;

            return numberOfMussels;
        }
    }
}
