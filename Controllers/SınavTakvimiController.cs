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
    public class SınavTakvimiController : Controller
    {
        private readonly FDbContext _context;

        public SınavTakvimiController(FDbContext context)
        {
            _context = context;
        }

        // GET: SınavTakvimi
        public async Task<IActionResult> Index()
        {
            var fDbContext = _context.SınavTakvimi.Include(s => s.Derss);
            return View(await fDbContext.ToListAsync());
        }

        // GET: SınavTakvimi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SınavTakvimi == null)
            {
                return NotFound();
            }

            var sınavTakvimi = await _context.SınavTakvimi
                .Include(s => s.Derss)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sınavTakvimi == null)
            {
                return NotFound();
            }

            return View(sınavTakvimi);
        }

        // GET: SınavTakvimi/Create
        public IActionResult Create()
        {
            ViewData["DerssId"] = new SelectList(_context.Dersler, "Id", "DersAdi");
            return View();
        }

        // POST: SınavTakvimi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DerssId,sinifno,tarih")] SınavTakvimi sınavTakvimi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sınavTakvimi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DerssId"] = new SelectList(_context.Dersler, "Id", "DersAdi", sınavTakvimi.DerssId);
            return View(sınavTakvimi);
        }

        // GET: SınavTakvimi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SınavTakvimi == null)
            {
                return NotFound();
            }

            var sınavTakvimi = await _context.SınavTakvimi.FindAsync(id);
            if (sınavTakvimi == null)
            {
                return NotFound();
            }
            ViewData["DerssId"] = new SelectList(_context.Dersler, "Id", "DersAdi", sınavTakvimi.DerssId);
            return View(sınavTakvimi);
        }

        // POST: SınavTakvimi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DerssId,sinifno,tarih")] SınavTakvimi sınavTakvimi)
        {
            if (id != sınavTakvimi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sınavTakvimi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SınavTakvimiExists(sınavTakvimi.Id))
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
            ViewData["DerssId"] = new SelectList(_context.Dersler, "Id", "DersAdi", sınavTakvimi.DerssId);
            return View(sınavTakvimi);
        }

        // GET: SınavTakvimi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SınavTakvimi == null)
            {
                return NotFound();
            }

            var sınavTakvimi = await _context.SınavTakvimi
                .Include(s => s.Derss)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sınavTakvimi == null)
            {
                return NotFound();
            }

            return View(sınavTakvimi);
        }

        // POST: SınavTakvimi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SınavTakvimi == null)
            {
                return Problem("Entity set 'FDbContext.SınavTakvimi' is null.");
            }
            var sınavTakvimi = await _context.SınavTakvimi.FindAsync(id);
            if (sınavTakvimi != null)
            {
                _context.SınavTakvimi.Remove(sınavTakvimi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SınavTakvimiExists(int id)
        {
            return (_context.SınavTakvimi?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
