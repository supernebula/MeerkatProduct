using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Nebula.FirstEC.OpenAPI.Controllers
{
    [Route("api/service/")]
    public class ServiceController : ApiController
    {
        [Route("api/service/do")]
        public HttpResponseMessage PostDo()
        {
            var routes = GlobalConfiguration.Configuration.Routes;
            foreach (IHttpRoute route in routes)
            {
                var routeData = route.GetRouteData("/", Request);
                Debug.WriteLine("");
            }

            var message = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("name=server/do")
            };
            return message;
        }
    }
}
