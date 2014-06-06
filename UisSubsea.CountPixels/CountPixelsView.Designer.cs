namespace UisSubsea.CountPixels
{
    partial class CountPixelsView
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.loadimagebtn = new System.Windows.Forms.Button();
            this.refreshbtn = new System.Windows.Forms.Button();
            this.Informationlbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(2, 1);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1280, 720);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(1303, 12);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(205, 149);
            this.textBox.TabIndex = 1;
            // 
            // loadimagebtn
            // 
            this.loadimagebtn.Location = new System.Drawing.Point(1303, 718);
            this.loadimagebtn.Name = "loadimagebtn";
            this.loadimagebtn.Size = new System.Drawing.Size(75, 23);
            this.loadimagebtn.TabIndex = 2;
            this.loadimagebtn.Text = "Load image";
            this.loadimagebtn.UseVisualStyleBackColor = true;
            this.loadimagebtn.Click += new System.EventHandler(this.loadimagebtn_Click);
            // 
            // refreshbtn
            // 
            this.refreshbtn.Location = new System.Drawing.Point(1433, 718);
            this.refreshbtn.Name = "refreshbtn";
            this.refreshbtn.Size = new System.Drawing.Size(75, 23);
            this.refreshbtn.TabIndex = 3;
            this.refreshbtn.Text = "Refresh";
            this.refreshbtn.UseVisualStyleBackColor = true;
            this.refreshbtn.Click += new System.EventHandler(this.refreshbtn_Click);
            // 
            // Informationlbl
            // 
            this.Informationlbl.AutoSize = true;
            this.Informationlbl.Location = new System.Drawing.Point(1288, 698);
            this.Informationlbl.Name = "Informationlbl";
            this.Informationlbl.Size = new System.Drawing.Size(13, 13);
            this.Informationlbl.TabIndex = 4;
            this.Informationlbl.Text = "..";
            // 
            // CountPixelsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1512, 753);
            this.Controls.Add(this.Informationlbl);
            this.Controls.Add(this.refreshbtn);
            this.Controls.Add(this.loadimagebtn);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.pictureBox);
            this.Name = "CountPixelsView";
            this.Text = "Count Pixels";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button loadimagebtn;
        private System.Windows.Forms.Button refreshbtn;
        private System.Windows.Forms.Label Informationlbl;
    }
}

