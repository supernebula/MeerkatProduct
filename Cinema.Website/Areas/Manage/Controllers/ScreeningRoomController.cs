using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Website.Areas.Manage.Controllers
{
    public class ScreeningRoomController : Controller
    {
        // GET: Manage/ScreeningRoom
        public ActionResult Index()
        {
            return View();
        }

        // GET: Manage/ScreeningRoom/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manage/ScreeningRoom/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/ScreeningRoom/Create
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

        // GET: Manage/ScreeningRoom/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manage/ScreeningRoom/Edit/5
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

        // GET: Manage/ScreeningRoom/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manage/ScreeningRoom/Delete/5
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
