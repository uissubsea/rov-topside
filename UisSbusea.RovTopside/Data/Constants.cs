﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UisSubsea.RovTopside.Data
{

    /**
     * This class holds the constants that will be used
     * by all of the components in the application.
     * */

    public class Constants
    {
        /**
         * These are the values we agreed to use to
         * mark the beginning and end of a packet.
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
        public const int NumberOfJoysticksNeeded = 3;

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
    }
}