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
        private Joystick mainJoystick;
        private PacketBuilder mainPacketBuilder;
        private Font font;
        private Brush brush;
        private PointF pointRecordingText;
        private PointF pointFocusValue;
        private PointF pointAutoFocus;
        private PointF pointDataReceived;
        private string overlayText = "Not recording";
        private string lastPacketReceived = "0";
        private Boolean fullScreen = false;
        private Camera camera;
        private int focus;
        private Boolean autofocus = true;

        public PilotView()
        {
            font = new Font("Arial", 18);
            brush = new SolidBrush(Color.Red);
            pointRecordingText = new PointF(30.0F, 30.0F);            
            pointAutoFocus = new PointF(30.0f, 70.0f);
            pointFocusValue = new PointF(30.0f, 110.0F);
            pointDataReceived = new PointF(30.0f, 150.0F);

            InitializeComponent();

            pictureBoxVideo.Paint += new PaintEventHandler(PaintOverlay);

            camera = new Camera(1, new Size(1280, 720), pictureBoxVideo);
            camera.Start();
        }

        private void PilotView_Load(object sender, EventArgs e)
        {
            mainJoystick = JoystickFactory.getMainController(this.Handle);
            System.Threading.WaitHandle handle = new System.Threading.AutoResetEvent(false);

            mainJoystick.Acquire(handle);

            mainPacketBuilder = new MainPacketBuilder(mainJoystick);

            JoystickStateHolder stateStore = new JoystickStateHolder();

            InterruptListener interruptListener = new InterruptListener(handle, mainPacketBuilder, stateStore);
            //interruptListener.JoystickStateChanged += JoystickState_Changed;
            Thread listener = new Thread(interruptListener.Listen);
            listener.IsBackground = true;
            listener.Start();

            CommunicationServer comServer = new CommunicationServer(stateStore);
            comServer.RovStateReceived += RovState_Received;
            Thread comThread = new Thread(comServer.Serve);
            comThread.IsBackground = true;
            comThread.Start();
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
        }

        private void PilotView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (camera != null)
                camera.Dispose();
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
