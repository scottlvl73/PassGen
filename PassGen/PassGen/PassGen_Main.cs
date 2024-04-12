using System;
using System.Text;
using System.Windows.Forms;

namespace PassGen
{
    public partial class PassGen_Main : Form
    {
        private User_Settings settingsForm;

        public PassGen_Main()
        {
            InitializeComponent();
            settingsForm = new User_Settings();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                int length = settingsForm.PasswordLength;
                bool includeUppercase = settingsForm.IncludeUppercase;
                bool includeLowercase = settingsForm.IncludeLowercase;
                bool includeNumbers = settingsForm.IncludeNumbers;
                bool includeSpecialChars = settingsForm.IncludeSpecialChars;

                // Calls the GeneratePassword method to generate a password based on specified parameters
                string password = GeneratePassword(length, includeUppercase, includeLowercase, includeNumbers, includeSpecialChars);

                // Shows the user's generated password in the main textbox
                txtPassword.Text = password;
            }
        }



        private string GeneratePassword(int length, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecialChars)
        {
            const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            const string numberChars = "0123456789";
            const string specialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            // Uses the specified characters to generate a pool of available selections
            string charPool = "";
            if (includeUppercase)
                charPool += uppercaseChars;
            if (includeLowercase)
                charPool += lowercaseChars;
            if (includeNumbers)
                charPool += numberChars;
            if (includeSpecialChars)
                charPool += specialChars;

            // Generate the password
            for (int i = 0; i < length; i++)
            {
                // Choose a random character from the pool
                int index = random.Next(0, charPool.Length);
                password.Append(charPool[index]);
            }

            return password.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Alerts the user that their password has been saved
            string message = "Are your sure you want to save this password?";
            string title = "Save";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string message_save = "Your password has been saved!";
                MessageBox.Show(message_save);

                //Code for submitting the textbox data to the DB should go here
                //Currently non-functional
            }
            else
            {
                string message_no = "Your password has not been saved...";
                MessageBox.Show(message_no);
            }

            
        }
    }
}