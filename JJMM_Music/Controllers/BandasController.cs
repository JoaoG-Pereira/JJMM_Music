using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JJMM_Music.Models;

namespace JJMM_Music.Controllers
{
    public class BandasController : Controller
    {
        private readonly BandasDBContext _context;

        public BandasController(BandasDBContext context)
        {
            _context = context;
        }

        // GET: Bandas
        public async Task<IActionResult> Index()
        {
            var bandasDBContext = _context.Banda.Include(b => b.IdGeneroNavigation);
            return View(await bandasDBContext.ToListAsync());
        }

        // GET: Bandas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banda = await _context.Banda
                .Include(b => b.IdGeneroNavigation)
                .FirstOrDefaultAsync(m => m.IdBanda == id);
            if (banda == null)
            {
                return NotFound();
            }

            return View(banda);
        }

        // GET: Bandas/Create
        public IActionResult Create()
        {
            ViewData["IdGenero"] = new SelectList(_context.Genero, "IdGenero", "IdGenero");
            return View();
        }

        // POST: Bandas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBanda,NomeBanda,IdGenero")] Banda banda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGenero"] = new SelectList(_context.Genero, "IdGenero", "IdGenero", banda.IdGenero);
            return View(banda);
        }

        // GET: Bandas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banda = await _context.Banda.FindAsync(id);
            if (banda == null)
            {
                return NotFound();
            }
            ViewData["IdGenero"] = new SelectList(_context.Genero, "IdGenero", "IdGenero", banda.IdGenero);
            return View(banda);
        }

        // POST: Bandas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBanda,NomeBanda,IdGenero")] Banda banda)
        {
            if (id != banda.IdBanda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BandaExists(banda.IdBanda))
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
            ViewData["IdGenero"] = new SelectList(_context.Genero, "IdGenero", "IdGenero", banda.IdGenero);
            return View(banda);
        }

        // GET: Bandas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banda = await _context.Banda
                .Include(b => b.IdGeneroNavigation)
                .FirstOrDefaultAsync(m => m.IdBanda == id);
            if (banda == null)
            {
                return NotFound();
            }

            return View(banda);
        }

        // POST: Bandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banda = await _context.Banda.FindAsync(id);
            _context.Banda.Remove(banda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BandaExists(int id)
        {
            return _context.Banda.Any(e => e.IdBanda == id);
        }
    }
}
