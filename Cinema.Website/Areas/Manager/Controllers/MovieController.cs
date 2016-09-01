using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using Cinema.Website.Areas.Manager.Models;
using Nebula.Cinema.Domain.QueryEntries;
using Nebula.Cinema.Domain.QueryEntries.Parameters;
using Nebula.Domain.Messaging;

namespace Cinema.Website.Areas.Manager.Controllers
{
    public class MovieController : Controller
    {
        [Dependency]
        public IMovieQueryEntry MovieQueryEntry { get; set; }

        [Dependency]
        public ICommandBus CommandBus { get; set; }

        // GET: Manager/Movie
        public async Task<ActionResult> Index(MovieQueryParameter param)
        {
            var pagedList = await MovieQueryEntry.RetrievePagedAsync(param);
            return View(pagedList.ConvertDto());
        }

        // GET: Manager/Movie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manager/Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Movie/Create
        [HttpPost]
        public ActionResult Create(MovieCreateDto value)
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

        // GET: Manager/Movie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manager/Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MovieCreateDto value)
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


        // GET: Manager/Movie/Delete/5
        public ActionResult Delete(int id)
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
