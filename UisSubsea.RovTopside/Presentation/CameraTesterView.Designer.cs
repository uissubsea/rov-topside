namespace UisSubsea.RovTopside.Presentation
{
    partial class CameraTesterView
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
            this.videoCanvas = new System.Windows.Forms.PictureBox();
            this.lblFrameRateHeading = new System.Windows.Forms.Label();
            this.lblFrameRateReceived = new System.Windows.Forms.Label();
            this.lblBitRateHeading = new System.Windows.Forms.Label();
            this.lblBitRate = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.videoCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // videoCanvas
            // 
            this.videoCanvas.Location = new System.Drawing.Point(13, 13);
            this.videoCanvas.Name = "videoCanvas";
            this.videoCanvas.Size = new System.Drawing.Size(1280, 720);
            this.videoCanvas.TabIndex = 0;
            this.videoCanvas.TabStop = false;
            // 
            // lblFrameRateHeading
            // 
            this.lblFrameRateHeading.AutoSize = true;
            this.lblFrameRateHeading.Location = new System.Drawing.Point(12, 740);
            this.lblFrameRateHeading.Name = "lblFrameRateHeading";
            this.lblFrameRateHeading.Size = new System.Drawing.Size(60, 13);
            this.lblFrameRateHeading.TabIndex = 1;
            this.lblFrameRateHeading.Text = "Frame rate:";
            // 
            // lblFrameRateReceived
            // 
            this.lblFrameRateReceived.AutoSize = true;
            this.lblFrameRateReceived.Location = new System.Drawing.Point(78, 740);
            this.lblFrameRateReceived.Name = "lblFrameRateReceived";
            this.lblFrameRateReceived.Size = new System.Drawing.Size(13, 13);
            this.lblFrameRateReceived.TabIndex = 2;
            this.lblFrameRateReceived.Text = "0";
            // 
            // lblBitRateHeading
            // 
            this.lblBitRateHeading.AutoSize = true;
            this.lblBitRateHeading.Location = new System.Drawing.Point(163, 740);
            this.lblBitRateHeading.Name = "lblBitRateHeading";
            this.lblBitRateHeading.Size = new System.Drawing.Size(43, 13);
            this.lblBitRateHeading.TabIndex = 3;
            this.lblBitRateHeading.Text = "Bit rate:";
            // 
            // lblBitRate
            // 
            this.lblBitRate.AutoSize = true;
            this.lblBitRate.Location = new System.Drawing.Point(212, 740);
            this.lblBitRate.Name = "lblBitRate";
            this.lblBitRate.Size = new System.Drawing.Size(13, 13);
            this.lblBitRate.TabIndex = 4;
            this.lblBitRate.Text = "0";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // CameraTesterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1307, 762);
            this.Controls.Add(this.lblBitRate);
            this.Controls.Add(this.lblBitRateHeading);
            this.Controls.Add(this.lblFrameRateReceived);
            this.Controls.Add(this.lblFrameRateHeading);
            this.Controls.Add(this.videoCanvas);
            this.Name = "CameraTesterView";
            this.Text = "Camera Tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CameraTesterView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.videoCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox videoCanvas;
        private System.Windows.Forms.Label lblFrameRateHeading;
        private System.Windows.Forms.Label lblFrameRateReceived;
        private System.Windows.Forms.Label lblBitRateHeading;
        private System.Windows.Forms.Label lblBitRate;
        private System.Windows.Forms.Timer timer;
    }
}