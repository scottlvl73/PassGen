using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassGen;

namespace TestUserPrefs
{
    public class MockSettings : ISettings
    {
        public int PasswordLength { get; set; }
        public bool IncludeUppercase { get; set; }
        public bool IncludeLowercase { get; set; }
        public bool IncludeNumbers { get; set; }
        public bool IncludeSpecialChars { get; set; }
        public bool ExcludeAmbiguousChars { get; set; }
        public bool AvoidRepeatingChars { get; set; }

        public void Save()
        {
            // Mock implementation. In unit tests, this can be left empty or used to verify the method is called.
        }

        public void Reload()
        {
            // Mock implementation. Can be left empty or used to reset properties to some default state.
        }
    }

}
