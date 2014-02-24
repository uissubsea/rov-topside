using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UisSubsea.RovTopside.Data;
using System.Threading;

namespace UisSubsea.RovTopside.Presentation
{
    public partial class PilotView : Form
    {
        private Joystick mainJoystick,leftJoystick, rightJoystick;
        private PacketBuilder mainPacketBuilder, leftPacketBuilder, rightPacketBuilder;
        private Font font;
        private Brush brush;
        private PointF pointRecordingText;
        private PointF pointFocusValue;
        private PointF pointAutoFocus;
        private PointF pointDataReceived;
        private PointF pointStopwatch;
        private string overlayText = "Not recording";
        private string lastPacketReceived = "0";
        private Boolean fullScreen = false;
        private Camera camera;
        private int focus;
        private Boolean autofocus = true;
        private System.Diagnostics.Stopwatch stopwatch;
        private CoPilotView copilotview;

        public PilotView()
        {
            font = new Font("Arial", 18);
            brush = new SolidBrush(Color.Red);
            pointRecordingText = new PointF(30.0f, 30.0f);            
            pointAutoFocus = new PointF(30.0f, 70.0f);
            pointFocusValue = new PointF(30.0f, 110.0f);
            pointDataReceived = new PointF(30.0f, 150.0f);
            pointStopwatch = new PointF(30.0f, 190.0f);
            stopwatch = new System.Diagnostics.Stopwatch();

            InitializeComponent();

            pictureBoxVideo.Paint += new PaintEventHandler(PaintOverlay);

            camera = CameraFactory.CreateMainCamera();
            camera.AddCanvas(pictureBoxVideo); 
            camera.Start();
        }
        public PictureBox pilotPictureBox()
        {
            return pictureBoxVideo;
        }

        private void PilotView_Load(object sender, EventArgs e)
        {
            initializeMainJoystick();
            initializeLeftJoystick(); 
            //inititalizeRightJoystick(); 
            JoystickStateStore stateStore = new JoystickStateStore();
            initializeMainJoystickStateListener(stateStore);
            initializeLeftJoystickStateListener(stateStore);
            initializeCommunicationServer(stateStore);

            //Initialize
            copilotview = new CoPilotView();
            copilotview.Show();
        }
        //Main joystick for the pilot
        private void initializeMainJoystick()
        {
            WaitHandle handle = new AutoResetEvent(false);
            mainJoystick = JoystickFactory.getMainController(this.Handle);
            mainJoystick.Acquire(handle);
        }
        //Left joystick for the CoPilot
        private void initializeLeftJoystick()
        {
            WaitHandle handle = new AutoResetEvent(false);
            leftJoystick = JoystickFactory.getManipulatorLeft(this.Handle);
            leftJoystick.Acquire(handle);
        }
        //Right joystick for the CoPilot
        private void inititalizeRightJoystick()
        {
            WaitHandle handle = new AutoResetEvent(false);
            rightJoystick = JoystickFactory.getManipulatorRight(this.Handle);
            rightJoystick.Acquire(handle);
        }

        private void initializeCommunicationServer(JoystickStateStore stateStore)
        {
            CommunicationServer comServer = new CommunicationServer(stateStore);
            comServer.RovStateReceived += RovState_Received;
            Thread comThread = new Thread(comServer.Serve);
            comThread.IsBackground = true;
            comThread.Start();
        } 

        private void initializeMainJoystickStateListener(JoystickStateStore stateStore)
        {
            mainPacketBuilder = new MainPacketBuilder(mainJoystick);         
            JoystickStateListener interruptListener = new JoystickStateListener(mainJoystick, mainPacketBuilder, stateStore);
            interruptListener.JoystickStateChanged += JoystickState_Changed;
            Thread listener = new Thread(interruptListener.Listen);
            listener.IsBackground = true;
            listener.Start();      
        }
        
        private void initializeLeftJoystickStateListener(JoystickStateStore statestore)
        {
            leftPacketBuilder = new ManipulatorLeftPacketBuilder(leftJoystick);
            JoystickStateListener interruptListener = new JoystickStateListener(leftJoystick, leftPacketBuilder, statestore);
            interruptListener.JoystickStateChanged += leftJoystickState_Changed;//Need more
            Thread listener = new Thread(interruptListener.Listen);
            listener.IsBackground = true;
            listener.Start();
        }

