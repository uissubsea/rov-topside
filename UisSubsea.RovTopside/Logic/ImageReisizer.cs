using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace UisSubsea.RovTopside.Logic
{
    public static class ImageReisizer
    {

        public static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Bitmap newImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.CompositingQuality = CompositingQuality.HighSpeed;
                g.SmoothingMode = SmoothingMode.HighSpeed;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;

                g.DrawImage(image, new System.Drawing.Rectangle(0, 0, width, height));
            }
            return newImage;
        }
    }
}
