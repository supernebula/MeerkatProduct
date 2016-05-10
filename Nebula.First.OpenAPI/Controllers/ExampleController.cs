using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nebula.First.OpenAPI.Controllers
{
    [Route("api/Example")]
    public class ExampleController : ApiController
    {
        [Route("api/Example/Test")]
        public HttpResponseMessage PostTest()
        {
            var key = "string1";
            var message = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("key=" + key)
            };  
            return message;
        }
    }
}
