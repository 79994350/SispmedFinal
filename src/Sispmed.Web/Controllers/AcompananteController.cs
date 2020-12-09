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
    public class AcompananteController : Controller
    {
        private readonly SispmedDbContext _context;

        public AcompananteController(SispmedDbContext context)
        {
            _context = context;
        }

        // GET: Acompanante
        public async Task<IActionResult> Index()
        {
            var sispmedDbContext = _context.Acompanantes.Include(a => a.Paciente).Include(a => a.TipoId);
            return View(await sispmedDbContext.ToListAsync());
        }

        // GET: Acompanante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acompanantes = await _context.Acompanantes
                .Include(a => a.Paciente)
                .Include(a => a.TipoId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acompanantes == null)
            {
                return NotFound();
            }

            return View(acompanantes);
        }

        // GET: Acompanante/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "CiuRes");
            ViewData["TipoIdId"] = new SelectList(_context.Tiposid, "Id", "NomTipo");
            return View();
        }

        // POST: Acompanante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Edad,MailAcom,NIdAcom,PApe,ParPac,PNom,SApe,SNom,TelAcom,TipoIdId,PacienteId")] Acompanantes acompanantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acompanantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "CiuRes", acompanantes.PacienteId);
            ViewData["TipoIdId"] = new SelectList(_context.Tiposid, "Id", "NomTipo", acompanantes.TipoIdId);
            return View(acompanantes);
        }

        // GET: Acompanante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acompanantes = await _context.Acompanantes.FindAsync(id);
            if (acompanantes == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "CiuRes", acompanantes.PacienteId);
            ViewData["TipoIdId"] = new SelectList(_context.Tiposid, "Id", "NomTipo", acompanantes.TipoIdId);
            return View(acompanantes);
        }

        // POST: Acompanante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Edad,MailAcom,NIdAcom,PApe,ParPac,PNom,SApe,SNom,TelAcom,TipoIdId,PacienteId")] Acompanantes acompanantes)
        {
            if (id != acompanantes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acompanantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcompanantesExists(acompanantes.Id))
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
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "CiuRes", acompanantes.PacienteId);
            ViewData["TipoIdId"] = new SelectList(_context.Tiposid, "Id", "NomTipo", acompanantes.TipoIdId);
            return View(acompanantes);
        }

        // GET: Acompanante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acompanantes = await _context.Acompanantes
                .Include(a => a.Paciente)
                .Include(a => a.TipoId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acompanantes == null)
            {
                return NotFound();
            }

            return View(acompanantes);
        }

        // POST: Acompanante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acompanantes = await _context.Acompanantes.FindAsync(id);
            _context.Acompanantes.Remove(acompanantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcompanantesExists(int id)
        {
            return _context.Acompanantes.Any(e => e.Id == id);
        }
    }
}
