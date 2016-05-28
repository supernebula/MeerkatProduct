using System.Text.RegularExpressions;

namespace Nebula.Utilities.Extension
{
    public static class RegexExtension
    {
        public static bool NotEqual(string source, string str)
        {
            var regex = new Regex($"{str}");
            var assert = regex.Match(source).Success;
            return assert;
        }
    }
}
