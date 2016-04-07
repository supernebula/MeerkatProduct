﻿using OpenAPI.Models.Message;
using System;
using System.Collections.Generic;
using Nebula.Utilities.Security;
using System.Web.Http;
using OpenAPI.Core.API;


namespace OpenAPI.Controllers
{
    /// <summary>
    /// 推送消息给来源平台
    /// </summary>
    [Route("api/Message")]
    public class MessageController : ApiController
    {
        string AppKey1 = "APP_KEY1"; 
        string AppSecret1 = "APP_SECRET"; 


        public MessageController()
        {
        }

        // POST: api/Message/Single
        /// <summary>
        /// POST方法请求，单发接口
        /// </summary>
        ///单用户发送消息参数
        /// <returns>推送结果</returns>
        [Route("api/Message/Single")]
        public SendMResult PostSingle([FromBody]SingleUserParameter param)
        {
            //return SendMessageResult.Ok;
            var paramDic = new Dictionary<string, string>();
            paramDic.Add("platform", param.Platform.ToString());
            paramDic.Add("siuserid", param.SiUserId);
            paramDic.Add("content", param.Content);
            paramDic.Add("timestamp", param.Timestamp);
            paramDic.Add("nonce", param.Nonce);
            return Failover(param, paramDic, () =>
            {
                //todo： 业务逻辑
            });
        }

        // POST: api/Message/Mult
        /// <summary>
        /// POST方法请求，多发接口
        /// </summary>
        ///单用户发送消息参数
        /// <returns>推送结果</returns>
        [Route("api/Message/Mult")]
        public SendMResult PostMult([FromBody]MultUserParameter param)
        {
            var paramDic = new Dictionary<string, string>();
            paramDic.Add("platform", param.Platform.ToString());
            paramDic.Add("siuserid", String.Join(",", param.SiUserId));
            paramDic.Add("content", param.Content);
            paramDic.Add("timestamp", param.Timestamp);
            paramDic.Add("nonce", param.Nonce);
            return Failover(param, paramDic, () =>
            {
                foreach (var siUserId in param.SiUserId)
                {
                    //todo： 业务逻辑
                }
            });
        }

        private SendMResult Failover(IApiParameter apiParam, IDictionary<string, string> paramDic, Action action)
        {
            try
            {
                if (apiParam.Sign != Signature.Sign(paramDic, AppSecret1))
                    return SendMResult.SignFailed;
                if (!Signature.IsValidTimestamp(apiParam.Timestamp))
                    return SendMResult.Expire;
                action.Invoke();
            }
            catch (Exception ex)
            {
                return new SendMResult() { Code = (int)System.Net.HttpStatusCode.BadRequest, Result = false, Message = ex.Message };
            }
            return SendMResult.Ok;
        }
    }

}
