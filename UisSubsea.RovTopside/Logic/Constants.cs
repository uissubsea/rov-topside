﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UisSubsea.RovTopside.Data
{
    /// <summary>
    /// This class holds the constants that will be used
    /// by some of the components in the application.
    /// </summary>

    public static class Constants
    {
        /**
         * These are the values we agreed to use to
         * mark the beginning and the end of a packet.
         * */
        public const byte StartByte = 255;
        public const byte StopByte = 251;

        /**
         * Size of ROV state packet.
         * Start and stop byte included.
         * */
        public const int InputBufferSize = 5;

        /**
         * Number of bytes needed to describe state of
         * one joystick.
         * Start and stop byte not included!
         * */
        public const int JoystickStatePacketSize = 6;

        /**
         * The frame resolution we want our cameras to provide us with.
         * */
        public static Size DesiredResolution = new Size(1280, 720);

        /**
         * One main controller to control the ROV
         * and two to control the manipulator arm.
         * */
        public const int NumberOfJoysticksNeeded = 2;

        /**
         * One tiltable camera on top of the ROV,
         * one close to the manipulator arm and
         * one rear facing camera.
         * */
        public const int NumberOfCamerasNeeded = 3;

        /**
         * Buffer capacity needed to hold one joystick state
         * packet. These are the packets beeing sent to the
         * ROV.
         * */
        public const int OutputBufferSize = JoystickStatePacketSize * NumberOfJoysticksNeeded;

        /*
         * These strings will be used to identify the cameras that
         * are connected. Use these in camera factory to initialize 
         * the correct cameras.
         * */
        public const string MicrosoftLifeCamMoniker = "vid_045e&pid_0772&mi_00#7";
        public const string LogitechC930eMonikerRear = "vid_046d&pid_0843&mi_00#7&1fddb";
        public const string LogitechC920Moniker = "vid_046d&pid_082d&mi_00#6&3eda";
        public const string LogitechC930eMonikerFront = "vid_046d&pid_0843&mi_00#7&313bb";

        /*
         * These strings will be used to identify the joysticks that
         * are conncected. We use Instance guid because product guid
         * is not unic for the same type of joystick
         * */
        public const string LogitechExtreme3DProGuid = "8e25a690";
        public const string Logitechextreme3DProManipulatorGuid = "132e2630";

        public static byte[] InitializationPacket = {
                                                       StartByte, 
                                                       125, 
                                                       125,
                                                       125,
                                                       125,
                                                       0,
                                                       0,
                                                       125,
                                                       125,
                                                       125,
                                                       0,
                                                       0,
                                                       StopByte
                                                   };
        
       /*
        * These int's will be used to set fullscreen to spesific screens.
        * */ 
        public const int PilotScreen = 0;
        public const int CoPilotScreen = 1;
    }
    
    
}
