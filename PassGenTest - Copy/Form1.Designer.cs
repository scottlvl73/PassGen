namespace PassGenTest
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            GenButton = new Button();
            PasswordBox = new TextBox();
            toolTip1 = new ToolTip(components);
            panel1 = new Panel();
            SettingsButton = new Button();
            SaveButton = new Button();
            PassGenLogo = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PassGenLogo).BeginInit();
            SuspendLayout();
            // 
            // GenButton
            // 
            GenButton.Location = new Point(117, 172);
            GenButton.Name = "GenButton";
            GenButton.Size = new Size(92, 32);
            GenButton.TabIndex = 1;
            GenButton.Text = "Generate";
            GenButton.UseVisualStyleBackColor = true;
            GenButton.Click += button1_Click;
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(86, 114);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.PlaceholderText = "Password will appear here...";
            PasswordBox.Size = new Size(253, 23);
            PasswordBox.TabIndex = 2;
            PasswordBox.TextAlign = HorizontalAlignment.Center;
            PasswordBox.TextChanged += textBox1_TextChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(SettingsButton);
            panel1.Controls.Add(SaveButton);
            panel1.Controls.Add(PasswordBox);
            panel1.Controls.Add(GenButton);
            panel1.Location = new Point(42, 102);
            panel1.Name = "panel1";
            panel1.Size = new Size(418, 342);
            panel1.TabIndex = 3;
            // 
            // SettingsButton
            // 
            SettingsButton.Location = new Point(215, 172);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(84, 32);
            SettingsButton.TabIndex = 4;
            SettingsButton.Text = "Settings";
            SettingsButton.UseVisualStyleBackColor = true;
            SettingsButton.Click += button1_Click_1;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(165, 237);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(92, 26);
            SaveButton.TabIndex = 3;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += button2_Click;
            // 
            // PassGenLogo
            // 
            PassGenLogo.Image = Properties.Resources.passgenlogotransparent1;
            PassGenLogo.Location = new Point(-2, -3);
            PassGenLogo.Name = "PassGenLogo";
            PassGenLogo.Size = new Size(503, 99);
            PassGenLogo.SizeMode = PictureBoxSizeMode.CenterImage;
            PassGenLogo.TabIndex = 4;
            PassGenLogo.TabStop = false;
            PassGenLogo.Click += pictureBox1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 478);
            Controls.Add(PassGenLogo);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "PassGen";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PassGenLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button GenButton;
        private TextBox PasswordBox;
        private ToolTip toolTip1;
        private Panel panel1;
        private Button SaveButton;
        private PictureBox PassGenLogo;
        private Button SettingsButton;
    }
}