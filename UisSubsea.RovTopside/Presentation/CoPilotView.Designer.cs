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
            this.aGauge2 = new System.Windows.Forms.AGauge();
            this.aGauge1 = new System.Windows.Forms.AGauge();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.aGauge3 = new System.Windows.Forms.AGauge();
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
            // aGauge2
            // 
            this.aGauge2.BaseArcColor = System.Drawing.Color.Red;
            this.aGauge2.BaseArcRadius = 60;
            this.aGauge2.BaseArcStart = 285;
            this.aGauge2.BaseArcSweep = 180;
            this.aGauge2.BaseArcWidth = 1;
            this.aGauge2.Center = new System.Drawing.Point(100, 100);
            this.aGauge2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aGauge2.Location = new System.Drawing.Point(1076, 185);
            this.aGauge2.MaxValue = 105F;
            this.aGauge2.MinValue = -75F;
            this.aGauge2.Name = "aGauge2";
            this.aGauge2.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Red;
            this.aGauge2.NeedleColor2 = System.Drawing.Color.Red;
            this.aGauge2.NeedleRadius = 50;
            this.aGauge2.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.aGauge2.NeedleWidth = 2;
            this.aGauge2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aGauge2.ScaleLinesInterColor = System.Drawing.Color.Red;
            this.aGauge2.ScaleLinesInterInnerRadius = 53;
            this.aGauge2.ScaleLinesInterOuterRadius = 60;
            this.aGauge2.ScaleLinesInterWidth = 1;
            this.aGauge2.ScaleLinesMajorColor = System.Drawing.Color.Red;
            this.aGauge2.ScaleLinesMajorInnerRadius = 50;
            this.aGauge2.ScaleLinesMajorOuterRadius = 60;
            this.aGauge2.ScaleLinesMajorStepValue = 30F;
            this.aGauge2.ScaleLinesMajorWidth = 1;
            this.aGauge2.ScaleLinesMinorColor = System.Drawing.Color.Red;
            this.aGauge2.ScaleLinesMinorInnerRadius = 55;
            this.aGauge2.ScaleLinesMinorOuterRadius = 60;
            this.aGauge2.ScaleLinesMinorTicks = 5;
            this.aGauge2.ScaleLinesMinorWidth = 1;
            this.aGauge2.ScaleNumbersColor = System.Drawing.Color.Red;
            this.aGauge2.ScaleNumbersFormat = null;
            this.aGauge2.ScaleNumbersRadius = 75;
            this.aGauge2.ScaleNumbersRotation = 0;
            this.aGauge2.ScaleNumbersStartScaleLine = 0;
            this.aGauge2.ScaleNumbersStepScaleLines = 2;
            this.aGauge2.Size = new System.Drawing.Size(191, 193);
            this.aGauge2.TabIndex = 3;
            this.aGauge2.Text = "aGauge2";
            this.aGauge2.Value = 0F;
            // 
            // aGauge1
            // 
            this.aGauge1.BaseArcColor = System.Drawing.Color.Red;
            this.aGauge1.BaseArcRadius = 60;
            this.aGauge1.BaseArcStart = 270;
            this.aGauge1.BaseArcSweep = 360;
            this.aGauge1.BaseArcWidth = 1;
            this.aGauge1.Center = new System.Drawing.Point(100, 100);
            this.aGauge1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aGauge1.Location = new System.Drawing.Point(1071, 3);
            this.aGauge1.MaxValue = 359F;
            this.aGauge1.MinValue = 0F;
            this.aGauge1.Name = "aGauge1";
            this.aGauge1.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Red;
            this.aGauge1.NeedleColor2 = System.Drawing.Color.Red;
            this.aGauge1.NeedleRadius = 60;
            this.aGauge1.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.aGauge1.NeedleWidth = 2;
            this.aGauge1.ScaleLinesInterColor = System.Drawing.Color.Red;
            this.aGauge1.ScaleLinesInterInnerRadius = 50;
            this.aGauge1.ScaleLinesInterOuterRadius = 60;
            this.aGauge1.ScaleLinesInterWidth = 1;
            this.aGauge1.ScaleLinesMajorColor = System.Drawing.Color.Red;
            this.aGauge1.ScaleLinesMajorInnerRadius = 55;
            this.aGauge1.ScaleLinesMajorOuterRadius = 60;
            this.aGauge1.ScaleLinesMajorStepValue = 45F;
            this.aGauge1.ScaleLinesMajorWidth = 2;
            this.aGauge1.ScaleLinesMinorColor = System.Drawing.Color.Red;
            this.aGauge1.ScaleLinesMinorInnerRadius = 55;
            this.aGauge1.ScaleLinesMinorOuterRadius = 60;
            this.aGauge1.ScaleLinesMinorTicks = 9;
            this.aGauge1.ScaleLinesMinorWidth = 1;
            this.aGauge1.ScaleNumbersColor = System.Drawing.Color.Red;
            this.aGauge1.ScaleNumbersFormat = null;
            this.aGauge1.ScaleNumbersRadius = 75;
            this.aGauge1.ScaleNumbersRotation = 0;
            this.aGauge1.ScaleNumbersStartScaleLine = 1;
            this.aGauge1.ScaleNumbersStepScaleLines = 1;
            this.aGauge1.Size = new System.Drawing.Size(196, 198);
            this.aGauge1.TabIndex = 4;
            this.aGauge1.Text = "aGauge1";
            this.aGauge1.Value = 0F;
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
            // aGauge3
            // 
            this.aGauge3.BaseArcColor = System.Drawing.Color.Red;
            this.aGauge3.BaseArcRadius = 60;
            this.aGauge3.BaseArcStart = 30;
            this.aGauge3.BaseArcSweep = 180;
            this.aGauge3.BaseArcWidth = 1;
            this.aGauge3.Center = new System.Drawing.Point(100, 100);
            this.aGauge3.Location = new System.Drawing.Point(962, 185);
            this.aGauge3.MaxValue = 30F;
            this.aGauge3.MinValue = -150F;
            this.aGauge3.Name = "aGauge3";
            this.aGauge3.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Red;
            this.aGauge3.NeedleColor2 = System.Drawing.Color.Red;
            this.aGauge3.NeedleRadius = 50;
            this.aGauge3.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.aGauge3.NeedleWidth = 2;
            this.aGauge3.ScaleLinesInterColor = System.Drawing.Color.Red;
            this.aGauge3.ScaleLinesInterInnerRadius = 53;
            this.aGauge3.ScaleLinesInterOuterRadius = 60;
            this.aGauge3.ScaleLinesInterWidth = 1;
            this.aGauge3.ScaleLinesMajorColor = System.Drawing.Color.Red;
            this.aGauge3.ScaleLinesMajorInnerRadius = 50;
            this.aGauge3.ScaleLinesMajorOuterRadius = 60;
            this.aGauge3.ScaleLinesMajorStepValue = 30F;
            this.aGauge3.ScaleLinesMajorWidth = 2;
            this.aGauge3.ScaleLinesMinorColor = System.Drawing.Color.Red;
            this.aGauge3.ScaleLinesMinorInnerRadius = 55;
            this.aGauge3.ScaleLinesMinorOuterRadius = 60;
            this.aGauge3.ScaleLinesMinorTicks = 5;
            this.aGauge3.ScaleLinesMinorWidth = 1;
            this.aGauge3.ScaleNumbersColor = System.Drawing.Color.Red;
            this.aGauge3.ScaleNumbersFormat = null;
            this.aGauge3.ScaleNumbersRadius = 75;
            this.aGauge3.ScaleNumbersRotation = 0;
            this.aGauge3.ScaleNumbersStartScaleLine = 0;
            this.aGauge3.ScaleNumbersStepScaleLines = 1;
            this.aGauge3.Size = new System.Drawing.Size(185, 193);
            this.aGauge3.TabIndex = 7;
            this.aGauge3.Text = "aGauge3";
            this.aGauge3.Value = 0F;
            // 
            // CoPilotView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.aGauge3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.aGauge1);
            this.Controls.Add(this.aGauge2);
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
        private System.Windows.Forms.AGauge aGauge2;
        private System.Windows.Forms.AGauge aGauge1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.AGauge aGauge3;
    }
}