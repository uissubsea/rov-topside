using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    public class RovState
    {
        private int heading;
        private int cameraTilt;      
        private Boolean error; 
        
        private int rearCameraTilt;
        private int frontCameraTilt;
        private int depth;
        private int distance;

        public RovState(int heading, int cameraTilt, Boolean error)
        {
            this.heading = heading;
            this.cameraTilt = cameraTilt;
            this.error = error;
        }

        public RovState(int heading, int depth, int distance , int rearCameraTilt, int frontCameraTilt, Boolean error)
        {
            this.heading = heading;
            this.depth = depth;
            this.distance = distance;
            this.rearCameraTilt = rearCameraTilt;
            this.frontCameraTilt = frontCameraTilt;
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

        public Boolean Error
        {
            get
            {
                return error;
            }
        }

        public int FronCameraTilt
        {
            get
            {
                return frontCameraTilt;
            }
        }

        public int RearCameraTilt
        {
            get
            {
                return rearCameraTilt;
            }
        }

        public int Depth
        {
            get
            {
                return depth;
            }
        }

        public int Distance
        {
            get
            {
                return Distance;
            }
        }
    }
}
