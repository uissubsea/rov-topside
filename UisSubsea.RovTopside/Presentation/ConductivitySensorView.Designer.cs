namespace UisSubsea.RovTopside.Presentation
{
    partial class ConductivitySensorView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.lblCommand = new System.Windows.Forms.Label();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtDataReceived = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblPorts = new System.Windows.Forms.Label();
            this.lblDataReceived = new System.Windows.Forms.Label();
            this.grpCalibration = new System.Windows.Forms.GroupBox();
            this.btnLow = new System.Windows.Forms.Button();
            this.btnHigh = new System.Windows.Forms.Button();
            this.btnDry = new System.Windows.Forms.Button();
            this.btnProbe = new System.Windows.Forms.Button();
            this.grpOperational = new System.Windows.Forms.GroupBox();
            this.btnI = new System.Windows.Forms.Button();
            this.btnX = new System.Windows.Forms.Button();
            this.btnR = new System.Windows.Forms.Button();
            this.btnL0 = new System.Windows.Forms.Button();
            this.btnE = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnL1 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpCalibration.SuspendLayout();
            this.grpOperational.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCommand
            // 
            this.txtCommand.Enabled = false;
            this.txtCommand.Location = new System.Drawing.Point(12, 279);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(121, 20);
            this.txtCommand.TabIndex = 0;
            // 
            // lblCommand
            // 
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(12, 263);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(54, 13);
            this.lblCommand.TabIndex = 1;
            this.lblCommand.Text = "Command";
            // 
            // cmbPorts
            // 
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(12, 32);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(121, 21);
            this.cmbPorts.TabIndex = 2;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(139, 30);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtDataReceived
            // 
            this.txtDataReceived.BackColor = System.Drawing.Color.White;
            this.txtDataReceived.Location = new System.Drawing.Point(12, 90);
            this.txtDataReceived.Multiline = true;
            this.txtDataReceived.Name = "txtDataReceived";
            this.txtDataReceived.ReadOnly = true;
            this.txtDataReceived.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDataReceived.Size = new System.Drawing.Size(202, 160);
            this.txtDataReceived.TabIndex = 4;
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(139, 277);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblPorts
            // 
            this.lblPorts.AutoSize = true;
            this.lblPorts.Location = new System.Drawing.Point(12, 13);
            this.lblPorts.Name = "lblPorts";
            this.lblPorts.Size = new System.Drawing.Size(76, 13);
            this.lblPorts.TabIndex = 6;
            this.lblPorts.Text = "Available ports";
            // 
            // lblDataReceived
            // 
            this.lblDataReceived.AutoSize = true;
            this.lblDataReceived.Location = new System.Drawing.Point(12, 71);
            this.lblDataReceived.Name = "lblDataReceived";
            this.lblDataReceived.Size = new System.Drawing.Size(74, 13);
            this.lblDataReceived.TabIndex = 7;
            this.lblDataReceived.Text = "Data received";
            // 
            // grpCalibration
            // 
            this.grpCalibration.Controls.Add(this.btnLow);
            this.grpCalibration.Controls.Add(this.btnHigh);
            this.grpCalibration.Controls.Add(this.btnDry);
            this.grpCalibration.Controls.Add(this.btnProbe);
            this.grpCalibration.Enabled = false;
            this.grpCalibration.Location = new System.Drawing.Point(220, 90);
            this.grpCalibration.Name = "grpCalibration";
            this.grpCalibration.Size = new System.Drawing.Size(137, 160);
            this.grpCalibration.TabIndex = 8;
            this.grpCalibration.TabStop = false;
            this.grpCalibration.Text = "Calibration commands";
            // 
            // btnLow
            // 
            this.btnLow.Location = new System.Drawing.Point(6, 106);
            this.btnLow.Name = "btnLow";
            this.btnLow.Size = new System.Drawing.Size(75, 23);
            this.btnLow.TabIndex = 3;
            this.btnLow.Text = "Low (Z62)";
            this.btnLow.UseVisualStyleBackColor = true;
            this.btnLow.Click += new System.EventHandler(this.btnLow_Click);
            // 
            // btnHigh
            // 
            this.btnHigh.Location = new System.Drawing.Point(6, 77);
            this.btnHigh.Name = "btnHigh";
            this.btnHigh.Size = new System.Drawing.Size(75, 23);
            this.btnHigh.TabIndex = 2;
            this.btnHigh.Text = "High (Z90)";
            this.btnHigh.UseVisualStyleBackColor = true;
            this.btnHigh.Click += new System.EventHandler(this.btnHigh_Click);
            // 
            // btnDry
            // 
            this.btnDry.Location = new System.Drawing.Point(6, 48);
            this.btnDry.Name = "btnDry";
            this.btnDry.Size = new System.Drawing.Size(75, 23);
            this.btnDry.TabIndex = 1;
            this.btnDry.Text = " Dry (Z0)";
            this.btnDry.UseVisualStyleBackColor = true;
            this.btnDry.Click += new System.EventHandler(this.btnDry_Click);
            // 
            // btnProbe
            // 
            this.btnProbe.Location = new System.Drawing.Point(6, 19);
            this.btnProbe.Name = "btnProbe";
            this.btnProbe.Size = new System.Drawing.Size(75, 23);
            this.btnProbe.TabIndex = 0;
            this.btnProbe.Text = "Probe (K10)";
            this.btnProbe.UseVisualStyleBackColor = true;
            this.btnProbe.Click += new System.EventHandler(this.btnProbe_Click);
            // 
            // grpOperational
            // 
            this.grpOperational.Controls.Add(this.btnI);
            this.grpOperational.Controls.Add(this.btnX);
            this.grpOperational.Controls.Add(this.btnR);
            this.grpOperational.Controls.Add(this.btnL0);
            this.grpOperational.Controls.Add(this.btnE);
            this.grpOperational.Controls.Add(this.btnC);
            this.grpOperational.Controls.Add(this.btnL1);
            this.grpOperational.Enabled = false;
            this.grpOperational.Location = new System.Drawing.Point(363, 90);
            this.grpOperational.Name = "grpOperational";
            this.grpOperational.Size = new System.Drawing.Size(179, 160);
            this.grpOperational.TabIndex = 9;
            this.grpOperational.TabStop = false;
            this.grpOperational.Text = "Operational commands";
            // 
            // btnI
            // 
            this.btnI.Location = new System.Drawing.Point(88, 77);
            this.btnI.Name = "btnI";
            this.btnI.Size = new System.Drawing.Size(75, 23);
            this.btnI.TabIndex = 6;
            this.btnI.Text = "I";
            this.btnI.UseVisualStyleBackColor = true;
            this.btnI.Click += new System.EventHandler(this.btnI_Click);
            // 
            // btnX
            // 
            this.btnX.Location = new System.Drawing.Point(89, 48);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(75, 23);
            this.btnX.TabIndex = 5;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = true;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // btnR
            // 
            this.btnR.Location = new System.Drawing.Point(8, 77);
            this.btnR.Name = "btnR";
            this.btnR.Size = new System.Drawing.Size(75, 23);
            this.btnR.TabIndex = 4;
            this.btnR.Text = "R";
            this.btnR.UseVisualStyleBackColor = true;
            this.btnR.Click += new System.EventHandler(this.btnR_Click);
            // 
            // btnL0
            // 
            this.btnL0.Location = new System.Drawing.Point(8, 48);
            this.btnL0.Name = "btnL0";
            this.btnL0.Size = new System.Drawing.Size(75, 23);
            this.btnL0.TabIndex = 3;
            this.btnL0.Text = "L0";
            this.btnL0.UseVisualStyleBackColor = true;
            this.btnL0.Click += new System.EventHandler(this.btnL0_Click);
            // 
            // btnE
            // 
            this.btnE.Location = new System.Drawing.Point(89, 19);
            this.btnE.Name = "btnE";
            this.btnE.Size = new System.Drawing.Size(75, 23);
            this.btnE.TabIndex = 2;
            this.btnE.Text = "E";
            this.btnE.UseVisualStyleBackColor = true;
            this.btnE.Click += new System.EventHandler(this.btnE_Click);
            // 
            // btnC
            // 
            this.btnC.Location = new System.Drawing.Point(8, 106);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(75, 23);
            this.btnC.TabIndex = 1;
            this.btnC.Text = "C";
            this.btnC.UseVisualStyleBackColor = true;
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            // 
            // btnL1
            // 
            this.btnL1.Location = new System.Drawing.Point(7, 18);
            this.btnL1.Name = "btnL1";
            this.btnL1.Size = new System.Drawing.Size(75, 23);
            this.btnL1.TabIndex = 0;
            this.btnL1.Text = "L1";
            this.btnL1.UseVisualStyleBackColor = true;
            this.btnL1.Click += new System.EventHandler(this.btnL1_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(221, 277);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ConductivitySensorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 311);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grpOperational);
            this.Controls.Add(this.grpCalibration);
            this.Controls.Add(this.lblDataReceived);
            this.Controls.Add(this.lblPorts);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtDataReceived);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cmbPorts);
            this.Controls.Add(this.lblCommand);
            this.Controls.Add(this.txtCommand);
            this.Name = "ConductivitySensorView";
            this.Text = "Conductivity Sensor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConductivitySensorView_FormClosing);
            this.Load += new System.EventHandler(this.SerialCommunicationView_Load);
            this.grpCalibration.ResumeLayout(false);
            this.grpOperational.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.ComboBox cmbPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtDataReceived;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblPorts;
        private System.Windows.Forms.Label lblDataReceived;
        private System.Windows.Forms.GroupBox grpCalibration;
        private System.Windows.Forms.Button btnLow;
        private System.Windows.Forms.Button btnHigh;
        private System.Windows.Forms.Button btnDry;
        private System.Windows.Forms.Button btnProbe;
        private System.Windows.Forms.GroupBox grpOperational;
        private System.Windows.Forms.Button btnI;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Button btnR;
        private System.Windows.Forms.Button btnL0;
        private System.Windows.Forms.Button btnE;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnL1;
        private System.Windows.Forms.Button btnClear;
    }
}