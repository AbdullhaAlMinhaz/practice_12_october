using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using practice_12_october.Data;
using practice_12_october.Models;

namespace practice_12_october.Controllers
{
    public class ManageCowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManageCowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ManageCows
        public async Task<IActionResult> Index()
        {
            return View(await _context.ManageCow.ToListAsync());
        }

        // GET: ManageCows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manageCow = await _context.ManageCow
                .FirstOrDefaultAsync(m => m.Tag_Number == id);
            if (manageCow == null)
            {
                return NotFound();
            }

            return View(manageCow);
        }

        [Authorize]
        // GET: ManageCows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManageCows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tag_Number,Name,Breeds,DateOfBirth,gender,Status")] ManageCow manageCow)
        {
            
            
                _context.Add(manageCow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(manageCow);
        }
        [Authorize]
        // GET: ManageCows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manageCow = await _context.ManageCow.FindAsync(id);
            if (manageCow == null)
            {
                return NotFound();
            }
            return View(manageCow);
        }

        // POST: ManageCows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tag_Number,Name,Breeds,DateOfBirth,gender,Status")] ManageCow manageCow)
        {
            if (id != manageCow.Tag_Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manageCow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManageCowExists(manageCow.Tag_Number))
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
            return View(manageCow);
        }
        [Authorize]
        // GET: ManageCows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manageCow = await _context.ManageCow
                .FirstOrDefaultAsync(m => m.Tag_Number == id);
            if (manageCow == null)
            {
                return NotFound();
            }

            return View(manageCow);
        }

        // POST: ManageCows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manageCow = await _context.ManageCow.FindAsync(id);
            if (manageCow != null)
            {
                _context.ManageCow.Remove(manageCow);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManageCowExists(int id)
        {
            return _context.ManageCow.Any(e => e.Tag_Number == id);
        }
    }
}
