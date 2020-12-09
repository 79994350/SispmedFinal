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
    public class ArlsController : Controller
    {
        private readonly SispmedDbContext _context;

        public ArlsController(SispmedDbContext context)
        {
            _context = context;
        }

        // GET: Arls
        public async Task<IActionResult> Index()
        {
            return View(await _context.Arl.ToListAsync());
        }

        // GET: Arls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arl = await _context.Arl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arl == null)
            {
                return NotFound();
            }

            return View(arl);
        }

        // GET: Arls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomArl,TelArl")] Arl arl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arl);
        }

        // GET: Arls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arl = await _context.Arl.FindAsync(id);
            if (arl == null)
            {
                return NotFound();
            }
            return View(arl);
        }

        // POST: Arls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomArl,TelArl")] Arl arl)
        {
            if (id != arl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArlExists(arl.Id))
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
            return View(arl);
        }

        // GET: Arls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arl = await _context.Arl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arl == null)
            {
                return NotFound();
            }

            return View(arl);
        }

        // POST: Arls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arl = await _context.Arl.FindAsync(id);
            _context.Arl.Remove(arl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArlExists(int id)
        {
            return _context.Arl.Any(e => e.Id == id);
        }
    }
}
