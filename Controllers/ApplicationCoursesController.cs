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
    public class ApplicationCoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationCoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationCourses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ApplicationCourse.Include(a => a.Course).Include(a => a.StagesApplication).Include(a => a.Worker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ApplicationCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationCourse = await _context.ApplicationCourse
                .Include(a => a.Course)
                .Include(a => a.StagesApplication)
                .Include(a => a.Worker)
                .FirstOrDefaultAsync(m => m.ApplicationCourseID == id);
            if (applicationCourse == null)
            {
                return NotFound();
            }

            return View(applicationCourse);
        }

        // GET: ApplicationCourses/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Course, "CourseID", "CourseID");
            ViewData["StagesApplicationID"] = new SelectList(_context.StagesApplication, "StagesApplicationID", "StagesApplicationID");
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID");
            return View();
        }

        // POST: ApplicationCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationCourseID,WorkerID,CourseID,StagesApplicationID")] ApplicationCourse applicationCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Course, "CourseID", "CourseID", applicationCourse.CourseID);
            ViewData["StagesApplicationID"] = new SelectList(_context.StagesApplication, "StagesApplicationID", "StagesApplicationID", applicationCourse.StagesApplicationID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", applicationCourse.WorkerID);
            return View(applicationCourse);
        }

        // GET: ApplicationCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationCourse = await _context.ApplicationCourse.FindAsync(id);
            if (applicationCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Course, "CourseID", "CourseID", applicationCourse.CourseID);
            ViewData["StagesApplicationID"] = new SelectList(_context.StagesApplication, "StagesApplicationID", "StagesApplicationID", applicationCourse.StagesApplicationID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", applicationCourse.WorkerID);
            return View(applicationCourse);
        }

        // POST: ApplicationCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationCourseID,WorkerID,CourseID,StagesApplicationID")] ApplicationCourse applicationCourse)
        {
            if (id != applicationCourse.ApplicationCourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationCourseExists(applicationCourse.ApplicationCourseID))
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
            ViewData["CourseID"] = new SelectList(_context.Course, "CourseID", "CourseID", applicationCourse.CourseID);
            ViewData["StagesApplicationID"] = new SelectList(_context.StagesApplication, "StagesApplicationID", "StagesApplicationID", applicationCourse.StagesApplicationID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "ID", "ID", applicationCourse.WorkerID);
            return View(applicationCourse);
        }

        // GET: ApplicationCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationCourse = await _context.ApplicationCourse
                .Include(a => a.Course)
                .Include(a => a.StagesApplication)
                .Include(a => a.Worker)
                .FirstOrDefaultAsync(m => m.ApplicationCourseID == id);
            if (applicationCourse == null)
            {
                return NotFound();
            }

            return View(applicationCourse);
        }

        // POST: ApplicationCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationCourse = await _context.ApplicationCourse.FindAsync(id);
            _context.ApplicationCourse.Remove(applicationCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationCourseExists(int id)
        {
            return _context.ApplicationCourse.Any(e => e.ApplicationCourseID == id);
        }
    }
}
