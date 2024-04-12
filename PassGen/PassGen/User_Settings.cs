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
        //Retrieves the status of the checkboxes and then retains them
        public int PasswordLength { get; private set; }
        public bool IncludeUppercase { get; private set; }
        public bool IncludeLowercase { get; private set; }
        public bool IncludeNumbers { get; private set; }
        public bool IncludeSpecialChars { get; private set; }

        public User_Settings()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //Applies the selected parameters to the algorithm and then generates the password
            PasswordLength = (int)numericUpDownLength.Value;
            IncludeUppercase = chkIncludeUppercase.Checked;
            IncludeLowercase = chkIncludeLowercase.Checked;
            IncludeNumbers = chkIncludeNumbers.Checked;
            IncludeSpecialChars = chkIncludeSpecialChars.Checked;

            //Confirms the user's choice
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
