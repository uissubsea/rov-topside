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
        /// Set the heading the in degrees.Because we get 1 byte
        /// for the value of the theading. We need to multiply with 2 
        /// to convert from byte to degrees. (0-180)
        /// </summary>
        /// <param name="heading"></param>
        void SetHeading(int heading);

        /// <summary>
        /// Set the front camera angle from 0-180 degrees.Because we 
        /// get 1 byte(0-250) for the value of the camera angle. We need to 
        /// divide with 1.39 (if total rotation of the camera is 180) to convert from 
        /// byte to actuale degree of the camera.
        /// </summary>
        /// <param name="angle"></param>
        void SetFrontCameraAngle(int angle);

        /// <summary>
        /// Set the rear camera angle from 0-180 degrees.Because we 
        /// get 1 byte(0-250) for the value of the camera angle. We need to 
        /// divide with 1.39 (if total rotation of the camera is 180) to convert from 
        /// byte to actuale degree of the camera.
        /// </summary>
        /// <param name="angle"></param>
        void SetRearCameraAngle(int angle);

        /// <summary>
        /// Set the depth of the ROV. Because we get 1 byte(0-250) for the value of the depth. 
        /// We need to multiple with 3 () to convert from 
        /// byte to actuale depth in cm.
        /// </summary>
        /// <param name="depth"></param>
        void SetDepth(double depth);

        /// <summary>
        /// Set the distiance ahead the ROV. Because we get 1 byte(0-250) for the value of the distance. 
        /// We need to multiple with 2 () to convert from 
        /// byte to actuale depth in cm.
        /// </summary>
        /// <param name="distance"></param>
        void SetLaserDistanceMeasured(double distance);

        /// <summary>
        /// Set the state of the sensordata we get from the ROV.
        /// </summary>
        /// <param name="sensorstate"></param>
        void setSensorState(bool sensorstate);
    }
}
