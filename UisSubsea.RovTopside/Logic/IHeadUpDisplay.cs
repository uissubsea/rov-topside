using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace UisSubsea.RovTopside.Logic
{
    public interface IHeadUpDisplay
    {
        void SetHeading(Graphics g, int heading);
        void SetFrontCameraAngle(Graphics g, int angle);
        void SetRearCameraAngle(Graphics g, int angle);
        void SetAltitude(Graphics g, int altitude);
        void SetFocus(Graphics g, int focus);
        void SetThrottle(Graphics g, int throttle);
        void SetGain(Graphics g, bool full);
        void SetElapsedTime(Graphics g, Stopwatch stopwatch);
    }
}
