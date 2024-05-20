using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassGen
{
    public class SettingsWrapper : ISettings
    {
        public int PasswordLength
        {
            get => Properties.Settings.Default.PasswordLength;
            set => Properties.Settings.Default.PasswordLength = value;
        }

        public bool IncludeUppercase
        {
            get => Properties.Settings.Default.IncludeUppercase;
            set => Properties.Settings.Default.IncludeUppercase = value;
        }

        public bool IncludeLowercase
        {
            get => Properties.Settings.Default.IncludeLowercase;
            set => Properties.Settings.Default.IncludeLowercase = value;
        }

        public bool IncludeNumbers
        {
            get => Properties.Settings.Default.IncludeNumbers;
            set => Properties.Settings.Default.IncludeNumbers = value;
        }

        public bool IncludeSpecialChars
        {
            get => Properties.Settings.Default.IncludeSpecialChars;
            set => Properties.Settings.Default.IncludeSpecialChars = value;
        }

        public bool ExcludeAmbiguousChars
        {
            get => Properties.Settings.Default.ExcludeAmbiguousChars;
            set => Properties.Settings.Default.ExcludeAmbiguousChars = value;
        }

        public bool AvoidRepeatingChars
        {
            get => Properties.Settings.Default.AvoidRepeatingChars;
            set => Properties.Settings.Default.AvoidRepeatingChars = value;
        }

        public void Save()
        {
            Properties.Settings.Default.Save();
        }
    }
}

