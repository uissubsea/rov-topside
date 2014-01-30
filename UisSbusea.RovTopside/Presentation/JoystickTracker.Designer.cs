namespace UisSubsea.RovTopside.Presentation
{
    partial class JoystickTracker
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
            this.components = new System.ComponentModel.Container();
            this.tmrRefreshStick = new System.Windows.Forms.Timer(this.components);
            this.trkYaw = new System.Windows.Forms.TrackBar();
            this.trkThrottle = new System.Windows.Forms.TrackBar();
            this.lblRoll = new System.Windows.Forms.Label();
            this.lblPitch = new System.Windows.Forms.Label();
            this.lblYaw = new System.Windows.Forms.Label();
            this.lblThrottle = new System.Windows.Forms.Label();
            this.cmbAvailablePorts = new System.Windows.Forms.ComboBox();
            this.btnUsePort = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblCom = new System.Windows.Forms.Label();
            this.chkManualSend = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trkYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkThrottle)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrRefreshStick
            // 
            this.tmrRefreshStick.Interval = 10;
            this.tmrRefreshStick.Tick += new System.EventHandler(this.tmrRefreshStick_Tick);
            // 
            // trkYaw
            // 
            this.trkYaw.Location = new System.Drawing.Point(16, 304);
            this.trkYaw.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trkYaw.Maximum = 250;
            this.trkYaw.Name = "trkYaw";
            this.trkYaw.Size = new System.Drawing.Size(291, 56);
            this.trkYaw.TabIndex = 0;
            this.trkYaw.TickFrequency = 25;
            this.trkYaw.Value = 125;
            // 
            // trkThrottle
            // 
            this.trkThrottle.Location = new System.Drawing.Point(316, 15);
            this.trkThrottle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trkThrottle.Maximum = 250;
            this.trkThrottle.Name = "trkThrottle";
            this.trkThrottle.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trkThrottle.Size = new System.Drawing.Size(56, 261);
            this.trkThrottle.TabIndex = 1;
            this.trkThrottle.TickFrequency = 25;
            // 
            // lblRoll
            // 
            this.lblRoll.AutoSize = true;
            this.lblRoll.Location = new System.Drawing.Point(723, 27);
            this.lblRoll.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(32, 17);
            this.lblRoll.TabIndex = 2;
            this.lblRoll.Text = "Roll";
            // 
            // lblPitch
            // 
            this.lblPitch.AutoSize = true;
            this.lblPitch.Location = new System.Drawing.Point(723, 75);
            this.lblPitch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPitch.Name = "lblPitch";
            this.lblPitch.Size = new System.Drawing.Size(39, 17);
            this.lblPitch.TabIndex = 3;
            this.lblPitch.Text = "Pitch";
            // 
            // lblYaw
            // 
            this.lblYaw.AutoSize = true;
            this.lblYaw.Location = new System.Drawing.Point(723, 119);
            this.lblYaw.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYaw.Name = "lblYaw";
            this.lblYaw.Size = new System.Drawing.Size(34, 17);
            this.lblYaw.TabIndex = 4;
            this.lblYaw.Text = "Yaw";
            // 
            // lblThrottle
            // 
            this.lblThrottle.AutoSize = true;
            this.lblThrottle.Location = new System.Drawing.Point(723, 167);
            this.lblThrottle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThrottle.Name = "lblThrottle";
            this.lblThrottle.Size = new System.Drawing.Size(57, 17);
            this.lblThrottle.TabIndex = 5;
            this.lblThrottle.Text = "Throttle";
            // 
            // cmbAvailablePorts
            // 
            this.cmbAvailablePorts.FormattingEnabled = true;
            this.cmbAvailablePorts.Location = new System.Drawing.Point(467, 304);
            this.cmbAvailablePorts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbAvailablePorts.Name = "cmbAvailablePorts";
            this.cmbAvailablePorts.Size = new System.Drawing.Size(160, 24);
            this.cmbAvailablePorts.TabIndex = 6;
            // 
            // btnUsePort
            // 
            this.btnUsePort.Location = new System.Drawing.Point(636, 302);
            this.btnUsePort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUsePort.Name = "btnUsePort";
            this.btnUsePort.Size = new System.Drawing.Size(100, 28);
            this.btnUsePort.TabIndex = 7;
            this.btnUsePort.Text = "Use";
            this.btnUsePort.UseVisualStyleBackColor = true;
            this.btnUsePort.Click += new System.EventHandler(this.btnUsePort_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(80, 368);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(405, 152);
            this.txtOutput.TabIndex = 8;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(548, 368);
            this.txtInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ReadOnly = true;
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(424, 143);
            this.txtInput.TabIndex = 9;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(16, 368);
            this.lblOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(55, 17);
            this.lblOutput.TabIndex = 10;
            this.lblOutput.Text = "Output:";
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(495, 372);
            this.lblInput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(43, 17);
            this.lblInput.TabIndex = 11;
            this.lblInput.Text = "Input:";
            // 
            // lblCom
            // 
            this.lblCom.AutoSize = true;
            this.lblCom.Location = new System.Drawing.Point(385, 308);
            this.lblCom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCom.Name = "lblCom";
            this.lblCom.Size = new System.Drawing.Size(73, 17);
            this.lblCom.TabIndex = 12;
            this.lblCom.Text = "COM-port:";
            // 
            // chkManualSend
            // 
            this.chkManualSend.AutoSize = true;
            this.chkManualSend.Location = new System.Drawing.Point(805, 309);
            this.chkManualSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkManualSend.Name = "chkManualSend";
            this.chkManualSend.Size = new System.Drawing.Size(111, 21);
            this.chkManualSend.TabIndex = 14;
            this.chkManualSend.Text = "Manual send";
            this.chkManualSend.UseVisualStyleBackColor = true;
            this.chkManualSend.CheckedChanged += new System.EventHandler(this.chkManualSend_CheckedChanged);
            // 
            // JoystickTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 535);
            this.Controls.Add(this.chkManualSend);
            this.Controls.Add(this.lblCom);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnUsePort);
            this.Controls.Add(this.cmbAvailablePorts);
            this.Controls.Add(this.lblThrottle);
            this.Controls.Add(this.lblYaw);
            this.Controls.Add(this.lblPitch);
            this.Controls.Add(this.lblRoll);
            this.Controls.Add(this.trkThrottle);
            this.Controls.Add(this.trkYaw);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "JoystickTracker";
            this.Text = "Joystick Debugger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JoystickTracker_FormClosing);
            this.Load += new System.EventHandler(this.JoystickTracker_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JoystickTracker_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.trkYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkThrottle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrRefreshStick;
        private System.Windows.Forms.TrackBar trkYaw;
        private System.Windows.Forms.TrackBar trkThrottle;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.Label lblPitch;
        private System.Windows.Forms.Label lblYaw;
        private System.Windows.Forms.Label lblThrottle;
        private System.Windows.Forms.ComboBox cmbAvailablePorts;
        private System.Windows.Forms.Button btnUsePort;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblCom;
        private System.Windows.Forms.CheckBox chkManualSend;
    }
}

