using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UisSubsea.RovTopside.Data;

namespace UisSubsea.RovTopside.Logic
{
    /// <summary>
    /// This class handles the data reiceived event whenever
    /// it is invoked from the communication server.
    /// 
    /// The data is presented in both views (pilot and co-pilot).
    /// </summary>

    public class RovStateReceivedHandler
    {        
        private ICommunicationServer comServer;
        private IPilotViewHandler pilotViewHandler;
        private ICoPilotViewHandler copilotViewhandler;

        public RovStateReceivedHandler(ICommunicationServer comServer, 
            IPilotViewHandler overlayHandler, ICoPilotViewHandler copilotviewhandler)
        {
            this.comServer = comServer;
            this.pilotViewHandler = overlayHandler;
            this.copilotViewhandler = copilotviewhandler;

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
            presentRovStateOnPilotView(state);
            presentRovStateOnCoPilotView(state);
        }

        private void presentRovStateOnPilotView(RovState state)
        {
            pilotViewHandler.SetHeading(state.Heading);
            pilotViewHandler.SetFrontCameraAngle(state.FrontCameraTilt);          
            pilotViewHandler.SetRearCameraAngle(state.RearCameraTilt);  
            pilotViewHandler.SetAltitude(state.DistanceToBottom);
        }

        private void presentRovStateOnCoPilotView(RovState state)
        {
            copilotViewhandler.SetHeading(state.Heading);
            copilotViewhandler.SetFrontCameraAngle(state.FrontCameraTilt);
            copilotViewhandler.SetRearCameraAngle(state.RearCameraTilt);
            copilotViewhandler.SetDistanceToBottom(state.DistanceToBottom);
            copilotViewhandler.SomethingIsWrong(state.Error);
        }
    }
}
