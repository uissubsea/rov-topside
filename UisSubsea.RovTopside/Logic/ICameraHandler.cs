using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Logic
{
    ///<summary>
    ///Camera handler interface
    ///</summary>
    public interface ICameraHandler
    {
        /// <summary>
        /// Toggle recoding
        /// </summary>
        void ToggleRecording();

        /// <summary>
        /// Takes a snapshot from the camera
        /// </summary>
        void Snapshot();

        /// <summary>
        /// Change which camera that shows on the pilot screen
        /// </summary>
        void ChangePilotCamera();

        /// <summary>
        /// Change wich camera that shows on the co pilot screen
        /// </summary>
        void ChangeCoPilotCamera();

        /// <summary>
        /// Set camera foucs to autofocus
        /// </summary>
        void PilotCameraAutofocus();

        /// <summary>
        /// Set camera focus to autofocus
        /// </summary>
        void CoPilotCameraAutofocus();

        /// <summary>
        /// Set camera focus to manuel
        /// </summary>
        /// <param name="focus"></param>
        void PilotCameraSetFocus(int focus);

        /// <summary>
        /// Set camera focus to manuel
        /// </summary>
        /// <param name="focus"></param>
        void CoPilotCameraSetFocus(int focus);
    }
}
