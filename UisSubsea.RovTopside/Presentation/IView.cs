using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Logic
{
    public interface IView
    {
        ICamera GetCamera();
        void SetCamera(ICamera camera);
    }
}
