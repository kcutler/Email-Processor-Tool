namespace CheckEmail
{
    partial class CNS_Proccessor
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
            this.SendButton = new System.Windows.Forms.Button();
            this.FromBox = new System.Windows.Forms.TextBox();
            this.FromLabel = new System.Windows.Forms.Label();
            this.ToLabel = new System.Windows.Forms.Label();
            this.ToBox = new System.Windows.Forms.TextBox();
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.SubjectBox = new System.Windows.Forms.TextBox();
            this.BodyLabel = new System.Windows.Forms.Label();
            this.BodyBox = new System.Windows.Forms.TextBox();
            this.CCBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(74, 693);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 0;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // FromBox
            // 
            this.FromBox.Location = new System.Drawing.Point(74, 12);
            this.FromBox.Name = "FromBox";
            this.FromBox.Size = new System.Drawing.Size(147, 22);
            this.FromBox.TabIndex = 1;
            this.FromBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(21, 17);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(40, 17);
            this.FromLabel.TabIndex = 2;
            this.FromLabel.Text = "From";
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(238, 12);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(25, 17);
            this.ToLabel.TabIndex = 3;
            this.ToLabel.Text = "To";
            // 
            // ToBox
            // 
            this.ToBox.Location = new System.Drawing.Point(269, 12);
            this.ToBox.Name = "ToBox";
            this.ToBox.Size = new System.Drawing.Size(167, 22);
            this.ToBox.TabIndex = 4;
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Location = new System.Drawing.Point(6, 131);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(55, 17);
            this.SubjectLabel.TabIndex = 5;
            this.SubjectLabel.Text = "Subject";
            // 
            // SubjectBox
            // 
            this.SubjectBox.Location = new System.Drawing.Point(74, 131);
            this.SubjectBox.Name = "SubjectBox";
            this.SubjectBox.Size = new System.Drawing.Size(362, 22);
            this.SubjectBox.TabIndex = 6;
            // 
            // BodyLabel
            // 
            this.BodyLabel.AutoSize = true;
            this.BodyLabel.Location = new System.Drawing.Point(21, 177);
            this.BodyLabel.Name = "BodyLabel";
            this.BodyLabel.Size = new System.Drawing.Size(40, 17);
            this.BodyLabel.TabIndex = 7;
            this.BodyLabel.Text = "Body";
            // 
            // BodyBox
            // 
            this.BodyBox.Location = new System.Drawing.Point(74, 177);
            this.BodyBox.Multiline = true;
            this.BodyBox.Name = "BodyBox";
            this.BodyBox.Size = new System.Drawing.Size(362, 496);
            this.BodyBox.TabIndex = 8;
            // 
            // CCBox
            // 
            this.CCBox.Location = new System.Drawing.Point(74, 48);
            this.CCBox.Multiline = true;
            this.CCBox.Name = "CCBox";
            this.CCBox.Size = new System.Drawing.Size(362, 70);
            this.CCBox.TabIndex = 9;
            this.CCBox.TextChanged += new System.EventHandler(this.CCBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "CC";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CNS_Proccessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 728);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CCBox);
            this.Controls.Add(this.BodyBox);
            this.Controls.Add(this.BodyLabel);
            this.Controls.Add(this.SubjectBox);
            this.Controls.Add(this.SubjectLabel);
            this.Controls.Add(this.ToBox);
            this.Controls.Add(this.ToLabel);
            this.Controls.Add(this.FromLabel);
            this.Controls.Add(this.FromBox);
            this.Controls.Add(this.SendButton);
            this.Name = "CNS_Proccessor";
            this.Text = "CNS Proccessor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox FromBox;
        private System.Windows.Forms.Label FromLabel;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.TextBox ToBox;
        private System.Windows.Forms.Label SubjectLabel;
        private System.Windows.Forms.TextBox SubjectBox;
        private System.Windows.Forms.Label BodyLabel;
        private System.Windows.Forms.TextBox BodyBox;
        private System.Windows.Forms.TextBox CCBox;
        private System.Windows.Forms.Label label1;
    }
}

