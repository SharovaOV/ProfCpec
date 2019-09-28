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
    public class StagesRequalificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StagesRequalificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StagesRequalifications
        public async Task<IActionResult> Index()
        {
            return View(await _context.StagesRequalification.ToListAsync());
        }

        // GET: StagesRequalifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stagesRequalification = await _context.StagesRequalification
                .FirstOrDefaultAsync(m => m.StagesRequalificationID == id);
            if (stagesRequalification == null)
            {
                return NotFound();
            }

            return View(stagesRequalification);
        }

        // GET: StagesRequalifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StagesRequalifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StagesRequalificationID,Name")] StagesRequalification stagesRequalification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stagesRequalification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stagesRequalification);
        }

        // GET: StagesRequalifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stagesRequalification = await _context.StagesRequalification.FindAsync(id);
            if (stagesRequalification == null)
            {
                return NotFound();
            }
            return View(stagesRequalification);
        }

        // POST: StagesRequalifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StagesRequalificationID,Name")] StagesRequalification stagesRequalification)
        {
            if (id != stagesRequalification.StagesRequalificationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stagesRequalification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StagesRequalificationExists(stagesRequalification.StagesRequalificationID))
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
            return View(stagesRequalification);
        }

        // GET: StagesRequalifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stagesRequalification = await _context.StagesRequalification
                .FirstOrDefaultAsync(m => m.StagesRequalificationID == id);
            if (stagesRequalification == null)
            {
                return NotFound();
            }

            return View(stagesRequalification);
        }

        // POST: StagesRequalifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stagesRequalification = await _context.StagesRequalification.FindAsync(id);
            _context.StagesRequalification.Remove(stagesRequalification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StagesRequalificationExists(int id)
        {
            return _context.StagesRequalification.Any(e => e.StagesRequalificationID == id);
        }
    }
}
