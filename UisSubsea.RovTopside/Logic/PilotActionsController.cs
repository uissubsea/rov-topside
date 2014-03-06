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

        private JoystickStateListener pilotStickListener;
        private ICameraHandler cameraHandler;
        private IPilotViewHandler pilotView;

        private bool buttonPressed = false;
        
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

            pilotView.VerticalLeverIsNeutral(VerticalLeverIsNeutral());
        }

        private bool changePilotCamera()
        {
            // The following code makes sure that an action 
            // is only performed when the buttons is released.
            // If we don't perform this check, the action will be performed
            // every time the joystick produces an interrupt. That means
            // that pressing the button while moving the joystick, will 
            // cause the action to be performed way to many times.

            bool shouldChangeCamera = false;
            if(buttonPressed)
            {
                if (!pilotStickListener.Joystick.Buttons()[PilotButton.ChangeCamera])
                {
                    buttonPressed = false;
                    shouldChangeCamera = true;
                }
            }
            else
            {
                buttonPressed = pilotStickListener.Joystick.Buttons()[PilotButton.ChangeCamera];
            }

            return shouldChangeCamera;

        }

        private bool reverse()
        {
            return pilotStickListener.Joystick.Buttons()[PilotButton.Reverse];
        }

        private bool toggleStopwatch()
        {
            return pilotStickListener.Joystick.Buttons()[PilotButton.ToggleStopwatch];
        }

        private bool VerticalLeverIsNeutral()
        {
            return pilotStickListener.Joystick.Throttle() == 125;
        }

        private bool AllAxisesAreInNeutral(Joystick joystick)
        {
            return (joystick.Pitch() == 125 && joystick.Roll() == 125 && joystick.Throttle() == 125);
        }
    }
}
