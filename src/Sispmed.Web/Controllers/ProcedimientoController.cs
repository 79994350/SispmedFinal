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
    public class ProcedimientoController : Controller
    {
        private readonly SispmedDbContext _context;

        public ProcedimientoController(SispmedDbContext context)
        {
            _context = context;
        }

        // GET: Procedimiento
        public async Task<IActionResult> Index()
        {
            return View(await _context.Procedimientos.ToListAsync());
        }

        // GET: Procedimiento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimientos = await _context.Procedimientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedimientos == null)
            {
                return NotFound();
            }

            return View(procedimientos);
        }

        // GET: Procedimiento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procedimiento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodProc,NomProc,PreProc,Valor")] Procedimientos procedimientos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedimientos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procedimientos);
        }

        // GET: Procedimiento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimientos = await _context.Procedimientos.FindAsync(id);
            if (procedimientos == null)
            {
                return NotFound();
            }
            return View(procedimientos);
        }

        // POST: Procedimiento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodProc,NomProc,PreProc,Valor")] Procedimientos procedimientos)
        {
            if (id != procedimientos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedimientos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedimientosExists(procedimientos.Id))
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
            return View(procedimientos);
        }

        // GET: Procedimiento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimientos = await _context.Procedimientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedimientos == null)
            {
                return NotFound();
            }

            return View(procedimientos);
        }

        // POST: Procedimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procedimientos = await _context.Procedimientos.FindAsync(id);
            _context.Procedimientos.Remove(procedimientos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedimientosExists(int id)
        {
            return _context.Procedimientos.Any(e => e.Id == id);
        }
    }
}
