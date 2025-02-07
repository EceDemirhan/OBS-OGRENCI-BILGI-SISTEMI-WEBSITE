using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    [Authorize]
    public class OgrenciController : Controller
    {
        private readonly FDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public OgrenciController(FDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Ogrenci
        public async Task<IActionResult> Index()
        {
              return _context.Ogrenci != null ? 
                          View(await _context.Ogrenci.ToListAsync()) :
                          Problem("Entity set 'DBContext.Ogrenci'  is null.");
        }

        // GET: Ogrenci/Details/5
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

        // GET: Ogrenci/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ogrenci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Soyadi,sinif,email,cinsiyet,Fotograf,ImageFile")] Ogrenci ogrenci)
        {
            
            if (ModelState.IsValid)
            {
                string wwwrootpath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(ogrenci.ImageFile.FileName);
                string extension = Path.GetExtension(ogrenci.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                ogrenci.Fotograf = "~/Contents/" + fileName;
                string path = Path.Combine(wwwrootpath + "/Contents/", fileName);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await ogrenci.ImageFile.CopyToAsync(filestream);
                }

                // Save the ogrenci object to the database here
                _context.Add(ogrenci);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); // Redirect to the Index action or another appropriate action
            }
            return View(ogrenci);
        }

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

        // POST: Ogrenci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

       
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Soyadi,sinif,email,cinsiyet,Fotograf,ImageFile")] Ogrenci ogrenci)
        {
            
            if (id != ogrenci.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingOgrenci = await _context.Ogrenci.FindAsync(id);

                    // Eğer yeni bir resim yüklenmişse
                    if (ogrenci.ImageFile != null)
                    {
                        string wwwrootpath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(ogrenci.ImageFile.FileName);
                        string extension = Path.GetExtension(ogrenci.ImageFile.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        ogrenci.Fotograf = "~/Contents/" + fileName;
                        string path = Path.Combine(wwwrootpath + "/Contents/", fileName);
                        using (var filestream = new FileStream(path, FileMode.Create))
                        {
                            await ogrenci.ImageFile.CopyToAsync(filestream);
                        }

                        // Eski resmi sil
                        if (!string.IsNullOrEmpty(existingOgrenci.Fotograf))
                        {
                            var oldImagePath = Path.Combine(wwwrootpath, existingOgrenci.Fotograf.TrimStart('~'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }
                    }

                    _context.Entry(existingOgrenci).CurrentValues.SetValues(ogrenci);
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

        // GET: Ogrenci/Delete/5
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

        // POST: Ogrenci/Delete/5
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
