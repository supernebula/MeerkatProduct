using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using log4net;
using log4net.Config;
using OpenAPI.Models.Product;

[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace OpenAPI.Controllers
{
    /// <summary>
    /// 订单API
    /// </summary>
    [Route("api/Order")]
    public class OrderController : ApiController
    {
        ILog logerror = log4net.LogManager.GetLogger("logerror");

        // POST: api/Order/
        public HttpResponseMessage PostSubmit([FromBody]SubmitOrderParameter param)
        {
            logerror.Error("api/Order:NotImplementedException");
            return new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent("订单提交成功") };
        }
    }

}
