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
    public class FlowerTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlowerTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FlowerTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FlowerType.ToListAsync());
        }

        // GET: FlowerTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flowerType = await _context.FlowerType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flowerType == null)
            {
                return NotFound();
            }

            return View(flowerType);
        }

        // GET: FlowerTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FlowerTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FlowerType flowerType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flowerType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flowerType);
        }

        // GET: FlowerTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flowerType = await _context.FlowerType.FindAsync(id);
            if (flowerType == null)
            {
                return NotFound();
            }
            return View(flowerType);
        }

        // POST: FlowerTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] FlowerType flowerType)
        {
            if (id != flowerType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flowerType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlowerTypeExists(flowerType.Id))
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
            return View(flowerType);
        }

        // GET: FlowerTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flowerType = await _context.FlowerType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flowerType == null)
            {
                return NotFound();
            }

            return View(flowerType);
        }

        // POST: FlowerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flowerType = await _context.FlowerType.FindAsync(id);
            _context.FlowerType.Remove(flowerType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlowerTypeExists(int id)
        {
            return _context.FlowerType.Any(e => e.Id == id);
        }
    }
}
