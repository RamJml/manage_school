using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HighSchoolManager.Data;

namespace HighSchoolManager.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TypeEquippementMatiere>()
                .HasKey(c => new { c.Matiere_FK, c.TypeEquippement_FK});
        }
        public readonly static string[] Jours = {
            "Lundi",
            "Mardi",
            "Mercredi",
            "Jeudi",
            "Vendredi",
            "Samedi"
        };
        public readonly static string[] Horaire = {
            "08:00-08:55",
            "09:00-09:55",
            "10:00-10:55",
            "11:00-11:55",

            "14:00-14:55",
            "15:00-15:55",
            "16:00-16:55",
            "17:00-17:55"
        };

        public DbSet<Enseignant> Enseignant { get; set; }
        public DbSet<Etudiant> Etudiant { get; set; }

        public DbSet<Absence> Absence { get; set; }
        public DbSet<Seance> Seance { get; set; }

        public DbSet<Niveau> Niveaux { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Groupe> Groupes { get; set; }

        public DbSet<Salle> Salle { get; set; }
        public DbSet<Matiere> Matiere { get; set; }
        public DbSet<Equippement> Equippement { get; set; }
        public DbSet<TypeEquippement> TypeEquippement { get; set; }
        public DbSet<Specialite> Specialite { get; set; }
        public DbSet<TypeEquippementMatiere> TypeEquippementMatiere { get; set; }

    }
}