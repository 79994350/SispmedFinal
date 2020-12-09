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
    public class ConvenioController : Controller
    {
        private readonly SispmedDbContext _context;

        public ConvenioController(SispmedDbContext context)
        {
            _context = context;
        }

        // GET: Convenio
        public async Task<IActionResult> Index()
        {
            var sispmedDbContext = _context.Convenios.Include(c => c.Eps);
            return View(await sispmedDbContext.ToListAsync());
        }

        // GET: Convenio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenios = await _context.Convenios
                .Include(c => c.Eps)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (convenios == null)
            {
                return NotFound();
            }

            return View(convenios);
        }

        // GET: Convenio/Create
        public IActionResult Create()
        {
            ViewData["EpsId"] = new SelectList(_context.Eps, "Id", "NomEps");
            return View();
        }

        // POST: Convenio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CosConv,DurConv,FecAper,NomConv,ObjConv,Resolu,EpsId,Estado")] Convenios convenios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(convenios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EpsId"] = new SelectList(_context.Eps, "Id", "NomEps", convenios.EpsId);
            return View(convenios);
        }

        // GET: Convenio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenios = await _context.Convenios.FindAsync(id);
            if (convenios == null)
            {
                return NotFound();
            }
            ViewData["EpsId"] = new SelectList(_context.Eps, "Id", "NomEps", convenios.EpsId);
            return View(convenios);
        }

        // POST: Convenio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CosConv,DurConv,FecAper,NomConv,ObjConv,Resolu,EpsId,Estado")] Convenios convenios)
        {
            if (id != convenios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(convenios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConveniosExists(convenios.Id))
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
            ViewData["EpsId"] = new SelectList(_context.Eps, "Id", "NomEps", convenios.EpsId);
            return View(convenios);
        }

        // GET: Convenio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenios = await _context.Convenios
                .Include(c => c.Eps)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (convenios == null)
            {
                return NotFound();
            }

            return View(convenios);
        }

        // POST: Convenio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var convenios = await _context.Convenios.FindAsync(id);
            _context.Convenios.Remove(convenios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConveniosExists(int id)
        {
            return _context.Convenios.Any(e => e.Id == id);
        }
    }
}
