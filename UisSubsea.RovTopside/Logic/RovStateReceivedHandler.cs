﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UisSubsea.RovTopside.Data;

namespace UisSubsea.RovTopside.Logic
{
    public class RovStateReceivedHandler
    {
        private CommunicationServer comServer;
        private IPilotViewHandler overlayHandler;
        private ICoPilotViewHandler copilotviewhandler;

        public RovStateReceivedHandler(CommunicationServer comServer, 
            IPilotViewHandler overlayHandler, ICoPilotViewHandler copilotviewhandler)
        {
            this.comServer = comServer;
            this.overlayHandler = overlayHandler;
            this.copilotviewhandler = copilotviewhandler;

            comServer.RovStateReceived += comServer_RovStateReceived;
        }

        private void comServer_RovStateReceived(object sender, DataReceivedEventArgs e)
        {
            handleStateChanged(readRovState(e.Data));
        }

        private RovState readRovState(byte[] p)
        {
            return RovStateBuilder.BuildRovState(p);
        }

        private void handleStateChanged(RovState state)
        {
            overlayHandler.SetHeading(state.Heading);
            overlayHandler.SetFrontCameraAngle(state.FronCameraTilt);
            overlayHandler.SetDepth(state.Depth);
            overlayHandler.SetRearCameraAngle(state.RearCameraTilt);

            copilotviewhandler.SetHeading(state.Heading);
            copilotviewhandler.SetFrontCameraAngle(state.FronCameraTilt);
            copilotviewhandler.SetRearCameraAngle(state.RearCameraTilt);
            copilotviewhandler.SetDepth(state.Depth);
            copilotviewhandler.SetLaserDistanceMeasured(state.Distance);
            copilotviewhandler.setSensorState(state.Error);
        }

    }
}
