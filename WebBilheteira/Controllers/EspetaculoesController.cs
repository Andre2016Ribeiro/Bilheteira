using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bilheteira;
using WebBilheteira.Data;

namespace WebBilheteira.Controllers
{
    public class EspetaculoesController : Controller
    {
        private readonly WebBilheteiraContext _context;

        public EspetaculoesController(WebBilheteiraContext context)
        {
            _context = context;
        }

        // GET: Espetaculoes
        public async Task<IActionResult> Index()
        {
            var webBilheteiraContext = _context.Espetaculo.Include(e => e.TipoEspetaculo);
            return View(await webBilheteiraContext.ToListAsync());
        }

        // GET: Espetaculoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espetaculo = await _context.Espetaculo
                .Include(e => e.TipoEspetaculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (espetaculo == null)
            {
                return NotFound();
            }

            return View(espetaculo);
        }

        // GET: Espetaculoes/Create
        public IActionResult Create()
        {
            ViewData["TipoEspetaculoId"] = new SelectList(_context.TipoEspetaculo, "Id", "Id");
            return View();
        }

        // POST: Espetaculoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Descricao,Elenco,TipoEspetaculoId")] Espetaculo espetaculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(espetaculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoEspetaculoId"] = new SelectList(_context.TipoEspetaculo, "Id", "Id", espetaculo.TipoEspetaculoId);
            return View(espetaculo);
        }

        // GET: Espetaculoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espetaculo = await _context.Espetaculo.FindAsync(id);
            if (espetaculo == null)
            {
                return NotFound();
            }
            ViewData["TipoEspetaculoId"] = new SelectList(_context.TipoEspetaculo, "Id", "Id", espetaculo.TipoEspetaculoId);
            return View(espetaculo);
        }

        // POST: Espetaculoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Descricao,Elenco,TipoEspetaculoId")] Espetaculo espetaculo)
        {
            if (id != espetaculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(espetaculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspetaculoExists(espetaculo.Id))
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
            ViewData["TipoEspetaculoId"] = new SelectList(_context.TipoEspetaculo, "Id", "Id", espetaculo.TipoEspetaculoId);
            return View(espetaculo);
        }

        // GET: Espetaculoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espetaculo = await _context.Espetaculo
                .Include(e => e.TipoEspetaculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (espetaculo == null)
            {
                return NotFound();
            }

            return View(espetaculo);
        }

        // POST: Espetaculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var espetaculo = await _context.Espetaculo.FindAsync(id);
            _context.Espetaculo.Remove(espetaculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspetaculoExists(int id)
        {
            return _context.Espetaculo.Any(e => e.Id == id);
        }
    }
}
