namespace Project2Ferrer15738
{
    partial class CatchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatchForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nameTbox = new System.Windows.Forms.TextBox();
            this.HPTbox = new System.Windows.Forms.TextBox();
            this.CPTbox = new System.Windows.Forms.TextBox();
            this.CatchButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "HP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(13, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "CP";
            // 
            // nameTbox
            // 
            this.nameTbox.Location = new System.Drawing.Point(66, 44);
            this.nameTbox.Name = "nameTbox";
            this.nameTbox.Size = new System.Drawing.Size(100, 20);
            this.nameTbox.TabIndex = 3;
            // 
            // HPTbox
            // 
            this.HPTbox.Location = new System.Drawing.Point(66, 81);
            this.HPTbox.Name = "HPTbox";
            this.HPTbox.Size = new System.Drawing.Size(100, 20);
            this.HPTbox.TabIndex = 4;
            // 
            // CPTbox
            // 
            this.CPTbox.Location = new System.Drawing.Point(66, 114);
            this.CPTbox.Name = "CPTbox";
            this.CPTbox.Size = new System.Drawing.Size(100, 20);
            this.CPTbox.TabIndex = 5;
            // 
            // CatchButton
            // 
            this.CatchButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CatchButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CatchButton.Image = ((System.Drawing.Image)(resources.GetObject("CatchButton.Image")));
            this.CatchButton.Location = new System.Drawing.Point(12, 159);
            this.CatchButton.Name = "CatchButton";
            this.CatchButton.Size = new System.Drawing.Size(75, 23);
            this.CatchButton.TabIndex = 6;
            this.CatchButton.Text = "Catch";
            this.CatchButton.UseVisualStyleBackColor = true;
            this.CatchButton.Click += new System.EventHandler(this.CatchButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(198, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // CatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(415, 201);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CatchButton);
            this.Controls.Add(this.CPTbox);
            this.Controls.Add(this.HPTbox);
            this.Controls.Add(this.nameTbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CatchForm";
            this.Text = "Catch";
            this.Load += new System.EventHandler(this.CatchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTbox;
        private System.Windows.Forms.TextBox HPTbox;
        private System.Windows.Forms.TextBox CPTbox;
        private System.Windows.Forms.Button CatchButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}