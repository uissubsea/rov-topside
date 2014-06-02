using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace UisSubsea.RovTopside.Logic
{
    public class HeadUpDisplay
    {
        private Dictionary<int, string> course;

        // Font and brushes for overlay drawing.
        private Font font;
        private Font fontAltitude;
        private Brush brush;
        private Brush greenBrush;
        private Pen redPen;

        private Point throttlePoint;
        private Point headingPoint;
        private Point altitudePoint;

        public HeadUpDisplay(Color hudColor)
        {
            font = new Font("Arial", 14);
            fontAltitude = new Font("Arial", 11);
            brush = new SolidBrush(hudColor);
            greenBrush = new SolidBrush(Color.Green);
            redPen = new Pen(brush);

            throttlePoint = new Point(100, 50);
            headingPoint = new Point(295, 50);
            altitudePoint = new Point(650, 70);

            course = new Dictionary<int, string>()
            {
                {0, "N"},
                {30, "3"},
                {60, "6"},
                {90, "E"},
                {120, "12"},
                {150, "15"},
                {180, "S"},
                {210, "21"},
                {240, "24"},
                {270, "W"},
                {300, "30"},
                {330, "33"}
            };
        }

        public void drawThrottleIndicator(Graphics g, Point p, int value)
        {
            g.DrawRectangle(redPen, p.X - 1, p.Y - 1, 16, 151);

            if (value == 125)
            {
                g.FillRectangle(greenBrush, p.X, p.Y, 15, 150);
            }
            else if (value < 125)
            {
                int deflection = (int)((125 - value) * 0.6);
                g.FillRectangle(brush, p.X, p.Y + 75, 15, deflection);
            }
            else
            {
                int deflection = (int)((value - 125) * 0.6);
                g.FillRectangle(brush, p.X, p.Y + (75 - deflection), 15, deflection);
            }
        }

        public void drawHeadingIndicator(Graphics g, Point p, int heading)
        {
            //Border
            g.DrawLine(redPen, p.X, p.Y, p.X, p.Y + 15);
            g.DrawLine(redPen, p.X, p.Y, p.X + 18 * 10, p.Y);
            g.DrawLine(redPen, p.X + 18 * 10, p.Y, p.X + 18 * 10, p.Y + 15);

            //Offset
            int offset = heading % 10;

            //Ticks
            for (int i = 0; i < 18; i++)
            {
                if (offset < 5)
                {
                    if (i % 2 == 0)
                        g.DrawLine(redPen, p.X + 10 * i + (5 - offset) * 2, p.Y,
                            p.X + 10 * i + (5 - offset) * 2, p.Y + 10);
                    else
                        g.DrawLine(redPen, p.X + 10 * i + (5 - offset) * 2,
                            p.Y, p.X + 10 * i + (5 - offset) * 2, p.Y + 5);
                }
                else
                {
                    if (i % 2 == 0)
                        g.DrawLine(redPen, p.X + 10 * i + (10 - offset) * 2,
                            p.Y, p.X + 10 * i + (10 - offset) * 2, p.Y + 5);
                    else
                        g.DrawLine(redPen, p.X + 10 * i + (10 - offset) * 2,
                            p.Y, p.X + 10 * i + (10 - offset) * 2, p.Y + 10);
                }
            }

            GraphicsPath numberBox = new GraphicsPath(
            new Point[]
            { 
                new Point(p.X + 65, p.Y - 30),
                new Point(p.X + 115, p.Y - 30),
                new Point(p.X + 115, p.Y - 10),
                new Point(p.X + 95, p.Y - 10), 
                new Point(p.X + 90, p.Y),
                new Point(p.X + 85, p.Y - 10),
                new Point(p.X + 65, p.Y - 10), 
                new Point(p.X + 65, p.Y - 30)
            },
            new byte[] {
                (byte)PathPointType.Start,
                (byte)PathPointType.Line,
                (byte)PathPointType.Line,
                (byte)PathPointType.Line,
                (byte)PathPointType.Line, 
                (byte)PathPointType.Line,
                (byte)PathPointType.Line, 
                (byte)PathPointType.Line
            });

            //Number box
            g.DrawPath(redPen, numberBox);
            float x = heading < 100 ? (heading < 10 ? p.X + 82 : p.X + 75) : p.X + 70;
            g.DrawString(heading.ToString(), font, brush, new PointF(x, p.Y - 30));

            //Compass course
            int nearestTen = ((int)Math.Round(heading / 10.0)) * 10;

            for (int i = nearestTen - 40; i <= nearestTen + 40;)
            {
                int hdg = i < 0 ? (i + 360) : (i > 359 ? (i - 360) : i);
                int xOffset = 0;
                if (i >= 0)
                    xOffset = (Math.Abs((hdg - i) - 40) + (hdg - heading));
                else
                    xOffset = Math.Abs((360 - hdg) - 40) - heading;
                if (course.ContainsKey(hdg))
                {
                    int stringWidth = 0;
                    if (course[hdg].Length > 1)
                        stringWidth = -3;
                    else
                        stringWidth = 2;
                    g.DrawString(course[hdg], font, brush, p.X + xOffset*2 + stringWidth, p.Y + 20);
                    i += 30;
                }
                else
                {
                    i += 10;
                } 
            }
        }

        public void drawAltitudeIndicator(Graphics g, Point p, int altitude)
        {
            //Border
            g.DrawLine(redPen, p.X, p.Y, p.X + 15, p.Y);
            g.DrawLine(redPen, p.X, p.Y, p.X, p.Y + 18 * 10);
            g.DrawLine(redPen, p.X, p.Y + 18 * 10, p.X + 15, p.Y + 18 * 10);

            //Offset
            int offset = altitude % 10;

            //Ticks
            for (int i = 0; i < 18; i++)
            {
                if (offset < 5)
                {
                    if (i % 2 == 0)
                        g.DrawLine(redPen, p.X, p.Y + 10 * (i+1) - (5 - offset) * 2,
                            p.X + 5, p.Y + 10 * (i+1) - (5 - offset) * 2);
                    else
                        g.DrawLine(redPen, p.X, p.Y + 10 * (i+1) - (5 - offset) * 2,
                            p.X + 10, p.Y + 10 * (i+1) - (5 - offset) * 2);
                }
                else
                {
                    if (i % 2 == 0)
                        g.DrawLine(redPen, p.X, p.Y + 10 * (i+1) - (10 - offset) * 2, 
                            p.X + 10, p.Y + 10 * (i+1) - (10 - offset) * 2);
                    else
                        g.DrawLine(redPen, p.X, p.Y + 10 * (i+1) - (10 - offset) * 2, 
                            p.X + 5, p.Y + 10 * (i+1) - (10 - offset) * 2);
                }
            }

            GraphicsPath numberBox = new GraphicsPath(
            new Point[]
            { 
                new Point(p.X - 55, p.Y + 77),
                new Point(p.X - 5, p.Y + 77),
                new Point(p.X - 5, p.Y + 85),
                new Point(p.X, p.Y + 90), 
                new Point(p.X - 5, p.Y + 95),
                new Point(p.X - 5, p.Y + 103),
                new Point(p.X - 55, p.Y + 103), 
                new Point(p.X - 55, p.Y + 77)
            },
            new byte[] {
                (byte)PathPointType.Start,
                (byte)PathPointType.Line,
                (byte)PathPointType.Line,
                (byte)PathPointType.Line,
                (byte)PathPointType.Line, 
                (byte)PathPointType.Line,
                (byte)PathPointType.Line, 
                (byte)PathPointType.Line
            });

            //Number box
            g.DrawPath(redPen, numberBox);
            float xOffset = altitude < 100 ? (altitude < 10 ? 7.0F : 5.0F) : 0.0F;
            g.DrawString(altitude.ToString(), font, brush, new PointF(p.X - 50 + xOffset, p.Y + 79));

            //Altitude
            int nearestTen = ((int)Math.Round(altitude / 10.0)) * 10;

            for (int i = nearestTen - 40; i <= nearestTen + 40; i += 10)
            {
                int y = ((i - nearestTen) + 40)*2 - (nearestTen - altitude)*2;
                if(nearestTen + (nearestTen - i) >= 0)
                    g.DrawString((nearestTen + (nearestTen - i)).ToString(), fontAltitude, brush, p.X + 40, p.Y + y);
            }
        }
    }
}
