namespace PassGenTest
{
    partial class PassGenSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassGenSettingsForm));
            groupBox1 = new GroupBox();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            label1 = new Label();
            PasswordLengthSlider = new TrackBar();
            AdjustedPassLength = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PasswordLengthSlider).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox4);
            groupBox1.Controls.Add(checkBox3);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Location = new Point(36, 23);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(475, 120);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select Character Set";
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(275, 81);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(183, 19);
            checkBox4.TabIndex = 3;
            checkBox4.Text = "Special Symbols (#, @, $, etc.)";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(29, 81);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(103, 19);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "Numbers (0-9)";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(275, 22);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(146, 19);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "Lowercase Letters (a-z)";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(29, 22);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(150, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Uppercase Letters (A-Z)";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 201);
            label1.Name = "label1";
            label1.Size = new Size(137, 15);
            label1.TabIndex = 2;
            label1.Text = "Adjust Password Length:";
            // 
            // PasswordLengthSlider
            // 
            PasswordLengthSlider.Location = new Point(192, 201);
            PasswordLengthSlider.Maximum = 20;
            PasswordLengthSlider.Minimum = 6;
            PasswordLengthSlider.Name = "PasswordLengthSlider";
            PasswordLengthSlider.Size = new Size(204, 45);
            PasswordLengthSlider.TabIndex = 4;
            PasswordLengthSlider.Value = 6;
            PasswordLengthSlider.Scroll += trackBar1_Scroll;
            // 
            // AdjustedPassLength
            // 
            AdjustedPassLength.Location = new Point(259, 235);
            AdjustedPassLength.Name = "AdjustedPassLength";
            AdjustedPassLength.ReadOnly = true;
            AdjustedPassLength.Size = new Size(81, 23);
            AdjustedPassLength.TabIndex = 5;
            AdjustedPassLength.TextAlign = HorizontalAlignment.Center;
            // 
            // PassGenSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 472);
            Controls.Add(AdjustedPassLength);
            Controls.Add(PasswordLengthSlider);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PassGenSettingsForm";
            Text = "PassGen Settings";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PasswordLengthSlider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label label1;
        private TrackBar PasswordLengthSlider;
        private TextBox AdjustedPassLength;
    }
}