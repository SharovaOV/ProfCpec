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
    public class RolOfProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolOfProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RolOfProjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.RolOfProject.ToListAsync());
        }

        // GET: RolOfProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolOfProject = await _context.RolOfProject
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rolOfProject == null)
            {
                return NotFound();
            }

            return View(rolOfProject);
        }

        // GET: RolOfProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RolOfProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] RolOfProject rolOfProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolOfProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rolOfProject);
        }

        // GET: RolOfProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolOfProject = await _context.RolOfProject.FindAsync(id);
            if (rolOfProject == null)
            {
                return NotFound();
            }
            return View(rolOfProject);
        }

        // POST: RolOfProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] RolOfProject rolOfProject)
        {
            if (id != rolOfProject.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolOfProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolOfProjectExists(rolOfProject.ID))
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
            return View(rolOfProject);
        }

        // GET: RolOfProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolOfProject = await _context.RolOfProject
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rolOfProject == null)
            {
                return NotFound();
            }

            return View(rolOfProject);
        }

        // POST: RolOfProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rolOfProject = await _context.RolOfProject.FindAsync(id);
            _context.RolOfProject.Remove(rolOfProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolOfProjectExists(int id)
        {
            return _context.RolOfProject.Any(e => e.ID == id);
        }
    }
}
