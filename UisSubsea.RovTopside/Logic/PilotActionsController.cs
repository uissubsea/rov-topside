using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UisSubsea.RovTopside.Data;

namespace UisSubsea.RovTopside.Logic
{
    public class PilotActionsController
    {

        JoystickStateListener pilotStickListener;
        ICameraHandler cameraHandler;
        IPilotViewHandler pilotView;
        
        public PilotActionsController(JoystickStateListener pilotStickListener, 
            ICameraHandler cameraHandler, IPilotViewHandler pilotView)
        {
            this.pilotStickListener = pilotStickListener;
            this.cameraHandler = cameraHandler;
            this.pilotView = pilotView;

            this.pilotStickListener.JoystickStateChanged += pilotStick_StateChanged;
        }

        private void pilotStick_StateChanged(object sender, EventArgs e)
        {
            if (changePilotCamera() || reverse())
                cameraHandler.ChangePilotCamera();

            if (toggleStopwatch())
                pilotView.ToggleStopwatch();

            if (increaseFocus())
                cameraHandler.IncreasePilotCameraFocus();
            
            if (decreaseFocus())
                cameraHandler.DecreasePilotCameraFocus();

            if (autofocus())
                cameraHandler.PilotCameraAutofocus();

            pilotView.VerticalLeverIsNeutral(VerticalLeverIsNeutral());
        }

        private Boolean changePilotCamera()
        {
            return (pilotStickListener.Joystick.Buttons()[JoystickActionButtons.ChangePilotCamera]
                && AllAxisesAreInNeutral(pilotStickListener.Joystick));
        }

        private Boolean reverse()
        {
            return pilotStickListener.Joystick.Buttons()[JoystickActionButtons.Reverse];
        }

        private Boolean toggleStopwatch()
        {
            return pilotStickListener.Joystick.Buttons()[JoystickActionButtons.ToggleStopwatch];
        }

        private Boolean VerticalLeverIsNeutral()
        {
            return pilotStickListener.Joystick.Throttle() == 125;
        }

        private Boolean AllAxisesAreInNeutral(Joystick joystick)
        {
            return (joystick.Pitch() == 125 && joystick.Roll() == 125 && joystick.Throttle() == 125);
        }

        private Boolean increaseFocus()
        {
            return pilotStickListener.Joystick.Buttons()[JoystickActionButtons.IncreasePilotCameraFocus];
        }

        private Boolean decreaseFocus()
        {
            return pilotStickListener.Joystick.Buttons()[JoystickActionButtons.DecreasePilotCameraFocus];
        }

        private Boolean autofocus()
        {
            return pilotStickListener.Joystick.Buttons()[JoystickActionButtons.PilotCameraAutofocus];
        }
    }
}
