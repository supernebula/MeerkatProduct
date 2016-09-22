using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Website.Areas.Manage.Controllers
{
    public class ScreeningController : Controller
    {
        // GET: Manage/Screening
        public ActionResult Index()
        {
            return View();
        }

        // GET: Manage/Screening/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manage/Screening/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Screening/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manage/Screening/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manage/Screening/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manage/Screening/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manage/Screening/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
