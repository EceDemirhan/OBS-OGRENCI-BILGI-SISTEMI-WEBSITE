using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication21.DbContext;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class SinavTakvimisController : Controller
    {
        private readonly DBContext _context;

        public SinavTakvimisController(DBContext context)
        {
            _context = context;
        }

        // GET: SinavTakvimis
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.SinavTakvimi.Include(s => s.Derss);
            return View(await dBContext.ToListAsync());
        }

        // GET: SinavTakvimis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SinavTakvimi == null)
            {
                return NotFound();
            }

            var sinavTakvimi = await _context.SinavTakvimi
                .Include(s => s.Derss)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sinavTakvimi == null)
            {
                return NotFound();
            }

            return View(sinavTakvimi);
        }

        // GET: SinavTakvimis/Create
        public IActionResult Create()
        {
            ViewData["DerssId"] = new SelectList(_context.Dersler, "Id", "DersAdi");
            return View();
        }

        // POST: SinavTakvimis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DerssId,sinifno,tarih")] SinavTakvimi sinavTakvimi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinavTakvimi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DerssId"] = new SelectList(_context.Dersler, "Id", "DersAdi", sinavTakvimi.DerssId);
            return View(sinavTakvimi);
        }

        // GET: SinavTakvimis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SinavTakvimi == null)
            {
                return NotFound();
            }

            var sinavTakvimi = await _context.SinavTakvimi.FindAsync(id);
            if (sinavTakvimi == null)
            {
                return NotFound();
            }
            ViewData["DerssId"] = new SelectList(_context.Dersler, "Id", "DersAdi", sinavTakvimi.DerssId);
            return View(sinavTakvimi);
        }

        // POST: SinavTakvimis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DerssId,sinifno,tarih")] SinavTakvimi sinavTakvimi)
        {
            if (id != sinavTakvimi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinavTakvimi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinavTakvimiExists(sinavTakvimi.Id))
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
            ViewData["DerssId"] = new SelectList(_context.Dersler, "Id", "DersAdi", sinavTakvimi.DerssId);
            return View(sinavTakvimi);
        }

        // GET: SinavTakvimis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SinavTakvimi == null)
            {
                return NotFound();
            }

            var sinavTakvimi = await _context.SinavTakvimi
                .Include(s => s.Derss)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sinavTakvimi == null)
            {
                return NotFound();
            }

            return View(sinavTakvimi);
        }

        // POST: SinavTakvimis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SinavTakvimi == null)
            {
                return Problem("Entity set 'DBContext.SinavTakvimi'  is null.");
            }
            var sinavTakvimi = await _context.SinavTakvimi.FindAsync(id);
            if (sinavTakvimi != null)
            {
                _context.SinavTakvimi.Remove(sinavTakvimi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinavTakvimiExists(int id)
        {
          return (_context.SinavTakvimi?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
