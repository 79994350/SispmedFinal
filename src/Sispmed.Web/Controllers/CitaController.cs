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
    public class CitaController : Controller
    {
        private readonly SispmedDbContext _context;

        public CitaController(SispmedDbContext context)
        {
            _context = context;
        }

        // GET: Cita
        public async Task<IActionResult> Index()
        {
            var sispmedDbContext = _context.Citas.Include(c => c.Acompanante).Include(c => c.Empleado).Include(c => c.Paciente).Include(c => c.Sede);
            return View(await sispmedDbContext.ToListAsync());
        }

        // GET: Cita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = await _context.Citas
                .Include(c => c.Acompanante)
                .Include(c => c.Empleado)
                .Include(c => c.Paciente)
                .Include(c => c.Sede)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citas == null)
            {
                return NotFound();
            }

            return View(citas);
        }

        // GET: Cita/Create
        public IActionResult Create()
        {
            ViewData["AcompananteId"] = new SelectList(_context.Acompanantes, "Id", "MailAcom");
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "PNom");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "CiuRes");
            ViewData["SedeId"] = new SelectList(_context.Sedes, "Id", "DirSede");
            return View();
        }

        // POST: Cita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Fecha,AcompananteId,EmpleadoId,PacienteId,SedeId")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcompananteId"] = new SelectList(_context.Acompanantes, "Id", "MailAcom", citas.AcompananteId);
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "PNom", citas.EmpleadoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "CiuRes", citas.PacienteId);
            ViewData["SedeId"] = new SelectList(_context.Sedes, "Id", "DirSede", citas.SedeId);
            return View(citas);
        }

        // GET: Cita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = await _context.Citas.FindAsync(id);
            if (citas == null)
            {
                return NotFound();
            }
            ViewData["AcompananteId"] = new SelectList(_context.Acompanantes, "Id", "MailAcom", citas.AcompananteId);
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", citas.EmpleadoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "CiuRes", citas.PacienteId);
            ViewData["SedeId"] = new SelectList(_context.Sedes, "Id", "DirSede", citas.SedeId);
            return View(citas);
        }

        // POST: Cita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Fecha,AcompananteId,EmpleadoId,PacienteId,SedeId")] Citas citas)
        {
            if (id != citas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitasExists(citas.Id))
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
            ViewData["AcompananteId"] = new SelectList(_context.Acompanantes, "Id", "MailAcom", citas.AcompananteId);
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", citas.EmpleadoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "CiuRes", citas.PacienteId);
            ViewData["SedeId"] = new SelectList(_context.Sedes, "Id", "DirSede", citas.SedeId);
            return View(citas);
        }

        // GET: Cita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = await _context.Citas
                .Include(c => c.Acompanante)
                .Include(c => c.Empleado)
                .Include(c => c.Paciente)
                .Include(c => c.Sede)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citas == null)
            {
                return NotFound();
            }

            return View(citas);
        }

        // POST: Cita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citas = await _context.Citas.FindAsync(id);
            _context.Citas.Remove(citas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitasExists(int id)
        {
            return _context.Citas.Any(e => e.Id == id);
        }
    }
}
