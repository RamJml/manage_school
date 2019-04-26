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
    public class EquippementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquippementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Equippements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Equippement.Include(e => e.Ref_TypeEquippement);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Equippements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equippement = await _context.Equippement
                .Include(e => e.Ref_TypeEquippement)
                .FirstOrDefaultAsync(m => m.Equippement_id == id);
            if (equippement == null)
            {
                return NotFound();
            }

            return View(equippement);
        }

        // GET: Equippements/Create
        public IActionResult Create()
        {
            ViewData["TypeEquippement_id_FK"] = new SelectList(_context.Set<TypeEquippement>(), "Type_Equippement_id", "Type_Equippement_id");
            return View();
        }

        // POST: Equippements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Equippement_id,Equippement_designation,TypeEquippement_id_FK")] Equippement equippement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equippement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeEquippement_id_FK"] = new SelectList(_context.Set<TypeEquippement>(), "Type_Equippement_id", "Type_Equippement_id", equippement.TypeEquippement_id_FK);
            return View(equippement);
        }

        // GET: Equippements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equippement = await _context.Equippement.FindAsync(id);
            if (equippement == null)
            {
                return NotFound();
            }
            ViewData["TypeEquippement_id_FK"] = new SelectList(_context.Set<TypeEquippement>(), "Type_Equippement_id", "Type_Equippement_id", equippement.TypeEquippement_id_FK);
            return View(equippement);
        }

        // POST: Equippements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Equippement_id,Equippement_designation,TypeEquippement_id_FK")] Equippement equippement)
        {
            if (id != equippement.Equippement_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equippement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquippementExists(equippement.Equippement_id))
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
            ViewData["TypeEquippement_id_FK"] = new SelectList(_context.Set<TypeEquippement>(), "Type_Equippement_id", "Type_Equippement_id", equippement.TypeEquippement_id_FK);
            return View(equippement);
        }

        // GET: Equippements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equippement = await _context.Equippement
                .Include(e => e.Ref_TypeEquippement)
                .FirstOrDefaultAsync(m => m.Equippement_id == id);
            if (equippement == null)
            {
                return NotFound();
            }

            return View(equippement);
        }

        // POST: Equippements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equippement = await _context.Equippement.FindAsync(id);
            _context.Equippement.Remove(equippement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquippementExists(int id)
        {
            return _context.Equippement.Any(e => e.Equippement_id == id);
        }
    }
}
