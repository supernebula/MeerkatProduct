using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Utilities.Security
{
    public class Signature
    {
        public static string Sign(IDictionary<string, string> parameters, string secret)
        {
            var sortedParams = new SortedDictionary<string, string>(parameters);
            var query = new StringBuilder(secret);
            foreach (KeyValuePair<string, string> kv in sortedParams)
            {
                if (String.IsNullOrWhiteSpace(kv.Value))
                    continue;
                query.Append(kv.Key).Append(kv.Value);
            }
            var value = Hash.MD5Encrypt(query.ToString());
            return value;
        }

        public static bool IsValidTimestamp(string timestamp, double expireMinutes = 15)
        {
            DateTime time;
            try
            {
                time = DateTime.ParseExact(timestamp, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                return false;
            }
            
            if (time.AddMinutes(expireMinutes) < DateTime.Now)
                return false;
            return true;
        }
    }
}
