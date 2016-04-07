using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAPI.Core.API
{
    public interface IApiParameter
    {
        /// <summary>
        /// AppKey
        /// </summary>
        string Key { get; set; }
        /// <summary>
        /// MD5 Sign
        /// </summary>
        string Sign { get; set; }

        /// <summary>
        /// 时间戳 yyyyMMddHHmmss
        /// </summary>
        string Timestamp { get; set; }

        /// <summary>
        /// 随机数
        /// </summary>
        string Nonce { get; set; }
    }
}
