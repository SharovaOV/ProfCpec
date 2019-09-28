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
    public class ProjectWorkersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectWorkersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectWorkers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjectWorker.Include(p => p.Project).Include(p => p.RolOfProject).Include(p => p.Worker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProjectWorkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectWorker = await _context.ProjectWorker
                .Include(p => p.Project)
                .Include(p => p.RolOfProject)
                .Include(p => p.Worker)
                .FirstOrDefaultAsync(m => m.ProjectWorkerID == id);
            if (projectWorker == null)
            {
                return NotFound();
            }

            return View(projectWorker);
        }

        // GET: ProjectWorkers/Create
        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "ProjectID");
            ViewData["RolOfProjectID"] = new SelectList(_context.RolOfProject, "ID", "ID");
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID");
            return View();
        }

        // POST: ProjectWorkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectWorkerID,ProjectID,WorkerID,RolOfProjectID")] ProjectWorker projectWorker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectWorker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "ProjectID", projectWorker.ProjectID);
            ViewData["RolOfProjectID"] = new SelectList(_context.RolOfProject, "ID", "ID", projectWorker.RolOfProjectID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", projectWorker.WorkerID);
            return View(projectWorker);
        }

        // GET: ProjectWorkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectWorker = await _context.ProjectWorker.FindAsync(id);
            if (projectWorker == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "ProjectID", projectWorker.ProjectID);
            ViewData["RolOfProjectID"] = new SelectList(_context.RolOfProject, "ID", "ID", projectWorker.RolOfProjectID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", projectWorker.WorkerID);
            return View(projectWorker);
        }

        // POST: ProjectWorkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectWorkerID,ProjectID,WorkerID,RolOfProjectID")] ProjectWorker projectWorker)
        {
            if (id != projectWorker.ProjectWorkerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectWorker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectWorkerExists(projectWorker.ProjectWorkerID))
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
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "ProjectID", projectWorker.ProjectID);
            ViewData["RolOfProjectID"] = new SelectList(_context.RolOfProject, "ID", "ID", projectWorker.RolOfProjectID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", projectWorker.WorkerID);
            return View(projectWorker);
        }

        // GET: ProjectWorkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectWorker = await _context.ProjectWorker
                .Include(p => p.Project)
                .Include(p => p.RolOfProject)
                .Include(p => p.Worker)
                .FirstOrDefaultAsync(m => m.ProjectWorkerID == id);
            if (projectWorker == null)
            {
                return NotFound();
            }

            return View(projectWorker);
        }

        // POST: ProjectWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectWorker = await _context.ProjectWorker.FindAsync(id);
            _context.ProjectWorker.Remove(projectWorker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectWorkerExists(int id)
        {
            return _context.ProjectWorker.Any(e => e.ProjectWorkerID == id);
        }
    }
}
