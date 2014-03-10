using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    /**
     * Build an rov state object based
     * on data received from the ROV
     * */
    public static class RovStateBuilder
    {
        //Getting a byte 0-180.
        private const double headingResolution = 2; // 360/250

        public static RovState BuildRovState(byte[] data)
        {
            if (packageIsValid(data))
            {
                int hdg = heading(data[0]);
                int frontCamTilt = cameraTilt(data[1]);
                int rearCamTilt = cameraTilt(data[2]);
                Boolean err = error(data[3]);
                int distance = distanceRov(data[4]);
                int depth = depthRov(data[5]);
                int distanceBottom = distanceToBottom(data[6]);
                return new RovState(hdg,frontCamTilt, rearCamTilt, err, distance, depth, distanceBottom);
            }
            else
                return new RovState(0, 0, 0,false, 0, 0,0);
        }

        private static Boolean error(byte statusByte)
        {
            if ((1 & statusByte) == 1)
                return true;
            else
                return false;
        }

        private static int heading(byte heading)
        {
            int hdg = heading;
            return (int)(heading * headingResolution);
        }

        private static int cameraTilt(byte camTilt)
        {
            int tilt = camTilt;
            return (int)(tilt);
        }

        private static Boolean packageIsValid(byte[] package)
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
