using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    public class RovState
    {
        public int Heading { get; private set; }   
        private bool error;        
        private int rearCameraTilt;
        private int frontCameraTilt;
        private int depth;
        private int distanceToBottom;
        private int distance;

        public RovState(int heading, int frontCameraTilt, int rearCameraTilt, Boolean error, int distance, int depth, int distanceToBottom)
        {
            this.Heading = heading;
            this.frontCameraTilt = frontCameraTilt;
            this.rearCameraTilt = rearCameraTilt;
            this.error = error; 
            this.distance = distance;
            this.depth = depth;
            this.distanceToBottom = distanceToBottom;   
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

        public int DistanceToBottom
        {
            get
            {
                return distanceToBottom;
            }
        }

        public int Distance
        {
            get
            {
                return distance;
            }
        }
    }
}
