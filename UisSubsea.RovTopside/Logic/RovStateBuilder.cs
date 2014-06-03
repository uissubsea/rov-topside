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
        private const int headingResolution = 2;
        private const int altitudeAboveGroundLevelResolution = 3;

        private const int numberOfBytes = 5;

        public static RovState BuildRovState(byte[] data)
        {
            if (packageIsValid(data))
            {
                bool err = error(data[0]); 
                int hdg = heading(data[1]);
                int frontCamTilt = frontCameraTilt(data[2]);
                int rearCamTilt = rearCameraTilt(data[3]);   
                int distanceBottom = AltitudeAboveGroundLevel(data[4]);

                return new RovState(hdg, frontCamTilt, rearCamTilt, err, distanceBottom);
            }
            else
                return new RovState(0, 0, 0, false, 0);
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
            return (heading * headingResolution);
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
            return package.Count() == numberOfBytes;
        }

        private static int AltitudeAboveGroundLevel(byte centimetresToBottom)
        {
            return (int)centimetresToBottom*altitudeAboveGroundLevelResolution;
        }
    }
}
