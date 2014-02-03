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

        private StateSender stateSender;
        private StateReceiver stateReceiver;

        private Boolean readyToSend;
        private Boolean manualSend;

        private MainPacketBuilder mainpacketbuilder;

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

        private void writeState()
        {
            if (stateSender != null)
            {
                byte[] data = stateSender.WriteState();
                foreach (byte b in data)
                {
                    txtOutput.AppendText((byte)b + " ");
                }
                txtOutput.AppendText("\r\n");
            }
        }

        private void refresh()
        {
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

            if (readyToSend && !manualSend)
                writeState();


            //Repaint the form
            this.Invalidate();
        }

        private void tmrRefreshStick_Tick(object sender, EventArgs e)
        {
            refresh();
        }

        private void JoystickTracker_Load(object sender, EventArgs e)
        {
            joystick = JoystickFactory.getMainController(this.Handle);
            joystick.Acquire();


            string[] ports = SerialPort.GetPortNames();
            cmbAvailablePorts.DataSource = ports;

            tmrRefreshStick.Enabled = true;
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
            //Check for reverse button
            if (buttons[9])
            {
                mainpacketbuilder.ToggleReverse();
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
            tmrRefreshStick.Stop();
            stateReceiver.DataReceived -= ComPort_DataReceived;

            if (joystick != null)
                joystick.Unacquire();
            if (joystickManipulatorLeft != null)
                joystickManipulatorLeft.Unacquire();
            if (joystickManipulatorRight != null)
                joystickManipulatorRight.Unacquire();

            //System.Threading.Thread.Sleep(1000);
           // SerialPortSingleton.Instance.Close();                        
        }

        private void btnUsePort_Click(object sender, EventArgs e)
        {
            try
            {
                String port = cmbAvailablePorts.SelectedItem.ToString();
                numberOfJoysticksAttached = Joystick.getNumberOfJoysticks();

                if (numberOfJoysticksAttached == 3)
                {
                    joystickManipulatorLeft = JoystickFactory.getManipulatorLeft(this.Handle);
                    joystickManipulatorRight = JoystickFactory.getManipulatorRight(this.Handle);

                    joystickManipulatorLeft.Acquire();
                    joystickManipulatorRight.Acquire();
                }


                if (!String.IsNullOrEmpty(port))
                {
                    List<PacketBuilder> pb = new List<PacketBuilder>();
                    mainpacketbuilder = new MainPacketBuilder(joystick);

                    pb.Add(mainpacketbuilder);

                    if (numberOfJoysticksAttached == 3)
                    {
                        pb.Add(new ManipulatorLeftPacketBuilder(joystickManipulatorLeft));
                        pb.Add(new ManipulatorRightPacketBuilder(joystickManipulatorRight));

                    }


                    stateSender = new StateSender(pb);
                    btnUsePort.Enabled = false;

                    stateReceiver = new StateReceiver();
                    stateReceiver.DataReceived += ComPort_DataReceived;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No compatible device found!");

            }

        }

        private void JoystickTracker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && readyToSend && manualSend)
                writeState();
        }

        private void chkManualSend_CheckedChanged(object sender, EventArgs e)
        {
            manualSend = chkManualSend.Checked;
        }



    }
}
