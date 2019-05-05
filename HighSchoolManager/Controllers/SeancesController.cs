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
    public class SeancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Seances
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Seance.Include(s => s.Ref_Enseignant).Include(s => s.Ref_Groupe).Include(s => s.Ref_Matiere).Include(s => s.Ref_Salle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Seances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seance = await _context.Seance
                .Include(s => s.Ref_Enseignant)
                .Include(s => s.Ref_Groupe)
                .Include(s => s.Ref_Matiere)
                .Include(s => s.Ref_Salle)
                .FirstOrDefaultAsync(m => m.Seance_id == id);
            if (seance == null)
            {
                return NotFound();
            }

            return View(seance);
        }

        // GET: Seances/Create
        public IActionResult Create()
        {

            ViewData["Seance_Jour"] = new SelectList(ApplicationDbContext.Jours);
            ViewData["Seance_Heure"] = new SelectList(ApplicationDbContext.Horaire);
            ViewData["Enseignant_id_FK"] = new SelectList(_context.Enseignant, "Id", "Id");
            ViewData["Groupe_id_FK"] = new SelectList(_context.Groupes, "Groupe_id", "Groupe_id");
            ViewData["Matiere_id_FK"] = new SelectList(_context.Matiere, "Matiere_id", "Matiere_id");
            ViewData["Salle_id_FK"] = new SelectList(_context.Salle, "Salle_id", "Salle_id");
            return View();
        }

        // POST: Seances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Seance_id,Seance_Jour,Seance_Heure,Enseignant_id_FK,Matiere_id_FK,Salle_id_FK,Groupe_id_FK")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Enseignant_id_FK"] = new SelectList(_context.Enseignant, "Id", "Id", seance.Enseignant_id_FK);
            ViewData["Groupe_id_FK"] = new SelectList(_context.Groupes, "Groupe_id", "Groupe_id", seance.Groupe_id_FK);
            ViewData["Matiere_id_FK"] = new SelectList(_context.Matiere, "Matiere_id", "Matiere_id", seance.Matiere_id_FK);
            ViewData["Salle_id_FK"] = new SelectList(_context.Salle, "Salle_id", "Salle_id", seance.Salle_id_FK);
            return View(seance);
        }

        // GET: Seances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seance = await _context.Seance.FindAsync(id);
            if (seance == null)
            {
                return NotFound();
            }
            ViewData["Enseignant_id_FK"] = new SelectList(_context.Enseignant, "Id", "Id", seance.Enseignant_id_FK);
            ViewData["Groupe_id_FK"] = new SelectList(_context.Groupes, "Groupe_id", "Groupe_id", seance.Groupe_id_FK);
            ViewData["Matiere_id_FK"] = new SelectList(_context.Matiere, "Matiere_id", "Matiere_id", seance.Matiere_id_FK);
            ViewData["Salle_id_FK"] = new SelectList(_context.Salle, "Salle_id", "Salle_id", seance.Salle_id_FK);
            return View(seance);
        }

        // POST: Seances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Seance_id,Seance_Jour,Seance_Heure,Enseignant_id_FK,Matiere_id_FK,Salle_id_FK,Groupe_id_FK")] Seance seance)
        {
            if (id != seance.Seance_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeanceExists(seance.Seance_id))
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
            ViewData["Enseignant_id_FK"] = new SelectList(_context.Enseignant, "Id", "Id", seance.Enseignant_id_FK);
            ViewData["Groupe_id_FK"] = new SelectList(_context.Groupes, "Groupe_id", "Groupe_id", seance.Groupe_id_FK);
            ViewData["Matiere_id_FK"] = new SelectList(_context.Matiere, "Matiere_id", "Matiere_id", seance.Matiere_id_FK);
            ViewData["Salle_id_FK"] = new SelectList(_context.Salle, "Salle_id", "Salle_id", seance.Salle_id_FK);
            return View(seance);
        }

        // GET: Seances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seance = await _context.Seance
                .Include(s => s.Ref_Enseignant)
                .Include(s => s.Ref_Groupe)
                .Include(s => s.Ref_Matiere)
                .Include(s => s.Ref_Salle)
                .FirstOrDefaultAsync(m => m.Seance_id == id);
            if (seance == null)
            {
                return NotFound();
            }

            return View(seance);
        }

        // POST: Seances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seance = await _context.Seance.FindAsync(id);
            _context.Seance.Remove(seance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeanceExists(int id)
        {
            return _context.Seance.Any(e => e.Seance_id == id);
        }
    }
}
