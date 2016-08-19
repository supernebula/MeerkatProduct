using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Website.Areas.Manager.Controllers
{
    public class ScreeningController : Controller
    {
        // GET: Manager/Screening
        public ActionResult Index()
        {
            return View();
        }

        // GET: Manager/Screening/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manager/Screening/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Screening/Create
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

        // GET: Manager/Screening/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manager/Screening/Edit/5
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

        // GET: Manager/Screening/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manager/Screening/Delete/5
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
