using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Diagnostics;

namespace UisSubsea.RovTopside.Logic
{
    public class HeadUpDisplay : IHeadUpDisplay
    {
        private Dictionary<int, string> course;

        // Font and brushes for overlay drawing.
        private Font font;
        private Font fontAltitude;
        private Brush brush;
        private Brush greenBrush;
        private Pen redPen;

        // Points for overlay drawing.
        private Point pointAltitude;
        private Point pointFocus;
        private Point pointHeading;
        private Point pointStopwatch;
        private Point pointFrontCameraAngle;
        private Point pointRearCameraAngle;
        private Point pointHalveGain;
        private Point pointThrottle;  

        public HeadUpDisplay(Color hudColor)
        {
            font = new Font("Arial", 14);
            fontAltitude = new Font("Arial", 11);
            brush = new SolidBrush(hudColor);
            greenBrush = new SolidBrush(Color.Green);
            redPen = new Pen(brush);

            //Top right
            pointStopwatch = new Point(1150, 30);

            //Bottom left
            pointFocus = new Point(30, 660);

            //Bottomright
            pointFrontCameraAngle = new Point(1150, 620);
            pointRearCameraAngle = new Point(1150, 660);

            //Top left
            pointHalveGain = new Point(30, 30);

            //Top center
            pointHeading = new Point(550, 50);

            //Right center
            pointAltitude = new Point(1150, 250);

            //Left center
            pointThrottle = new Point(30, 270);

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

        public void SetThrottle(Graphics g, int throttle)
        {
            g.DrawRectangle(redPen, pointThrottle.X - 1, pointThrottle.Y - 1, 16, 151);

            if (throttle == 125)
            {
                g.FillRectangle(greenBrush, pointThrottle.X, pointThrottle.Y, 15, 150);
            }
            else if (throttle < 125)
            {
                int deflection = (int)((125 - throttle) * 0.6);
                g.FillRectangle(brush, pointThrottle.X, pointThrottle.Y + 75, 15, deflection);
            }
            else
            {
                int deflection = (int)((throttle - 125) * 0.6);
                g.FillRectangle(brush, pointThrottle.X, pointThrottle.Y + (75 - deflection), 15, deflection);
            }
        }

        public void SetHeading(Graphics g, int heading)
        {
            //Border
            g.DrawLine(redPen, pointHeading.X, pointHeading.Y, pointHeading.X, pointHeading.Y + 15);
            g.DrawLine(redPen, pointHeading.X, pointHeading.Y, pointHeading.X + 18 * 10, pointHeading.Y);
            g.DrawLine(redPen, pointHeading.X + 18 * 10, pointHeading.Y, pointHeading.X + 18 * 10, pointHeading.Y + 15);

            //Offset
            int offset = heading % 10;

            //Ticks
            for (int i = 0; i < 18; i++)
            {
                if (offset < 5)
                {
                    if (i % 2 == 0)
                        g.DrawLine(redPen, pointHeading.X + 10 * i + (5 - offset) * 2, pointHeading.Y,
                            pointHeading.X + 10 * i + (5 - offset) * 2, pointHeading.Y + 10);
                    else
                        g.DrawLine(redPen, pointHeading.X + 10 * i + (5 - offset) * 2,
                            pointHeading.Y, pointHeading.X + 10 * i + (5 - offset) * 2, pointHeading.Y + 5);
                }
                else
                {
                    if (i % 2 == 0)
                        g.DrawLine(redPen, pointHeading.X + 10 * i + (10 - offset) * 2,
                            pointHeading.Y, pointHeading.X + 10 * i + (10 - offset) * 2, pointHeading.Y + 5);
                    else
                        g.DrawLine(redPen, pointHeading.X + 10 * i + (10 - offset) * 2,
                            pointHeading.Y, pointHeading.X + 10 * i + (10 - offset) * 2, pointHeading.Y + 10);
                }
            }

            GraphicsPath numberBox = new GraphicsPath(
            new Point[]
            { 
                new Point(pointHeading.X + 65, pointHeading.Y - 30),
                new Point(pointHeading.X + 115, pointHeading.Y - 30),
                new Point(pointHeading.X + 115, pointHeading.Y - 10),
                new Point(pointHeading.X + 95, pointHeading.Y - 10), 
                new Point(pointHeading.X + 90, pointHeading.Y),
                new Point(pointHeading.X + 85, pointHeading.Y - 10),
                new Point(pointHeading.X + 65, pointHeading.Y - 10), 
                new Point(pointHeading.X + 65, pointHeading.Y - 30)
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
            float x = heading < 100 ? (heading < 10 ? pointHeading.X + 82 : pointHeading.X + 75) : pointHeading.X + 70;
            g.DrawString(heading.ToString(), font, brush, new PointF(x, pointHeading.Y - 30));

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
                    g.DrawString(course[hdg], font, brush, pointHeading.X + xOffset*2 + stringWidth, pointHeading.Y + 20);
                    i += 30;
                }
                else
                {
                    i += 10;
                } 
            }
        }

        public void SetAltitude(Graphics g, int altitude)
        {
            //Border
            g.DrawLine(redPen, pointAltitude.X, pointAltitude.Y, pointAltitude.X + 15, pointAltitude.Y);
            g.DrawLine(redPen, pointAltitude.X, pointAltitude.Y, pointAltitude.X, pointAltitude.Y + 18 * 10);
            g.DrawLine(redPen, pointAltitude.X, pointAltitude.Y + 18 * 10, pointAltitude.X + 15, pointAltitude.Y + 18 * 10);

            //Offset
            int offset = altitude % 10;

            //Ticks
            for (int i = 0; i < 18; i++)
            {
                if (offset < 5)
                {
                    if (i % 2 == 0)
                        g.DrawLine(redPen, pointAltitude.X, pointAltitude.Y + 10 * (i+1) - (5 - offset) * 2,
                            pointAltitude.X + 5, pointAltitude.Y + 10 * (i+1) - (5 - offset) * 2);
                    else
                        g.DrawLine(redPen, pointAltitude.X, pointAltitude.Y + 10 * (i+1) - (5 - offset) * 2,
                            pointAltitude.X + 10, pointAltitude.Y + 10 * (i+1) - (5 - offset) * 2);
                }
                else
                {
                    if (i % 2 == 0)
                        g.DrawLine(redPen, pointAltitude.X, pointAltitude.Y + 10 * (i+1) - (10 - offset) * 2, 
                            pointAltitude.X + 10, pointAltitude.Y + 10 * (i+1) - (10 - offset) * 2);
                    else
                        g.DrawLine(redPen, pointAltitude.X, pointAltitude.Y + 10 * (i+1) - (10 - offset) * 2, 
                            pointAltitude.X + 5, pointAltitude.Y + 10 * (i+1) - (10 - offset) * 2);
                }
            }

            GraphicsPath numberBox = new GraphicsPath(
            new Point[]
            { 
                new Point(pointAltitude.X - 55, pointAltitude.Y + 77),
                new Point(pointAltitude.X - 5, pointAltitude.Y + 77),
                new Point(pointAltitude.X - 5, pointAltitude.Y + 85),
                new Point(pointAltitude.X, pointAltitude.Y + 90), 
                new Point(pointAltitude.X - 5, pointAltitude.Y + 95),
                new Point(pointAltitude.X - 5, pointAltitude.Y + 103),
                new Point(pointAltitude.X - 55, pointAltitude.Y + 103), 
                new Point(pointAltitude.X - 55, pointAltitude.Y + 77)
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
            g.DrawString(altitude.ToString(), font, brush, new PointF(pointAltitude.X - 50 + xOffset, pointAltitude.Y + 79));

            //Altitude
            int nearestTen = ((int)Math.Round(altitude / 10.0)) * 10;

            for (int i = nearestTen - 40; i <= nearestTen + 40; i += 10)
            {
                int y = ((i - nearestTen) + 40)*2 - (nearestTen - altitude)*2;
                if(nearestTen + (nearestTen - i) >= 0)
                    g.DrawString((nearestTen + (nearestTen - i)).ToString(), fontAltitude, brush, pointAltitude.X + 40, pointAltitude.Y + y);
            }
        }

        public void SetFrontCameraAngle(Graphics g, int angle)
        {
            g.DrawString("CAM1: " + angle + (char)176, font, brush, pointFrontCameraAngle);
        }

        public void SetRearCameraAngle(Graphics g, int angle)
        {
            g.DrawString("CAM2: " + angle + (char)176, font, brush, pointRearCameraAngle);
        }

        public void SetFocus(Graphics g, int focus)
        {
            if (focus != -1)
                g.DrawString("MF: " + focus.ToString(), font, brush, pointFocus);
            else
                g.DrawString("AF", font, brush, pointFocus);
        }

        public void SetGain(Graphics g, bool half)
        {
            g.DrawString("GAIN: " + (half == true ? "HALF" : "FULL"), font, brush, pointHalveGain);
        }

        public void SetElapsedTime(Graphics g, Stopwatch stopwatch)
        {
            TimeSpan span = stopwatch.Elapsed;
            string stopwatchstring = string.Format("{0}:{1}", Math.Floor(span.TotalMinutes), span.ToString("ss"));
            g.DrawString(stopwatchstring, font, brush, pointStopwatch);
        }
    }
}
