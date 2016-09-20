using System;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using Cinema.Website.Areas.Manager.Models;
using Nebula.Cinema.Domain.Commands;
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
        public async Task<ActionResult> Details(Guid id)
        {
            var item = await MovieQueryEntry.FetchAsync(id);
            var dto = item.ConvertDto();
            return View(dto);
        }

        // GET: Manager/Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Movie/Create
        [HttpPost]
        public async Task<ActionResult> Create(MovieCreateDto value)
        {
            try
            {
                await CommandBus.SendAsync(new MovieCreateCommand()
                {
                    AggregateRoot = value.Convert()
                });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/Movie/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var item = await MovieQueryEntry.FetchAsync(id);
            var dto = item.ConvertCreateDto();
            return View(dto);
        }

        // POST: Manager/Movie/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, MovieCreateDto value)
        {
            try
            {
                await CommandBus.SendAsync(new MovieUpdateCommand()
                {
                    AggregateRoot = value.Convert()
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View(value);
            }
        }


        // GET: Manager/Movie/Delete/5
        public async Task<Guid> Delete(Guid id)
        {
            try
            {
                await CommandBus.SendAsync(new MovieDeleteCommand()
                {
                    AggregateRootId = id
                });

                return id;
            }
            catch
            {
                return Guid.Empty;
            }
        }
    }
}
