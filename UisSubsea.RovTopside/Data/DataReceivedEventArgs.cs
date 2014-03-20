using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    /// <summary>
    /// This is a wrapper class for the data that is
    /// received from the serial port.
    /// </summary>

    public class DataReceivedEventArgs : EventArgs
    {      
        public byte[] Data { get; set; }
    }
}
