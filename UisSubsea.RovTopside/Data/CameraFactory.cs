using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using UisSubsea.RovTopside.Logic;

namespace UisSubsea.RovTopside.Data
{
    public class CameraFactory
    {
        private static ICamera mainCamera;
        private static ICamera manipulatorCamera;
        private static ICamera rearCamera;

        public static ICamera GetMainCamera()
        {
            if (CameraFactory.mainCamera != null)
                return mainCamera;
            else return CameraFactory.mainCamera = 
                new Camera(getCameraIndex(Constants.LogitechC930eMonikerFront), 
                    Constants.DesiredResolution);
        }

        public static ICamera GetManipulatorCamera()
        {
            if (CameraFactory.manipulatorCamera != null)
                return manipulatorCamera;
            else return CameraFactory.manipulatorCamera = 
                new Camera(getCameraIndex(Constants.LogitechC920Moniker), 
                    Constants.DesiredResolution);
        }

        public static ICamera GetRearCamera()
        {
            if (CameraFactory.rearCamera != null)
                return rearCamera;
            else return CameraFactory.rearCamera = 
                new Camera(getCameraIndex(Constants.LogitechC930eMonikerRear), 
                    Constants.DesiredResolution);
        }

        public static void DisposeAll()
        {
            if (CameraFactory.mainCamera != null)
                CameraFactory.mainCamera.Dispose();
            if (CameraFactory.manipulatorCamera != null)
                CameraFactory.manipulatorCamera.Dispose();
            if (CameraFactory.rearCamera != null)
                CameraFactory.rearCamera.Dispose();
        }

        private static  int getCameraIndex(string cameraMoniker)
        {
            FilterInfoCollection connectedCameras = Camera.CamerasConnected();
            for (int i = 0; i < connectedCameras.Count; i++)
            {
                string moniker = connectedCameras[i].MonikerString;
                string id = moniker.Substring(20, cameraMoniker.Length);
                if (id.Equals(cameraMoniker))
                    return i;
            }
            return -1;
        }
    }
}
