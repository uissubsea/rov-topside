using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{   
    /// <summary>
    /// Build an rov state object based
    /// on data received from the ROV
    /// </summary>

    public static class RovStateBuilder
    {
        // We need to multiply the heading by 2 because
        // the number received goes from 0 - 180.
        private const double headingResolution = 2;

        public static RovState BuildRovState(byte[] data)
        {
            if (packageIsValid(data))
            {
                bool err = error(data[0]); 
                int hdg = heading(data[1]);
                int frontCamTilt = frontCameraTilt(data[2]);
                int rearCamTilt = rearCameraTilt(data[3]);   
                int distance = distanceRov(data[4]);
                int depth = depthRov(data[5]);
                int distanceBottom = distanceToBottom(data[6]);

                return new RovState(hdg, frontCamTilt, rearCamTilt, err, distance, depth, distanceBottom);
            }
            else
                return new RovState(0, 0, 0, false, 0, 0, 0);
        }

        private static bool error(byte statusByte)
        {
            if ((1 & statusByte) == 1)
                return true;
            else
                return false;
        }

        private static int heading(byte heading)
        {
            int hdg = heading;
            return (int)(hdg * headingResolution);
        }

        private static int frontCameraTilt(byte camTilt)
        {
            int tilt = camTilt -75;                                                                               
            return (int)(tilt);
        }

        private static int rearCameraTilt(byte camTilt)
        {
            int tilt = camTilt;
            return (tilt*-1)+30;
        }

        private static bool packageIsValid(byte[] package)
        {
            return package.Count() == 7;
        }
        
        private static int depthRov(byte rovDepth)
        {
            int depth = rovDepth;
            return (int)depth*3; 
        }

        private static int distanceToBottom(byte toBottom)
        {
            int distance = toBottom;
            return (int)distance*3;
        }

        private static int distanceRov(byte rovDistance)
        {
            int distance = rovDistance;
            return (int)distance*2;
        }
    }
}
