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
    public class MigrationController : Controller
    {
        private readonly SispmedDbContext _context;

        public MigrationController(SispmedDbContext context)
        {
            _context = context;
        }

        // GET: Migration
        public async Task<IActionResult> Index()
        {
            return View(await _context.Migrations.ToListAsync());
        }

        // GET: Migration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var migrations = await _context.Migrations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (migrations == null)
            {
                return NotFound();
            }

            return View(migrations);
        }

        // GET: Migration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Migration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Migration,Batch")] Migrations migrations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(migrations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(migrations);
        }

        // GET: Migration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var migrations = await _context.Migrations.FindAsync(id);
            if (migrations == null)
            {
                return NotFound();
            }
            return View(migrations);
        }

        // POST: Migration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Migration,Batch")] Migrations migrations)
        {
            if (id != migrations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(migrations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MigrationsExists(migrations.Id))
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
            return View(migrations);
        }

        // GET: Migration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var migrations = await _context.Migrations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (migrations == null)
            {
                return NotFound();
            }

            return View(migrations);
        }

        // POST: Migration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var migrations = await _context.Migrations.FindAsync(id);
            _context.Migrations.Remove(migrations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MigrationsExists(int id)
        {
            return _context.Migrations.Any(e => e.Id == id);
        }
    }
}
