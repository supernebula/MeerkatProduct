using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Website.Areas.Manager.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Manager/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}