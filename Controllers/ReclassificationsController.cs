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
    public class ReclassificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReclassificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reclassifications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reclassification.Include(r => r.Position).Include(r => r.StagesRequalification).Include(r => r.Worker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reclassifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclassification = await _context.Reclassification
                .Include(r => r.Position)
                .Include(r => r.StagesRequalification)
                .Include(r => r.Worker)
                .FirstOrDefaultAsync(m => m.ReclassificationID == id);
            if (reclassification == null)
            {
                return NotFound();
            }

            return View(reclassification);
        }

        // GET: Reclassifications/Create
        public IActionResult Create()
        {
            ViewData["PositionID"] = new SelectList(_context.Position, "PositionID", "Name");
            ViewData["StagesRequalificationID"] = new SelectList(_context.StagesRequalification, "StagesRequalificationID", "StagesRequalificationID");
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID");
            return View();
        }

        // POST: Reclassifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReclassificationID,WorkerID,PositionID,StagesRequalificationID,ReclassificationMentor")] Reclassification reclassification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reclassification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PositionID"] = new SelectList(_context.Position, "PositionID", "Name", reclassification.PositionID);
            ViewData["StagesRequalificationID"] = new SelectList(_context.StagesRequalification, "StagesRequalificationID", "StagesRequalificationID", reclassification.StagesRequalificationID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", reclassification.WorkerID);
            return View(reclassification);
        }

        // GET: Reclassifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclassification = await _context.Reclassification.FindAsync(id);
            if (reclassification == null)
            {
                return NotFound();
            }
            ViewData["PositionID"] = new SelectList(_context.Position, "PositionID", "Name", reclassification.PositionID);
            ViewData["StagesRequalificationID"] = new SelectList(_context.StagesRequalification, "StagesRequalificationID", "StagesRequalificationID", reclassification.StagesRequalificationID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", reclassification.WorkerID);
            return View(reclassification);
        }

        // POST: Reclassifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReclassificationID,WorkerID,PositionID,StagesRequalificationID,ReclassificationMentor")] Reclassification reclassification)
        {
            if (id != reclassification.ReclassificationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reclassification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReclassificationExists(reclassification.ReclassificationID))
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
            ViewData["PositionID"] = new SelectList(_context.Position, "PositionID", "Name", reclassification.PositionID);
            ViewData["StagesRequalificationID"] = new SelectList(_context.StagesRequalification, "StagesRequalificationID", "StagesRequalificationID", reclassification.StagesRequalificationID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", reclassification.WorkerID);
            return View(reclassification);
        }

        // GET: Reclassifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclassification = await _context.Reclassification
                .Include(r => r.Position)
                .Include(r => r.StagesRequalification)
                .Include(r => r.Worker)
                .FirstOrDefaultAsync(m => m.ReclassificationID == id);
            if (reclassification == null)
            {
                return NotFound();
            }

            return View(reclassification);
        }

        // POST: Reclassifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reclassification = await _context.Reclassification.FindAsync(id);
            _context.Reclassification.Remove(reclassification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReclassificationExists(int id)
        {
            return _context.Reclassification.Any(e => e.ReclassificationID == id);
        }
    }
}
