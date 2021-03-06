﻿using System;
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
    /// <summary>
    /// The applications main controller. 
    /// All the components are initialized and tied together here.
    /// </summary>

    public class MainController
    {
        public Form pilotView;
        private Form coPilotView;
        private IJoystick pilotJoystick;
        private IJoystick coPilotRightJoystick;
        private PilotActionsController pilotActionsController;
        private CoPilotActionsController coPilotActionsController;
        private IJoystickStateListener pilotStickListener, coPilotRightStickListener;
        private ICameraHandler cameraController;

        public MainController()
        {
            initializeComponents();
        }

        private void initializeComponents()
        {
            initializeViews();

            initializeJoysticks();
            JoystickStateStore stateStore = new JoystickStateStore();
            initializeJoystickListeners(stateStore);

            initializeCameraController();

            initializeTopSideActionsControllers();

            initializeCommunicationServer(stateStore);

            pilotView.Show();
            coPilotView.Show();

            SerialPortSingleton.Instance.Write(Constants.InitializationPacket,
                0, Constants.InitializationPacket.Length);
        }

        private void initializeViews()
        {
            pilotView = new PilotView(CameraFactory.GetMainCamera(), new HeadUpDisplay(Color.Red));
            ((IView)pilotView).SetFullScreen(Constants.PilotScreen);

            coPilotView = new CoPilotView(CameraFactory.GetManipulatorCamera());
            ((IView)coPilotView).SetFullScreen(Constants.CoPilotScreen);
        }

        private void initializeCameraController()
        {
            cameraController = new CameraController((IView)pilotView, (IView)coPilotView,
                CameraFactory.GetMainCamera(), CameraFactory.GetManipulatorCamera(), CameraFactory.GetRearCamera());
        }

        private void initializeTopSideActionsControllers()
        {
            pilotActionsController = new PilotActionsController(pilotStickListener, cameraController, (IPilotViewHandler)pilotView);
            coPilotActionsController = new CoPilotActionsController(coPilotRightStickListener, cameraController, (ICoPilotViewHandler)coPilotView);
        }

        private void initializeCommunicationServer(JoystickStateStore stateStore)
        {
            ICommunicationServer comServer = new CommunicationServer(stateStore);
            RunInBackgroundThread(comServer.Serve);
            new RovStateReceivedHandler(comServer, (IPilotViewHandler)pilotView, (ICoPilotViewHandler)coPilotView);
        }

        private void initializeJoystickListeners(JoystickStateStore stateStore)
        {
            initializePilotJoystickListener(stateStore);
            initializeCoPilotRightJoystickListener(stateStore);
        }

        private void initializeCoPilotRightJoystickListener(JoystickStateStore stateStore)
        {
            ManipulatorRightPacketBuilder rightPacketBuilder =
                new ManipulatorRightPacketBuilder(coPilotRightJoystick);
            coPilotRightStickListener = new JoystickStateListener(coPilotRightJoystick,
                rightPacketBuilder, stateStore);

            RunInBackgroundThread(coPilotRightStickListener.Listen);
        }


        private void initializePilotJoystickListener(JoystickStateStore stateStore)
        {
            MainPacketBuilder mainPacketBuilder = new MainPacketBuilder(pilotJoystick);
            pilotStickListener = new JoystickStateListener(pilotJoystick,
                mainPacketBuilder, stateStore);

            RunInBackgroundThread(pilotStickListener.Listen);
        }

        private void initializeJoysticks()
        {
            initializePilotJoystick();
            initializeCoPilotRightJoystick();
        }

        private void initializeCoPilotRightJoystick()
        {
            WaitHandle handle = new AutoResetEvent(false);
            pilotJoystick = JoystickFactory.GetMainController(pilotView.Handle);
            pilotJoystick.Acquire(handle);
        }

        private void initializePilotJoystick()
        {
            WaitHandle handle = new AutoResetEvent(false);
            coPilotRightJoystick = JoystickFactory.GetManipulatorRight(pilotView.Handle);
            coPilotRightJoystick.Acquire(handle);
        }

        private void RunInBackgroundThread(ThreadStart methodToRun)
        {
            Thread worker = new Thread(methodToRun);
            worker.IsBackground = true;
            worker.Start();
        }
    }
}
