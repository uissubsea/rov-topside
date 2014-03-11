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
        private JoystickStateListener coPilotLeftStickListener;
        private JoystickStateListener coPilotRightStickListener;
        private ICameraHandler cameraHandler;
        private ICoPilotViewHandler coPilotView;

        private int leftFocusSlider = 0;
        private int rightFocusSlider = 0;
        
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

            if (rightFocusSliderChanged())
                cameraHandler.CoPilotCameraSetFocus((int)(rightFocusSlider * 0.24));
            
            if (rightStickAutofocus())
                cameraHandler.CoPilotCameraAutofocus();
        }

        private void coPilotLeftStick_StateChanged(object sender, EventArgs e)
        {
            if (leftFocusSliderChanged())
                cameraHandler.PilotCameraSetFocus((int)(leftFocusSlider*0.24));
            if (leftStickAutofocus())
                cameraHandler.PilotCameraAutofocus();
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

        private bool leftFocusSliderChanged()
        {
            if(leftFocusSlider != coPilotLeftStickListener.Joystick.Slider())
            {
                leftFocusSlider = coPilotLeftStickListener.Joystick.Slider();
                return true;
            }
            return false;
        }

        private bool leftStickAutofocus()
        {
            return coPilotLeftStickListener.Joystick.Buttons()[PilotButton.CameraAutofocus];
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
