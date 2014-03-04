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

        private Boolean toggleRecording()
        {
            return coPilotRightStickListener.Joystick.Buttons()[CoPilotButton.ToggleRecording];
        }

        private Boolean snapshot()
        {
            return coPilotRightStickListener.Joystick.Buttons()[CoPilotButton.Snapshot];
        }

        private Boolean changeCoPilotCamera()
        {
            return (coPilotRightStickListener.Joystick.Buttons()[CoPilotButton.ChangeCamera]
                && AllAxisesAreInNeutral(coPilotRightStickListener.Joystick));
        }

        private Boolean AllAxisesAreInNeutral(Joystick joystick)
        {
            return (joystick.Pitch() == 125 && joystick.Roll() == 125 && joystick.Throttle() == 125);
        }

        private Boolean increaseFocus()
        {
            return coPilotRightStickListener.Joystick.Buttons()[CoPilotButton.IncreaseCameraFocus];
        }

        private Boolean decreaseFocus()
        {
            return coPilotRightStickListener.Joystick.Buttons()[CoPilotButton.DecreaseCameraFocus];
        }

        private Boolean rightStickAutofocus()
        {
            return coPilotRightStickListener.Joystick.Buttons()[CoPilotButton.CameraAutofocus];
        }

        private Boolean leftFocusSliderChanged()
        {
            if(leftFocusSlider != coPilotLeftStickListener.Joystick.Slider())
            {
                leftFocusSlider = coPilotLeftStickListener.Joystick.Slider();
                return true;
            }
            return false;
        }

        private Boolean leftStickAutofocus()
        {
            return coPilotLeftStickListener.Joystick.Buttons()[PilotButton.CameraAutofocus];
        }

        private Boolean rightFocusSliderChanged()
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
