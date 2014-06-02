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
using System.IO.Ports;
using System.Threading;

namespace UisSubsea.RovTopside.Presentation
{
    /// <summary>
    /// Debug application to debug communication with the ROV
    /// as well as joystick input handeling.
    /// </summary>

    public partial class JoystickTrackerView : Form
    {
        private Joystick joystick;
        private Joystick joystick2;

        private int roll = 125;
        private int pitch = 125;
        private int yaw = 125;
        private int throttlePercentage = 0;
        private int pov = -1;

        //Create something we can draw with
        private Pen pen;
        private Brush whiteBrush;
        private Brush blackBrush;
        private Font font;

        private MainPacketBuilder mainpacketbuilder;
        private Thread listener;
        private Thread comThread;

        private Thread listener2;
        private ManipulatorRightPacketBuilder manipPacketBuilder;

        private JoystickStateStore stateStore;

        public JoystickTrackerView()
        {
            InitializeComponent();

            pen = new Pen(Color.Black);
            whiteBrush = new SolidBrush(Color.White);
            blackBrush = new SolidBrush(Color.Black);
            font = new Font("Arial", 10);
        }

        private void readRovState(byte[] data)
        {
            /*foreach (byte b in data)
            {
                txtInput.AppendText((byte)b + " ");
            }
            txtInput.AppendText("\r\n");*/

            string packet = "";

            foreach (byte b in data)
                packet += (byte)b + " ";

            txtInput.Text = packet;
        }

        private void readOutputData()
        {
            /*foreach (byte b in stateStore.Main)
                txtOutput.AppendText((byte)b + " ");

            txtOutput.AppendText("\r\n");*/
            string packet = "";

            foreach (byte b in stateStore.Main)
                packet += (byte)b + " ";

            txtOutput.Text = packet;
        }

        private void refresh()
        {
            //Reverse
            if (joystick.Buttons()[9])
                mainpacketbuilder.ToggleReverse();

            if (joystick.Buttons()[0])
            {
                // not implemented
            }             

            //Capture stick Position.
            roll = stateStore.Main[0];
            pitch = stateStore.Main[1];
            yaw = stateStore.Main[2];
            throttlePercentage = stateStore.Main[3];

            //Capture point-of-view hat
            pov = joystick.PointOfView();

            updateThrottleTracker();
            updateYawTracker();

            updateLabels();

            //Repaint the form
            this.Invalidate();
        }

        private void JoystickTracker_Load(object sender, EventArgs e)
        {
            joystick = new Joystick(this.Handle, 0, 250, JoystickType.MainController);
            System.Threading.WaitHandle waitHandle = new System.Threading.AutoResetEvent(false);
            joystick.Acquire(waitHandle);

            joystick2 = new Joystick(this.Handle, 0, 250, JoystickType.ManipulatorRight);
            System.Threading.WaitHandle waitHandle2 = new System.Threading.AutoResetEvent(false);
            joystick2.Acquire(waitHandle2);

            mainpacketbuilder = new MainPacketBuilder(joystick);
            manipPacketBuilder = new ManipulatorRightPacketBuilder(joystick2);

            stateStore = new JoystickStateStore();

            JoystickStateListener interruptListener = new JoystickStateListener(joystick, mainpacketbuilder, stateStore);
            interruptListener.JoystickStateChanged += JoystickState_Changed;
            listener = new Thread(interruptListener.Listen);
            listener.IsBackground = true;
            listener.Start();

            JoystickStateListener interruptListener2 = new JoystickStateListener(joystick2, manipPacketBuilder, stateStore);
            listener2 = new Thread(interruptListener2.Listen);
            listener2.IsBackground = true;
            listener2.Start();

            CommunicationServer comServer = new CommunicationServer(stateStore);
            comServer.RovStateReceived += RovState_Received;
            comThread = new Thread(comServer.Serve);
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
                        this.txtOutput.BeginInvoke(new MethodInvoker(delegate() { readOutputData(); }));
                        this.txtInput.BeginInvoke(new MethodInvoker(delegate() { readRovState(e.Data); }));               
                        return;
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                // NOT YET IMPLEMENTED
            }
        }

