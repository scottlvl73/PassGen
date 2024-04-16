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

        public User_Settings()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //Applies the selected parameters to the algorithm and then generates the password
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
