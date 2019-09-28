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
    public class HobbiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HobbiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hobbies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hobby.ToListAsync());
        }

        // GET: Hobbies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobby = await _context.Hobby
                .FirstOrDefaultAsync(m => m.HobbyID == id);
            if (hobby == null)
            {
                return NotFound();
            }

            return View(hobby);
        }

        // GET: Hobbies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hobbies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HobbyID,Name")] Hobby hobby)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hobby);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hobby);
        }

        // GET: Hobbies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobby = await _context.Hobby.FindAsync(id);
            if (hobby == null)
            {
                return NotFound();
            }
            return View(hobby);
        }

        // POST: Hobbies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HobbyID,Name")] Hobby hobby)
        {
            if (id != hobby.HobbyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hobby);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HobbyExists(hobby.HobbyID))
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
            return View(hobby);
        }

        // GET: Hobbies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobby = await _context.Hobby
                .FirstOrDefaultAsync(m => m.HobbyID == id);
            if (hobby == null)
            {
                return NotFound();
            }

            return View(hobby);
        }

        // POST: Hobbies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hobby = await _context.Hobby.FindAsync(id);
            _context.Hobby.Remove(hobby);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HobbyExists(int id)
        {
            return _context.Hobby.Any(e => e.HobbyID == id);
        }
    }
}
