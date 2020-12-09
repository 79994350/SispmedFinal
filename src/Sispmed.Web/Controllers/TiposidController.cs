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
    public class TiposidController : Controller
    {
        private readonly SispmedDbContext _context;

        public TiposidController(SispmedDbContext context)
        {
            _context = context;
        }

        // GET: Tiposid
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tiposid.ToListAsync());
        }

        // GET: Tiposid/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposid = await _context.Tiposid
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposid == null)
            {
                return NotFound();
            }

            return View(tiposid);
        }

        // GET: Tiposid/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tiposid/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,NomTipo")] Tiposid tiposid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposid);
        }

        // GET: Tiposid/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposid = await _context.Tiposid.FindAsync(id);
            if (tiposid == null)
            {
                return NotFound();
            }
            return View(tiposid);
        }

        // POST: Tiposid/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,NomTipo")] Tiposid tiposid)
        {
            if (id != tiposid.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposidExists(tiposid.Id))
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
            return View(tiposid);
        }

        // GET: Tiposid/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposid = await _context.Tiposid
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposid == null)
            {
                return NotFound();
            }

            return View(tiposid);
        }

        // POST: Tiposid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposid = await _context.Tiposid.FindAsync(id);
            _context.Tiposid.Remove(tiposid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposidExists(int id)
        {
            return _context.Tiposid.Any(e => e.Id == id);
        }
    }
}
