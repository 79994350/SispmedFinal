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
    public class PacienteController : Controller
    {
        private readonly SispmedDbContext _context;

        public PacienteController(SispmedDbContext context)
        {
            _context = context;
        }

        // GET: Paciente
        public async Task<IActionResult> Index()
        {
            var sispmedDbContext = _context.Pacientes.Include(p => p.Eps).Include(p => p.TipoId);
            return View(await sispmedDbContext.ToListAsync());
        }

        // GET: Paciente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacientes = await _context.Pacientes
                .Include(p => p.Eps)
                .Include(p => p.TipoId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacientes == null)
            {
                return NotFound();
            }

            return View(pacientes);
        }

        // GET: Paciente/Create
        public IActionResult Create()
        {
            ViewData["EpsId"] = new SelectList(_context.Eps, "Id", "NomEps");
            ViewData["TipoIdId"] = new SelectList(_context.Tiposid, "Id", "NomTipo");
            return View();
        }

        // POST: Paciente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CiuRes,DirRes,ECivil,MailPac,FecNac,Genero,NIdPac,PApe,PNom,Regimen,Rh,SApe,SNom,TelPac,EpsId,TipoIdId")] Pacientes pacientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EpsId"] = new SelectList(_context.Eps, "Id", "NomEps", pacientes.EpsId);
            ViewData["TipoIdId"] = new SelectList(_context.Tiposid, "Id", "NomTipo", pacientes.TipoIdId);
            return View(pacientes);
        }

        // GET: Paciente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacientes = await _context.Pacientes.FindAsync(id);
            if (pacientes == null)
            {
                return NotFound();
            }
            ViewData["EpsId"] = new SelectList(_context.Eps, "Id", "NomEps", pacientes.EpsId);
            ViewData["TipoIdId"] = new SelectList(_context.Tiposid, "Id", "NomTipo", pacientes.TipoIdId);
            return View(pacientes);
        }

        // POST: Paciente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CiuRes,DirRes,ECivil,MailPac,FecNac,Genero,NIdPac,PApe,PNom,Regimen,Rh,SApe,SNom,TelPac,EpsId,TipoIdId")] Pacientes pacientes)
        {
            if (id != pacientes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacientesExists(pacientes.Id))
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
            ViewData["EpsId"] = new SelectList(_context.Eps, "Id", "NomEps", pacientes.EpsId);
            ViewData["TipoIdId"] = new SelectList(_context.Tiposid, "Id", "NomTipo", pacientes.TipoIdId);
            return View(pacientes);
        }

        // GET: Paciente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacientes = await _context.Pacientes
                .Include(p => p.Eps)
                .Include(p => p.TipoId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacientes == null)
            {
                return NotFound();
            }

            return View(pacientes);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacientes = await _context.Pacientes.FindAsync(id);
            _context.Pacientes.Remove(pacientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacientesExists(int id)
        {
            return _context.Pacientes.Any(e => e.Id == id);
        }
    }
}
