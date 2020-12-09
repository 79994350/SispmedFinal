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
    public class EmpleadoController : Controller
    {
        private readonly SispmedDbContext _context;

        public EmpleadoController(SispmedDbContext context)
        {
            _context = context;
        }

        // GET: Empleado
        public async Task<IActionResult> Index()
        {
            var sispmedDbContext = _context.Empleados.Include(e => e.Arl).Include(e => e.Cargo).Include(e => e.Eps).Include(e => e.TiposId);
            return View(await sispmedDbContext.ToListAsync());
        }

        // GET: Empleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados
                .Include(e => e.Arl)
                .Include(e => e.Cargo)
                .Include(e => e.Eps)
                .Include(e => e.TiposId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // GET: Empleado/Create
        public IActionResult Create()
        {
            ViewData["ArlId"] = new SelectList(_context.Arl, "Id", "NomArl");
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "NomCar");
            ViewData["EpsId"] = new SelectList(_context.Eps, "Id", "NomEps");
            ViewData["TiposIdId"] = new SelectList(_context.Tiposid, "Id", "NomTipo");
            return View();
        }

        // POST: Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CiuRes,DirRes,ECivil,MailEmp,FecIng,FecNac,Genero,NIdEmp,PApe,PNom,Rh,SApe,SNom,TelEmp,ArlId,CargoId,EpsId,TiposIdId,Estado")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArlId"] = new SelectList(_context.Arl, "Id", "NomArl", empleados.ArlId);
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "NomCar", empleados.CargoId);
            ViewData["EpsId"] = new SelectList(_context.Eps, "Id", "NomEps", empleados.EpsId);
            ViewData["TiposIdId"] = new SelectList(_context.Tiposid, "Id", "NomTipo", empleados.TiposIdId);
            return View(empleados);
        }

        // GET: Empleado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }
            ViewData["ArlId"] = new SelectList(_context.Arl, "Id", "NomArl", empleados.ArlId);
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "NomCar", empleados.CargoId);
            ViewData["EpsId"] = new SelectList(_context.Eps, "Id", "NomEps", empleados.EpsId);
            ViewData["TiposIdId"] = new SelectList(_context.Tiposid, "Id", "NomTipo", empleados.TiposIdId);
            return View(empleados);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CiuRes,DirRes,ECivil,MailEmp,FecIng,FecNac,Genero,NIdEmp,PApe,PNom,Rh,SApe,SNom,TelEmp,ArlId,CargoId,EpsId,TiposIdId,Estado")] Empleados empleados)
        {
            if (id != empleados.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadosExists(empleados.Id))
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
            ViewData["ArlId"] = new SelectList(_context.Arl, "Id", "NomArl", empleados.ArlId);
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "NomCar", empleados.CargoId);
            ViewData["EpsId"] = new SelectList(_context.Eps, "Id", "NomEps", empleados.EpsId);
            ViewData["TiposIdId"] = new SelectList(_context.Tiposid, "Id", "NomTipo", empleados.TiposIdId);
            return View(empleados);
        }

        // GET: Empleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados
                .Include(e => e.Arl)
                .Include(e => e.Cargo)
                .Include(e => e.Eps)
                .Include(e => e.TiposId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleados = await _context.Empleados.FindAsync(id);
            _context.Empleados.Remove(empleados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadosExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
