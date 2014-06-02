using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Logic
{
    /// <summary>
    /// The functionality that the pilot view
    /// should support.
    /// </summary>

    public interface IPilotViewHandler
    {
        void SetHeading(int heading);
        void SetFrontCameraAngle(int angle);
        void SetRearCameraAngle(int angle);
        void SetAltitude(int altitude);
        void SetFocus(int focus);
        void SetThrottle(int throttle);
        void ToggleGain();
        void ToggleStopwatch();
    }
}
