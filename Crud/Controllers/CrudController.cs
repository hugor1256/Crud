using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crud.Data;
using Crud.Models;

namespace Crud.Controllers
{
    public class CrudController : Controller
    {
        private readonly CrudDbContext _context;

        public CrudController(CrudDbContext context)
        {
            _context = context;
        }

        // GET: Crud
        public async Task<IActionResult> Index()
        {
              return _context.Cruds != null ? 
                          View(await _context.Cruds.ToListAsync()) :
                          Problem("Entity set 'CrudDbContext.Cruds'  is null.");
        }

        // GET: Crud/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cruds == null)
            {
                return NotFound();
            }

            var crud = await _context.Cruds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crud == null)
            {
                return NotFound();
            }

            return View(crud);
        }

        // GET: Crud/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crud/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cpf,Senha")] Models.Crud crud)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crud);
        }

        // GET: Crud/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cruds == null)
            {
                return NotFound();
            }

            var crud = await _context.Cruds.FindAsync(id);
            if (crud == null)
            {
                return NotFound();
            }
            return View(crud);
        }

        // POST: Crud/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cpf,Senha")] Models.Crud crud)
        {
            if (id != crud.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrudExists(crud.Id))
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
            return View(crud);
        }

        // GET: Crud/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cruds == null)
            {
                return NotFound();
            }

            var crud = await _context.Cruds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crud == null)
            {
                return NotFound();
            }

            return View(crud);
        }

        // POST: Crud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cruds == null)
            {
                return Problem("Entity set 'CrudDbContext.Cruds'  is null.");
            }
            var crud = await _context.Cruds.FindAsync(id);
            if (crud != null)
            {
                _context.Cruds.Remove(crud);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrudExists(int id)
        {
          return (_context.Cruds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
