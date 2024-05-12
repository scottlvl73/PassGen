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
            string connectionString = "Data Source=myDatabase.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT ID, EncryptedPassword, AESKey, IV FROM Passwords";
                using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        savedPasswordsListBox.Items.Clear();

                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string encryptedPassword = reader["EncryptedPassword"].ToString();
                            string aesKeyString = reader["AESKey"].ToString();
                            string ivString = reader["IV"].ToString();

                            byte[] encryptedPasswordBytes = Convert.FromBase64String(encryptedPassword);
                            byte[] aesKey = Convert.FromBase64String(aesKeyString);
                            byte[] iv = Convert.FromBase64String(ivString);

                            string decryptedPassword = Recrypt.Decrypt(encryptedPasswordBytes, aesKey, iv);

                            savedPasswordsListBox.Items.Add(new PasswordItem(id, encryptedPassword, aesKeyString, ivString, decryptedPassword));
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
            if (savedPasswordsListBox.SelectedItem != null)
            {
                string confirmationMessage = "Are you sure you want to delete this password? This action cannot be undone and the password will be permanently lost.";
                string confirmationTitle = "Confirm Deletion";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(confirmationMessage, confirmationTitle, buttons, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string connectionString = "Data Source=myDatabase.db;Version=3;";
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        PasswordItem selectedPassword = (PasswordItem)savedPasswordsListBox.SelectedItem;

                        string clearQuery = "DELETE FROM Passwords WHERE ID = @id";
                        using (SQLiteCommand command = new SQLiteCommand(clearQuery, connection))
                        {
                            command.Parameters.AddWithValue("@id", selectedPassword.ID);
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
        //Class that holds the ID for the DB & the encrypted password
        //Allows for the modified query to only delete selected passwords from the table
        public class PasswordItem
        {
            public int ID { get; }
            public string EncryptedPassword { get; }
            public string AESKey { get; }
            public string IV { get; }
            public string DecryptedPassword { get; }

            public PasswordItem(int id, string encryptedPassword, string aesKey, string iv, string decryptedPassword)
            {
                ID = id;
                EncryptedPassword = encryptedPassword;
                AESKey = aesKey;
                IV = iv;
                DecryptedPassword = decryptedPassword;
            }

            public override string ToString()
            {
                return DecryptedPassword;
            }
        }
        //Displays additional information about the selected password
        //Includes the ID, Encrypted and Decrypted versions, the AES key, and the IV
        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (savedPasswordsListBox.SelectedItem != null)
            {
                PasswordItem selectedPassword = (PasswordItem)savedPasswordsListBox.SelectedItem;

                string message = $"ID: {selectedPassword.ID}\n" +
                                 $"Encrypted Password: {selectedPassword.EncryptedPassword}\n" +
                                 $"Decrypted Password: {selectedPassword.DecryptedPassword}\n" +
                                 $"AES Key: {selectedPassword.AESKey}\n" +
                                 $"IV: {selectedPassword.IV}";

                MessageBox.Show(message, "Password Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a password to view details.", "No Password Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void passwordHistoryExportBtn_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to choose the export file location
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv";
            saveFileDialog.Title = "Export Passwords";
            saveFileDialog.FileName = "passwords";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Open the selected file for writing
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    // Write each decrypted password from the list to the file
                    foreach (PasswordItem passwordItem in savedPasswordsListBox.Items)
                    {
                        writer.WriteLine(passwordItem.DecryptedPassword);
                    }
                }

                MessageBox.Show("Passwords exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
