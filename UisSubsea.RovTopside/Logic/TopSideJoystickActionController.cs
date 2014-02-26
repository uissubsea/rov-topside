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
            return pilotStick.Joystick.Buttons()[2];
        }

        private Boolean changeCoPilotCamera()
        {
            return coPilotRightStick.Joystick.Buttons()[1];
        }

        private Boolean toggleRecording()
        {
            return coPilotRightStick.Joystick.Buttons()[5];
        }

        private Boolean snapshot()
        {
            return coPilotRightStick.Joystick.Buttons()[4];
        }

        private Boolean toggleStopwatch()
        {
            return pilotStick.Joystick.Buttons()[4];
        }

        private Boolean reverse()
        {
            return JoystickFactory.GetMainController().Buttons()[1];
        }

        private Boolean VerticalLeverIsNeutral()
        {
            return JoystickFactory.GetMainController().Throttle() == 125;
        }
    }
}
