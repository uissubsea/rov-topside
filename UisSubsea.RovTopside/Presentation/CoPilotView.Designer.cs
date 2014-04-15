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
            this.frontCamGauge = new System.Windows.Forms.AGauge();
            this.rearCamGauge = new System.Windows.Forms.AGauge();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.headingLabelText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.distanceToBottomLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.laserDistanceLabel = new System.Windows.Forms.Label();
            this.videoPictureBox = new System.Windows.Forms.PictureBox();
            this.headingIndicatorInstrumentControl1 = new UisSubsea.RovTopside.Presentation.Controls.HeadingIndicatorInstrumentControl();
            this.altimeterInstrumentControl1 = new UisSubsea.RovTopside.Presentation.Controls.AltimeterInstrumentControl();
            this.SensorButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.norwayFlagPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.videoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.norwayFlagPictureBox)).BeginInit();
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
            this.frontCamGauge.Location = new System.Drawing.Point(1066, 3);
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
            // rearCamGauge
            // 
            this.rearCamGauge.BaseArcColor = System.Drawing.Color.White;
            this.rearCamGauge.BaseArcRadius = 60;
            this.rearCamGauge.BaseArcStart = 30;
            this.rearCamGauge.BaseArcSweep = 180;
            this.rearCamGauge.BaseArcWidth = 1;
            this.rearCamGauge.Center = new System.Drawing.Point(100, 100);
            this.rearCamGauge.Location = new System.Drawing.Point(1073, 169);
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
            this.rearCamGauge.Size = new System.Drawing.Size(185, 195);
            this.rearCamGauge.TabIndex = 7;
            this.rearCamGauge.Text = "RearCam";
            this.rearCamGauge.Value = 0F;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(1144, 290);
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
            this.label3.Location = new System.Drawing.Point(1144, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "Front camera";
            // 
            // headingLabelText
            // 
            this.headingLabelText.AutoSize = true;
            this.headingLabelText.Cursor = System.Windows.Forms.Cursors.Default;
            this.headingLabelText.ForeColor = System.Drawing.Color.Yellow;
            this.headingLabelText.Location = new System.Drawing.Point(1078, 367);
            this.headingLabelText.Name = "headingLabelText";
            this.headingLabelText.Size = new System.Drawing.Size(13, 13);
            this.headingLabelText.TabIndex = 17;
            this.headingLabelText.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1058, 649);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "cm: ";
            // 
            // distanceToBottomLabel
            // 
            this.distanceToBottomLabel.AutoSize = true;
            this.distanceToBottomLabel.Location = new System.Drawing.Point(1081, 649);
            this.distanceToBottomLabel.Name = "distanceToBottomLabel";
            this.distanceToBottomLabel.Size = new System.Drawing.Size(13, 13);
            this.distanceToBottomLabel.TabIndex = 22;
            this.distanceToBottomLabel.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1058, 503);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Laser:";
            // 
            // laserDistanceLabel
            // 
            this.laserDistanceLabel.AutoSize = true;
            this.laserDistanceLabel.Location = new System.Drawing.Point(1094, 503);
            this.laserDistanceLabel.Name = "laserDistanceLabel";
            this.laserDistanceLabel.Size = new System.Drawing.Size(13, 13);
            this.laserDistanceLabel.TabIndex = 24;
            this.laserDistanceLabel.Text = "0";
            // 
            // videoPictureBox
            // 
            this.videoPictureBox.Location = new System.Drawing.Point(-5, -25);
            this.videoPictureBox.Name = "videoPictureBox";
            this.videoPictureBox.Size = new System.Drawing.Size(1055, 706);
            this.videoPictureBox.TabIndex = 0;
            this.videoPictureBox.TabStop = false;
            // 
            // headingIndicatorInstrumentControl1
            // 
            this.headingIndicatorInstrumentControl1.ForeColor = System.Drawing.Color.Yellow;
            this.headingIndicatorInstrumentControl1.Location = new System.Drawing.Point(1097, 351);
            this.headingIndicatorInstrumentControl1.Name = "headingIndicatorInstrumentControl1";
            this.headingIndicatorInstrumentControl1.Size = new System.Drawing.Size(155, 151);
            this.headingIndicatorInstrumentControl1.TabIndex = 19;
            this.headingIndicatorInstrumentControl1.Text = "headingIndicatorInstrumentControl1";
            // 
            // altimeterInstrumentControl1
            // 
            this.altimeterInstrumentControl1.Location = new System.Drawing.Point(1109, 520);
            this.altimeterInstrumentControl1.Name = "altimeterInstrumentControl1";
            this.altimeterInstrumentControl1.Size = new System.Drawing.Size(143, 142);
            this.altimeterInstrumentControl1.TabIndex = 18;
            this.altimeterInstrumentControl1.Text = "altimeterInstrumentControl1";
            // 
            // SensorButton
            // 
            this.SensorButton.BackColor = System.Drawing.SystemColors.MenuBar;
            this.SensorButton.ForeColor = System.Drawing.Color.Black;
            this.SensorButton.Location = new System.Drawing.Point(1135, 686);
            this.SensorButton.Name = "SensorButton";
            this.SensorButton.Size = new System.Drawing.Size(86, 23);
            this.SensorButton.TabIndex = 25;
            this.SensorButton.Text = "Sensor alarm";
            this.SensorButton.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1057, 351);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Heading:";
            // 
            // norwayFlagPictureBox
            // 
            this.norwayFlagPictureBox.Location = new System.Drawing.Point(-6, 672);
            this.norwayFlagPictureBox.Name = "norwayFlagPictureBox";
            this.norwayFlagPictureBox.Size = new System.Drawing.Size(1056, 55);
            this.norwayFlagPictureBox.TabIndex = 27;
            this.norwayFlagPictureBox.TabStop = false;
            // 
            // CoPilotView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(1267, 721);
            this.Controls.Add(this.norwayFlagPictureBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SensorButton);
            this.Controls.Add(this.laserDistanceLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.distanceToBottomLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.headingIndicatorInstrumentControl1);
            this.Controls.Add(this.altimeterInstrumentControl1);
            this.Controls.Add(this.headingLabelText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rearCamGauge);
            this.Controls.Add(this.frontCamGauge);
            this.Controls.Add(this.videoPictureBox);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Yellow;
            this.Name = "CoPilotView";
            this.Text = "CoPilotView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CoPilotView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.videoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.norwayFlagPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox videoPictureBox;
        private System.Windows.Forms.AGauge frontCamGauge;
        private System.Windows.Forms.AGauge rearCamGauge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label headingLabelText;
        private Controls.HeadingIndicatorInstrumentControl headingIndicatorInstrumentControl1;
        private Controls.AltimeterInstrumentControl altimeterInstrumentControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label distanceToBottomLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label laserDistanceLabel;
        private System.Windows.Forms.Button SensorButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox norwayFlagPictureBox;

    }
}