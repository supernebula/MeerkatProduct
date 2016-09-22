using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Website.Areas.Manage.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Manage/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}