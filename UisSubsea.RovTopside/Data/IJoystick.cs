using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    /// <summary>
    /// Joystick interface.
    /// </summary>
 
    public interface IJoystick
    {
        /// <summary>
        /// Throttle slider.
        /// </summary>
        /// <returns>Returns the position of the
        /// throttle slider.</returns>
        int Throttle();

        /// <summary>
        /// Y-axis of the joystick.
        /// </summary>
        /// <returns>The position of the joystick
        /// along the Y-axis.</returns>
        int Pitch();

        /// <summary>
        /// X-axis of the joystick.
        /// </summary>
        /// <returns>The position of the joystick
        /// along the X-axis.</returns>
        int Roll();

        /// <summary>
        /// Z-axis of the joystick.
        /// </summary>
        /// <returns>The position of the secondary slider.</returns>
        int Slider();

        /// <summary>
        /// Rz-axis of the joystick.
        /// </summary>
        /// <returns>The rotation of the joystick around
        /// the Z-axis.</returns>
        int Yaw();

        /// <summary>
        /// Lets you determine which buttons are pressed
        /// on the joystick. Several buttons can be 
        /// pressed at once.
        /// </summary>
        /// <returns>An array representation of which
        /// buttons are pressed. The index represents the
        /// number of the button and the value says whether it
        /// is pressed or not. If the value is true, the button
        /// is pressed.</returns>
        bool[] Buttons();

        /// <summary>
        /// The PoV (point-of-view) hat on the joystick.
        /// </summary>
        /// <returns>A value from 0-359 which represents the
        /// angle / direction that the hat is pushed.</returns>
        int PointOfView();

        /// <summary>
        /// Type property.
        /// </summary>
        JoystickType Type
        {
            get;
        }
    }
}