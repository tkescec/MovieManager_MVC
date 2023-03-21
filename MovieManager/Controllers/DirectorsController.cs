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
    public class DirectorsController : BaseController
    {

        // GET: Directors
        public async Task<IActionResult> Index()
        {
              return View(await Db.Directors.ToListAsync());
        }

        // GET: Directors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || Db.Directors == null)
            {
                return NotFound();
            }

            var director = await Db.Directors
                .FirstOrDefaultAsync(m => m.Iddirector == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // GET: Directors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Directors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iddirector,FirstName,LastName")] Director director)
        {
            if (ModelState.IsValid)
            {
                Db.Add(director);
                await Db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        // GET: Directors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || Db.Directors == null)
            {
                return NotFound();
            }

            var director = await Db.Directors.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        // POST: Directors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iddirector,FirstName,LastName")] Director director)
        {
            if (id != director.Iddirector)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Db.Update(director);
                    await Db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorExists(director.Iddirector))
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
            return View(director);
        }

        // GET: Directors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || Db.Directors == null)
            {
                return NotFound();
            }

            var director = await Db.Directors
                .FirstOrDefaultAsync(m => m.Iddirector == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (Db.Directors == null)
            {
                return Problem("Entity set 'MovieManagerContext.Directors'  is null.");
            }
            var director = await Db.Directors.FindAsync(id);
            if (director != null)
            {
                Db.Directors.Remove(director);
            }
            
            await Db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectorExists(int id)
        {
          return Db.Directors.Any(e => e.Iddirector == id);
        }
    }
}
