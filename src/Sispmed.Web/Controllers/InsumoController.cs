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
    public class InsumoController : Controller
    {
        private readonly SispmedDbContext _context;

        public InsumoController(SispmedDbContext context)
        {
            _context = context;
        }

        // GET: Insumo
        public async Task<IActionResult> Index()
        {
            var sispmedDbContext = _context.Insumos.Include(i => i.Categoria);
            return View(await sispmedDbContext.ToListAsync());
        }

        // GET: Insumo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumos = await _context.Insumos
                .Include(i => i.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insumos == null)
            {
                return NotFound();
            }

            return View(insumos);
        }

        // GET: Insumo/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.CategoriasInsumos, "Id", "NomCate");
            return View();
        }

        // POST: Insumo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodIns,Concen,Labora,NomIns,PrecioU,Pres,Unid,CategoriaId")] Insumos insumos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insumos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.CategoriasInsumos, "Id", "NomCate", insumos.CategoriaId);
            return View(insumos);
        }

        // GET: Insumo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumos = await _context.Insumos.FindAsync(id);
            if (insumos == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.CategoriasInsumos, "Id", "NomCate", insumos.CategoriaId);
            return View(insumos);
        }

        // POST: Insumo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodIns,Concen,Labora,NomIns,PrecioU,Pres,Unid,CategoriaId")] Insumos insumos)
        {
            if (id != insumos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insumos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsumosExists(insumos.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.CategoriasInsumos, "Id", "NomCate", insumos.CategoriaId);
            return View(insumos);
        }

        // GET: Insumo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumos = await _context.Insumos
                .Include(i => i.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insumos == null)
            {
                return NotFound();
            }

            return View(insumos);
        }

        // POST: Insumo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insumos = await _context.Insumos.FindAsync(id);
            _context.Insumos.Remove(insumos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsumosExists(int id)
        {
            return _context.Insumos.Any(e => e.Id == id);
        }
    }
}
