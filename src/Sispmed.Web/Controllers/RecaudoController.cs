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
    public class RecaudoController : Controller
    {
        private readonly SispmedDbContext _context;

        public RecaudoController(SispmedDbContext context)
        {
            _context = context;
        }

        // GET: Recaudo
        public async Task<IActionResult> Index()
        {
            var sispmedDbContext = _context.Recaudos.Include(r => r.Empleado);
            return View(await sispmedDbContext.ToListAsync());
        }

        // GET: Recaudo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recaudos = await _context.Recaudos
                .Include(r => r.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recaudos == null)
            {
                return NotFound();
            }

            return View(recaudos);
        }

        // GET: Recaudo/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id");
            return View();
        }

        // POST: Recaudo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Concep,ForPago,Valor,EmpleadoId")] Recaudos recaudos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recaudos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", recaudos.EmpleadoId);
            return View(recaudos);
        }

        // GET: Recaudo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recaudos = await _context.Recaudos.FindAsync(id);
            if (recaudos == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", recaudos.EmpleadoId);
            return View(recaudos);
        }

        // POST: Recaudo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Concep,ForPago,Valor,EmpleadoId")] Recaudos recaudos)
        {
            if (id != recaudos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recaudos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecaudosExists(recaudos.Id))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", recaudos.EmpleadoId);
            return View(recaudos);
        }

        // GET: Recaudo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recaudos = await _context.Recaudos
                .Include(r => r.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recaudos == null)
            {
                return NotFound();
            }

            return View(recaudos);
        }

        // POST: Recaudo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recaudos = await _context.Recaudos.FindAsync(id);
            _context.Recaudos.Remove(recaudos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecaudosExists(int id)
        {
            return _context.Recaudos.Any(e => e.Id == id);
        }
    }
}
