﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Evol.FirstEC.OpenAPI.Controllers
{
    [Route("api/Example")]
    public class ExampleController : ApiController
    {
        [Route("api/Example/PostTest")]
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
