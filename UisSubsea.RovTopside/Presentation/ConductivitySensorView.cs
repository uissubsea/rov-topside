using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
namespace UisSubsea.RovTopside.Presentation
{
    public partial class ConductivitySensorView : Form
    {
        private SerialPort port;
        private Thread worker;

        public ConductivitySensorView()
        {
            InitializeComponent();
        }

        private void SerialCommunicationView_Load(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            cmbPorts.DataSource = ports;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cmbPorts.SelectedIndex > -1)
            {
                Connect(cmbPorts.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Please select a port first");
            }
        }

        private void Connect(string portName)
        {
            if (cmbPorts.Enabled == true)
            {
                port = new SerialPort(portName);
                if (!port.IsOpen)
                {
                    port.BaudRate = 38400;
                    port.DataBits = 8;
                    port.StopBits = StopBits.One;
                    port.Parity = Parity.None;
                    port.Open();
                    RunInBackgroundThread(readUntilCarriageReturn);

                    btnConnect.Text = "Disconnect";
                    cmbPorts.Enabled = false;
                    lblPorts.Enabled = false;
                    txtCommand.Enabled = true;
                    btnSend.Enabled = true;
                    grpCalibration.Enabled = true;
                    grpOperational.Enabled = true;
                    btnClear.Enabled = true;
                }
            }
            else
            {
                worker.Abort();
                port.Close();
                btnConnect.Text = "Connect";
                cmbPorts.Enabled = true;
                lblPorts.Enabled = true;
                txtCommand.Enabled = false;
                btnSend.Enabled = false;
                grpCalibration.Enabled = false;
                grpOperational.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sendCommand(txtCommand.Text);
            txtCommand.Clear();
        }

        private void sendCommand(string command)
        {
            byte[] array = Encoding.ASCII.GetBytes(command + "\r");
            port.Write(array, 0, array.Length);
        }

        private void ConductivitySensorView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (port != null)
            {
                if (port.IsOpen)
                    port.Close();
            }
        }

        private void readUntilCarriageReturn()
        {
            List<byte> asciiList = new List<byte>();

            while (true)
            {
                try
                {
                    byte indata = (byte)port.ReadByte();
                    asciiList.Add(indata);

                    //ASCII 13 is equal to carriage return
                    if (indata == 13)
                    {
                        string dataString = System.Text.Encoding.ASCII.GetString(asciiList.ToArray());

                        txtDataReceived.Invoke(new MethodInvoker(delegate
                        {
                            txtDataReceived.AppendText(dataString + "\r\n\r\n");
                        }));

                        asciiList.Clear();
                    }
                }
                catch (ThreadAbortException)
                {
                    //Not yet implemented
                }
            }
        }

        private void RunInBackgroundThread(ThreadStart methodToRun)
        {
            worker = new Thread(methodToRun);
            worker.IsBackground = true;
            worker.Start();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnSend.PerformClick();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnL1_Click(object sender, EventArgs e)
        {
            sendCommand("L1");
        }

        private void btnL0_Click(object sender, EventArgs e)
        {
            sendCommand("L0");
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            sendCommand("R");
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            sendCommand("C");
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            sendCommand("E");
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            sendCommand("X");
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            sendCommand("I");
        }

        private void btnProbe_Click(object sender, EventArgs e)
        {
            sendCommand("P,3");
        }

        private void btnDry_Click(object sender, EventArgs e)
        {
            sendCommand("Z0");
        }

        private void btnHigh_Click(object sender, EventArgs e)
        {
            sendCommand("Z90");
        }

        private void btnLow_Click(object sender, EventArgs e)
        {
            sendCommand("Z62");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDataReceived.Clear();
        }
    }
}
