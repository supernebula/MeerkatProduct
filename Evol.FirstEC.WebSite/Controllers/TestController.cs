using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Evol.FirstEC.WebSite.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return Content("Index");
        }

        // GET: Test/Ass
        public ActionResult Ass()
        {
            var entry = Assembly.GetEntryAssembly();
            return Content("entry=" + entry);
        }
    }
}