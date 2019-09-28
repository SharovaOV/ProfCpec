using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfSpec.Data;
using ProfSpec.Models;

namespace ProfSpec.Controllers
{
    public class InterestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InterestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Interests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Interest.Include(i => i.DirectionsOfTraining);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Interests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interest = await _context.Interest
                .Include(i => i.DirectionsOfTraining)
                .FirstOrDefaultAsync(m => m.InterestID == id);
            if (interest == null)
            {
                return NotFound();
            }

            return View(interest);
        }

        // GET: Interests/Create
        public IActionResult Create()
        {
            ViewData["DirectionsOfTrainingID"] = new SelectList(_context.Set<DirectionsOfTraining>(), "DirectionsID", "DirectionsID");
            return View();
        }

        // POST: Interests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InterestID,Name,DirectionsOfTrainingID")] Interest interest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectionsOfTrainingID"] = new SelectList(_context.Set<DirectionsOfTraining>(), "DirectionsID", "DirectionsID", interest.DirectionsOfTrainingID);
            return View(interest);
        }

        // GET: Interests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interest = await _context.Interest.FindAsync(id);
            if (interest == null)
            {
                return NotFound();
            }
            ViewData["DirectionsOfTrainingID"] = new SelectList(_context.Set<DirectionsOfTraining>(), "DirectionsID", "DirectionsID", interest.DirectionsOfTrainingID);
            return View(interest);
        }

        // POST: Interests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InterestID,Name,DirectionsOfTrainingID")] Interest interest)
        {
            if (id != interest.InterestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterestExists(interest.InterestID))
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
            ViewData["DirectionsOfTrainingID"] = new SelectList(_context.Set<DirectionsOfTraining>(), "DirectionsID", "DirectionsID", interest.DirectionsOfTrainingID);
            return View(interest);
        }

        // GET: Interests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interest = await _context.Interest
                .Include(i => i.DirectionsOfTraining)
                .FirstOrDefaultAsync(m => m.InterestID == id);
            if (interest == null)
            {
                return NotFound();
            }

            return View(interest);
        }

        // POST: Interests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interest = await _context.Interest.FindAsync(id);
            _context.Interest.Remove(interest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterestExists(int id)
        {
            return _context.Interest.Any(e => e.InterestID == id);
        }
    }
}
