namespace UisSubsea.RovTopside.Presentation
{
    partial class CoPilotView
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
            this.frontCamGauge = new System.Windows.Forms.AGauge();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.rearCamGauge = new System.Windows.Forms.AGauge();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.headingLabelText = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.videoPictureBox = new System.Windows.Forms.PictureBox();
            this.headingIndicatorInstrumentControl1 = new UisSubsea.RovTopside.Presentation.Controls.HeadingIndicatorInstrumentControl();
            this.altimeterInstrumentControl1 = new UisSubsea.RovTopside.Presentation.Controls.AltimeterInstrumentControl();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // frontCamGauge
            // 
            this.frontCamGauge.BaseArcColor = System.Drawing.Color.White;
            this.frontCamGauge.BaseArcRadius = 60;
            this.frontCamGauge.BaseArcStart = 285;
            this.frontCamGauge.BaseArcSweep = 180;
            this.frontCamGauge.BaseArcWidth = 1;
            this.frontCamGauge.Center = new System.Drawing.Point(100, 100);
            this.frontCamGauge.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frontCamGauge.Location = new System.Drawing.Point(1055, 30);
            this.frontCamGauge.MaxValue = 105F;
            this.frontCamGauge.MinValue = -75F;
            this.frontCamGauge.Name = "frontCamGauge";
            this.frontCamGauge.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Yellow;
            this.frontCamGauge.NeedleColor2 = System.Drawing.Color.Yellow;
            this.frontCamGauge.NeedleRadius = 50;
            this.frontCamGauge.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.frontCamGauge.NeedleWidth = 2;
            this.frontCamGauge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.frontCamGauge.ScaleLinesInterColor = System.Drawing.Color.White;
            this.frontCamGauge.ScaleLinesInterInnerRadius = 53;
            this.frontCamGauge.ScaleLinesInterOuterRadius = 60;
            this.frontCamGauge.ScaleLinesInterWidth = 1;
            this.frontCamGauge.ScaleLinesMajorColor = System.Drawing.Color.White;
            this.frontCamGauge.ScaleLinesMajorInnerRadius = 50;
            this.frontCamGauge.ScaleLinesMajorOuterRadius = 60;
            this.frontCamGauge.ScaleLinesMajorStepValue = 30F;
            this.frontCamGauge.ScaleLinesMajorWidth = 1;
            this.frontCamGauge.ScaleLinesMinorColor = System.Drawing.Color.White;
            this.frontCamGauge.ScaleLinesMinorInnerRadius = 55;
            this.frontCamGauge.ScaleLinesMinorOuterRadius = 60;
            this.frontCamGauge.ScaleLinesMinorTicks = 5;
            this.frontCamGauge.ScaleLinesMinorWidth = 1;
            this.frontCamGauge.ScaleNumbersColor = System.Drawing.Color.White;
            this.frontCamGauge.ScaleNumbersFormat = null;
            this.frontCamGauge.ScaleNumbersRadius = 75;
            this.frontCamGauge.ScaleNumbersRotation = 0;
            this.frontCamGauge.ScaleNumbersStartScaleLine = 0;
            this.frontCamGauge.ScaleNumbersStepScaleLines = 2;
            this.frontCamGauge.Size = new System.Drawing.Size(191, 193);
            this.frontCamGauge.TabIndex = 3;
            this.frontCamGauge.Text = "FrontCam";
            this.frontCamGauge.Value = 0F;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(1055, 522);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Fullscreen";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rearCamGauge
            // 
            this.rearCamGauge.BaseArcColor = System.Drawing.Color.White;
            this.rearCamGauge.BaseArcRadius = 60;
            this.rearCamGauge.BaseArcStart = 30;
            this.rearCamGauge.BaseArcSweep = 180;
            this.rearCamGauge.BaseArcWidth = 1;
            this.rearCamGauge.Center = new System.Drawing.Point(100, 100);
            this.rearCamGauge.Location = new System.Drawing.Point(1055, 211);
            this.rearCamGauge.MaxValue = 30F;
            this.rearCamGauge.MinValue = -150F;
            this.rearCamGauge.Name = "rearCamGauge";
            this.rearCamGauge.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Yellow;
            this.rearCamGauge.NeedleColor2 = System.Drawing.Color.Yellow;
            this.rearCamGauge.NeedleRadius = 50;
            this.rearCamGauge.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.rearCamGauge.NeedleWidth = 2;
            this.rearCamGauge.ScaleLinesInterColor = System.Drawing.Color.White;
            this.rearCamGauge.ScaleLinesInterInnerRadius = 53;
            this.rearCamGauge.ScaleLinesInterOuterRadius = 60;
            this.rearCamGauge.ScaleLinesInterWidth = 1;
            this.rearCamGauge.ScaleLinesMajorColor = System.Drawing.Color.White;
            this.rearCamGauge.ScaleLinesMajorInnerRadius = 50;
            this.rearCamGauge.ScaleLinesMajorOuterRadius = 60;
            this.rearCamGauge.ScaleLinesMajorStepValue = 30F;
            this.rearCamGauge.ScaleLinesMajorWidth = 2;
            this.rearCamGauge.ScaleLinesMinorColor = System.Drawing.Color.White;
            this.rearCamGauge.ScaleLinesMinorInnerRadius = 55;
            this.rearCamGauge.ScaleLinesMinorOuterRadius = 60;
            this.rearCamGauge.ScaleLinesMinorTicks = 5;
            this.rearCamGauge.ScaleLinesMinorWidth = 1;
            this.rearCamGauge.ScaleNumbersColor = System.Drawing.Color.White;
            this.rearCamGauge.ScaleNumbersFormat = null;
            this.rearCamGauge.ScaleNumbersRadius = 75;
            this.rearCamGauge.ScaleNumbersRotation = 0;
            this.rearCamGauge.ScaleNumbersStartScaleLine = 0;
            this.rearCamGauge.ScaleNumbersStepScaleLines = 1;
            this.rearCamGauge.Size = new System.Drawing.Size(185, 180);
            this.rearCamGauge.TabIndex = 7;
            this.rearCamGauge.Text = "RearCam";
            this.rearCamGauge.Value = 0F;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(1126, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "Rear camera";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(1124, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "Front camera";
            // 
            // headingLabelText
            // 
            this.headingLabelText.AutoSize = true;
            this.headingLabelText.ForeColor = System.Drawing.Color.Yellow;
            this.headingLabelText.Location = new System.Drawing.Point(1157, 532);
            this.headingLabelText.Name = "headingLabelText";
            this.headingLabelText.Size = new System.Drawing.Size(13, 13);
            this.headingLabelText.TabIndex = 17;
            this.headingLabelText.Text = "0";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(1066, 571);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 104);
            this.trackBar1.TabIndex = 20;
            this.trackBar1.TickFrequency = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // videoPictureBox
            // 
            this.videoPictureBox.Location = new System.Drawing.Point(-6, -31);
            this.videoPictureBox.Name = "videoPictureBox";
            this.videoPictureBox.Size = new System.Drawing.Size(1055, 706);
            this.videoPictureBox.TabIndex = 0;
            this.videoPictureBox.TabStop = false;
            // 
            // headingIndicatorInstrumentControl1
            // 
            this.headingIndicatorInstrumentControl1.ForeColor = System.Drawing.Color.Yellow;
            this.headingIndicatorInstrumentControl1.Location = new System.Drawing.Point(1095, 410);
            this.headingIndicatorInstrumentControl1.Name = "headingIndicatorInstrumentControl1";
            this.headingIndicatorInstrumentControl1.Size = new System.Drawing.Size(115, 119);
            this.headingIndicatorInstrumentControl1.TabIndex = 19;
            this.headingIndicatorInstrumentControl1.Text = "headingIndicatorInstrumentControl1";
            // 
            // altimeterInstrumentControl1
            // 
            this.altimeterInstrumentControl1.Location = new System.Drawing.Point(1108, 557);
            this.altimeterInstrumentControl1.Name = "altimeterInstrumentControl1";
            this.altimeterInstrumentControl1.Size = new System.Drawing.Size(102, 102);
            this.altimeterInstrumentControl1.TabIndex = 18;
            this.altimeterInstrumentControl1.Text = "altimeterInstrumentControl1";
            // 
            // CoPilotView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.headingIndicatorInstrumentControl1);
            this.Controls.Add(this.altimeterInstrumentControl1);
            this.Controls.Add(this.headingLabelText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rearCamGauge);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.frontCamGauge);
            this.Controls.Add(this.videoPictureBox);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Yellow;
            this.Name = "CoPilotView";
            this.Text = "CoPilotView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox videoPictureBox;
        private System.Windows.Forms.AGauge frontCamGauge;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.AGauge rearCamGauge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label headingLabelText;
        private System.Windows.Forms.TrackBar trackBar1;
        private Controls.HeadingIndicatorInstrumentControl headingIndicatorInstrumentControl1;
        private Controls.AltimeterInstrumentControl altimeterInstrumentControl1;

    }
}