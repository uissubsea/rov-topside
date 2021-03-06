﻿namespace UisSubsea.RovTopside.Presentation
{
    partial class JoystickTrackerView
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
            this.trkYaw = new System.Windows.Forms.TrackBar();
            this.trkThrottle = new System.Windows.Forms.TrackBar();
            this.lblRoll = new System.Windows.Forms.Label();
            this.lblPitch = new System.Windows.Forms.Label();
            this.lblYaw = new System.Windows.Forms.Label();
            this.lblThrottle = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trkYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkThrottle)).BeginInit();
            this.SuspendLayout();
            // 
            // trkYaw
            // 
            this.trkYaw.Location = new System.Drawing.Point(12, 247);
            this.trkYaw.Maximum = 250;
            this.trkYaw.Name = "trkYaw";
            this.trkYaw.Size = new System.Drawing.Size(218, 45);
            this.trkYaw.TabIndex = 0;
            this.trkYaw.TickFrequency = 25;
            this.trkYaw.Value = 125;
            // 
            // trkThrottle
            // 
            this.trkThrottle.Location = new System.Drawing.Point(237, 12);
            this.trkThrottle.Maximum = 250;
            this.trkThrottle.Name = "trkThrottle";
            this.trkThrottle.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trkThrottle.Size = new System.Drawing.Size(45, 212);
            this.trkThrottle.TabIndex = 1;
            this.trkThrottle.TickFrequency = 25;
            // 
            // lblRoll
            // 
            this.lblRoll.AutoSize = true;
            this.lblRoll.Location = new System.Drawing.Point(542, 22);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(25, 13);
            this.lblRoll.TabIndex = 2;
            this.lblRoll.Text = "Roll";
            // 
            // lblPitch
            // 
            this.lblPitch.AutoSize = true;
            this.lblPitch.Location = new System.Drawing.Point(542, 61);
            this.lblPitch.Name = "lblPitch";
            this.lblPitch.Size = new System.Drawing.Size(31, 13);
            this.lblPitch.TabIndex = 3;
            this.lblPitch.Text = "Pitch";
            // 
            // lblYaw
            // 
            this.lblYaw.AutoSize = true;
            this.lblYaw.Location = new System.Drawing.Point(542, 97);
            this.lblYaw.Name = "lblYaw";
            this.lblYaw.Size = new System.Drawing.Size(28, 13);
            this.lblYaw.TabIndex = 4;
            this.lblYaw.Text = "Yaw";
            // 
            // lblThrottle
            // 
            this.lblThrottle.AutoSize = true;
            this.lblThrottle.Location = new System.Drawing.Point(542, 136);
            this.lblThrottle.Name = "lblThrottle";
            this.lblThrottle.Size = new System.Drawing.Size(43, 13);
            this.lblThrottle.TabIndex = 5;
            this.lblThrottle.Text = "Throttle";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(60, 299);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(305, 124);
            this.txtOutput.TabIndex = 8;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(411, 299);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ReadOnly = true;
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(319, 117);
            this.txtInput.TabIndex = 9;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(12, 299);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(42, 13);
            this.lblOutput.TabIndex = 10;
            this.lblOutput.Text = "Output:";
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(371, 302);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(34, 13);
            this.lblInput.TabIndex = 11;
            this.lblInput.Text = "Input:";
            // 
            // JoystickTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 435);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lblThrottle);
            this.Controls.Add(this.lblYaw);
            this.Controls.Add(this.lblPitch);
            this.Controls.Add(this.lblRoll);
            this.Controls.Add(this.trkThrottle);
            this.Controls.Add(this.trkYaw);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "JoystickTracker";
            this.Text = "Joystick Debugger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JoystickTracker_FormClosing);
            this.Load += new System.EventHandler(this.JoystickTracker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trkYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkThrottle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trkYaw;
        private System.Windows.Forms.TrackBar trkThrottle;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.Label lblPitch;
        private System.Windows.Forms.Label lblYaw;
        private System.Windows.Forms.Label lblThrottle;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblInput;
    }
}

