using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarDelivery.Data;
using CarDelivery.Models;

namespace CarDelivery.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarDeliveryContext _context;

        public CarsController(CarDeliveryContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var carDeliveryContext = _context.Cars.Include(c => c.Complectations);
            return View(await carDeliveryContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars
                .Include(c => c.Complectations)
                .FirstOrDefaultAsync(m => m.Carid == id);
            if (cars == null)
            {
                return NotFound();
            }

            return View(cars);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["Complectationid"] = new SelectList(_context.Complectations, "Complectationid", "Name");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Carid,Make,Model,Complectationid,Price")] Cars cars)
        {
            if (true)
            {
                _context.Add(cars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Complectationid"] = new SelectList(_context.Complectations, "Complectationid", "Name", cars.Complectationid);
            return View(cars);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars.FindAsync(id);
            if (cars == null)
            {
                return NotFound();
            }
            ViewData["Complectationid"] = new SelectList(_context.Complectations, "Complectationid", "Complectationid", cars.Complectationid);
            return View(cars);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Carid,Make,Model,Complectationid,Price")] Cars cars)
        {
            if (id != cars.Carid)
            {
                return NotFound();
            }

            if (true)
            {
                try
                {
                    _context.Update(cars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarsExists(cars.Carid))
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
            ViewData["Complectationid"] = new SelectList(_context.Complectations, "Complectationid", "Complectationid", cars.Complectationid);
            return View(cars);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars
                .Include(c => c.Complectations)
                .FirstOrDefaultAsync(m => m.Carid == id);
            if (cars == null)
            {
                return NotFound();
            }

            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cars = await _context.Cars.FindAsync(id);
            if (cars != null)
            {
                _context.Cars.Remove(cars);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarsExists(int id)
        {
            return _context.Cars.Any(e => e.Carid == id);
        }
    }
}
