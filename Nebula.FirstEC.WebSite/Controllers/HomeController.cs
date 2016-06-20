using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Nebula.FirstEC.WebSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Thread.Sleep(100);
            throw new HttpException("测试异常");
            return Content("Hello World!");
        }
    }
}