        private void JoystickState_Changed(object sender, EventArgs e)
        {
            if (joystick != null)
            {
                try
                {
                    if (InvokeRequired)
                    {
                        if (!this.IsDisposed)
                        {
                            this.Invoke(new MethodInvoker(delegate() { refresh(); }));
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

        protected override void OnPaint(PaintEventArgs pe)
        {
            //Paint the base before we do anything else
            base.OnPaint(pe);

            // get the graphics object
            Graphics g = pe.Graphics;

            drawJoystickPosition(g);
            drawPoV(g);
            drawButtons(g);
        }

        private void updateYawTracker()
        {
            //Update yaw tracker;
            if (yaw >= trkYaw.Minimum && yaw <= trkYaw.Maximum)
                trkYaw.Value = yaw;
        }

        private void updateThrottleTracker()
        {
            //Update throttle tracker
            if (throttlePercentage >= trkThrottle.Minimum && throttlePercentage <= trkThrottle.Maximum)
                trkThrottle.Value = throttlePercentage;
        }

        private void drawJoystickPosition(Graphics g)
        {
            //Joystick position
            g.FillRectangle(whiteBrush, 10, 10, 210, 210);
            g.DrawRectangle(pen, 10, 10, 210, 210);
            //210 / 250 = 0.8
            //That way we can map stick position into an square which is smaller than 250
            g.FillRectangle(blackBrush, (int)(10 + roll * 0.8), (int)(10 + pitch * 0.8), 10, 10);
        }

        private void drawPoV(Graphics g)
        {
            //Circles of PoV
            for (int i = 0; i < 8; i++)
            {
                int x = (int)(50 * Math.Cos(2 * Math.PI * i / 8));
                int y = (int)(50 * Math.Sin(2 * Math.PI * i / 8));
                g.DrawEllipse(pen, x + 400, y + 70, 20, 20);
            }

            //Fill the correct circle when PoV hat is not in center
            if (pov != -1)
            {
                int xPressed = (int)(50 * Math.Cos(2 * Math.PI * (pov / 45 - 2) / 8));
                int yPressed = (int)(50 * Math.Sin(2 * Math.PI * (pov / 45 - 2) / 8));
                g.FillEllipse(blackBrush, xPressed + 400, yPressed + 70, 20, 20);
            }
            else
            {
                //Fill center if PoV hat is not used
                g.FillEllipse(blackBrush, 400, 70, 20, 20);
            }
        }

        private void drawButtons(Graphics g)
        {
            bool[] buttons = joystick.Buttons();

            //Draw a maximum of 12 buttons
            //to prevent a lot of buttons never
            //used
            int numberOfButtonsToDraw;
            if (buttons.Length >= 12)
                numberOfButtonsToDraw = 12;
            else
                numberOfButtonsToDraw = buttons.Length;

            //Gauge for buttons.
            for (int i = 0; i < numberOfButtonsToDraw; i++)
            {
                //Highlight buttons that are pressed
                if (buttons[i])
                {
                    g.FillEllipse(blackBrush, (350 + i * 30), 200, 20, 20);
                    g.DrawString((i + 1).ToString(), font, whiteBrush, new PointF((353 + i * 30.0F), 203.0F));
                }
                else
                {
                    g.DrawEllipse(pen, (350 + i * 30), 200, 20, 20);
                    g.DrawString((i + 1).ToString(), font, blackBrush, new PointF((353 + i * 30.0F), 203.0F));
                }
            }
        }

        private void updateLabels()
        {
            lblRoll.Text = "Roll: " + roll;
            lblPitch.Text = "Pitch: " + pitch;
            lblYaw.Text = "Yaw: " + yaw;
            lblThrottle.Text = "Throttle: " + throttlePercentage;
        }

        private void JoystickTracker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (joystick != null)
                joystick.Unacquire();
        }
    }
}
