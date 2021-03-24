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
    public class MusicasController : Controller
    {
        private readonly BandasDBContext _context;

        public MusicasController(BandasDBContext context)
        {
            _context = context;
        }

        // GET: Musicas
        public async Task<IActionResult> Index()
        {
            var bandasDBContext = _context.Musica.Include(m => m.IdAlbumNavigation);
            return View(await bandasDBContext.ToListAsync());
        }

        // GET: Musicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musica = await _context.Musica
                .Include(m => m.IdAlbumNavigation)
                .FirstOrDefaultAsync(m => m.IdMusica == id);
            if (musica == null)
            {
                return NotFound();
            }

            return View(musica);
        }

        // GET: Musicas/Create
        public IActionResult Create()
        {
            ViewData["IdAlbum"] = new SelectList(_context.Album, "IdAlbum", "IdAlbum");
            return View();
        }

        // POST: Musicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMusica,Titulo,Ano,Duracao,Link,IdAlbum")] Musica musica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlbum"] = new SelectList(_context.Album, "IdAlbum", "IdAlbum", musica.IdAlbum);
            return View(musica);
        }

        // GET: Musicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musica = await _context.Musica.FindAsync(id);
            if (musica == null)
            {
                return NotFound();
            }
            ViewData["IdAlbum"] = new SelectList(_context.Album, "IdAlbum", "IdAlbum", musica.IdAlbum);
            return View(musica);
        }

        // POST: Musicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMusica,Titulo,Ano,Duracao,Link,IdAlbum")] Musica musica)
        {
            if (id != musica.IdMusica)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicaExists(musica.IdMusica))
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
            ViewData["IdAlbum"] = new SelectList(_context.Album, "IdAlbum", "IdAlbum", musica.IdAlbum);
            return View(musica);
        }

        // GET: Musicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musica = await _context.Musica
                .Include(m => m.IdAlbumNavigation)
                .FirstOrDefaultAsync(m => m.IdMusica == id);
            if (musica == null)
            {
                return NotFound();
            }

            return View(musica);
        }

        // POST: Musicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musica = await _context.Musica.FindAsync(id);
            _context.Musica.Remove(musica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicaExists(int id)
        {
            return _context.Musica.Any(e => e.IdMusica == id);
        }

       }
}
