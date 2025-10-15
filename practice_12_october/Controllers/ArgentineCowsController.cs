using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using practice_12_october.Data;
using practice_12_october.Models;

namespace practice_12_october.Controllers
{
    public class ArgentineCowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArgentineCowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArgentineCows
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArgentineCow.ToListAsync());
        }

        // GET: ArgentineCows/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var argentineCow = await _context.ArgentineCow
                .FirstOrDefaultAsync(m => m.id == id);
            if (argentineCow == null)
            {
                return NotFound();
            }

            return View(argentineCow);
        }

        // GET: ArgentineCows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArgentineCows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,DateOfBirth,description,price,First_Vacine_date,Last_Vacine_date,color")] ArgentineCow argentineCow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(argentineCow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(argentineCow);
        }

        // GET: ArgentineCows/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var argentineCow = await _context.ArgentineCow.FindAsync(id);
            if (argentineCow == null)
            {
                return NotFound();
            }
            return View(argentineCow);
        }

        // POST: ArgentineCows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,name,DateOfBirth,description,price,First_Vacine_date,Last_Vacine_date,color")] ArgentineCow argentineCow)
        {
            if (id != argentineCow.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(argentineCow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArgentineCowExists(argentineCow.id))
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
            return View(argentineCow);
        }

        // GET: ArgentineCows/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var argentineCow = await _context.ArgentineCow
                .FirstOrDefaultAsync(m => m.id == id);
            if (argentineCow == null)
            {
                return NotFound();
            }

            return View(argentineCow);
        }

        // POST: ArgentineCows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var argentineCow = await _context.ArgentineCow.FindAsync(id);
            if (argentineCow != null)
            {
                _context.ArgentineCow.Remove(argentineCow);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArgentineCowExists(string id)
        {
            return _context.ArgentineCow.Any(e => e.id == id);
        }
    }
}
