namespace UisSubsea.RovTopside.Presentation
{
    partial class CameraSelector
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
            this.cmbCamerasConnected = new System.Windows.Forms.ComboBox();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbCamerasConnected
            // 
            this.cmbCamerasConnected.FormattingEnabled = true;
            this.cmbCamerasConnected.Location = new System.Drawing.Point(86, 34);
            this.cmbCamerasConnected.Name = "cmbCamerasConnected";
            this.cmbCamerasConnected.Size = new System.Drawing.Size(164, 21);
            this.cmbCamerasConnected.TabIndex = 0;            
            // 
            // btnLaunch
            // 
            this.btnLaunch.Location = new System.Drawing.Point(86, 61);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(164, 23);
            this.btnLaunch.TabIndex = 1;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // CameraSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 131);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.cmbCamerasConnected);
            this.Name = "CameraSelector";
            this.Text = "CameraSelector";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCamerasConnected;
        private System.Windows.Forms.Button btnLaunch;
    }
}