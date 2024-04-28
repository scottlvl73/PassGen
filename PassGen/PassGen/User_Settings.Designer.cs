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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_Settings));
            btnApply = new Button();
            numericUpDownLength = new NumericUpDown();
            chkIncludeUppercase = new CheckBox();
            chkIncludeLowercase = new CheckBox();
            chkIncludeNumbers = new CheckBox();
            chkIncludeSpecialChars = new CheckBox();
            groupBox1 = new GroupBox();
            chkAvoidRepeatingChars = new CheckBox();
            chkExcludeAmbiguous = new CheckBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLength).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnApply
            // 
            btnApply.BackColor = SystemColors.InactiveCaption;
            btnApply.Font = new Font("Calibri", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnApply.Location = new Point(496, 353);
            btnApply.Margin = new Padding(3, 4, 3, 4);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(86, 31);
            btnApply.TabIndex = 0;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Click += btnApply_Click;
            // 
            // numericUpDownLength
            // 
            numericUpDownLength.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            numericUpDownLength.Location = new Point(494, 273);
            numericUpDownLength.Margin = new Padding(3, 5, 3, 5);
            numericUpDownLength.Name = "numericUpDownLength";
            numericUpDownLength.Size = new Size(88, 28);
            numericUpDownLength.TabIndex = 1;
            // 
            // chkIncludeUppercase
            // 
            chkIncludeUppercase.AutoSize = true;
            chkIncludeUppercase.Location = new Point(30, 41);
            chkIncludeUppercase.Margin = new Padding(3, 4, 3, 4);
            chkIncludeUppercase.Name = "chkIncludeUppercase";
            chkIncludeUppercase.Size = new Size(182, 22);
            chkIncludeUppercase.TabIndex = 2;
            chkIncludeUppercase.Text = "Uppercase Letters (A - Z)";
            chkIncludeUppercase.UseVisualStyleBackColor = true;
            // 
            // chkIncludeLowercase
            // 
            chkIncludeLowercase.AutoSize = true;
            chkIncludeLowercase.Location = new Point(293, 41);
            chkIncludeLowercase.Margin = new Padding(3, 4, 3, 4);
            chkIncludeLowercase.Name = "chkIncludeLowercase";
            chkIncludeLowercase.Size = new Size(178, 22);
            chkIncludeLowercase.TabIndex = 3;
            chkIncludeLowercase.Text = "Lowercase Letters (a - z)";
            chkIncludeLowercase.UseVisualStyleBackColor = true;
            // 
            // chkIncludeNumbers
            // 
            chkIncludeNumbers.AutoSize = true;
            chkIncludeNumbers.Location = new Point(30, 113);
            chkIncludeNumbers.Margin = new Padding(3, 4, 3, 4);
            chkIncludeNumbers.Name = "chkIncludeNumbers";
            chkIncludeNumbers.Size = new Size(125, 22);
            chkIncludeNumbers.TabIndex = 4;
            chkIncludeNumbers.Text = "Numbers (0 - 9)";
            chkIncludeNumbers.UseVisualStyleBackColor = true;
            // 
            // chkIncludeSpecialChars
            // 
            chkIncludeSpecialChars.AutoSize = true;
            chkIncludeSpecialChars.Location = new Point(293, 113);
            chkIncludeSpecialChars.Margin = new Padding(3, 4, 3, 4);
            chkIncludeSpecialChars.Name = "chkIncludeSpecialChars";
            chkIncludeSpecialChars.Size = new Size(226, 22);
            chkIncludeSpecialChars.TabIndex = 5;
            chkIncludeSpecialChars.Text = "Special Characters (#, @, $, etc.)";
            chkIncludeSpecialChars.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkAvoidRepeatingChars);
            groupBox1.Controls.Add(chkExcludeAmbiguous);
            groupBox1.Controls.Add(chkIncludeUppercase);
            groupBox1.Controls.Add(chkIncludeSpecialChars);
            groupBox1.Controls.Add(chkIncludeLowercase);
            groupBox1.Controls.Add(chkIncludeNumbers);
            groupBox1.Font = new Font("Calibri", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(39, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(543, 249);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select Character Set";
            // 
            // chkAvoidRepeatingChars
            // 
            chkAvoidRepeatingChars.AutoSize = true;
            chkAvoidRepeatingChars.Location = new Point(293, 192);
            chkAvoidRepeatingChars.Margin = new Padding(3, 4, 3, 4);
            chkAvoidRepeatingChars.Name = "chkAvoidRepeatingChars";
            chkAvoidRepeatingChars.Size = new Size(200, 22);
            chkAvoidRepeatingChars.TabIndex = 7;
            chkAvoidRepeatingChars.Text = "Avoid Repeating Characters";
            chkAvoidRepeatingChars.UseVisualStyleBackColor = true;
            // 
            // chkExcludeAmbiguous
            // 
            chkExcludeAmbiguous.AutoSize = true;
            chkExcludeAmbiguous.Location = new Point(30, 192);
            chkExcludeAmbiguous.Margin = new Padding(3, 4, 3, 4);
            chkExcludeAmbiguous.Name = "chkExcludeAmbiguous";
            chkExcludeAmbiguous.Size = new Size(219, 22);
            chkExcludeAmbiguous.TabIndex = 6;
            chkExcludeAmbiguous.Text = "Exclude Ambiguous Characters";
            chkExcludeAmbiguous.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(326, 277);
            label1.Name = "label1";
            label1.Size = new Size(162, 18);
            label1.TabIndex = 7;
            label1.Text = "Adjust Password Length: ";
            // 
            // User_Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(623, 400);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(numericUpDownLength);
            Controls.Add(btnApply);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
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
        private CheckBox chkAvoidRepeatingChars;
        private CheckBox chkExcludeAmbiguous;
    }
}