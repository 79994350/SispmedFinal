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
    public class SedeController : Controller
    {
        private readonly SispmedDbContext _context;

        public SedeController(SispmedDbContext context)
        {
            _context = context;
        }

        // GET: Sede
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sedes.ToListAsync());
        }

        // GET: Sede/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sedes = await _context.Sedes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sedes == null)
            {
                return NotFound();
            }

            return View(sedes);
        }

        // GET: Sede/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sede/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DirSede,NomSede,TelSede")] Sedes sedes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sedes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sedes);
        }

        // GET: Sede/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sedes = await _context.Sedes.FindAsync(id);
            if (sedes == null)
            {
                return NotFound();
            }
            return View(sedes);
        }

        // POST: Sede/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DirSede,NomSede,TelSede")] Sedes sedes)
        {
            if (id != sedes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sedes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SedesExists(sedes.Id))
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
            return View(sedes);
        }

        // GET: Sede/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sedes = await _context.Sedes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sedes == null)
            {
                return NotFound();
            }

            return View(sedes);
        }

        // POST: Sede/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sedes = await _context.Sedes.FindAsync(id);
            _context.Sedes.Remove(sedes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SedesExists(int id)
        {
            return _context.Sedes.Any(e => e.Id == id);
        }
    }
}
