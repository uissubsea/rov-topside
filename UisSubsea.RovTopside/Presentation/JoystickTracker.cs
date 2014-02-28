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
    public partial class JoystickTracker : Form
    {

        private Joystick joystick;
        private Joystick joystickManipulatorLeft;
        private Joystick joystickManipulatorRight;

        private int roll = 125;
        private int pitch = 125;
        private int yaw = 125;
        private int throttlePercentage = 0;
        private int pov = -1;
        private int numberOfJoysticksAttached = 0;

        //Create something we can draw with
        private Pen pen;
        private Brush whiteBrush;
        private Brush blackBrush;
        private Font font;

        private Boolean readyToSend;
        private Boolean manualSend;

        private MainPacketBuilder mainpacketbuilder;
        private Thread listener;
        private Thread comThread;

        public JoystickTracker()
        {
            InitializeComponent();

            pen = new Pen(Color.Black);
            whiteBrush = new SolidBrush(Color.White);
            blackBrush = new SolidBrush(Color.Black);
            font = new Font("Arial", 10);
        }

        private void ComPort_DataReceived(object sender, DataReceivedEventArgs args)
        {
            try
            {
                if (InvokeRequired)
                {
                    if (!this.IsDisposed)
                    {
                        this.Invoke(new Action(() => readRovState(args.Data)));
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
            foreach (byte b in data)
            {
                txtInput.AppendText((byte)b + " ");
            }
            txtInput.AppendText("\r\n");

            readyToSend = true;


        }

        private void refresh()
        {
            //Reverse
            if (joystick.Buttons()[9])
                mainpacketbuilder.ToggleReverse();


            //Capture stick Position.
            roll = joystick.Roll();
            pitch = joystick.Pitch();
            yaw = joystick.Yaw();
            throttlePercentage = joystick.Throttle();

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
            joystick = new Joystick(this.Handle, 0, 250);
            System.Threading.WaitHandle handle = new System.Threading.AutoResetEvent(false);

            joystick.Acquire(handle);

            mainpacketbuilder = new MainPacketBuilder(joystick);

            JoystickStateStore stateStore = new JoystickStateStore();

            JoystickStateListener interruptListener = new JoystickStateListener(joystick, mainpacketbuilder, stateStore);
            interruptListener.JoystickStateChanged += JoystickState_Changed;
            listener = new Thread(interruptListener.Listen);
            listener.IsBackground = true;
            listener.Start();

            CommunicationServer comServer = new CommunicationServer(stateStore);
            comServer.RovStateReceived += RovState_Received;
            comThread = new Thread(comServer.Serve);
            comThread.IsBackground = true;
            comThread.Start();

            //string[] ports = SerialPort.GetPortNames();
            //cmbAvailablePorts.DataSource = ports;

            //tmrRefreshStick.Enabled = true;
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
                            this.Invoke(new Action(() => refresh()));
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
            if (joystickManipulatorLeft != null)
                joystickManipulatorLeft.Unacquire();
            if (joystickManipulatorRight != null)
                joystickManipulatorRight.Unacquire();
        }
    }
}
