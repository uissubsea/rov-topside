﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;

namespace UisSubsea.RovTopside.Data
{
    public class CameraFactory
    {
        private static Camera mainCamera;
        private static Camera manipulatorCamera;
        private static Camera rearCamera;

        public Camera CreateMainCamera(PictureBox canvas)
        {
            if (CameraFactory.mainCamera != null)
                return mainCamera;
            else return CameraFactory.mainCamera = 
                new Camera(getCameraIndex(Constants.LogitechC930eMoniker), 
                    Constants.DesiredResolution, canvas);
        }

        public Camera CreateManipulatorCamera(PictureBox canvas)
        {
            if (CameraFactory.manipulatorCamera != null)
                return manipulatorCamera;
            else return CameraFactory.manipulatorCamera = 
                new Camera(getCameraIndex(Constants.LogitechC920Moniker), 
                    Constants.DesiredResolution, canvas);
        }

        public Camera CreateRearCamera(PictureBox canvas)
        {
            if (CameraFactory.rearCamera != null)
                return rearCamera;
            else return CameraFactory.rearCamera = 
                new Camera(getCameraIndex(Constants.MicrosoftLifeCamMoniker), 
                    Constants.DesiredResolution, canvas);
        }

        private int getCameraIndex(String cameraMoniker)
        {
            FilterInfoCollection connectedCameras = Camera.CamerasConnected();
            for (int i = 0; i < connectedCameras.Count; i++)
            {
                String moniker = connectedCameras[i].MonikerString;
                String id = moniker.Substring(20, cameraMoniker.Length);
                if (id.Equals(cameraMoniker))
                    return i;
            }
            return -1;
        }
    }
}