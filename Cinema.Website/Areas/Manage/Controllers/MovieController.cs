using System;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using Cinema.Website.Areas.Manage.Models;
using Nebula.Cinema.Domain.Commands;
using Nebula.Cinema.Domain.QueryEntries;
using Nebula.Cinema.Domain.QueryEntries.Parameters;
using Nebula.Domain.Messaging;

namespace Cinema.Website.Areas.Manage.Controllers
{
    public class MovieController : Controller
    {
        [Dependency]
        public IMovieQueryEntry MovieQueryEntry { get; set; }

        [Dependency]
        public ICommandBus CommandBus { get; set; }

        // GET: Manage/Movie
        public async Task<ActionResult> Index(MovieQueryParameter param)
        {
            var pagedList = await MovieQueryEntry.PagedAsync(e => true, 1, 10);
            return View(pagedList.ConvertDto());
        }

        // GET: Manage/Movie/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var item = await MovieQueryEntry.FetchAsync(id);
            var dto = item.ConvertDto();
            return View(dto);
        }

        // GET: Manage/Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Movie/Create
        [HttpPost]
        public async Task<ActionResult> Create(MovieCreateDto value)
        {
            if (!TryValidateModel(value))
                return View(value);
            await CommandBus.SendAsync(new MovieCreateCommand()
            {
                AggregateRoot = value.Convert()
            });
            return RedirectToAction("Index");
        }

        // GET: Manage/Movie/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var item = await MovieQueryEntry.FetchAsync(id);
            var dto = item.ConvertCreateDto();
            return View(dto);
        }

        // POST: Manage/Movie/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, MovieCreateDto value)
        {
            if (!TryValidateModel(value))
                return View(value);
            await CommandBus.SendAsync(new MovieUpdateCommand()
            {
                AggregateRoot = value.Convert()
            });

            return RedirectToAction("Index");
        }


        // GET: Manage/Movie/Delete/5
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
