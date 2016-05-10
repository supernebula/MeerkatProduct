using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Moq;

namespace Nebula.First.WebSite.Tests.TestStart
{
    public static class MvcContextMockHelper
    {
        public static HttpContextBase MockHttpContext()
        {
            var httpContenxt = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var resposne = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();
            var server = new Mock<HttpServerUtilityBase>();

            resposne.Setup(resp => resp.ApplyAppPathModifier(It.IsAny<string>())).Returns((string s) => s);

            httpContenxt.Setup(ctx => ctx.Request).Returns(request.Object);
            httpContenxt.Setup(ctx => ctx.Response).Returns(resposne.Object);
            httpContenxt.Setup(ctx => ctx.Session).Returns(session.Object);
            httpContenxt.Setup(ctx => ctx.Server).Returns(server.Object);

            return httpContenxt.Object;
        }


        public static HttpContextBase MockHttpContext(string url)
        {
            HttpContextBase httpContext = MockHttpContext();
            httpContext.Request.SetRequestUrl(url);
            return httpContext;

        }

        public static void SetSession(this HttpSessionStateBase session)
        {
            throw new NotImplementedException();
        }


        public static void SetRequestUrl(this HttpRequestBase request, string url, FormCollection formCollection = null)
        {
            url = url ?? String.Empty;
            if (String.IsNullOrWhiteSpace(url))
                return;
            var mock = Mock.Get(request);
            mock.Setup(req => req.QueryString).Returns(HttpUtility.ParseQueryString(url.Contains("?") ? url.Substring(url.IndexOf("?", StringComparison.CurrentCulture)) : String.Empty));
            mock.Setup(req => req.AppRelativeCurrentExecutionFilePath).Returns(url.Contains("?") ? url.Substring(0, url.IndexOf("?", StringComparison.CurrentCulture)) : url);
            mock.Setup(req => req.PathInfo).Returns(String.Empty);
            mock.Setup(req => req.Form).Returns(formCollection);

        }


    }
}
