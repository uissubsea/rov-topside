using System;
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
        private IOverlayHandler overlayHandler;
        private int gaugeHandler;

        public RovStateReceivedHandler(CommunicationServer comServer, 
            IOverlayHandler overlayHandler, int gaugeHandler)
        {
            this.comServer = comServer;
            this.overlayHandler = overlayHandler;
            this.gaugeHandler = gaugeHandler;

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
            overlayHandler.SetFrontCameraAngle(state.CameraTilt);

            //gaugeHandler.SetHeading(state.Heading);
            //gaugeHandler.SetFrontCameraAngle(state.CameraTilt);
        }

    }
}
