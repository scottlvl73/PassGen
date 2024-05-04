using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassGen
{
    public partial class PasswordHistory : Form
    {
        public PasswordHistory()
        {
            InitializeComponent();

            // Populate password history when the form is loaded

            PopulatePasswordHistory();
        }

        private void PopulatePasswordHistory()
        {
            // Connect to the database
            string connectionString = "Data Source=myDatabase.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Retrieve saved passwords from the local database
                string selectQuery = "SELECT EncryptedPassword, AESKey, IV FROM Passwords";
                using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // Clear existing items in the listbox
                        savedPasswordsListBox.Items.Clear();

                        while (reader.Read())
                        {
                            string encryptedPassword = reader["EncryptedPassword"].ToString();
                            string aesKeyString = reader["AESKey"].ToString();
                            string ivString = reader["IV"].ToString();

                            byte[] encryptedPasswordBytes = Convert.FromBase64String(encryptedPassword);
                            byte[] aesKey = Convert.FromBase64String(aesKeyString);
                            byte[] iv = Convert.FromBase64String(ivString);

                            // Decrypt the password
                            string decryptedPassword = Recrypt.Decrypt(encryptedPasswordBytes, aesKey, iv);

                            // Add decrypted password to the listbox
                            savedPasswordsListBox.Items.Add(decryptedPassword);
                        }
                    }
                }
            }
        }

        private void passwordHistoryCopyBtn_Click(object sender, EventArgs e)
        {
            // Copy selected password to clipboard
            if (savedPasswordsListBox.SelectedItem != null)
            {
                Clipboard.SetText(savedPasswordsListBox.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Please select a password to copy.", "No Password Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void passwordHistoryDeleteBtn_Click(object sender, EventArgs e)
        {
            // Check if a password is selected
            if (savedPasswordsListBox.SelectedItem != null)
            {
                // Display a confirmation dialog box
                string confirmationMessage = "Are you sure you want to delete this password? This action cannot be undone and the password will be permanently lost.";
                string confirmationTitle = "Confirm Deletion";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(confirmationMessage, confirmationTitle, buttons, MessageBoxIcon.Warning);

                // If the user confirms deletion, proceed with deletion
                if (result == DialogResult.Yes)
                {
                    // Connect to the database
                    string connectionString = "Data Source=myDatabase.db;Version=3;";
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        string selectedPassword = savedPasswordsListBox.SelectedItem.ToString();

                        // Delete the password from the database
                        string clearQuery = "DELETE FROM Passwords WHERE EncryptedPassword = @encryptedPassword";
                        using (SQLiteCommand command = new SQLiteCommand(clearQuery, connection))
                        {
                            command.Parameters.AddWithValue("@encryptedPassword", selectedPassword);
                            command.ExecuteNonQuery();
                        }
                    }

                    // Refresh the password history list after deletion
                    PopulatePasswordHistory();
                }
            }
            else
            {
                MessageBox.Show("Please select a password to delete.", "No Password Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
