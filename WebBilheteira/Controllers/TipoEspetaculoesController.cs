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
    public class TipoEspetaculoesController : Controller
    {
        private readonly WebBilheteiraContext _context;

        public TipoEspetaculoesController(WebBilheteiraContext context)
        {
            _context = context;
        }

        // GET: TipoEspetaculoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoEspetaculo.ToListAsync());
        }

        // GET: TipoEspetaculoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEspetaculo = await _context.TipoEspetaculo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEspetaculo == null)
            {
                return NotFound();
            }

            return View(tipoEspetaculo);
        }

        // GET: TipoEspetaculoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEspetaculoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo")] TipoEspetaculo tipoEspetaculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEspetaculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEspetaculo);
        }

        // GET: TipoEspetaculoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEspetaculo = await _context.TipoEspetaculo.FindAsync(id);
            if (tipoEspetaculo == null)
            {
                return NotFound();
            }
            return View(tipoEspetaculo);
        }

        // POST: TipoEspetaculoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo")] TipoEspetaculo tipoEspetaculo)
        {
            if (id != tipoEspetaculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEspetaculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEspetaculoExists(tipoEspetaculo.Id))
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
            return View(tipoEspetaculo);
        }

        // GET: TipoEspetaculoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEspetaculo = await _context.TipoEspetaculo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEspetaculo == null)
            {
                return NotFound();
            }

            return View(tipoEspetaculo);
        }

        // POST: TipoEspetaculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEspetaculo = await _context.TipoEspetaculo.FindAsync(id);
            _context.TipoEspetaculo.Remove(tipoEspetaculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEspetaculoExists(int id)
        {
            return _context.TipoEspetaculo.Any(e => e.Id == id);
        }
    }
}
