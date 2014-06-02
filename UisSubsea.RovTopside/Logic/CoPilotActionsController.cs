using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UisSubsea.RovTopside.Data;

namespace UisSubsea.RovTopside.Logic
{
    /// <summary>
    /// This class handles the actions (mostly camera operations) 
    /// performed by the co-pilot.
    /// </summary>

    public class CoPilotActionsController
    {
        private IJoystickStateListener coPilotRightStickListener;
        private ICameraHandler cameraHandler;
        private ICoPilotViewHandler coPilotView;

        private int leftFocusSlider = 0;
        private int rightFocusSlider = 0;
        
        public CoPilotActionsController(IJoystickStateListener coPilotRightStickListener, ICameraHandler cameraHandler, 
            ICoPilotViewHandler coPilotView)
        {
            this.coPilotRightStickListener = coPilotRightStickListener;
            this.cameraHandler = cameraHandler;
            this.coPilotView = coPilotView;

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

            if (rightFocusSliderChanged())
            {
                cameraHandler.CoPilotCameraSetFocus((int)(rightFocusSlider * 0.24));
                cameraHandler.PilotCameraSetFocus((int)(leftFocusSlider * 1.02));
            }
                
            
            if (rightStickAutofocus())
            {
                cameraHandler.CoPilotCameraAutofocus();
                cameraHandler.PilotCameraAutofocus();
            }

        }

        private bool toggleRecording()
        {
            return coPilotRightStickListener.Joystick.Buttons()[CoPilotButton.ToggleRecording];
        }

        private bool snapshot()
        {
            return coPilotRightStickListener.Joystick.Buttons()[CoPilotButton.Snapshot];
        }

        private bool changeCoPilotCamera()
        {
            return (coPilotRightStickListener.Joystick.Buttons()[CoPilotButton.ChangeCamera]);              
        }

        private bool AllAxisesAreInNeutral(Joystick joystick)
        {
            return (joystick.Pitch() == 125 && joystick.Roll() == 125 && joystick.Throttle() == 125);
        }

        private bool rightStickAutofocus()
        {
            return coPilotRightStickListener.Joystick.Buttons()[CoPilotButton.CameraAutofocus];
        }

        private bool rightFocusSliderChanged()
        {
            if (rightFocusSlider != coPilotRightStickListener.Joystick.Throttle())
            {
                rightFocusSlider = coPilotRightStickListener.Joystick.Throttle();
                return true;
            }
            return false;
        }
    }
}
