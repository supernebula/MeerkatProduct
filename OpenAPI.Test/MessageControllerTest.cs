using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenAPI.Controllers;
using OpenAPI.Models.Message;
using Nebula.Utilities;
using System.Collections.Generic;
using Nebula.Utilities.Security;

namespace OpenAPI.Test
{
    [TestClass]
    public class MessageControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var messageController = new MessageController();
            var param = new SingleUserParameter()
            {
                Key = "SISS",
                Timestamp = DateTime.Now.ToString("yyyyMMddHHmmss"),
                Nonce = "2364",
                SiUserId = "103222043",
                Content = "您好，欢迎您关注医保服务窗<a href=\"http://www.baidu.com\">帮助中心</a>"
            };

            var paramDic = new Dictionary<string, string>(); 
            paramDic.Add("SiUserId", param.SiUserId);
            paramDic.Add("Content", param.Content);
            paramDic.Add("Timestamp", param.Timestamp);
            paramDic.Add("Nonce", param.Nonce);
            param.Sign = Signature.Sign(paramDic, "SECRETVALUE");

            var result = messageController.PostSingle(param);
            Console.WriteLine(String.Format("Result:{0}, Code:{1}, Message:{2}", result.Result, result.Code, result.Message));
            Assert.IsTrue(result.Result, result.Message);
        }
    }
}
