using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using demo2;

namespace demo2.Controllers
{
    public class TaikhoannhanviensController : Controller
    {
        private readonly QLSHOPTHOITRANGContext _context;

        public TaikhoannhanviensController(QLSHOPTHOITRANGContext context)
        {
            _context = context;
        }
        [Route("Page1")]
        // GET: Taikhoannhanviens
        public async Task<IActionResult> Index()
        {
            var qLSHOPTHOITRANGContext = _context.Taikhoannhanviens.Include(t => t.ManhanvienNavigation);
            return View(await qLSHOPTHOITRANGContext.ToListAsync());
        }

        // GET: Taikhoannhanviens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Taikhoannhanviens == null)
            {
                return NotFound();
            }

            var taikhoannhanvien = await _context.Taikhoannhanviens
                .Include(t => t.ManhanvienNavigation)
                .FirstOrDefaultAsync(m => m.Mataikhoan == id);
            if (taikhoannhanvien == null)
            {
                return NotFound();
            }

            return View(taikhoannhanvien);
        }

        // GET: Taikhoannhanviens/Create
        public IActionResult Create()
        {
            ViewData["Manhanvien"] = new SelectList(_context.Nhanviens, "Manhanvien", "Manhanvien");
            return View();
        }

        // POST: Taikhoannhanviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mataikhoan,Ngaytao,Tentaikhoan,Matkhau,Trangthai,Manhanvien")] Taikhoannhanvien taikhoannhanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taikhoannhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Manhanvien"] = new SelectList(_context.Nhanviens, "Manhanvien", "Manhanvien", taikhoannhanvien.Manhanvien);
            return View(taikhoannhanvien);
        }

        // GET: Taikhoannhanviens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Taikhoannhanviens == null)
            {
                return NotFound();
            }

            var taikhoannhanvien = await _context.Taikhoannhanviens.FindAsync(id);
            if (taikhoannhanvien == null)
            {
                return NotFound();
            }
            ViewData["Manhanvien"] = new SelectList(_context.Nhanviens, "Manhanvien", "Manhanvien", taikhoannhanvien.Manhanvien);
            return View(taikhoannhanvien);
        }

        // POST: Taikhoannhanviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mataikhoan,Ngaytao,Tentaikhoan,Matkhau,Trangthai,Manhanvien")] Taikhoannhanvien taikhoannhanvien)
        {
            if (id != taikhoannhanvien.Mataikhoan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taikhoannhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaikhoannhanvienExists(taikhoannhanvien.Mataikhoan))
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
            ViewData["Manhanvien"] = new SelectList(_context.Nhanviens, "Manhanvien", "Manhanvien", taikhoannhanvien.Manhanvien);
            return View(taikhoannhanvien);
        }

        // GET: Taikhoannhanviens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Taikhoannhanviens == null)
            {
                return NotFound();
            }

            var taikhoannhanvien = await _context.Taikhoannhanviens
                .Include(t => t.ManhanvienNavigation)
                .FirstOrDefaultAsync(m => m.Mataikhoan == id);
            if (taikhoannhanvien == null)
            {
                return NotFound();
            }

            return View(taikhoannhanvien);
        }

        // POST: Taikhoannhanviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Taikhoannhanviens == null)
            {
                return Problem("Entity set 'QLSHOPTHOITRANGContext.Taikhoannhanviens'  is null.");
            }
            var taikhoannhanvien = await _context.Taikhoannhanviens.FindAsync(id);
            if (taikhoannhanvien != null)
            {
                _context.Taikhoannhanviens.Remove(taikhoannhanvien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaikhoannhanvienExists(int id)
        {
          return _context.Taikhoannhanviens.Any(e => e.Mataikhoan == id);
        }
    }
}
