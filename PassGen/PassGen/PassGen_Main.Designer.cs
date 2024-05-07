namespace PassGen
{
    partial class PassGen_Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassGen_Main));
            btnGenerate = new Button();
            txtPassword = new TextBox();
            btnSave = new Button();
            pictureBox1 = new PictureBox();
            mainPanel = new Panel();
            btnViewPasswords = new Button();
            lblPasswordStrength = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // btnGenerate
            // 
            btnGenerate.Font = new Font("Calibri", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerate.Location = new Point(123, 205);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(92, 32);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.ButtonHighlight;
            txtPassword.Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(84, 122);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password will appear here...";
            txtPassword.ReadOnly = true;
            txtPassword.Size = new Size(253, 24);
            txtPassword.TabIndex = 1;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.Font = new Font("Calibri", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.Location = new Point(221, 205);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(92, 32);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(503, 196);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(btnViewPasswords);
            mainPanel.Controls.Add(lblPasswordStrength);
            mainPanel.Controls.Add(txtPassword);
            mainPanel.Controls.Add(btnGenerate);
            mainPanel.Controls.Add(btnSave);
            mainPanel.Font = new Font("Calibri", 9F, FontStyle.Bold, GraphicsUnit.Point);
            mainPanel.Location = new Point(46, 139);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(497, 455);
            mainPanel.TabIndex = 4;
            // 
            // btnViewPasswords
            // 
            btnViewPasswords.Font = new Font("Calibri", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnViewPasswords.Location = new Point(357, 262);
            btnViewPasswords.Name = "btnViewPasswords";
            btnViewPasswords.Size = new Size(92, 32);
            btnViewPasswords.TabIndex = 4;
            btnViewPasswords.Text = "Passwords";
            btnViewPasswords.UseVisualStyleBackColor = true;
            btnViewPasswords.Click += btnViewPasswords_Click;
            // 
            // lblPasswordStrength
            // 
            lblPasswordStrength.AutoSize = true;
            lblPasswordStrength.Location = new Point(196, 185);
            lblPasswordStrength.Name = "lblPasswordStrength";
            lblPasswordStrength.Size = new Size(0, 14);
            lblPasswordStrength.TabIndex = 3;
            // 
            // PassGen_Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(498, 439);
            Controls.Add(pictureBox1);
            Controls.Add(mainPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(514, 478);
            MinimizeBox = false;
            MinimumSize = new Size(514, 478);
            Name = "PassGen_Main";
            Text = "PassGen";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnGenerate;
        private TextBox txtPassword;
        private Button btnSave;
        private PictureBox pictureBox1;
        private Panel mainPanel;
        private Label lblPasswordStrength;
        private Button btnViewPasswords;
    }
}