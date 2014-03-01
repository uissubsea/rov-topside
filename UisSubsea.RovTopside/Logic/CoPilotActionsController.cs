using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UisSubsea.RovTopside.Data;

namespace UisSubsea.RovTopside.Logic
{
    public class CoPilotActionsController
    {

        JoystickStateListener coPilotLeftStickListener;
        JoystickStateListener coPilotRightStickListener;
        ICameraHandler cameraHandler;
        ICoPilotViewHandler coPilotView;
        
        public CoPilotActionsController(JoystickStateListener coPilotLeftStickListener, 
            JoystickStateListener coPilotRightStickListener, ICameraHandler cameraHandler, 
            ICoPilotViewHandler coPilotView)
        {
            this.coPilotLeftStickListener = coPilotLeftStickListener;
            this.coPilotRightStickListener = coPilotRightStickListener;
            this.cameraHandler = cameraHandler;
            this.coPilotView = coPilotView;

            this.coPilotLeftStickListener.JoystickStateChanged += coPilotLeftStick_StateChanged;
            this.coPilotRightStickListener.JoystickStateChanged += coPilotRightStick_StateChanged;
        }

        private void coPilotRightStick_StateChanged(object sender, EventArgs e)
        {
            if (toggleRecording())
                cameraHandler.ToggleRecording();
            if (snapshot())
                cameraHandler.Snapshot();
            if (changeCoPilotCamera())
                cameraHandler.ChangeCoPilotCamera();
        }

        private void coPilotLeftStick_StateChanged(object sender, EventArgs e)
        {
            // Not yet implemented
        }

        private Boolean toggleRecording()
        {
            return coPilotRightStickListener.Joystick.Buttons()[JoystickActionButtons.ToggleRecording];
        }

        private Boolean snapshot()
        {
            return coPilotRightStickListener.Joystick.Buttons()[JoystickActionButtons.Snapshot];
        }

        private Boolean changeCoPilotCamera()
        {
            return (coPilotRightStickListener.Joystick.Buttons()[JoystickActionButtons.ChangeCoPilotCamera]
                && AllAxisesAreInNeutral(coPilotRightStickListener.Joystick));
        }

        private Boolean AllAxisesAreInNeutral(Joystick joystick)
        {
            return (joystick.Pitch() == 125 && joystick.Roll() == 125 && joystick.Throttle() == 125);
        }
    }
}
