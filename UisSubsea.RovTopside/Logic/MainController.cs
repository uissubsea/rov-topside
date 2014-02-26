﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UisSubsea.RovTopside.Data;
using UisSubsea.RovTopside.Presentation;
using System.Threading;
using System.Windows.Forms;

namespace UisSubsea.RovTopside.Logic
{
    public class MainController
    {
        private Form pilotView;
        private Form coPilotView;
        private Joystick pilotJoystick;
        private Joystick coPilotLeftJoystick;
        private Joystick coPilotRightJoystick;
        private TopSideJoystickActionController topSideActionController;
        private JoystickStateListener pilotStickListener, coPilotLeftStickListener, coPilotRightStickListener;
        private ICameraHandler cameraController;

        public MainController()
        {
            initializeComponents();
        }

        private void initializeComponents()
        {
            pilotView = new PilotView(CameraFactory.GetMainCamera());
            coPilotView = new CoPilotView(CameraFactory.GetManipulatorCamera());

            initializeJoysticks();
            JoystickStateStore stateStore = new JoystickStateStore();
            initializeJoystickListeners(stateStore);

            cameraController = new CameraController((IView)pilotView, (IView)coPilotView,
                CameraFactory.GetMainCamera(), CameraFactory.GetManipulatorCamera(), CameraFactory.GetRearCamera());

            topSideActionController = new TopSideJoystickActionController(pilotStickListener,
                coPilotLeftStickListener, coPilotRightStickListener, cameraController,
                (ICoPilotViewHandler)coPilotView, (IOverlayHandler)pilotView);

            initializeCommunicationServer(stateStore);

            pilotView.Show();
            coPilotView.Show();
        }

        private void initializeCommunicationServer(JoystickStateStore stateStore)
        {
            CommunicationServer comServer = new CommunicationServer(stateStore);
            Thread comThread = new Thread(comServer.Serve);
            comThread.IsBackground = true;
            comThread.Start();
            //new RovStateReceivedHandler(comServer, (IOverlayHandler)pilotView, );
        }

        private void initializeJoystickListeners(JoystickStateStore stateStore)
        {
            initializePilotJoystickListener(stateStore);
            initializeCoPilotLeftJoystickListener(stateStore);
            initializeCoPilotRightJoystickListener(stateStore);
        }

        private void initializeCoPilotRightJoystickListener(JoystickStateStore stateStore)
        {
            ManipulatorRightPacketBuilder rightPacketBuilder =
                new ManipulatorRightPacketBuilder(coPilotRightJoystick);
            JoystickStateListener stateListener = new JoystickStateListener(coPilotRightJoystick,
                rightPacketBuilder, stateStore);

            RunInBackgroundThread(stateListener.Listen);
        }

        private void initializeCoPilotLeftJoystickListener(JoystickStateStore stateStore)
        {
            ManipulatorLeftPacketBuilder leftPacketBuilder =
                new ManipulatorLeftPacketBuilder(coPilotLeftJoystick);
            JoystickStateListener stateListener = new JoystickStateListener(coPilotLeftJoystick,
                leftPacketBuilder, stateStore);

            RunInBackgroundThread(stateListener.Listen);
        }

        private void initializePilotJoystickListener(JoystickStateStore stateStore)
        {
            MainPacketBuilder mainPacketBuilder = new MainPacketBuilder(pilotJoystick);
            JoystickStateListener stateListener = new JoystickStateListener(pilotJoystick,
                mainPacketBuilder, stateStore);

            RunInBackgroundThread(stateListener.Listen);
            //new JoystickStateChangedListener(stateListener); 
        }

        private void initializeJoysticks()
        {
            initializePilotJoystick();
            initializeCoPilotLeftJoystick();
            initializeCoPilotRightJoystick();
        }

        private void initializeCoPilotRightJoystick()
        {
            WaitHandle handle = new AutoResetEvent(false);
            pilotJoystick = JoystickFactory.GetMainController(pilotView.Handle);
            pilotJoystick.Acquire(handle);
        }

        private void initializeCoPilotLeftJoystick()
        {
            WaitHandle handle = new AutoResetEvent(false);
            coPilotLeftJoystick = JoystickFactory.GetManipulatorLeft(pilotView.Handle);
            coPilotLeftJoystick.Acquire(handle);
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
