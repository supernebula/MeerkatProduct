using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using log4net;

namespace Nebula.Web.Filters
{
    public class LogExceptionAttribute : HandleErrorAttribute
    {
       
        public override void OnException(ExceptionContext filterContext)
        {
            ILog log = LogManager.GetLogger("logerror");
            log.Error(filterContext.Exception.Message, filterContext.Exception);

            if (!filterContext.ExceptionHandled)
                base.OnException(filterContext);


        }
    }
}
