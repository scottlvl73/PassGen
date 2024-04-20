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
            lblPasswordStrength = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(167, 218);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(92, 32);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(84, 129);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password will appear here...";
            txtPassword.ReadOnly = true;
            txtPassword.Size = new Size(253, 23);
            txtPassword.TabIndex = 1;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(321, 305);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(92, 32);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.passgenlogotransparent1;
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(503, 99);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // mainPanel
            // 
            mainPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(lblPasswordStrength);
            mainPanel.Controls.Add(txtPassword);
            mainPanel.Controls.Add(btnGenerate);
            mainPanel.Controls.Add(btnSave);
            mainPanel.Location = new Point(45, 104);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(418, 342);
            mainPanel.TabIndex = 4;
            // 
            // lblPasswordStrength
            // 
            lblPasswordStrength.AutoSize = true;
            lblPasswordStrength.Location = new Point(196, 185);
            lblPasswordStrength.Name = "lblPasswordStrength";
            lblPasswordStrength.Size = new Size(0, 15);
            lblPasswordStrength.TabIndex = 3;
            // 
            // PassGen_Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 478);
            Controls.Add(pictureBox1);
            Controls.Add(mainPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
    }
}