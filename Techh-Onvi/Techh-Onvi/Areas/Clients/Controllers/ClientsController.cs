using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Techh_Onvi.Areas.Clients.Models;
using Techh_Onvi.Data;

namespace Techh_Onvi.Areas.Clients.Controllers
{
    [Area("Clients")]
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clients/Clients
        public async Task<IActionResult> Index()
        {
            return View(await _context._Clientes.ToListAsync());
        }

        // GET: Clients/Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var n_Clientes = await _context._Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (n_Clientes == null)
            {
                return NotFound();
            }

            return View(n_Clientes);
        }

        // GET: Clients/Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Solicitud")] N_Clientes n_Clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(n_Clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(n_Clientes);
        }

        // GET: Clients/Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var n_Clientes = await _context._Clientes.FindAsync(id);
            if (n_Clientes == null)
            {
                return NotFound();
            }
            return View(n_Clientes);
        }

        // POST: Clients/Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Solicitud")] N_Clientes n_Clientes)
        {
            if (id != n_Clientes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(n_Clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!N_ClientesExists(n_Clientes.Id))
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
            return View(n_Clientes);
        }

        // GET: Clients/Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var n_Clientes = await _context._Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (n_Clientes == null)
            {
                return NotFound();
            }

            return View(n_Clientes);
        }

        // POST: Clients/Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var n_Clientes = await _context._Clientes.FindAsync(id);
            _context._Clientes.Remove(n_Clientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool N_ClientesExists(int id)
        {
            return _context._Clientes.Any(e => e.Id == id);
        }
    }
}
