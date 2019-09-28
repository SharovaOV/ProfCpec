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
    public class CompetencePositionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompetencePositionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompetencePositions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CompetencePosition.Include(c => c.Competence).Include(c => c.Position);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CompetencePositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencePosition = await _context.CompetencePosition
                .Include(c => c.Competence)
                .Include(c => c.Position)
                .FirstOrDefaultAsync(m => m.CompetencePositionID == id);
            if (competencePosition == null)
            {
                return NotFound();
            }

            return View(competencePosition);
        }

        // GET: CompetencePositions/Create
        public IActionResult Create()
        {
            ViewData["CompetenceID"] = new SelectList(_context.Competence, "CompetenceID", "CompetenceID");
            ViewData["PositionID"] = new SelectList(_context.Position, "PositionID", "Name");
            return View();
        }

        // POST: CompetencePositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompetencePositionID,CompetenceID,PositionID,Level")] CompetencePosition competencePosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competencePosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompetenceID"] = new SelectList(_context.Competence, "CompetenceID", "CompetenceID", competencePosition.CompetenceID);
            ViewData["PositionID"] = new SelectList(_context.Position, "PositionID", "Name", competencePosition.PositionID);
            return View(competencePosition);
        }

        // GET: CompetencePositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencePosition = await _context.CompetencePosition.FindAsync(id);
            if (competencePosition == null)
            {
                return NotFound();
            }
            ViewData["CompetenceID"] = new SelectList(_context.Competence, "CompetenceID", "CompetenceID", competencePosition.CompetenceID);
            ViewData["PositionID"] = new SelectList(_context.Position, "PositionID", "Name", competencePosition.PositionID);
            return View(competencePosition);
        }

        // POST: CompetencePositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompetencePositionID,CompetenceID,PositionID,Level")] CompetencePosition competencePosition)
        {
            if (id != competencePosition.CompetencePositionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competencePosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetencePositionExists(competencePosition.CompetencePositionID))
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
            ViewData["CompetenceID"] = new SelectList(_context.Competence, "CompetenceID", "CompetenceID", competencePosition.CompetenceID);
            ViewData["PositionID"] = new SelectList(_context.Position, "PositionID", "Name", competencePosition.PositionID);
            return View(competencePosition);
        }

        // GET: CompetencePositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencePosition = await _context.CompetencePosition
                .Include(c => c.Competence)
                .Include(c => c.Position)
                .FirstOrDefaultAsync(m => m.CompetencePositionID == id);
            if (competencePosition == null)
            {
                return NotFound();
            }

            return View(competencePosition);
        }

        // POST: CompetencePositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competencePosition = await _context.CompetencePosition.FindAsync(id);
            _context.CompetencePosition.Remove(competencePosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetencePositionExists(int id)
        {
            return _context.CompetencePosition.Any(e => e.CompetencePositionID == id);
        }
    }
}
