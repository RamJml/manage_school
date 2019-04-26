using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HighSchoolManager.Data;

namespace HighSchoolManager.Controllers
{
    public class AbsencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbsencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Absences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Absence.Include(a => a.Ref_Etudiant).Include(a => a.Ref_Seance);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Absences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absence = await _context.Absence
                .Include(a => a.Ref_Etudiant)
                .Include(a => a.Ref_Seance)
                .FirstOrDefaultAsync(m => m.Absence_id == id);
            if (absence == null)
            {
                return NotFound();
            }

            return View(absence);
        }

        // GET: Absences/Create
        public IActionResult Create()
        {
            ViewData["Etudiant_FK"] = new SelectList(_context.Etudiant, "Id", "Id");
            ViewData["Seance_FK"] = new SelectList(_context.Seance, "Seance_id", "Seance_id");
            return View();
        }

        // POST: Absences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Absence_id,Etudiant_FK,Seance_FK")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(absence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Etudiant_FK"] = new SelectList(_context.Etudiant, "Id", "Id", absence.Etudiant_FK);
            ViewData["Seance_FK"] = new SelectList(_context.Seance, "Seance_id", "Seance_id", absence.Seance_FK);
            return View(absence);
        }

        // GET: Absences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absence = await _context.Absence.FindAsync(id);
            if (absence == null)
            {
                return NotFound();
            }
            ViewData["Etudiant_FK"] = new SelectList(_context.Etudiant, "Id", "Id", absence.Etudiant_FK);
            ViewData["Seance_FK"] = new SelectList(_context.Seance, "Seance_id", "Seance_id", absence.Seance_FK);
            return View(absence);
        }

        // POST: Absences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Absence_id,Etudiant_FK,Seance_FK")] Absence absence)
        {
            if (id != absence.Absence_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(absence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbsenceExists(absence.Absence_id))
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
            ViewData["Etudiant_FK"] = new SelectList(_context.Etudiant, "Id", "Id", absence.Etudiant_FK);
            ViewData["Seance_FK"] = new SelectList(_context.Seance, "Seance_id", "Seance_id", absence.Seance_FK);
            return View(absence);
        }

        // GET: Absences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absence = await _context.Absence
                .Include(a => a.Ref_Etudiant)
                .Include(a => a.Ref_Seance)
                .FirstOrDefaultAsync(m => m.Absence_id == id);
            if (absence == null)
            {
                return NotFound();
            }

            return View(absence);
        }

        // POST: Absences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var absence = await _context.Absence.FindAsync(id);
            _context.Absence.Remove(absence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbsenceExists(int id)
        {
            return _context.Absence.Any(e => e.Absence_id == id);
        }
    }
}
