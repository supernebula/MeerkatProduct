using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Serialization;

namespace OpenAPI.Models.Message
{
    public class SendMResult
    {
        [XmlIgnore]
        public static SendMResult Ok { get; private set; }

        [XmlIgnore]
        public static SendMResult SignFailed { get; private set; }

        [XmlIgnore]
        public static SendMResult Expire { get; private set; }

        static SendMResult()
        {
            Ok = new SendMResult() { Result = true, Code = (int)HttpStatusCode.OK, Message = "发送成功" };
            SignFailed = new SendMResult() { Result = false, Code = (int)HttpStatusCode.Forbidden, Message = "签名验证失败" };
            Expire = new SendMResult() { Result = false, Code = (int)HttpStatusCode.BadRequest, Message = "过期的请求" };
        }

        public bool Result { get; set; }

        public int Code { get; set; }

        public string Message { get; set; }
    }
}