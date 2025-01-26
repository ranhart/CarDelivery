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
    public class ComplectationsController : Controller
    {
        private readonly CarDeliveryContext _context;

        public ComplectationsController(CarDeliveryContext context)
        {
            _context = context;
        }

        // GET: Complectations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Complectations.ToListAsync());
        }

        // GET: Complectations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complectations = await _context.Complectations
                .FirstOrDefaultAsync(m => m.Complectationid == id);
            if (complectations == null)
            {
                return NotFound();
            }

            return View(complectations);
        }

        // GET: Complectations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Complectations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Complectationid,Name,Equipment,Engine")] Complectations complectations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(complectations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(complectations);
        }

        // GET: Complectations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complectations = await _context.Complectations.FindAsync(id);
            if (complectations == null)
            {
                return NotFound();
            }
            return View(complectations);
        }

        // POST: Complectations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Complectationid,Name,Equipment,Engine")] Complectations complectations)
        {
            if (id != complectations.Complectationid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(complectations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplectationsExists(complectations.Complectationid))
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
            return View(complectations);
        }

        // GET: Complectations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complectations = await _context.Complectations
                .FirstOrDefaultAsync(m => m.Complectationid == id);
            if (complectations == null)
            {
                return NotFound();
            }

            return View(complectations);
        }

        // POST: Complectations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var complectations = await _context.Complectations.FindAsync(id);
            if (complectations != null)
            {
                _context.Complectations.Remove(complectations);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComplectationsExists(int id)
        {
            return _context.Complectations.Any(e => e.Complectationid == id);
        }
    }
}
