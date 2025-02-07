using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication21.DbContext;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    [Authorize]
    public class OgrencisController : Controller
    {
        private readonly DBContext _context;

        public OgrencisController(DBContext context)
        {
            _context = context;
        }

        // GET: Ogrencis
        public async Task<IActionResult> Index()
        {
              return _context.Ogrenci != null ? 
                          View(await _context.Ogrenci.ToListAsync()) :
                          Problem("Entity set 'DBContext.Ogrenci'  is null.");
        }

        // GET: Ogrencis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ogrenci == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);
        }

        // GET: Ogrencis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ogrencis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Soyadi,sinif,email,cinsiyet,Fotograf")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogrenci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ogrenci);
        }

        // GET: Ogrencis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ogrenci == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenci.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }

        // POST: Ogrencis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Soyadi,sinif,email,cinsiyet,Fotograf")] Ogrenci ogrenci)
        {

            if (id != ogrenci.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogrenci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgrenciExists(ogrenci.Id))
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
            return View(ogrenci);
        }

        // GET: Ogrencis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ogrenci == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);
        }

        // POST: Ogrencis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ogrenci == null)
            {
                return Problem("Entity set 'DBContext.Ogrenci'  is null.");
            }
            var ogrenci = await _context.Ogrenci.FindAsync(id);
            if (ogrenci != null)
            {
                _context.Ogrenci.Remove(ogrenci);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OgrenciExists(int id)
        {
          return (_context.Ogrenci?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
