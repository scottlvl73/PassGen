using System;
using System.Text;
using System.Windows.Forms;

namespace PassGen
{
    public partial class PassGen_Main : Form
    {
        private StrengthMeter strengthMeter;

        const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        const string numberChars = "0123456789";
        const string specialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";

        public User_Settings settingsForm;

        public PassGen_Main()
        {
            InitializeComponent();
            settingsForm = new User_Settings();
            strengthMeter = new StrengthMeter();
            // Used for adjusting the location of the custom drawn meter
            //Important for any UI changes
            strengthMeter.Location = new Point(160, 265);
            //Used for adjust the size of the custom drawn meter
            //Important for any UI changes
            strengthMeter.Size = new Size(200, 20);
            Controls.Add(strengthMeter);

            strengthMeter.BringToFront();
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

                // Calculate password strength
                int strength = CalculatePasswordStrength(password, includeUppercase, includeLowercase, includeNumbers, includeSpecialChars);

                // Updates the drawn strengthMeter every time the CalculatePasswordStrength function is called
                strengthMeter.Strength = strength;

                // Updates the password strength label when the UpdatePasswordStrengthLabel function is called
                UpdatePasswordStrengthLabel(strength);
            }
        }

        //Algorithm for determining password strength
        private int CalculatePasswordStrength(string password, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecialChars)
        {
            //Measures length
            int lengthScore = password.Length * 4;

            //Checks for a variety in character sets to determine strength
            //Uses uppercase, lowercase, numbers, and special character pools
            int diversityScore = 0;
            if (includeUppercase) diversityScore += 26;
            if (includeLowercase) diversityScore += 26;
            if (includeNumbers) diversityScore += 10;
            if (includeSpecialChars) diversityScore += 26;

            //Checks for uniqueness, will deduct points from strength if repeated characters are generated
            int repeatedCharScore = password.Length - password.Distinct().Count();
            //Multiplies the strength based on the variety of character types generated
            int diversityBonus = diversityScore == 0 ? 0 : (password.Length - repeatedCharScore) * 2;

            int strength = lengthScore + diversityBonus - repeatedCharScore;

            return strength;
        }

        //Function for updating the label under the strengthMeter
        private void UpdatePasswordStrengthLabel(int strength)
        {
            if (strength < 33)
            {
                lblPasswordStrength.Text = "Weak";
                lblPasswordStrength.ForeColor = Color.Red;
            }
            else if (strength < 66)
            {
                lblPasswordStrength.Text = "Average";
                lblPasswordStrength.ForeColor = Color.Orange;
            }
            else
            {
                lblPasswordStrength.Text = "Strong";
                lblPasswordStrength.ForeColor = Color.Green;
            }
        }

        public string GeneratePassword(int length, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecialChars)
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
            string message = "Are you sure you want to save this password?";
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
                string message_no = "Your password has not been saved.";
                MessageBox.Show(message_no);
            }


        }
    }
}