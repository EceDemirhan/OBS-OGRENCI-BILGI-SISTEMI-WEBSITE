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
    public class NotlarsController : Controller
    {
        private readonly FDbContext _context;

        public NotlarsController(FDbContext context)
        {
            _context = context;
        }

        // GET: Notlars
        public async Task<IActionResult> Index()
        {
            var fDbContext = _context.Notlar.Include(n => n.Dersler).Include(n => n.Ogrenci);
            return View(await fDbContext.ToListAsync());
        }

        // GET: Notlars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notlar == null)
            {
                return NotFound();
            }

            var notlar = await _context.Notlar
                .Include(n => n.Dersler)
                .Include(n => n.Ogrenci)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notlar == null)
            {
                return NotFound();
            }

            return View(notlar);
        }

        // GET: Notlars/Create
        public IActionResult Create()
        {
            ViewData["DerslerId"] = new SelectList(_context.Dersler, "Id", "DersAdi");
            ViewData["OgrenciId"] = new SelectList(_context.Ogrenci, "Id", "Adi");
            return View();
        }

        // POST: Notlars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OgrenciId,DerslerId,Not,result")] Notlar notlar)
        {
            ModelState.Remove("Dersler");
            if (ModelState.IsValid)
            {
                _context.Add(notlar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DerslerId"] = new SelectList(_context.Dersler, "Id", "DersAdi", notlar.DerslerId);
            ViewData["OgrenciId"] = new SelectList(_context.Ogrenci, "Id", "Adi", notlar.OgrenciId);
            return View(notlar);
        }

        // GET: Notlars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notlar == null)
            {
                return NotFound();
            }

            var notlar = await _context.Notlar.FindAsync(id);
            if (notlar == null)
            {
                return NotFound();
            }
            ViewData["DerslerId"] = new SelectList(_context.Dersler, "Id", "DersAdi", notlar.DerslerId);
            ViewData["OgrenciId"] = new SelectList(_context.Ogrenci, "Id", "Adi", notlar.OgrenciId);
            return View(notlar);
        }

        // POST: Notlars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OgrenciId,DerslerId,Not,result")] Notlar notlar)
        {
            if (id != notlar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notlar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotlarExists(notlar.Id))
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
            ViewData["DerslerId"] = new SelectList(_context.Dersler, "Id", "DersAdi", notlar.DerslerId);
            ViewData["OgrenciId"] = new SelectList(_context.Ogrenci, "Id", "Adi", notlar.OgrenciId);
            return View(notlar);
        }

        // GET: Notlars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notlar == null)
            {
                return NotFound();
            }

            var notlar = await _context.Notlar
                .Include(n => n.Dersler)
                .Include(n => n.Ogrenci)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notlar == null)
            {
                return NotFound();
            }

            return View(notlar);
        }

        // POST: Notlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notlar == null)
            {
                return Problem("Entity set 'FDbContext.Notlar'  is null.");
            }
            var notlar = await _context.Notlar.FindAsync(id);
            if (notlar != null)
            {
                _context.Notlar.Remove(notlar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotlarExists(int id)
        {
          return (_context.Notlar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
