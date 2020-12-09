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
    public class CategoriaInsumoController : Controller
    {
        private readonly SispmedDbContext _context;

        public CategoriaInsumoController(SispmedDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaInsumo
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriasInsumos.ToListAsync());
        }

        // GET: CategoriaInsumo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriasInsumos = await _context.CategoriasInsumos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriasInsumos == null)
            {
                return NotFound();
            }

            return View(categoriasInsumos);
        }

        // GET: CategoriaInsumo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaInsumo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomCate,TipoCate")] CategoriasInsumos categoriasInsumos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriasInsumos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriasInsumos);
        }

        // GET: CategoriaInsumo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriasInsumos = await _context.CategoriasInsumos.FindAsync(id);
            if (categoriasInsumos == null)
            {
                return NotFound();
            }
            return View(categoriasInsumos);
        }

        // POST: CategoriaInsumo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomCate,TipoCate")] CategoriasInsumos categoriasInsumos)
        {
            if (id != categoriasInsumos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriasInsumos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriasInsumosExists(categoriasInsumos.Id))
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
            return View(categoriasInsumos);
        }

        // GET: CategoriaInsumo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriasInsumos = await _context.CategoriasInsumos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriasInsumos == null)
            {
                return NotFound();
            }

            return View(categoriasInsumos);
        }

        // POST: CategoriaInsumo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriasInsumos = await _context.CategoriasInsumos.FindAsync(id);
            _context.CategoriasInsumos.Remove(categoriasInsumos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriasInsumosExists(int id)
        {
            return _context.CategoriasInsumos.Any(e => e.Id == id);
        }
    }
}
