using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Serialization;

namespace OpenAPI.Models.Message
{
    public class SendMessageResult
    {
        [XmlIgnore]
        public static SendMessageResult Ok { get; private set; }

        [XmlIgnore]
        public static SendMessageResult SignFailed { get; private set; }

        [XmlIgnore]
        public static SendMessageResult Expire { get; private set; }

        static SendMessageResult()
        {
            Ok = new SendMessageResult() { Result = true, Code = (int)HttpStatusCode.OK, Message = "发送成功" };
            SignFailed = new SendMessageResult() { Result = false, Code = (int)HttpStatusCode.Forbidden, Message = "签名验证失败" };
            Expire = new SendMessageResult() { Result = false, Code = (int)HttpStatusCode.BadRequest, Message = "过期的请求" };
        }

        public bool Result { get; set; }

        public int Code { get; set; }

        public string Message { get; set; }
    }
}