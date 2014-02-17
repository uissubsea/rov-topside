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

        public RovState(int heading, int cameraTilt, Boolean error)
        {
            this.heading = heading;
            this.cameraTilt = cameraTilt;
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

    }
}
