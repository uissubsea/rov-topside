using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UisSubsea.RovTopside.Presentation;
using UisSubsea.RovTopside.Data;

namespace UisSubsea.RovTopside.Logic
{
    class CameraController : ICameraHandler
    {
        private ICamera mainCamera, manipulatorCamera, rearCamera;
        private IView pilotView, coPilotView;

        public CameraController(IView pilotView, IView coPilotView, ICamera mainCamera,
            ICamera manipulatorCamera, ICamera rearCamera)
        {
            this.pilotView = pilotView;
            this.coPilotView = coPilotView;
            this.mainCamera = mainCamera;
            this.manipulatorCamera = manipulatorCamera;
            this.rearCamera = rearCamera;
        }

        public void ToggleRecording()
        {
            pilotView.GetCamera().ToggleRecording();
            coPilotView.GetCamera().ToggleRecording();
        }
        
        public void Snapshot()
        {
            pilotView.GetCamera().Snapshot();
            coPilotView.GetCamera().Snapshot();
        }

        public void ChangePilotCamera()
        {
            if(pilotView.GetCamera().Equals(mainCamera))
            { 
                if(coPilotView.GetCamera().Equals(rearCamera))                             
                    setCamera(coPilotView, manipulatorCamera);

                setCamera(pilotView, rearCamera);

                /*if (pilotView.GetCamera().Equals(rearCamera))
                {
                    setCamera(pilotView, rearCamera);
                    System.Diagnostics.Debug.WriteLine("gggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");
                }

                if(pilotView.GetCamera().HandleEvents())
                    System.Diagnostics.Debug.WriteLine("jjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj");
                 */
            }
            else
            {
                setCamera(pilotView,mainCamera);
            }           
        }

        public void ChangeCoPilotCamera()
        {
            if (coPilotView.GetCamera().Equals(manipulatorCamera))
            {
                if (pilotView.GetCamera().Equals(rearCamera))
                    return;

                setCamera(coPilotView,rearCamera);
            }
            else
            {
                setCamera(coPilotView, manipulatorCamera);
            }           
        }
        
        private void setCamera(IView view, ICamera camera)
        {
            if (view.GetCamera().IsRecording)
            {
                view.GetCamera().ToggleRecording();
                view.SetCamera(camera);
                view.GetCamera().ToggleRecording();
            }
            else
                view.SetCamera(camera);
        }
    }
}
