using Microsoft.Practices.Unity;
using Nebula.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nebula.FirstEC.MobileSite.Controllers
{
    public class BaseController : Controller
    {
        [Dependency]
        public IUnitOfWork UnitOfWork { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.IsChildAction)
                UnitOfWork.BeginTransaction();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.IsChildAction)
            {
                UnitOfWork.Commit();
                UnitOfWork.Dispose();
            } 
        }
    }
}
