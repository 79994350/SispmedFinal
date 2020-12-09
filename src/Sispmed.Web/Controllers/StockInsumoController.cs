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
    public class StockInsumoController : Controller
    {
        private readonly SispmedDbContext _context;

        public StockInsumoController(SispmedDbContext context)
        {
            _context = context;
        }

        // GET: StockInsumo
        public async Task<IActionResult> Index()
        {
            var sispmedDbContext = _context.StockInsumos.Include(s => s.Insumo);
            return View(await sispmedDbContext.ToListAsync());
        }

        // GET: StockInsumo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockInsumos = await _context.StockInsumos
                .Include(s => s.Insumo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockInsumos == null)
            {
                return NotFound();
            }

            return View(stockInsumos);
        }

        // GET: StockInsumo/Create
        public IActionResult Create()
        {
            ViewData["InsumoId"] = new SelectList(_context.Insumos, "Id", "CodIns");
            return View();
        }

        // POST: StockInsumo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Disponi,Entradas,Salidas,InsumoId")] StockInsumos stockInsumos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockInsumos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InsumoId"] = new SelectList(_context.Insumos, "Id", "CodIns", stockInsumos.InsumoId);
            return View(stockInsumos);
        }

        // GET: StockInsumo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockInsumos = await _context.StockInsumos.FindAsync(id);
            if (stockInsumos == null)
            {
                return NotFound();
            }
            ViewData["InsumoId"] = new SelectList(_context.Insumos, "Id", "CodIns", stockInsumos.InsumoId);
            return View(stockInsumos);
        }

        // POST: StockInsumo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Disponi,Entradas,Salidas,InsumoId")] StockInsumos stockInsumos)
        {
            if (id != stockInsumos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockInsumos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockInsumosExists(stockInsumos.Id))
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
            ViewData["InsumoId"] = new SelectList(_context.Insumos, "Id", "CodIns", stockInsumos.InsumoId);
            return View(stockInsumos);
        }

        // GET: StockInsumo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockInsumos = await _context.StockInsumos
                .Include(s => s.Insumo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockInsumos == null)
            {
                return NotFound();
            }

            return View(stockInsumos);
        }

        // POST: StockInsumo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockInsumos = await _context.StockInsumos.FindAsync(id);
            _context.StockInsumos.Remove(stockInsumos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockInsumosExists(int id)
        {
            return _context.StockInsumos.Any(e => e.Id == id);
        }
    }
}
