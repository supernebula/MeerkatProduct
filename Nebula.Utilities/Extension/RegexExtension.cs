using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nebula.Utilities.Extension
{
    public static class RegexExtension
    {
        public static bool NotEqual(string source, string str)
        {
            var regex = new Regex(string.Format("{0}", str));
            var assert = regex.Match(source).Success;
            return assert;
        }
    }
}
