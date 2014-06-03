using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UisSubsea.RovTopside.Data;
using UisSubsea.RovTopside.Presentation;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace UisSubsea.RovTopside.Logic
{
    public class MainControllerDebug
    {
        public Form pilotView;
        private Form coPilotView;
        private IJoystick pilotJoystick;
        private IJoystick coPilotRightJoystick;

        public MainControllerDebug()
        {
            initializeComponents();
        }

        private void initializeComponents()
        {
            initializeViews();

            initializeJoysticks();
            JoystickStateStore stateStore = new JoystickStateStore();

            initializeCommunicationServer(stateStore);

            pilotView.Show();
            coPilotView.Show();
        }

        private void initializeViews()
        {
            pilotView = new PilotView(new CameraMock(), new HeadUpDisplay(Color.Red));
            coPilotView = new CoPilotView(new CameraMock());
        }

        private void initializeCommunicationServer(JoystickStateStore stateStore)
        {
            CommunicationServerMock comServer = new CommunicationServerMock(stateStore);
            RunInBackgroundThread(comServer.Serve);
            new RovStateReceivedHandler(comServer, (IPilotViewHandler)pilotView, (ICoPilotViewHandler)coPilotView);
        }

        private void initializeJoysticks()
        {
            initializePilotJoystick();
            initializeCoPilotRightJoystick();
        }

        private void initializeCoPilotRightJoystick()
        {
            pilotJoystick = new JoystickMock();
        }


        private void initializePilotJoystick()
        {
            coPilotRightJoystick = new JoystickMock();
        }

        private void RunInBackgroundThread(ThreadStart methodToRun)
        {
            Thread worker = new Thread(methodToRun);
            worker.IsBackground = true;
            worker.Start();
        }
    }
}
