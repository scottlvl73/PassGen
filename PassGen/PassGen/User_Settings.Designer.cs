namespace PassGen
{
    partial class User_Settings
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
            btnApply = new Button();
            numericUpDownLength = new NumericUpDown();
            chkIncludeUppercase = new CheckBox();
            chkIncludeLowercase = new CheckBox();
            chkIncludeNumbers = new CheckBox();
            chkIncludeSpecialChars = new CheckBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLength).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnApply
            // 
            btnApply.Location = new Point(434, 265);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(75, 23);
            btnApply.TabIndex = 0;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // numericUpDownLength
            // 
            numericUpDownLength.Location = new Point(389, 164);
            numericUpDownLength.Name = "numericUpDownLength";
            numericUpDownLength.Size = new Size(120, 23);
            numericUpDownLength.TabIndex = 1;
            // 
            // chkIncludeUppercase
            // 
            chkIncludeUppercase.AutoSize = true;
            chkIncludeUppercase.Location = new Point(26, 31);
            chkIncludeUppercase.Name = "chkIncludeUppercase";
            chkIncludeUppercase.Size = new Size(156, 19);
            chkIncludeUppercase.TabIndex = 2;
            chkIncludeUppercase.Text = "Uppercase Letters (A - Z)";
            chkIncludeUppercase.UseVisualStyleBackColor = true;
            // 
            // chkIncludeLowercase
            // 
            chkIncludeLowercase.AutoSize = true;
            chkIncludeLowercase.Location = new Point(256, 31);
            chkIncludeLowercase.Name = "chkIncludeLowercase";
            chkIncludeLowercase.Size = new Size(152, 19);
            chkIncludeLowercase.TabIndex = 3;
            chkIncludeLowercase.Text = "Lowercase Letters (a - z)";
            chkIncludeLowercase.UseVisualStyleBackColor = true;
            // 
            // chkIncludeNumbers
            // 
            chkIncludeNumbers.AutoSize = true;
            chkIncludeNumbers.Location = new Point(26, 85);
            chkIncludeNumbers.Name = "chkIncludeNumbers";
            chkIncludeNumbers.Size = new Size(109, 19);
            chkIncludeNumbers.TabIndex = 4;
            chkIncludeNumbers.Text = "Numbers (0 - 9)";
            chkIncludeNumbers.UseVisualStyleBackColor = true;
            // 
            // chkIncludeSpecialChars
            // 
            chkIncludeSpecialChars.AutoSize = true;
            chkIncludeSpecialChars.Location = new Point(256, 85);
            chkIncludeSpecialChars.Name = "chkIncludeSpecialChars";
            chkIncludeSpecialChars.Size = new Size(183, 19);
            chkIncludeSpecialChars.TabIndex = 5;
            chkIncludeSpecialChars.Text = "Special Symbols (#, @, $, etc.)";
            chkIncludeSpecialChars.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkIncludeUppercase);
            groupBox1.Controls.Add(chkIncludeSpecialChars);
            groupBox1.Controls.Add(chkIncludeLowercase);
            groupBox1.Controls.Add(chkIncludeNumbers);
            groupBox1.Location = new Point(34, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(475, 120);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select Character Set";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 166);
            label1.Name = "label1";
            label1.Size = new Size(140, 15);
            label1.TabIndex = 7;
            label1.Text = "Adjust Password Length: ";
            // 
            // User_Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 300);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(numericUpDownLength);
            Controls.Add(btnApply);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "User_Settings";
            Text = "Password Settings";
            ((System.ComponentModel.ISupportInitialize)numericUpDownLength).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnApply;
        private NumericUpDown numericUpDownLength;
        private CheckBox chkIncludeUppercase;
        private CheckBox chkIncludeLowercase;
        private CheckBox chkIncludeNumbers;
        private CheckBox chkIncludeSpecialChars;
        private GroupBox groupBox1;
        private Label label1;
    }
}