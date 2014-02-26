using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Logic
{
    public interface IOverlayHandler
    {
        void SetHeading(int heading);
        void SetFrontCameraAngle(int angle);
        void SetRearCameraAngle(int angle);
        void SetDepth(double depth);
        void VerticalLeverIsNeutral(Boolean isNeutral);
        void ToggleStopwatch();
    }
}
