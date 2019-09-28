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
    public class HobbyWorkersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HobbyWorkersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HobbyWorkers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HobbyWorker.Include(h => h.Hobby).Include(h => h.Worker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HobbyWorkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobbyWorker = await _context.HobbyWorker
                .Include(h => h.Hobby)
                .Include(h => h.Worker)
                .FirstOrDefaultAsync(m => m.HobbyWorkerID == id);
            if (hobbyWorker == null)
            {
                return NotFound();
            }

            return View(hobbyWorker);
        }

        // GET: HobbyWorkers/Create
        public IActionResult Create()
        {
            ViewData["HobbyID"] = new SelectList(_context.Hobby, "HobbyID", "HobbyID");
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID");
            return View();
        }

        // POST: HobbyWorkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HobbyWorkerID,WorkerID,HobbyID")] HobbyWorker hobbyWorker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hobbyWorker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HobbyID"] = new SelectList(_context.Hobby, "HobbyID", "HobbyID", hobbyWorker.HobbyID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", hobbyWorker.WorkerID);
            return View(hobbyWorker);
        }

        // GET: HobbyWorkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobbyWorker = await _context.HobbyWorker.FindAsync(id);
            if (hobbyWorker == null)
            {
                return NotFound();
            }
            ViewData["HobbyID"] = new SelectList(_context.Hobby, "HobbyID", "HobbyID", hobbyWorker.HobbyID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", hobbyWorker.WorkerID);
            return View(hobbyWorker);
        }

        // POST: HobbyWorkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HobbyWorkerID,WorkerID,HobbyID")] HobbyWorker hobbyWorker)
        {
            if (id != hobbyWorker.HobbyWorkerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hobbyWorker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HobbyWorkerExists(hobbyWorker.HobbyWorkerID))
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
            ViewData["HobbyID"] = new SelectList(_context.Hobby, "HobbyID", "HobbyID", hobbyWorker.HobbyID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", hobbyWorker.WorkerID);
            return View(hobbyWorker);
        }

        // GET: HobbyWorkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobbyWorker = await _context.HobbyWorker
                .Include(h => h.Hobby)
                .Include(h => h.Worker)
                .FirstOrDefaultAsync(m => m.HobbyWorkerID == id);
            if (hobbyWorker == null)
            {
                return NotFound();
            }

            return View(hobbyWorker);
        }

        // POST: HobbyWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hobbyWorker = await _context.HobbyWorker.FindAsync(id);
            _context.HobbyWorker.Remove(hobbyWorker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HobbyWorkerExists(int id)
        {
            return _context.HobbyWorker.Any(e => e.HobbyWorkerID == id);
        }
    }
}
