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

        private readonly ISettings _settings;

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

        public User_Settings(ISettings settings)
        {
            _settings = settings;
            InitializeComponent();
            LoadSettings();
        }

        public void LoadSettings()
        {
            // Loads user settings from Properties.Settings
            numericUpDownLength.Value = _settings.PasswordLength;
            chkIncludeUppercase.Checked = _settings.IncludeUppercase;
            chkIncludeLowercase.Checked = _settings.IncludeLowercase;
            chkIncludeNumbers.Checked = _settings.IncludeNumbers;
            chkIncludeSpecialChars.Checked = _settings.IncludeSpecialChars;
            chkExcludeAmbiguous.Checked = _settings.ExcludeAmbiguousChars;
            chkAvoidRepeatingChars.Checked = _settings.AvoidRepeatingChars;
        }

        public void SaveSettings()
        {
            // Saves user settings to Properties.Settings
            _settings.PasswordLength = (int)numericUpDownLength.Value;
            _settings.IncludeUppercase = chkIncludeUppercase.Checked;
            _settings.IncludeLowercase = chkIncludeLowercase.Checked;
            _settings.IncludeNumbers = chkIncludeNumbers.Checked;
            _settings.IncludeSpecialChars = chkIncludeSpecialChars.Checked;
            _settings.ExcludeAmbiguousChars = chkExcludeAmbiguous.Checked;
            _settings.AvoidRepeatingChars = chkAvoidRepeatingChars.Checked;
            _settings.Save();
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
