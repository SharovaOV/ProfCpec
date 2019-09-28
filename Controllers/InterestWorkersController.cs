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
    public class InterestWorkersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InterestWorkersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InterestWorkers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InterestWorker.Include(i => i.Interest).Include(i => i.Worker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InterestWorkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interestWorker = await _context.InterestWorker
                .Include(i => i.Interest)
                .Include(i => i.Worker)
                .FirstOrDefaultAsync(m => m.InterestWorkerID == id);
            if (interestWorker == null)
            {
                return NotFound();
            }

            return View(interestWorker);
        }

        // GET: InterestWorkers/Create
        public IActionResult Create()
        {
            ViewData["InterestID"] = new SelectList(_context.Interest, "InterestID", "InterestID");
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID");
            return View();
        }

        // POST: InterestWorkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InterestWorkerID,InterestID,WorkerID")] InterestWorker interestWorker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interestWorker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InterestID"] = new SelectList(_context.Interest, "InterestID", "InterestID", interestWorker.InterestID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", interestWorker.WorkerID);
            return View(interestWorker);
        }

        // GET: InterestWorkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interestWorker = await _context.InterestWorker.FindAsync(id);
            if (interestWorker == null)
            {
                return NotFound();
            }
            ViewData["InterestID"] = new SelectList(_context.Interest, "InterestID", "InterestID", interestWorker.InterestID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", interestWorker.WorkerID);
            return View(interestWorker);
        }

        // POST: InterestWorkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InterestWorkerID,InterestID,WorkerID")] InterestWorker interestWorker)
        {
            if (id != interestWorker.InterestWorkerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interestWorker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterestWorkerExists(interestWorker.InterestWorkerID))
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
            ViewData["InterestID"] = new SelectList(_context.Interest, "InterestID", "InterestID", interestWorker.InterestID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", interestWorker.WorkerID);
            return View(interestWorker);
        }

        // GET: InterestWorkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interestWorker = await _context.InterestWorker
                .Include(i => i.Interest)
                .Include(i => i.Worker)
                .FirstOrDefaultAsync(m => m.InterestWorkerID == id);
            if (interestWorker == null)
            {
                return NotFound();
            }

            return View(interestWorker);
        }

        // POST: InterestWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interestWorker = await _context.InterestWorker.FindAsync(id);
            _context.InterestWorker.Remove(interestWorker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterestWorkerExists(int id)
        {
            return _context.InterestWorker.Any(e => e.InterestWorkerID == id);
        }
    }
}
