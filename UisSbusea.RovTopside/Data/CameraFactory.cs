using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UisSubsea.RovTopside.Data
{
    class CameraFactory
    {

        private static Camera mainCamera;
        private static Camera manipulatorCamera;
        private static Camera rearCamera;

        public Camera CreateMainCamera(PictureBox canvas)
        {
            if (CameraFactory.mainCamera != null)
                return mainCamera;
            else return CameraFactory.mainCamera = new Camera(0, Constants.DesiredResolution, canvas);
        }

        public Camera CreateManipulatorCamera(PictureBox canvas)
        {
            if (CameraFactory.manipulatorCamera != null)
                return manipulatorCamera;
            else return CameraFactory.manipulatorCamera = new Camera(1, Constants.DesiredResolution, canvas);
        }

        public Camera CreateRearCamera(PictureBox canvas)
        {
            if (CameraFactory.rearCamera != null)
                return rearCamera;
            else return CameraFactory.rearCamera = new Camera(2, Constants.DesiredResolution, canvas);
        }
    }
}
