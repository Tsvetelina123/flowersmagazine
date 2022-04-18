using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Flowersmagazine.Data;

namespace Flowersmagazine.Controllers
{
    public class TypeBouquetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeBouquetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeBouquets
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeBouquet.ToListAsync());
        }

        // GET: TypeBouquets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeBouquet = await _context.TypeBouquet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeBouquet == null)
            {
                return NotFound();
            }

            return View(typeBouquet);
        }

        // GET: TypeBouquets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeBouquets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TypeBouquet typeBouquet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeBouquet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeBouquet);
        }

        // GET: TypeBouquets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeBouquet = await _context.TypeBouquet.FindAsync(id);
            if (typeBouquet == null)
            {
                return NotFound();
            }
            return View(typeBouquet);
        }

        // POST: TypeBouquets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TypeBouquet typeBouquet)
        {
            if (id != typeBouquet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeBouquet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeBouquetExists(typeBouquet.Id))
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
            return View(typeBouquet);
        }

        // GET: TypeBouquets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeBouquet = await _context.TypeBouquet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeBouquet == null)
            {
                return NotFound();
            }

            return View(typeBouquet);
        }

        // POST: TypeBouquets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeBouquet = await _context.TypeBouquet.FindAsync(id);
            _context.TypeBouquet.Remove(typeBouquet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeBouquetExists(int id)
        {
            return _context.TypeBouquet.Any(e => e.Id == id);
        }
    }
}
