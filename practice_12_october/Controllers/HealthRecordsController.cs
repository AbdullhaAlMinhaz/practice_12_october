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
    public class HealthRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HealthRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HealthRecords
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HealthRecord.Include(h => h.ManageCow);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HealthRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthRecord = await _context.HealthRecord
                .Include(h => h.ManageCow)
                .FirstOrDefaultAsync(m => m.H_RecordId == id);
            if (healthRecord == null)
            {
                return NotFound();
            }

            return View(healthRecord);
        }
        [Authorize]
        // GET: HealthRecords/Create
        public IActionResult Create()
        {
            ViewData["Tag_Number"] = new SelectList(_context.ManageCow, "Tag_Number", "Tag_Number");
            return View();
        }

        // POST: HealthRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("H_RecordId,RecordDate,F_Vaccine,L_Vaccine,Treatment,Health_Condition,Tag_Number")] HealthRecord healthRecord)
        {
           
                _context.Add(healthRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["Tag_Number"] = new SelectList(_context.ManageCow, "Tag_Number", "Tag_Number", healthRecord.Tag_Number);
            return View(healthRecord);
        }

        // GET: HealthRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthRecord = await _context.HealthRecord.FindAsync(id);
            if (healthRecord == null)
            {
                return NotFound();
            }
            ViewData["Tag_Number"] = new SelectList(_context.ManageCow, "Tag_Number", "Tag_Number", healthRecord.Tag_Number);
            return View(healthRecord);
        }

        // POST: HealthRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("H_RecordId,RecordDate,F_Vaccine,L_Vaccine,Treatment,Health_Condition,Tag_Number")] HealthRecord healthRecord)
        {
            if (id != healthRecord.H_RecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthRecordExists(healthRecord.H_RecordId))
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
            ViewData["Tag_Number"] = new SelectList(_context.ManageCow, "Tag_Number", "Tag_Number", healthRecord.Tag_Number);
            return View(healthRecord);
        }
        [Authorize]
        // GET: HealthRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthRecord = await _context.HealthRecord
                .Include(h => h.ManageCow)
                .FirstOrDefaultAsync(m => m.H_RecordId == id);
            if (healthRecord == null)
            {
                return NotFound();
            }

            return View(healthRecord);
        }
        [Authorize]
        // POST: HealthRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var healthRecord = await _context.HealthRecord.FindAsync(id);
            if (healthRecord != null)
            {
                _context.HealthRecord.Remove(healthRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthRecordExists(int id)
        {
            return _context.HealthRecord.Any(e => e.H_RecordId == id);
        }
    }
}
