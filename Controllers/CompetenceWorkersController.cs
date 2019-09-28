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
    public class CompetenceWorkersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompetenceWorkersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompetenceWorkers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CompetenceWorker.Include(c => c.Competence).Include(c => c.Worker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CompetenceWorkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenceWorker = await _context.CompetenceWorker
                .Include(c => c.Competence)
                .Include(c => c.Worker)
                .FirstOrDefaultAsync(m => m.CompetenceWorkerID == id);
            if (competenceWorker == null)
            {
                return NotFound();
            }

            return View(competenceWorker);
        }

        // GET: CompetenceWorkers/Create
        public IActionResult Create()
        {
            ViewData["CompetenceID"] = new SelectList(_context.Competence, "CompetenceID", "CompetenceID");
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID");
            return View();
        }

        // POST: CompetenceWorkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompetenceWorkerID,CompetenceID,WorkerID,Level")] CompetenceWorker competenceWorker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competenceWorker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompetenceID"] = new SelectList(_context.Competence, "CompetenceID", "CompetenceID", competenceWorker.CompetenceID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", competenceWorker.WorkerID);
            return View(competenceWorker);
        }

        // GET: CompetenceWorkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenceWorker = await _context.CompetenceWorker.FindAsync(id);
            if (competenceWorker == null)
            {
                return NotFound();
            }
            ViewData["CompetenceID"] = new SelectList(_context.Competence, "CompetenceID", "CompetenceID", competenceWorker.CompetenceID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", competenceWorker.WorkerID);
            return View(competenceWorker);
        }

        // POST: CompetenceWorkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompetenceWorkerID,CompetenceID,WorkerID,Level")] CompetenceWorker competenceWorker)
        {
            if (id != competenceWorker.CompetenceWorkerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competenceWorker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetenceWorkerExists(competenceWorker.CompetenceWorkerID))
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
            ViewData["CompetenceID"] = new SelectList(_context.Competence, "CompetenceID", "CompetenceID", competenceWorker.CompetenceID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", competenceWorker.WorkerID);
            return View(competenceWorker);
        }

        // GET: CompetenceWorkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenceWorker = await _context.CompetenceWorker
                .Include(c => c.Competence)
                .Include(c => c.Worker)
                .FirstOrDefaultAsync(m => m.CompetenceWorkerID == id);
            if (competenceWorker == null)
            {
                return NotFound();
            }

            return View(competenceWorker);
        }

        // POST: CompetenceWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competenceWorker = await _context.CompetenceWorker.FindAsync(id);
            _context.CompetenceWorker.Remove(competenceWorker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetenceWorkerExists(int id)
        {
            return _context.CompetenceWorker.Any(e => e.CompetenceWorkerID == id);
        }
    }
}
