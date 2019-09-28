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
    public class CompetenceCoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompetenceCoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompetenceCourses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CompetenceCourse.Include(c => c.Competence).Include(c => c.Course);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CompetenceCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenceCourse = await _context.CompetenceCourse
                .Include(c => c.Competence)
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.CompetenceCourseID == id);
            if (competenceCourse == null)
            {
                return NotFound();
            }

            return View(competenceCourse);
        }

        // GET: CompetenceCourses/Create
        public IActionResult Create()
        {
            ViewData["CompetenceID"] = new SelectList(_context.Competence, "CompetenceID", "CompetenceID");
            ViewData["CourseID"] = new SelectList(_context.Course, "CourseID", "CourseID");
            return View();
        }

        // POST: CompetenceCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompetenceCourseID,CompetenceID,CourseID,Level")] CompetenceCourse competenceCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competenceCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompetenceID"] = new SelectList(_context.Competence, "CompetenceID", "CompetenceID", competenceCourse.CompetenceID);
            ViewData["CourseID"] = new SelectList(_context.Course, "CourseID", "CourseID", competenceCourse.CourseID);
            return View(competenceCourse);
        }

        // GET: CompetenceCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenceCourse = await _context.CompetenceCourse.FindAsync(id);
            if (competenceCourse == null)
            {
                return NotFound();
            }
            ViewData["CompetenceID"] = new SelectList(_context.Competence, "CompetenceID", "CompetenceID", competenceCourse.CompetenceID);
            ViewData["CourseID"] = new SelectList(_context.Course, "CourseID", "CourseID", competenceCourse.CourseID);
            return View(competenceCourse);
        }

        // POST: CompetenceCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompetenceCourseID,CompetenceID,CourseID,Level")] CompetenceCourse competenceCourse)
        {
            if (id != competenceCourse.CompetenceCourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competenceCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetenceCourseExists(competenceCourse.CompetenceCourseID))
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
            ViewData["CompetenceID"] = new SelectList(_context.Competence, "CompetenceID", "CompetenceID", competenceCourse.CompetenceID);
            ViewData["CourseID"] = new SelectList(_context.Course, "CourseID", "CourseID", competenceCourse.CourseID);
            return View(competenceCourse);
        }

        // GET: CompetenceCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenceCourse = await _context.CompetenceCourse
                .Include(c => c.Competence)
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.CompetenceCourseID == id);
            if (competenceCourse == null)
            {
                return NotFound();
            }

            return View(competenceCourse);
        }

        // POST: CompetenceCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competenceCourse = await _context.CompetenceCourse.FindAsync(id);
            _context.CompetenceCourse.Remove(competenceCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetenceCourseExists(int id)
        {
            return _context.CompetenceCourse.Any(e => e.CompetenceCourseID == id);
        }
    }
}
