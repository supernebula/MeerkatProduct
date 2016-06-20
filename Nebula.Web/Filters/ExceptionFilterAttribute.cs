using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Http.Filters;
using System.Threading;
using System.Web.Http.Controllers;

namespace Nebula.Web.Filters
{
    public class WebExceptionFilterAttribute : ExceptionFilterAttribute, IExceptionFilter
    {

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string requestId = null;
            if (actionExecutedContext.Response.Content.Headers.Contains("requestId"))
                requestId = actionExecutedContext.Response.Content.Headers.GetValues("requestId").First();

            actionExecutedContext.Response.Content = new StringContent("请求标识：" + requestId + "发生了异常,Exception:" + actionExecutedContext.Exception.Message + "</br>InnerException:" + actionExecutedContext.Exception.InnerException.Message);
        }
    }
}
