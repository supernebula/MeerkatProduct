using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Nebula.Utilities.Hash
{
    public static class HashUtility
    {
        public static string Md5(string input)
        {
            var md5Hasher = new MD5CryptoServiceProvider();
            var bytes = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            var sBuilder = new StringBuilder();
            var result = bytes.Select(b => string.Format("{0:x2}", b)).ToArray();
            var output = string.Join(string.Empty, result);
            return output;
        }
    }
}
