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
    public class BilhetesController : Controller
    {
        private readonly WebBilheteiraContext _context;

        public BilhetesController(WebBilheteiraContext context)
        {
            _context = context;
        }

        // GET: Bilhetes
        public async Task<IActionResult> Index()
        {
            var webBilheteiraContext = _context.Bilhete.Include(b => b.Espetaculo).Include(b => b.Sala);
            return View(await webBilheteiraContext.ToListAsync());
        }

        // GET: Bilhetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilhete = await _context.Bilhete
                .Include(b => b.Espetaculo)
                .Include(b => b.Sala)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bilhete == null)
            {
                return NotFound();
            }

            return View(bilhete);
        }

        // GET: Bilhetes/Create
        public IActionResult Create()
        {
            ViewData["EspetaculoId"] = new SelectList(_context.Espetaculo, "Id", "Id");
            ViewData["SalaId"] = new SelectList(_context.Sala, "Id", "Id");
            return View();
        }

        // POST: Bilhetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EspetaculoId,SalaId,DataEspetaculo,NumBilhetes,Preco")] Bilhete bilhete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bilhete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspetaculoId"] = new SelectList(_context.Espetaculo, "Id", "Id", bilhete.EspetaculoId);
            ViewData["SalaId"] = new SelectList(_context.Sala, "Id", "Id", bilhete.SalaId);
            return View(bilhete);
        }

        // GET: Bilhetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilhete = await _context.Bilhete.FindAsync(id);
            if (bilhete == null)
            {
                return NotFound();
            }
            ViewData["EspetaculoId"] = new SelectList(_context.Espetaculo, "Id", "Id", bilhete.EspetaculoId);
            ViewData["SalaId"] = new SelectList(_context.Sala, "Id", "Id", bilhete.SalaId);
            return View(bilhete);
        }

        // POST: Bilhetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EspetaculoId,SalaId,DataEspetaculo,NumBilhetes,Preco")] Bilhete bilhete)
        {
            if (id != bilhete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bilhete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BilheteExists(bilhete.Id))
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
            ViewData["EspetaculoId"] = new SelectList(_context.Espetaculo, "Id", "Id", bilhete.EspetaculoId);
            ViewData["SalaId"] = new SelectList(_context.Sala, "Id", "Id", bilhete.SalaId);
            return View(bilhete);
        }

        // GET: Bilhetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilhete = await _context.Bilhete
                .Include(b => b.Espetaculo)
                .Include(b => b.Sala)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bilhete == null)
            {
                return NotFound();
            }

            return View(bilhete);
        }

        // POST: Bilhetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bilhete = await _context.Bilhete.FindAsync(id);
            _context.Bilhete.Remove(bilhete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BilheteExists(int id)
        {
            return _context.Bilhete.Any(e => e.Id == id);
        }
    }
}
