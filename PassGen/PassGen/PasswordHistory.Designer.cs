namespace PassGen
{
    partial class PasswordHistory
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
            savedPasswordsListBox = new ListBox();
            passwordHistoryCopyBtn = new Button();
            passwordHistoryDeleteBtn = new Button();
            btnDetails = new Button();
            passwordHistoryExportBtn = new Button();
            SuspendLayout();
            // 
            // savedPasswordsListBox
            // 
            savedPasswordsListBox.FormattingEnabled = true;
            savedPasswordsListBox.ItemHeight = 15;
            savedPasswordsListBox.Location = new Point(35, 26);
            savedPasswordsListBox.Name = "savedPasswordsListBox";
            savedPasswordsListBox.Size = new Size(327, 319);
            savedPasswordsListBox.TabIndex = 0;
            // 
            // passwordHistoryCopyBtn
            // 
            passwordHistoryCopyBtn.Location = new Point(35, 390);
            passwordHistoryCopyBtn.Name = "passwordHistoryCopyBtn";
            passwordHistoryCopyBtn.Size = new Size(75, 23);
            passwordHistoryCopyBtn.TabIndex = 1;
            passwordHistoryCopyBtn.Text = "Copy";
            passwordHistoryCopyBtn.UseVisualStyleBackColor = true;
            passwordHistoryCopyBtn.Click += passwordHistoryCopyBtn_Click;
            // 
            // passwordHistoryDeleteBtn
            // 
            passwordHistoryDeleteBtn.Location = new Point(287, 390);
            passwordHistoryDeleteBtn.Name = "passwordHistoryDeleteBtn";
            passwordHistoryDeleteBtn.Size = new Size(75, 23);
            passwordHistoryDeleteBtn.TabIndex = 2;
            passwordHistoryDeleteBtn.Text = "Delete";
            passwordHistoryDeleteBtn.UseVisualStyleBackColor = true;
            passwordHistoryDeleteBtn.Click += passwordHistoryDeleteBtn_Click;
            // 
            // btnDetails
            // 
            btnDetails.Location = new Point(116, 390);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(75, 23);
            btnDetails.TabIndex = 3;
            btnDetails.Text = "Details";
            btnDetails.UseVisualStyleBackColor = true;
            btnDetails.Click += btnDetails_Click;
            // 
            // passwordHistoryExportBtn
            // 
            passwordHistoryExportBtn.Location = new Point(206, 390);
            passwordHistoryExportBtn.Name = "passwordHistoryExportBtn";
            passwordHistoryExportBtn.Size = new Size(75, 23);
            passwordHistoryExportBtn.TabIndex = 4;
            passwordHistoryExportBtn.Text = "Export";
            passwordHistoryExportBtn.UseVisualStyleBackColor = true;
            passwordHistoryExportBtn.Click += passwordHistoryExportBtn_Click;
            // 
            // PasswordHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(395, 450);
            Controls.Add(passwordHistoryExportBtn);
            Controls.Add(btnDetails);
            Controls.Add(passwordHistoryDeleteBtn);
            Controls.Add(passwordHistoryCopyBtn);
            Controls.Add(savedPasswordsListBox);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "PasswordHistory";
            Text = "Saved Passwords";
            ResumeLayout(false);
        }

        #endregion

        public ListBox savedPasswordsListBox;
        private Button passwordHistoryCopyBtn;
        private Button passwordHistoryDeleteBtn;
        private Button btnDetails;
        private Button passwordHistoryExportBtn;
    }
}