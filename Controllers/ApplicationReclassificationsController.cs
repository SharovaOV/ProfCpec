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
    public class ApplicationReclassificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationReclassificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationReclassifications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ApplicationReclassification.Include(a => a.Position).Include(a => a.StagesApplication).Include(a => a.Worker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ApplicationReclassifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationReclassification = await _context.ApplicationReclassification
                .Include(a => a.Position)
                .Include(a => a.StagesApplication)
                .Include(a => a.Worker)
                .FirstOrDefaultAsync(m => m.ApplicationReclassificationID == id);
            if (applicationReclassification == null)
            {
                return NotFound();
            }

            return View(applicationReclassification);
        }

        // GET: ApplicationReclassifications/Create
        public IActionResult Create()
        {
            ViewData["PositionID"] = new SelectList(_context.Position, "PositionID", "Name");
            ViewData["StagesApplicationID"] = new SelectList(_context.StagesApplication, "StagesApplicationID", "StagesApplicationID");
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID");
            return View();
        }

        // POST: ApplicationReclassifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationReclassificationID,ApplicationCourseID,WorkerID,PositionID,StagesApplicationID")] ApplicationReclassification applicationReclassification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationReclassification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PositionID"] = new SelectList(_context.Position, "PositionID", "Name", applicationReclassification.PositionID);
            ViewData["StagesApplicationID"] = new SelectList(_context.StagesApplication, "StagesApplicationID", "StagesApplicationID", applicationReclassification.StagesApplicationID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", applicationReclassification.WorkerID);
            return View(applicationReclassification);
        }

        // GET: ApplicationReclassifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationReclassification = await _context.ApplicationReclassification.FindAsync(id);
            if (applicationReclassification == null)
            {
                return NotFound();
            }
            ViewData["PositionID"] = new SelectList(_context.Position, "PositionID", "Name", applicationReclassification.PositionID);
            ViewData["StagesApplicationID"] = new SelectList(_context.StagesApplication, "StagesApplicationID", "StagesApplicationID", applicationReclassification.StagesApplicationID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", applicationReclassification.WorkerID);
            return View(applicationReclassification);
        }

        // POST: ApplicationReclassifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationReclassificationID,ApplicationCourseID,WorkerID,PositionID,StagesApplicationID")] ApplicationReclassification applicationReclassification)
        {
            if (id != applicationReclassification.ApplicationReclassificationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationReclassification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationReclassificationExists(applicationReclassification.ApplicationReclassificationID))
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
            ViewData["PositionID"] = new SelectList(_context.Position, "PositionID", "Name", applicationReclassification.PositionID);
            ViewData["StagesApplicationID"] = new SelectList(_context.StagesApplication, "StagesApplicationID", "StagesApplicationID", applicationReclassification.StagesApplicationID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", applicationReclassification.WorkerID);
            return View(applicationReclassification);
        }

        // GET: ApplicationReclassifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationReclassification = await _context.ApplicationReclassification
                .Include(a => a.Position)
                .Include(a => a.StagesApplication)
                .Include(a => a.Worker)
                .FirstOrDefaultAsync(m => m.ApplicationReclassificationID == id);
            if (applicationReclassification == null)
            {
                return NotFound();
            }

            return View(applicationReclassification);
        }

        // POST: ApplicationReclassifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationReclassification = await _context.ApplicationReclassification.FindAsync(id);
            _context.ApplicationReclassification.Remove(applicationReclassification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationReclassificationExists(int id)
        {
            return _context.ApplicationReclassification.Any(e => e.ApplicationReclassificationID == id);
        }
    }
}
