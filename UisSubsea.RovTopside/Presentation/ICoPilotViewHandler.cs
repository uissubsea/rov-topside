using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Logic
{
    /// <summary>
    /// The functionality that the co-pilot view
    /// should support.
    /// </summary>
    
    public interface ICoPilotViewHandler
    {
        /// <summary>
        /// Set the heading the in degrees.
        /// </summary>
        /// <param name="heading">The value used to set the direction</param>
        void SetHeading(int heading);

        /// <summary>
        /// Set the front camera angle.
        /// </summary>
        /// <param name="angle">The value used to set the front camera angle </param>
        void SetFrontCameraAngle(int angle);

        /// <summary>
        /// Set the rear camera angle.
        /// </summary>
        /// <param name="angle">The value used to set the rear camera angle</param>
        void SetRearCameraAngle(int angle);

        /// <summary>
        /// Set the depth of the ROV to the sea surface. 
        /// </summary>
        /// <param name="depth">The value that indicates how deep the ROV is</param>
        void SetDepth(int depth);

        /// <summary>
        /// Set the depth of the ROV to the bottom
        /// </summary>
        /// <param name="distance">The value that show the distance to bottom</param>
        void SetDistanceToBottom(int distance);

        /// <summary>
        /// Set the distiance ahead the ROV.
        /// </summary>
        /// <param name="distance">The value that indicates the distance to a object</param>
        void SetLaserDistanceMeasured(int distance);

        /// <summary>
        /// Set the state of the sensordata we get from the ROV.
        /// </summary>
        /// <param name="error">Tha value used to alert the user that something is wrong</param>
        void SomethingIsWrong(bool error);
    }
}
