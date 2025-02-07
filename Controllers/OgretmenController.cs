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
    public class OgretmenController : Controller
    {
        private readonly FDbContext _context;

        public OgretmenController(FDbContext context)
        {
            _context = context;
        }

        // GET: Ogretmen
        public async Task<IActionResult> Index()
        {
            var fDbContext = _context.Ogretmen.Include(o => o.Ders);
            return View(await fDbContext.ToListAsync());
        }

        // GET: Ogretmen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ogretmen == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmen
                .Include(o => o.Ders)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogretmen == null)
            {
                return NotFound();
            }

            return View(ogretmen);
        }

        // GET: Ogretmen/Create
        public IActionResult Create()
        {
            ViewData["DersId"] = new SelectList(_context.Dersler, "Id", "DersAdi");
            return View();
        }

        // POST: Ogretmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Soyadi,email,DersId")] Ogretmen ogretmen)
        {
            ModelState.Remove("Ders");
            if (ModelState.IsValid)
            {
                _context.Add(ogretmen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DersId"] = new SelectList(_context.Dersler, "Id", "DersAdi", ogretmen.DersId);
            return View(ogretmen);
        }

        // GET: Ogretmen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ogretmen == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmen.FindAsync(id);
            if (ogretmen == null)
            {
                return NotFound();
            }
            ViewData["DersId"] = new SelectList(_context.Dersler, "Id", "DersAdi", ogretmen.DersId);
            return View(ogretmen);
        }

        // POST: Ogretmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Soyadi,email,DersId")] Ogretmen ogretmen)
        {
            if (id != ogretmen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogretmen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgretmenExists(ogretmen.Id))
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
            ViewData["DersId"] = new SelectList(_context.Dersler, "Id", "DersAdi", ogretmen.DersId);
            return View(ogretmen);
        }

        // GET: Ogretmen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ogretmen == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmen
                .Include(o => o.Ders)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogretmen == null)
            {
                return NotFound();
            }

            return View(ogretmen);
        }

        // POST: Ogretmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ogretmen == null)
            {
                return Problem("Entity set 'FDbContext.Ogretmen'  is null.");
            }
            var ogretmen = await _context.Ogretmen.FindAsync(id);
            if (ogretmen != null)
            {
                _context.Ogretmen.Remove(ogretmen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OgretmenExists(int id)
        {
          return (_context.Ogretmen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
