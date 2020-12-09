using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sispmed.Core.Domain;
using Sispmed.Infrastructure.Data;

namespace Sispmed.Web.Controllers
{
    public class MovInsumoController : Controller
    {
        private readonly SispmedDbContext _context;

        public MovInsumoController(SispmedDbContext context)
        {
            _context = context;
        }

        // GET: MovInsumo
        public async Task<IActionResult> Index()
        {
            var sispmedDbContext = _context.MovInsumos.Include(m => m.Insumo);
            return View(await sispmedDbContext.ToListAsync());
        }

        // GET: MovInsumo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movInsumos = await _context.MovInsumos
                .Include(m => m.Insumo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movInsumos == null)
            {
                return NotFound();
            }

            return View(movInsumos);
        }

        // GET: MovInsumo/Create
        public IActionResult Create()
        {
            ViewData["InsumoId"] = new SelectList(_context.Insumos, "Id", "CodIns");
            return View();
        }

        // POST: MovInsumo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cantidad,Concepto,Tipo,InsumoId")] MovInsumos movInsumos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movInsumos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InsumoId"] = new SelectList(_context.Insumos, "Id", "CodIns", movInsumos.InsumoId);
            return View(movInsumos);
        }

        // GET: MovInsumo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movInsumos = await _context.MovInsumos.FindAsync(id);
            if (movInsumos == null)
            {
                return NotFound();
            }
            ViewData["InsumoId"] = new SelectList(_context.Insumos, "Id", "CodIns", movInsumos.InsumoId);
            return View(movInsumos);
        }

        // POST: MovInsumo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cantidad,Concepto,Tipo,InsumoId")] MovInsumos movInsumos)
        {
            if (id != movInsumos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movInsumos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovInsumosExists(movInsumos.Id))
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
            ViewData["InsumoId"] = new SelectList(_context.Insumos, "Id", "CodIns", movInsumos.InsumoId);
            return View(movInsumos);
        }

        // GET: MovInsumo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movInsumos = await _context.MovInsumos
                .Include(m => m.Insumo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movInsumos == null)
            {
                return NotFound();
            }

            return View(movInsumos);
        }

        // POST: MovInsumo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movInsumos = await _context.MovInsumos.FindAsync(id);
            _context.MovInsumos.Remove(movInsumos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovInsumosExists(int id)
        {
            return _context.MovInsumos.Any(e => e.Id == id);
        }
    }
}
