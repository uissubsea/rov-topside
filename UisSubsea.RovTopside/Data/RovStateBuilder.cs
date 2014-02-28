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
        private const double headingResolution = 1.44; // 360/250

        public static RovState BuildRovState(byte[] data)
        {
            if (packageIsValid(data))
            {
                int hdg = heading(data[1]);
                int camTilt = cameraTilt(data[2]);
                Boolean err = error(data[3]);
                return new RovState(hdg, camTilt, err);
            }
            else
            {
                return new RovState(0, 0, false);
            }
        }

        public static RovState BuildRovStateComplet(byte[] data)
        {
            if (packageIsValid(data))
            {
                int hdg = heading(data[1]);
                int frontCamTilt = cameraTilt(data[2]);
                int rearCamTilt = cameraTilt(data[4]);
                Boolean err = error(data[3]);
                int distance = distanceRov(data[5]);
                int depth = depthRov(data[6]);
                return new RovState(hdg, depth, distance, rearCamTilt, frontCamTilt, err);
            }
            else
                return new RovState(0, 0, 0, 0, 0, false);
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
            return tilt;
        }

        private static Boolean packageIsValid(byte[] package)
        {
            if (package.Count() == 5)
                if (package[0] == Constants.StartByte && package[4] == Constants.StopByte)
                    return true;
                else
                    return false;
            else
                return false;
        }
        
        private static int depthRov(byte rovDepth)
        {
            int depth = rovDepth;

            return depth; 
        }

        private static int distanceRov(byte rovDistance)
        {
            int distance = rovDistance;
            return distance;
        }

    }
}
