using System.Web.Mvc;
using log4net;

namespace Evol.FirstEC.WebSite.Filters
{
    public class ExtendHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            string requestId =  filterContext.HttpContext.Response.Headers.Get("requestId");

            ILog log = LogManager.GetLogger("logerror");
            log.Error($"requestId:{requestId}, Exception:{filterContext.Exception.Message}");

            filterContext.Result = new ContentResult() {Content = $"requestId:{requestId},发生了异常" };
        }
    }
}
