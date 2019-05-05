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
    public class EnseignantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnseignantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enseignants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enseignant.Include(e => e.Ref_Specialite);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Enseignants/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignant
                .Include(e => e.Ref_Specialite)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // GET: Enseignants/Create
        public IActionResult Create()
        {
            ViewData["Specialite_id_FK"] = new SelectList(_context.Specialite, "Specialite_id", "Specialite_id");
            return View();
        }

        // POST: Enseignants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Enseignant_nom,Enseignant_prenom,Specialite_id_FK")] Enseignant enseignant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enseignant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Specialite_id_FK"] = new SelectList(_context.Specialite, "Specialite_id", "Specialite_id", enseignant.Specialite_id_FK);
            return View(enseignant);
        }

        // GET: Enseignants/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignant.FindAsync(id);
            if (enseignant == null)
            {
                return NotFound();
            }
            ViewData["Specialite_id_FK"] = new SelectList(_context.Specialite, "Specialite_id", "Specialite_id", enseignant.Specialite_id_FK);
            return View(enseignant);
        }

        // POST: Enseignants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Enseignant_nom,Enseignant_prenom,Specialite_id_FK")] Enseignant enseignant)
        {
            if (id != enseignant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enseignant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnseignantExists(enseignant.Id))
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
            ViewData["Specialite_id_FK"] = new SelectList(_context.Specialite, "Specialite_id", "Specialite_id", enseignant.Specialite_id_FK);
            return View(enseignant);
        }

        // GET: Enseignants/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignant
                .Include(e => e.Ref_Specialite)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // POST: Enseignants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var enseignant = await _context.Enseignant.FindAsync(id);
            _context.Enseignant.Remove(enseignant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnseignantExists(string id)
        {
            return _context.Enseignant.Any(e => e.Id == id);
        }
    }
}
