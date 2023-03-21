using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieManager.Models;

namespace MovieManager.Controllers
{
    public class MoviesController : BaseController
    {

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var movieManagerContext = Db.Movies.Include(m => m.Director).Include(m => m.ActorMovies);

            return View(await movieManagerContext.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || Db.Movies == null)
            {
                return NotFound();
            }

            var movie = await Db.Movies
                .Include(m => m.Director)
                .FirstOrDefaultAsync(m => m.Idmovie == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["DirectorId"] = new SelectList(Db.Directors, "Iddirector", "FullName");
            ViewData["ActorId"] = new SelectList(Db.Actors, "Idactor", "FirstName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmovie,Title,Desc,DirectorId,Files")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                var test = movie;
                var y= "";
                Db.Add(movie);
                await Db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectorId"] = new SelectList(Db.Directors, "Iddirector", "FullName", movie.DirectorId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || Db.Movies == null)
            {
                return NotFound();
            }

            var movie = await Db.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["DirectorId"] = new SelectList(Db.Directors, "Iddirector", "FullName", movie.DirectorId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmovie,Title,Desc,DirectorId")] Movie movie)
        {
            if (id != movie.Idmovie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Db.Update(movie);
                    await Db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Idmovie))
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
            ViewData["DirectorId"] = new SelectList(Db.Directors, "Iddirector", "FullName", movie.DirectorId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || Db.Movies == null)
            {
                return NotFound();
            }

            var movie = await Db.Movies
                .Include(m => m.Director)
                .FirstOrDefaultAsync(m => m.Idmovie == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (Db.Movies == null)
            {
                return Problem("Entity set 'MovieManagerContext.Movies'  is null.");
            }
            var movie = await Db.Movies.FindAsync(id);
            if (movie != null)
            {
                Db.Movies.Remove(movie);
            }
            
            await Db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
          return Db.Movies.Any(e => e.Idmovie == id);
        }
    }
}
