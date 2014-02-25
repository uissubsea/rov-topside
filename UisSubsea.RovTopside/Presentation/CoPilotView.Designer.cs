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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.frontCamGauge = new System.Windows.Forms.AGauge();
            this.headingGauge = new System.Windows.Forms.AGauge();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.rearCamGauge = new System.Windows.Forms.AGauge();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-4, -30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(960, 720);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frontCamGauge
            // 
            this.frontCamGauge.BaseArcColor = System.Drawing.Color.Red;
            this.frontCamGauge.BaseArcRadius = 60;
            this.frontCamGauge.BaseArcStart = 285;
            this.frontCamGauge.BaseArcSweep = 180;
            this.frontCamGauge.BaseArcWidth = 1;
            this.frontCamGauge.Center = new System.Drawing.Point(100, 100);
            this.frontCamGauge.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frontCamGauge.Location = new System.Drawing.Point(1076, 185);
            this.frontCamGauge.MaxValue = 105F;
            this.frontCamGauge.MinValue = -75F;
            this.frontCamGauge.Name = "frontCamGauge";
            this.frontCamGauge.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Red;
            this.frontCamGauge.NeedleColor2 = System.Drawing.Color.Red;
            this.frontCamGauge.NeedleRadius = 50;
            this.frontCamGauge.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.frontCamGauge.NeedleWidth = 2;
            this.frontCamGauge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.frontCamGauge.ScaleLinesInterColor = System.Drawing.Color.Red;
            this.frontCamGauge.ScaleLinesInterInnerRadius = 53;
            this.frontCamGauge.ScaleLinesInterOuterRadius = 60;
            this.frontCamGauge.ScaleLinesInterWidth = 1;
            this.frontCamGauge.ScaleLinesMajorColor = System.Drawing.Color.Red;
            this.frontCamGauge.ScaleLinesMajorInnerRadius = 50;
            this.frontCamGauge.ScaleLinesMajorOuterRadius = 60;
            this.frontCamGauge.ScaleLinesMajorStepValue = 30F;
            this.frontCamGauge.ScaleLinesMajorWidth = 1;
            this.frontCamGauge.ScaleLinesMinorColor = System.Drawing.Color.Red;
            this.frontCamGauge.ScaleLinesMinorInnerRadius = 55;
            this.frontCamGauge.ScaleLinesMinorOuterRadius = 60;
            this.frontCamGauge.ScaleLinesMinorTicks = 5;
            this.frontCamGauge.ScaleLinesMinorWidth = 1;
            this.frontCamGauge.ScaleNumbersColor = System.Drawing.Color.Red;
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
            // headingGauge
            // 
            this.headingGauge.BaseArcColor = System.Drawing.Color.Red;
            this.headingGauge.BaseArcRadius = 60;
            this.headingGauge.BaseArcStart = 270;
            this.headingGauge.BaseArcSweep = 360;
            this.headingGauge.BaseArcWidth = 1;
            this.headingGauge.Center = new System.Drawing.Point(100, 100);
            this.headingGauge.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headingGauge.Location = new System.Drawing.Point(1056, 12);
            this.headingGauge.MaxValue = 359F;
            this.headingGauge.MinValue = 0F;
            this.headingGauge.Name = "headingGauge";
            this.headingGauge.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Red;
            this.headingGauge.NeedleColor2 = System.Drawing.Color.Red;
            this.headingGauge.NeedleRadius = 60;
            this.headingGauge.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.headingGauge.NeedleWidth = 2;
            this.headingGauge.ScaleLinesInterColor = System.Drawing.Color.Red;
            this.headingGauge.ScaleLinesInterInnerRadius = 50;
            this.headingGauge.ScaleLinesInterOuterRadius = 60;
            this.headingGauge.ScaleLinesInterWidth = 1;
            this.headingGauge.ScaleLinesMajorColor = System.Drawing.Color.Red;
            this.headingGauge.ScaleLinesMajorInnerRadius = 55;
            this.headingGauge.ScaleLinesMajorOuterRadius = 60;
            this.headingGauge.ScaleLinesMajorStepValue = 45F;
            this.headingGauge.ScaleLinesMajorWidth = 2;
            this.headingGauge.ScaleLinesMinorColor = System.Drawing.Color.Red;
            this.headingGauge.ScaleLinesMinorInnerRadius = 55;
            this.headingGauge.ScaleLinesMinorOuterRadius = 60;
            this.headingGauge.ScaleLinesMinorTicks = 9;
            this.headingGauge.ScaleLinesMinorWidth = 1;
            this.headingGauge.ScaleNumbersColor = System.Drawing.Color.Red;
            this.headingGauge.ScaleNumbersFormat = null;
            this.headingGauge.ScaleNumbersRadius = 75;
            this.headingGauge.ScaleNumbersRotation = 0;
            this.headingGauge.ScaleNumbersStartScaleLine = 1;
            this.headingGauge.ScaleNumbersStepScaleLines = 1;
            this.headingGauge.Size = new System.Drawing.Size(196, 198);
            this.headingGauge.TabIndex = 4;
            this.headingGauge.Text = "aGauge1";
            this.headingGauge.Value = 0F;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(1177, 646);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Fullscreen";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rearCamGauge
            // 
            this.rearCamGauge.BaseArcColor = System.Drawing.Color.Red;
            this.rearCamGauge.BaseArcRadius = 60;
            this.rearCamGauge.BaseArcStart = 30;
            this.rearCamGauge.BaseArcSweep = 180;
            this.rearCamGauge.BaseArcWidth = 1;
            this.rearCamGauge.Center = new System.Drawing.Point(100, 100);
            this.rearCamGauge.Location = new System.Drawing.Point(962, 185);
            this.rearCamGauge.MaxValue = 30F;
            this.rearCamGauge.MinValue = -150F;
            this.rearCamGauge.Name = "rearCamGauge";
            this.rearCamGauge.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Red;
            this.rearCamGauge.NeedleColor2 = System.Drawing.Color.Red;
            this.rearCamGauge.NeedleRadius = 50;
            this.rearCamGauge.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.rearCamGauge.NeedleWidth = 2;
            this.rearCamGauge.ScaleLinesInterColor = System.Drawing.Color.Red;
            this.rearCamGauge.ScaleLinesInterInnerRadius = 53;
            this.rearCamGauge.ScaleLinesInterOuterRadius = 60;
            this.rearCamGauge.ScaleLinesInterWidth = 1;
            this.rearCamGauge.ScaleLinesMajorColor = System.Drawing.Color.Red;
            this.rearCamGauge.ScaleLinesMajorInnerRadius = 50;
            this.rearCamGauge.ScaleLinesMajorOuterRadius = 60;
            this.rearCamGauge.ScaleLinesMajorStepValue = 30F;
            this.rearCamGauge.ScaleLinesMajorWidth = 2;
            this.rearCamGauge.ScaleLinesMinorColor = System.Drawing.Color.Red;
            this.rearCamGauge.ScaleLinesMinorInnerRadius = 55;
            this.rearCamGauge.ScaleLinesMinorOuterRadius = 60;
            this.rearCamGauge.ScaleLinesMinorTicks = 5;
            this.rearCamGauge.ScaleLinesMinorWidth = 1;
            this.rearCamGauge.ScaleNumbersColor = System.Drawing.Color.Red;
            this.rearCamGauge.ScaleNumbersFormat = null;
            this.rearCamGauge.ScaleNumbersRadius = 75;
            this.rearCamGauge.ScaleNumbersRotation = 0;
            this.rearCamGauge.ScaleNumbersStartScaleLine = 0;
            this.rearCamGauge.ScaleNumbersStepScaleLines = 1;
            this.rearCamGauge.Size = new System.Drawing.Size(185, 193);
            this.rearCamGauge.TabIndex = 7;
            this.rearCamGauge.Text = "RearCam";
            this.rearCamGauge.Value = 0F;
            // 
            // CoPilotView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.rearCamGauge);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.headingGauge);
            this.Controls.Add(this.frontCamGauge);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Name = "CoPilotView";
            this.Text = "CoPilotView";
            this.Load += new System.EventHandler(this.CoPilotView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.AGauge frontCamGauge;
        private System.Windows.Forms.AGauge headingGauge;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.AGauge rearCamGauge;
    }
}