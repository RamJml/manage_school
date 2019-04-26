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
    public class TypeEquippementMatieresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeEquippementMatieresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeEquippementMatieres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TypeEquippementMatiere.Include(t => t.Ref_Matiere).Include(t => t.Ref_TypeEquippement);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TypeEquippementMatieres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeEquippementMatiere = await _context.TypeEquippementMatiere
                .Include(t => t.Ref_Matiere)
                .Include(t => t.Ref_TypeEquippement)
                .FirstOrDefaultAsync(m => m.Matiere_FK == id);
            if (typeEquippementMatiere == null)
            {
                return NotFound();
            }

            return View(typeEquippementMatiere);
        }

        // GET: TypeEquippementMatieres/Create
        public IActionResult Create()
        {
            ViewData["Matiere_FK"] = new SelectList(_context.Matiere, "Matiere_id", "Matiere_id");
            ViewData["TypeEquippement_FK"] = new SelectList(_context.TypeEquippement, "Type_Equippement_id", "Type_Equippement_id");
            return View();
        }

        // POST: TypeEquippementMatieres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeEquippement_FK,Matiere_FK")] TypeEquippementMatiere typeEquippementMatiere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeEquippementMatiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Matiere_FK"] = new SelectList(_context.Matiere, "Matiere_id", "Matiere_id", typeEquippementMatiere.Matiere_FK);
            ViewData["TypeEquippement_FK"] = new SelectList(_context.TypeEquippement, "Type_Equippement_id", "Type_Equippement_id", typeEquippementMatiere.TypeEquippement_FK);
            return View(typeEquippementMatiere);
        }

        // GET: TypeEquippementMatieres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeEquippementMatiere = await _context.TypeEquippementMatiere.FindAsync(id);
            if (typeEquippementMatiere == null)
            {
                return NotFound();
            }
            ViewData["Matiere_FK"] = new SelectList(_context.Matiere, "Matiere_id", "Matiere_id", typeEquippementMatiere.Matiere_FK);
            ViewData["TypeEquippement_FK"] = new SelectList(_context.TypeEquippement, "Type_Equippement_id", "Type_Equippement_id", typeEquippementMatiere.TypeEquippement_FK);
            return View(typeEquippementMatiere);
        }

        // POST: TypeEquippementMatieres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeEquippement_FK,Matiere_FK")] TypeEquippementMatiere typeEquippementMatiere)
        {
            if (id != typeEquippementMatiere.Matiere_FK)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeEquippementMatiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeEquippementMatiereExists(typeEquippementMatiere.Matiere_FK))
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
            ViewData["Matiere_FK"] = new SelectList(_context.Matiere, "Matiere_id", "Matiere_id", typeEquippementMatiere.Matiere_FK);
            ViewData["TypeEquippement_FK"] = new SelectList(_context.TypeEquippement, "Type_Equippement_id", "Type_Equippement_id", typeEquippementMatiere.TypeEquippement_FK);
            return View(typeEquippementMatiere);
        }

        // GET: TypeEquippementMatieres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeEquippementMatiere = await _context.TypeEquippementMatiere
                .Include(t => t.Ref_Matiere)
                .Include(t => t.Ref_TypeEquippement)
                .FirstOrDefaultAsync(m => m.Matiere_FK == id);
            if (typeEquippementMatiere == null)
            {
                return NotFound();
            }

            return View(typeEquippementMatiere);
        }

        // POST: TypeEquippementMatieres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeEquippementMatiere = await _context.TypeEquippementMatiere.FindAsync(id);
            _context.TypeEquippementMatiere.Remove(typeEquippementMatiere);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeEquippementMatiereExists(int id)
        {
            return _context.TypeEquippementMatiere.Any(e => e.Matiere_FK == id);
        }
    }
}
