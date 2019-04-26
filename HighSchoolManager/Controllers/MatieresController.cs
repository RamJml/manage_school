﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HighSchoolManager.Data;

namespace HighSchoolManager.Controllers
{
    public class MatieresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatieresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Matieres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Matiere.Include(m => m.Ref_Specialite);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Matieres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matiere
                .Include(m => m.Ref_Specialite)
                .FirstOrDefaultAsync(m => m.Matiere_id == id);
            if (matiere == null)
            {
                return NotFound();
            }

            return View(matiere);
        }

        // GET: Matieres/Create
        public IActionResult Create()
        {
            ViewData["Specialite_id_FK"] = new SelectList(_context.Specialite, "Specialite_id", "Specialite_id");
            return View();
        }

        // POST: Matieres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matiere_id,Matiere_designation,Specialite_id_FK")] Matiere matiere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Specialite_id_FK"] = new SelectList(_context.Specialite, "Specialite_id", "Specialite_id", matiere.Specialite_id_FK);
            return View(matiere);
        }

        // GET: Matieres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matiere.FindAsync(id);
            if (matiere == null)
            {
                return NotFound();
            }
            ViewData["Specialite_id_FK"] = new SelectList(_context.Specialite, "Specialite_id", "Specialite_id", matiere.Specialite_id_FK);
            return View(matiere);
        }

        // POST: Matieres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matiere_id,Matiere_designation,Specialite_id_FK")] Matiere matiere)
        {
            if (id != matiere.Matiere_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatiereExists(matiere.Matiere_id))
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
            ViewData["Specialite_id_FK"] = new SelectList(_context.Specialite, "Specialite_id", "Specialite_id", matiere.Specialite_id_FK);
            return View(matiere);
        }

        // GET: Matieres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matiere
                .Include(m => m.Ref_Specialite)
                .FirstOrDefaultAsync(m => m.Matiere_id == id);
            if (matiere == null)
            {
                return NotFound();
            }

            return View(matiere);
        }

        // POST: Matieres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matiere = await _context.Matiere.FindAsync(id);
            _context.Matiere.Remove(matiere);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatiereExists(int id)
        {
            return _context.Matiere.Any(e => e.Matiere_id == id);
        }
    }
}
