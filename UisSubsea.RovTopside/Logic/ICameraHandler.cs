using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Logic
{
    public interface ICameraHandler
    {
        void ToggleRecording();
        void Snapshot();
        void ChangePilotCamera();
        void ChangeCoPilotCamera();
        void IncreasePilotCameraFocus();
        void DecreasePilotCameraFocus();
        void IncreaseCoPilotCameraFocus();
        void DecreaseCoPilotCameraFocus();
        void PilotCameraAutofocus();
        void CoPilotCameraAutofocus();
        void PilotCameraSetFocus(int focus);
        void CoPilotCameraSetFocus(int focus);
    }
}
