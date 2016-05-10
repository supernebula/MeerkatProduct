using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nebula.First.WebSite.Tests.TestStart
{
    public class MvcMockUtility
    {
        public static HttpContextBase MockHttpContext()
        {
            throw  new NotImplementedException();
        }

        public static HttpSessionStateBase MockHttpSession()
        {
            throw new NotImplementedException();
        }

        public static HttpRequestBase MockHttpRequest()
        {
            throw new NotImplementedException();
        }
    }
}
