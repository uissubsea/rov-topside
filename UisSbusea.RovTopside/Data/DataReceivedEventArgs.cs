using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    public class DataReceivedEventArgs : EventArgs
    {
        public byte[] Data { get; set; }
    }
}
