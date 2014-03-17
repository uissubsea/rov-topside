﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    public class RovState
    {
        /// <summary>
        /// This class is meant to provide a logic
        /// representation of the ROVs current state.
        /// </summary>

        public int Heading { get; private set; }
        public bool Error { get; private set; }
        public int RearCameraTilt { get; private set; }
        public int FrontCameraTilt { get; private set; }
        public int Depth { get; private set; }
        public int DistanceToBottom { get; private set; }
        public int Distance { get; private set; }

        public RovState(int heading, int frontCameraTilt, int rearCameraTilt, bool error, int distance, int depth, int distanceToBottom)
        {
            this.Heading = heading;
            this.FrontCameraTilt = frontCameraTilt;
            this.RearCameraTilt = rearCameraTilt;
            this.Error = error; 
            this.Distance = distance;
            this.Depth = depth;
            this.DistanceToBottom = distanceToBottom;   
        }
    }
}