        private void JoystickState_Changed(object sender, EventArgs e)
        {

            if (mainJoystick != null)
            {
                try
                {
                    if (InvokeRequired)
                    {
                        if (!this.IsDisposed)
                        {
                            this.Invoke(new Action(() => toggleStopWatch()));
                            //this.Invoke(new Action(() => changeCoPilotView()));
                            return;
                        }
                    }
                }
                catch (ObjectDisposedException)
                {
                    // NOT YET IMPLEMENTED
                }
            }
        }
        public void leftJoystickState_Changed(object sender, EventArgs e)
            {
                if(leftJoystick != null)
                {
                    System.Diagnostics.Debug.WriteLine("joystick er ikke null");
                    try
                    {
                        if(InvokeRequired)
                        {
                            if(!this.IsDisposed)
                            {
                                this.Invoke(new Action(() => changeCoPilotView()));
                                return;
                            }
                        }
                    }
                    catch (ObjectDisposedException) { }
                }

            }
        
        private void toggleStopWatch()
        {
            if (mainJoystick.Buttons()[11])
            {
                if (stopwatch.IsRunning)
                    stopwatch.Stop();
                else
                    stopwatch.Start();
            }         
        }

        private void changeCoPilotView()
        {
            //if(leftJoystick.Buttons()[8])
             //   copilotview.changeToReversCam();
            
            //else 
            if(leftJoystick.Buttons()[9])
                copilotview.changePrecisionView();
            
           // else if(leftJoystick.Buttons()[10])           
           //     copilotview.changeView();          
        }

        private void RovState_Received(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (InvokeRequired)
                {
                    if (!this.IsDisposed)
                    {
                        this.Invoke(new Action(() => readRovState(e.Data)));
                        return;
                    }

                }
            }
            catch (ObjectDisposedException)
            {
                // NOT YET IMPLEMENTED
            }
        }

        private void readRovState(byte[] data)
        {
            String packet = "";
            foreach (byte b in data)
            {
                packet += (byte)b + " ";
            }
            lastPacketReceived = packet;
        }

        private void PaintOverlay(object sender, PaintEventArgs args)
        {
            args.Graphics.DrawString(overlayText, font, brush, pointRecordingText);
            args.Graphics.DrawString("Autofocus: " + autofocus.ToString(), font, brush, pointAutoFocus);
            args.Graphics.DrawString("Focus value: " + focus.ToString(), font, brush, pointFocusValue);
            args.Graphics.DrawString("ROV state: " + lastPacketReceived, font, brush, pointDataReceived);

            TimeSpan span = stopwatch.Elapsed;
            String stopwatchString = string.Format("{0}:{1}", Math.Floor(span.TotalMinutes), span.ToString("ss"));
            args.Graphics.DrawString("Timer: " + stopwatchString, font, brush, pointStopwatch);
        }

        private void PilotView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (camera != null)
                camera.Dispose();

            try
            {
                copilotview.Close();
            }
            catch (Exception) {}
           
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            else if (keyData == Keys.F11)
            {
                if (!fullScreen)
                {
                    fullScreen = true;
                    this.WindowState = FormWindowState.Normal;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    fullScreen = false;
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Normal;
                }
            }
            else if (keyData == Keys.S)
            {
                camera.Snapshot();
            }
            else if (keyData == Keys.V)
            {
                camera.ToggleRecording();
                if (camera.IsRecording)
                    overlayText = "Recording";
                else
                    overlayText = "Not recording";
            }
            else if (keyData == Keys.Up)
            {
                if (autofocus)
                    autofocus = false;

                if (focus < 40)
                {
                    focus++;
                    camera.SetFocus(focus);
                }
            }
            else if (keyData == Keys.Down)
            {
                if (focus > 0)
                {
                    focus--;
                    camera.SetFocus(focus);
                }
            }
            else if (keyData == Keys.A)
            {
                autofocus = true;
                focus = 0;
                camera.AutoFocus();
            }              

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
