using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Moq;

namespace ExampleWeb.Tests.TestStart
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


        }
    }
}
