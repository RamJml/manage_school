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
    public class TypeEquippementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeEquippementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeEquippements
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeEquippement.ToListAsync());
        }

        // GET: TypeEquippements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeEquippement = await _context.TypeEquippement
                .FirstOrDefaultAsync(m => m.Type_Equippement_id == id);
            if (typeEquippement == null)
            {
                return NotFound();
            }

            return View(typeEquippement);
        }

        // GET: TypeEquippements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeEquippements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Type_Equippement_id,Type_Equippement_designation")] TypeEquippement typeEquippement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeEquippement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeEquippement);
        }

        // GET: TypeEquippements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeEquippement = await _context.TypeEquippement.FindAsync(id);
            if (typeEquippement == null)
            {
                return NotFound();
            }
            return View(typeEquippement);
        }

        // POST: TypeEquippements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Type_Equippement_id,Type_Equippement_designation")] TypeEquippement typeEquippement)
        {
            if (id != typeEquippement.Type_Equippement_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeEquippement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeEquippementExists(typeEquippement.Type_Equippement_id))
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
            return View(typeEquippement);
        }

        // GET: TypeEquippements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeEquippement = await _context.TypeEquippement
                .FirstOrDefaultAsync(m => m.Type_Equippement_id == id);
            if (typeEquippement == null)
            {
                return NotFound();
            }

            return View(typeEquippement);
        }

        // POST: TypeEquippements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeEquippement = await _context.TypeEquippement.FindAsync(id);
            _context.TypeEquippement.Remove(typeEquippement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeEquippementExists(int id)
        {
            return _context.TypeEquippement.Any(e => e.Type_Equippement_id == id);
        }
    }
}
