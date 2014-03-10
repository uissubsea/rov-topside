using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Logic
{
    /// <summary>
    /// Co pilot view handler
    /// </summary>
    public interface ICoPilotViewHandler
    {
        /// <summary>
        /// Set the heading the in degrees.
        /// </summary>
        /// <param name="heading"></param>
        void SetHeading(int heading);

        /// <summary>
        /// Set the front camera angle from 0-180 degrees.
        /// </summary>
        /// <param name="angle"></param>
        void SetFrontCameraAngle(int angle);

        /// <summary>
        /// Set the rear camera angle from 0-180 degrees.
        /// </summary>
        /// <param name="angle"></param>
        void SetRearCameraAngle(int angle);

        /// <summary>
        /// Set the depth of the ROV. 
        /// </summary>
        /// <param name="depth"></param>
        void SetDepth(int depth);

        /// <summary>
        /// Set the distiance ahead the ROV.
        /// </summary>
        /// <param name="distance"></param>
        void SetLaserDistanceMeasured(int distance);

        /// <summary>
        /// Set the state of the sensordata we get from the ROV.
        /// </summary>
        /// <param name="sensorstate"></param>
        void setSensorState(bool sensorstate);
    }
}
