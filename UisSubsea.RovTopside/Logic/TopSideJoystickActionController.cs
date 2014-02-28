using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UisSubsea.RovTopside.Data;

namespace UisSubsea.RovTopside.Logic
{
    public class TopSideJoystickActionController
    {
        JoystickStateListener pilotStick, coPilotLeftStick, coPilotRightStick;
        
        ICameraHandler cameraHandler;
        ICoPilotViewHandler coPilotView;
        IOverlayHandler pilotOverlay;

        public TopSideJoystickActionController(JoystickStateListener pilotStick, 
            JoystickStateListener coPilotLeftStick, JoystickStateListener coPilotRightStick, 
            ICameraHandler cameraHandler, ICoPilotViewHandler coPilotView, IOverlayHandler pilotOverlay)
        {
            this.pilotStick = pilotStick;
            this.coPilotLeftStick = coPilotLeftStick;
            this.coPilotRightStick = coPilotRightStick;

            this.cameraHandler = cameraHandler;
            this.coPilotView = coPilotView;
            this.pilotOverlay = pilotOverlay;

            setEventHandlers();
        }

        private void setEventHandlers()
        {
            this.pilotStick.JoystickStateChanged += pilotStick_StateChanged;
            this.coPilotLeftStick.JoystickStateChanged += coPilotLeftStick_StateChanged;
            this.coPilotRightStick.JoystickStateChanged += coPilotRightStick_StateChanged;
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
            //throw new NotImplementedException();
        }

        private void pilotStick_StateChanged(object sender, EventArgs e)
        {
            if (changePilotCamera() || reverse())
                cameraHandler.ChangePilotCamera();

            if (toggleStopwatch())
                pilotOverlay.ToggleStopwatch();

            pilotOverlay.VerticalLeverIsNeutral(VerticalLeverIsNeutral());
        }

        private Boolean changePilotCamera()
        {
            return (pilotStick.Joystick.Buttons()[JoystickActionButtons.ChangePilotCamera]
                && AllAxisesAreInNeutral(pilotStick.Joystick));
        }

        private Boolean changeCoPilotCamera()
        {
            return (coPilotRightStick.Joystick.Buttons()[JoystickActionButtons.ChangeCoPilotCamera]
                && AllAxisesAreInNeutral(coPilotRightStick.Joystick));
        }

        private Boolean toggleRecording()
        {
            return coPilotRightStick.Joystick.Buttons()[JoystickActionButtons.ToggleRecording];
        }

        private Boolean snapshot()
        {
            return coPilotRightStick.Joystick.Buttons()[JoystickActionButtons.Snapshot];
        }

        private Boolean toggleStopwatch()
        {
            return pilotStick.Joystick.Buttons()[JoystickActionButtons.ToggleStopwatch];
        }

        private Boolean reverse()
        {
            return pilotStick.Joystick.Buttons()[JoystickActionButtons.Reverse];
        }

        private Boolean VerticalLeverIsNeutral()
        {
            return pilotStick.Joystick.Throttle() == 125;
        }

        private Boolean AllAxisesAreInNeutral(Joystick joystick)
        {
            return (joystick.Pitch() == 125 && joystick.Roll() == 125 && joystick.Throttle() == 125);
        }
    }
}
