using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    /// <summary>
    /// Implement this interface if your class
    /// has the ability to handle a video feed.
    /// </summary>

    public interface IView
    {
        ICamera GetCamera();
        void SetCamera(ICamera camera);
        void SetFullScreen(int screen);
    }
}
