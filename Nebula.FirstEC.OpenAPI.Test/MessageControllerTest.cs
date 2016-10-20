using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evol.FirstEC.OpenAPI.Controllers;
using Evol.FirstEC.OpenAPI.Models.Product;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Evol.Utilities.Hash;
using Evol.Utilities.Serialization;

namespace Evol.First.OpenAPI.Test
{
    [TestClass]
    public class MessageControllerTest
    {
        private string AppId => "appidvalue1";
        private string AppSecret => "appsecret09";

        private string BaseUri => "http://localhost:8100/";

        [TestMethod]
        public void TestMethod1()
        {
            var messageController = new OrderController();
            var param = new SubmitOrderParameter()
            {
                ProductId = "11223344",
                UserId = "aaccbbdd",
                Number = 2,
                Address = "XX路100号"
            };

            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var content = JsonUtility.Serialize(param);
            var sign = HashUtility.Md5(AppSecret + content + timestamp);
            var baseUri = new Uri(new Uri(BaseUri), new Uri("/api/Order"));
            var httpClient = new HttpClient() { BaseAddress = baseUri };

            httpClient.DefaultRequestHeaders.Add("AppId", AppId);
            httpClient.DefaultRequestHeaders.Add("Sign", sign);
            httpClient.DefaultRequestHeaders.Add("Timestamp", timestamp);
            httpClient.DefaultRequestHeaders.Add("Accept-Charset", "utf-8");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            Trace.WriteLine("sign:\r\n" + sign);
            Trace.WriteLine("content:\r\n" + content);
            var httpContent = new StringContent(
            content: content,
            encoding: Encoding.UTF8,
            mediaType: "text/json");

            var result = httpClient.PostAsync("", httpContent).Result;

            Trace.WriteLine("ReasonPhrase:\r\n" + result.ReasonPhrase);
            Assert.IsTrue(result.IsSuccessStatusCode, "服务端API执行失败");
            var responseStr = result.Content.ReadAsStringAsync().Result;
            Trace.WriteLine(responseStr);
        }
    }
}
