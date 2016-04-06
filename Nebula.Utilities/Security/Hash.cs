using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Utilities.Security
{
    public static class Hash
    {
        public static string MD5Encrypt(string str)
        {
            var md5 = MD5.Create();
            var encoding = new UTF8Encoding();
            byte[] val = md5.ComputeHash(encoding.GetBytes(str));
            var result = BitConverter.ToString(val).Replace("-", "").ToUpper();
            return result;
        }
    }
}
