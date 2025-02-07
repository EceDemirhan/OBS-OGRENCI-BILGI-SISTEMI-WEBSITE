using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class DersProgramisController : Controller
    {
        private readonly FDbContext _context;

        public DersProgramisController(FDbContext context)
        {
            _context = context;
        }

        // GET: DersProgramis
        public async Task<IActionResult> Index()
        {
            var courses = _context.DersProgrami
        .Include(c => c.Dersler)
        .AsNoTracking();
            return View(await courses.ToListAsync());
        }

        // GET: DersProgramis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DersProgrami == null)
            {
                return NotFound();
            }

            var dersProgrami = await _context.DersProgrami
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dersProgrami == null)
            {
                return NotFound();
            }

            return View(dersProgrami);
        }

        // GET: DersProgramis/Create
        public IActionResult Create()
        {
            ViewData["DersId"] = new SelectList(_context.Dersler, "Id", "DersAdi");
            return View();
        }

        // POST: DersProgramis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DersId,tarih")] DersProgrami dersProgrami)
        {
            ModelState.Remove("Dersler");
            if (ModelState.IsValid)
            {
                _context.Add(dersProgrami);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DersId"] = new SelectList(_context.Dersler, "Id", "DersAdi", dersProgrami.DersId);
            return View(dersProgrami);
        }

        // GET: DersProgramis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DersProgrami == null)
            {
                return NotFound();
            }

            var dersProgrami = await _context.DersProgrami.FindAsync(id);
            if (dersProgrami == null)
            {
                return NotFound();
            }
            return View(dersProgrami);
        }

        // POST: DersProgramis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DersId,tarih")] DersProgrami dersProgrami)
        {
            ModelState.Remove("Dersler");
            if (id != dersProgrami.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dersProgrami);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DersProgramiExists(dersProgrami.Id))
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
            return View(dersProgrami);
        }

        // GET: DersProgramis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DersProgrami == null)
            {
                return NotFound();
            }

            var dersProgrami = await _context.DersProgrami
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dersProgrami == null)
            {
                return NotFound();
            }

            return View(dersProgrami);
        }

        // POST: DersProgramis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DersProgrami == null)
            {
                return Problem("Entity set 'FDbContext.DersProgrami'  is null.");
            }
            var dersProgrami = await _context.DersProgrami.FindAsync(id);
            if (dersProgrami != null)
            {
                _context.DersProgrami.Remove(dersProgrami);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DersProgramiExists(int id)
        {
          return (_context.DersProgrami?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
