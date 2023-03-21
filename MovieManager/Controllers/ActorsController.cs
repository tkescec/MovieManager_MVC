using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieManager.Models;

namespace MovieManager.Controllers
{
    public class ActorsController : BaseController
    {

        // GET: Actors
        public async Task<IActionResult> Index()
        {
              return View(await Db.Actors.ToListAsync());
        }

        // GET: Actors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || Db.Actors == null)
            {
                return NotFound();
            }

            var actor = await Db.Actors
                .FirstOrDefaultAsync(m => m.Idactor == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idactor,FirstName,LastName")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                Db.Add(actor);
                await Db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // GET: Actors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || Db.Actors == null)
            {
                return NotFound();
            }

            var actor = await Db.Actors.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idactor,FirstName,LastName")] Actor actor)
        {
            if (id != actor.Idactor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Db.Update(actor);
                    await Db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorExists(actor.Idactor))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // GET: Actors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || Db.Actors == null)
            {
                return NotFound();
            }

            var actor = await Db.Actors
                .FirstOrDefaultAsync(m => m.Idactor == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (Db.Actors == null)
            {
                return Problem("Entity set 'MovieManagerContext.Actors'  is null.");
            }
            var actor = await Db.Actors.FindAsync(id);
            if (actor != null)
            {
                Db.Actors.Remove(actor);
            }
            
            await Db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int id)
        {
          return Db.Actors.Any(e => e.Idactor == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
