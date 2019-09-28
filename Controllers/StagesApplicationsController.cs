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
    public class StagesApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StagesApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StagesApplications
        public async Task<IActionResult> Index()
        {
            return View(await _context.StagesApplication.ToListAsync());
        }

        // GET: StagesApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stagesApplication = await _context.StagesApplication
                .FirstOrDefaultAsync(m => m.StagesApplicationID == id);
            if (stagesApplication == null)
            {
                return NotFound();
            }

            return View(stagesApplication);
        }

        // GET: StagesApplications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StagesApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StagesApplicationID,Name")] StagesApplication stagesApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stagesApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stagesApplication);
        }

        // GET: StagesApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stagesApplication = await _context.StagesApplication.FindAsync(id);
            if (stagesApplication == null)
            {
                return NotFound();
            }
            return View(stagesApplication);
        }

        // POST: StagesApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StagesApplicationID,Name")] StagesApplication stagesApplication)
        {
            if (id != stagesApplication.StagesApplicationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stagesApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StagesApplicationExists(stagesApplication.StagesApplicationID))
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
            return View(stagesApplication);
        }

        // GET: StagesApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stagesApplication = await _context.StagesApplication
                .FirstOrDefaultAsync(m => m.StagesApplicationID == id);
            if (stagesApplication == null)
            {
                return NotFound();
            }

            return View(stagesApplication);
        }

        // POST: StagesApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stagesApplication = await _context.StagesApplication.FindAsync(id);
            _context.StagesApplication.Remove(stagesApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StagesApplicationExists(int id)
        {
            return _context.StagesApplication.Any(e => e.StagesApplicationID == id);
        }
    }
}
