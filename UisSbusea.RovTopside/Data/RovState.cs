using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    class RovState
    {
        private int heading;
        private int cameraTilt;
        private double depth;
        private Boolean error;

        public RovState(int heading, int cameraTilt, double depth, Boolean error)
        {
            this.heading = heading;
            this.cameraTilt = cameraTilt;
            this.depth = depth;
            this.error = error;
        }

        public int Heading
        {
            get
            {
                return heading;
            }
        }

        public int CameraTilt
        {
            get
            {
                return cameraTilt;
            }
        }

        public double Depth
        {
            get
            {
                return depth;
            }
        }

        public Boolean Error
        {
            get
            {
                return error;
            }
        }

    }
}
