using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassGen
{
    public interface ISettings
    {
        int PasswordLength { get; set; }
        bool IncludeUppercase { get; set; }
        bool IncludeLowercase { get; set; }
        bool IncludeNumbers { get; set; }
        bool IncludeSpecialChars { get; set; }
        bool ExcludeAmbiguousChars { get; set; }
        bool AvoidRepeatingChars { get; set; }
        void Save();
    }
}

