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
        private const byte startByte = 251;
        private const byte stopByte = 255;

        public static RovState BuildRovState(byte[] data)
        {
            if (packageIsValid(data))
            {
                int hdg = heading(data[2]);
                int camTilt = cameraTilt(data[3]);
                Boolean err = error(data[4]);
                return new RovState(hdg, camTilt, err);
            }
            else
            {
                return new RovState(0, 0, false);
            }
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
                if (package[0] == startByte && package[4] == stopByte)
                    return true;
                else
                    return false;
            else
                return false;
        }

    }
}
