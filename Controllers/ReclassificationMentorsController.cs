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
    public class ReclassificationMentorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReclassificationMentorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReclassificationMentors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ReclassificationMentor.Include(r => r.Mentor).Include(r => r.Reclassification);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReclassificationMentors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclassificationMentor = await _context.ReclassificationMentor
                .Include(r => r.Mentor)
                .Include(r => r.Reclassification)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reclassificationMentor == null)
            {
                return NotFound();
            }

            return View(reclassificationMentor);
        }

        // GET: ReclassificationMentors/Create
        public IActionResult Create()
        {
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID");
            ViewData["ReclassificationID"] = new SelectList(_context.Set<Reclassification>(), "ReclassificationID", "ReclassificationID");
            return View();
        }

        // POST: ReclassificationMentors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ReclassificationID,WorkerID")] ReclassificationMentor reclassificationMentor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reclassificationMentor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", reclassificationMentor.WorkerID);
            ViewData["ReclassificationID"] = new SelectList(_context.Set<Reclassification>(), "ReclassificationID", "ReclassificationID", reclassificationMentor.ReclassificationID);
            return View(reclassificationMentor);
        }

        // GET: ReclassificationMentors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclassificationMentor = await _context.ReclassificationMentor.FindAsync(id);
            if (reclassificationMentor == null)
            {
                return NotFound();
            }
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", reclassificationMentor.WorkerID);
            ViewData["ReclassificationID"] = new SelectList(_context.Set<Reclassification>(), "ReclassificationID", "ReclassificationID", reclassificationMentor.ReclassificationID);
            return View(reclassificationMentor);
        }

        // POST: ReclassificationMentors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ReclassificationID,WorkerID")] ReclassificationMentor reclassificationMentor)
        {
            if (id != reclassificationMentor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reclassificationMentor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReclassificationMentorExists(reclassificationMentor.ID))
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
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", reclassificationMentor.WorkerID);
            ViewData["ReclassificationID"] = new SelectList(_context.Set<Reclassification>(), "ReclassificationID", "ReclassificationID", reclassificationMentor.ReclassificationID);
            return View(reclassificationMentor);
        }

        // GET: ReclassificationMentors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclassificationMentor = await _context.ReclassificationMentor
                .Include(r => r.Mentor)
                .Include(r => r.Reclassification)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reclassificationMentor == null)
            {
                return NotFound();
            }

            return View(reclassificationMentor);
        }

        // POST: ReclassificationMentors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reclassificationMentor = await _context.ReclassificationMentor.FindAsync(id);
            _context.ReclassificationMentor.Remove(reclassificationMentor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReclassificationMentorExists(int id)
        {
            return _context.ReclassificationMentor.Any(e => e.ID == id);
        }
    }
}
