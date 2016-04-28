using System;
using System.Net.Http;
using System.Web.Http;
using OpenAPI.Models.Product;


namespace OpenAPI.Controllers
{
    /// <summary>
    /// 订单API
    /// </summary>
    [Route("api/Order")]
    public class OrderController : ApiController
    {

        // POST: api/Order/
        public HttpResponseMessage PostSingle([FromBody]SubmitOrderParameter param)
        {
            throw new NotImplementedException();
        }
    }

}
