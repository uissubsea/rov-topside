using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace UisSubsea.RovTopside.Data
{
    public class ImageUtils
    {

        public static Bitmap ResizeBitmap(Image source, float scale)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            // Figure out the new size.
            var width = (int)(source.Width * scale);
            var height = (int)(source.Height * scale);

            // Create the new bitmap.
            // Note that Bitmap has a resize constructor, but you can't control the quality.
            var bmp = new Bitmap(width, height);

            using (var g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = InterpolationMode.Low;
                g.DrawImage(source, new Rectangle(0, 0, width, height));
                g.Save();
            }

            return bmp;
        }

    }
}
