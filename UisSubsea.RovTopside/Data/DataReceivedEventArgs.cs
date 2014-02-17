using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    /**
     * This is a wrapper class for the data that is
     * received from the serial port.
     * It should be used to trigger an event in the UI layer
     * so that it be can be presented in the debug view
     * */
    public class DataReceivedEventArgs : EventArgs
    {
        public byte[] Data { get; set; }
    }
}
