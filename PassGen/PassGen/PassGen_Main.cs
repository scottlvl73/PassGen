using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace PassGen
{
    public partial class PassGen_Main : Form
    {
        private StrengthMeter strengthMeter;
        private Random random = new Random();

        const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        const string numberChars = "0123456789";
        const string specialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";
        const string ambiguousChars = "il1Lo0O";

        public User_Settings settingsForm;

        public PassGen_Main()
        {
            InitializeComponent();
            settingsForm = new User_Settings();
            strengthMeter = new StrengthMeter();
            // Used for adjusting the location of the custom drawn meter
            //Important for any UI changes
            strengthMeter.Location = new Point(155, 295);
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

                // Check if password length is at least 1
                if (length < 1)
                {
                    MessageBox.Show("Please select a minimum length of 1 for your password.", "Invalid Password Length", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit the method without further execution
                }

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
        /// <summary>
        /// Algorithm for determining password strength through the various controls provided to the user
        /// </summary>
        /// <param name="password">this is the password generated length</param>
        /// <param name="includeUppercase">whether the user decided to include upper case letters</param>
        /// <param name="includeLowercase">whether the user decided to include lowercase letters</param>
        /// <param name="includeNumbers">whether the user decided to include numerals</param>
        /// <param name="includeSpecialChars">whether the user decided to include special characters</param>
        /// <returns>the strength of the password</returns>
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
                lblPasswordStrength.Text = "WEAK";
                lblPasswordStrength.ForeColor = Color.Red;
            }
            else if (strength < 66)
            {
                lblPasswordStrength.Text = "AVERAGE";
                lblPasswordStrength.ForeColor = Color.Orange;
            }
            else
            {
                lblPasswordStrength.Text = "STRONG";
                lblPasswordStrength.ForeColor = Color.Green;
            }
        }
        /// <summary>
        /// The GeneratePassword method checks the whether the checkboxs were turned on for all user controls and then generates a password with the user enabled parameters.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="includeUppercase">whether the user decided to include upper case letters</param>
        /// <param name="includeLowercase">whether the user decided to include lowercase letters</param>
        /// <param name="includeNumbers">whether the user decided to include numerals</param>
        /// <param name="includeSpecialChars">whether the user decided to include special characters</param>
        /// /// <returns></returns>
        public string GeneratePassword(int length, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecialChars)
        {

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

            // Check if the length of charPool is less than the desired password length
            if (charPool.Length < length)
            {
                MessageBox.Show("The selected character set is too small to generate a password of the desired length.", "Invalid Character Set", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ""; // Return an empty string to indicate failure
            }

            // Remove ambiguous characters from the character pool
            foreach (char ambiguousChar in ambiguousChars)
            {
                charPool = charPool.Replace(ambiguousChar.ToString(), "");
            }

            char lastChar = '\0';
            int consecutiveCount = 0;

            // Generate the password
            for (int i = 0; i < length; i++)
            {
                // Choose a random character from the pool
                int index = random.Next(0, charPool.Length);
                char selectedChar = charPool[index];

                // Check for consecutive characters
                if (selectedChar == lastChar)
                {
                    consecutiveCount++;
                    if (consecutiveCount > 2)
                    {
                        // Choose a different character if more than two consecutive characters
                        while (selectedChar == lastChar)
                        {
                            index = random.Next(0, charPool.Length);
                            selectedChar = charPool[index];
                        }
                        consecutiveCount = 0;
                    }
                }
                else
                {
                    consecutiveCount = 0;
                }

                // Append selected character to the password
                password.Append(selectedChar);
                lastChar = selectedChar;
            }

            return password.ToString();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            //encrypt the password using Recrypt Class
            byte[] key = new byte[16];
            byte[] iv = new byte[16];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
                rng.GetBytes(iv);

            }
            string message = "Are you sure you want to save this password?";
            string title = "Save";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string passWord = txtPassword.Text;
            byte[] encryptedPassword = Recrypt.Encrypt(passWord, key, iv);
            string encryptedPasswordString = Convert.ToBase64String(encryptedPassword);


            string message_save = "Your password has been saved!\n \n" + passWord + "\n \n Your encrypted Password \n \n" + encryptedPasswordString + "\n \n Your AES Key \n \n" + Convert.ToBase64String(key) + "\n \n your Insertion Vector is \n \n" + Convert.ToBase64String(iv);
            MessageBox.Show(message_save);
            Clipboard.SetText(encryptedPasswordString + "\n" + Convert.ToBase64String(key) + "\n" + Convert.ToBase64String(iv));

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