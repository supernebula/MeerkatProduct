using OpenAPI.Models;
using OpenAPI.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Nebula.Utilities.Security;
using System.Web.Http;

namespace OpenAPI.Controllers
{
    [Route("api/Message")]

    public class MessageController : ApiController
    {

        string AppKey1 = "SISS";
        string AppSecret1 = "SECRETVALUE";

        // POST: api/Message
        [Route("Single")]
        public SendMessageResult PostSingle([FromBody]SingleUserParameter param)
        {
            var paramDic = new Dictionary<string, string>();
            paramDic.Add("SiUserId", param.SiUserId);
            paramDic.Add("Content", param.Content);
            paramDic.Add("Timestamp", param.Timestamp);
            paramDic.Add("Nonce", param.Nonce);
            if (param.Sign != Signature.Sign(paramDic, AppSecret1))
                return SendMessageResult.SignFailed;
            if (!Signature.IsValidTimestamp(param.Timestamp))
                return SendMessageResult.Expire;
            return SendMessageResult.Ok;
        }




    }



}
