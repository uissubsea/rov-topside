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
            this.AvstandLasertxb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.answertxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.textBox.Size = new System.Drawing.Size(334, 149);
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
            // AvstandLasertxb
            // 
            this.AvstandLasertxb.HideSelection = false;
            this.AvstandLasertxb.Location = new System.Drawing.Point(1303, 223);
            this.AvstandLasertxb.Name = "AvstandLasertxb";
            this.AvstandLasertxb.Size = new System.Drawing.Size(133, 20);
            this.AvstandLasertxb.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1300, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Avstand på laserene i cm:";
            // 
            // answertxt
            // 
            this.answertxt.Location = new System.Drawing.Point(1303, 292);
            this.answertxt.Multiline = true;
            this.answertxt.Name = "answertxt";
            this.answertxt.Size = new System.Drawing.Size(315, 171);
            this.answertxt.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1300, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Svar:";
            // 
            // CountPixelsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1649, 753);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.answertxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AvstandLasertxb);
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
        private System.Windows.Forms.TextBox AvstandLasertxb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox answertxt;
        private System.Windows.Forms.Label label2;
    }
}

