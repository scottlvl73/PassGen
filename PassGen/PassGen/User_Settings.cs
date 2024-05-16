using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassGen
{
    public partial class User_Settings : Form
    {

        // Properties to access control values
        public int PasswordLength
        {
            get => (int)numericUpDownLength.Value;
            set => numericUpDownLength.Value = value;
        }

        public bool IncludeUppercase
        {
            get => chkIncludeUppercase.Checked;
            set => chkIncludeUppercase.Checked = value;
        }

        public bool IncludeLowercase
        {
            get => chkIncludeLowercase.Checked;
            set => chkIncludeLowercase.Checked = value;
        }

        public bool IncludeNumbers
        {
            get => chkIncludeNumbers.Checked;
            set => chkIncludeNumbers.Checked = value;
        }

        public bool IncludeSpecialChars
        {
            get => chkIncludeSpecialChars.Checked;
            set => chkIncludeSpecialChars.Checked = value;
        }

        // Properties for toggling new features
        public bool ExcludeAmbiguousChars
        {
            get => chkExcludeAmbiguous.Checked;
            set => chkExcludeAmbiguous.Checked = value;
        }

        public bool AvoidRepeatingChars
        {
            get => chkAvoidRepeatingChars.Checked;
            set => chkAvoidRepeatingChars.Checked = value;
        }

        public User_Settings()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            // Loads user settings from Properties.Settings
            numericUpDownLength.Value = Properties.Settings.Default.PasswordLength;
            chkIncludeUppercase.Checked = Properties.Settings.Default.IncludeUppercase;
            chkIncludeLowercase.Checked = Properties.Settings.Default.IncludeLowercase;
            chkIncludeNumbers.Checked = Properties.Settings.Default.IncludeNumbers;
            chkIncludeSpecialChars.Checked = Properties.Settings.Default.IncludeSpecialChars;
            chkExcludeAmbiguous.Checked = Properties.Settings.Default.ExcludeAmbiguousChars;
            chkAvoidRepeatingChars.Checked = Properties.Settings.Default.AvoidRepeatingChars;
        }

        private void SaveSettings()
        {
            // Saves user settings to Properties.Settings
            Properties.Settings.Default.PasswordLength = (int)numericUpDownLength.Value;
            Properties.Settings.Default.IncludeUppercase = chkIncludeUppercase.Checked;
            Properties.Settings.Default.IncludeLowercase = chkIncludeLowercase.Checked;
            Properties.Settings.Default.IncludeNumbers = chkIncludeNumbers.Checked;
            Properties.Settings.Default.IncludeSpecialChars = chkIncludeSpecialChars.Checked;
            Properties.Settings.Default.ExcludeAmbiguousChars = chkExcludeAmbiguous.Checked;
            Properties.Settings.Default.AvoidRepeatingChars = chkAvoidRepeatingChars.Checked;
            Properties.Settings.Default.Save();
        }

        public void btnApply_Click(object sender, EventArgs e)
        {
            SaveSettings();
            //Applies the selected parameters to the algorithm and then generates the password
            DialogResult = DialogResult.OK;
            Close();
        }

        //Saves settings even if the user manually closes the form without hitting apply
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                SaveSettings();
            }
        }
    }
}
