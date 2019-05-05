﻿// <auto-generated />
using System;
using HighSchoolManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HighSchoolManager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HighSchoolManager.Data.Absence", b =>
                {
                    b.Property<int>("Absence_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Etudiant_FK");

                    b.Property<int>("Seance_FK");

                    b.HasKey("Absence_id");

                    b.HasIndex("Etudiant_FK");

                    b.HasIndex("Seance_FK");

                    b.ToTable("Absence");
                });

            modelBuilder.Entity("HighSchoolManager.Data.Enseignant", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Enseignant_nom");

                    b.Property<string>("Enseignant_prenom");

                    b.Property<int>("Specialite_id_FK");

                    b.HasKey("Id");

                    b.HasIndex("Specialite_id_FK");

                    b.ToTable("Enseignant");
                });

            modelBuilder.Entity("HighSchoolManager.Data.Equippement", b =>
                {
                    b.Property<int>("Equippement_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Equippement_designation");

                    b.Property<int>("Salle_id_FK_equip");

                    b.Property<int>("TypeEquippement_id_FK");

                    b.HasKey("Equippement_id");

                    b.HasIndex("Salle_id_FK_equip");

                    b.HasIndex("TypeEquippement_id_FK");

                    b.ToTable("Equippement");
                });

            modelBuilder.Entity("HighSchoolManager.Data.Etudiant", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Etudiant_contact_parent");

                    b.Property<string>("Etudiant_nom");

                    b.Property<string>("Etudiant_prenom");

                    b.Property<int>("Groupe_id_FK");

                    b.HasKey("Id");

                    b.HasIndex("Groupe_id_FK");

                    b.ToTable("Etudiant");
                });

            modelBuilder.Entity("HighSchoolManager.Data.Groupe", b =>
                {
                    b.Property<int>("Groupe_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Groupe_designation");

                    b.Property<int>("Option_id_FK");

                    b.HasKey("Groupe_id");

                    b.HasIndex("Option_id_FK");

                    b.ToTable("Groupes");
                });

            modelBuilder.Entity("HighSchoolManager.Data.Matiere", b =>
                {
                    b.Property<int>("Matiere_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Matiere_designation");

                    b.Property<int>("Specialite_id_FK");

                    b.HasKey("Matiere_id");

                    b.HasIndex("Specialite_id_FK");

                    b.ToTable("Matiere");
                });

            modelBuilder.Entity("HighSchoolManager.Data.Niveau", b =>
                {
                    b.Property<int>("Niveau_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Niveau_designation");

                    b.HasKey("Niveau_id");

                    b.ToTable("Niveaux");
                });

            modelBuilder.Entity("HighSchoolManager.Data.Option", b =>
                {
                    b.Property<int>("Option_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Niveau_id_FK");

                    b.Property<string>("Option_designation");

                    b.HasKey("Option_id");

                    b.HasIndex("Niveau_id_FK");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("HighSchoolManager.Data.Salle", b =>
                {
                    b.Property<int>("Salle_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Salle_Capacite");

                    b.Property<string>("Salle_designation");

                    b.HasKey("Salle_id");

                    b.ToTable("Salle");
                });

            modelBuilder.Entity("HighSchoolManager.Data.Seance", b =>
                {
                    b.Property<int>("Seance_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Enseignant_id_FK");

                    b.Property<int>("Groupe_id_FK");

                    b.Property<int>("Matiere_id_FK");

                    b.Property<int>("Salle_id_FK");

                    b.Property<string>("Seance_Heure");

                    b.Property<string>("Seance_Jour");

                    b.HasKey("Seance_id");

                    b.HasIndex("Enseignant_id_FK");

                    b.HasIndex("Groupe_id_FK");

                    b.HasIndex("Matiere_id_FK");

                    b.HasIndex("Salle_id_FK");

                    b.ToTable("Seance");
                });

            modelBuilder.Entity("HighSchoolManager.Data.Specialite", b =>
                {
                    b.Property<int>("Specialite_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Specialite_designation");

                    b.HasKey("Specialite_id");

                    b.ToTable("Specialite");
                });

            modelBuilder.Entity("HighSchoolManager.Data.TypeEquippement", b =>
                {
                    b.Property<int>("Type_Equippement_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Matiere_id");

                    b.Property<string>("Type_Equippement_designation");

                    b.HasKey("Type_Equippement_id");

                    b.HasIndex("Matiere_id");

                    b.ToTable("TypeEquippement");
                });

            modelBuilder.Entity("HighSchoolManager.Data.TypeEquippementMatiere", b =>
                {
                    b.Property<int>("Matiere_FK");

                    b.Property<int>("TypeEquippement_FK");

                    b.HasKey("Matiere_FK", "TypeEquippement_FK");

                    b.HasIndex("TypeEquippement_FK");

                    b.ToTable("TypeEquippementMatiere");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HighSchoolManager.Data.Absence", b =>
                {
                    b.HasOne("HighSchoolManager.Data.Etudiant", "Ref_Etudiant")
                        .WithMany()
                        .HasForeignKey("Etudiant_FK");

                    b.HasOne("HighSchoolManager.Data.Seance", "Ref_Seance")
                        .WithMany()
                        .HasForeignKey("Seance_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HighSchoolManager.Data.Enseignant", b =>
                {
                    b.HasOne("HighSchoolManager.Data.Specialite", "Ref_Specialite")
                        .WithMany("Enseignant_Specialite")
                        .HasForeignKey("Specialite_id_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HighSchoolManager.Data.Equippement", b =>
                {
                    b.HasOne("HighSchoolManager.Data.Salle", "Ref_Salle_equip")
                        .WithMany("Salle_Equippement")
                        .HasForeignKey("Salle_id_FK_equip")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HighSchoolManager.Data.TypeEquippement", "Ref_TypeEquippement")
                        .WithMany()
                        .HasForeignKey("TypeEquippement_id_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HighSchoolManager.Data.Etudiant", b =>
                {
                    b.HasOne("HighSchoolManager.Data.Groupe", "Ref_Groupe")
                        .WithMany()
                        .HasForeignKey("Groupe_id_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HighSchoolManager.Data.Groupe", b =>
                {
                    b.HasOne("HighSchoolManager.Data.Option", "Ref_Option")
                        .WithMany()
                        .HasForeignKey("Option_id_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HighSchoolManager.Data.Matiere", b =>
                {
                    b.HasOne("HighSchoolManager.Data.Specialite", "Ref_Specialite")
                        .WithMany("Matieres_Specialite")
                        .HasForeignKey("Specialite_id_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HighSchoolManager.Data.Option", b =>
                {
                    b.HasOne("HighSchoolManager.Data.Niveau", "Ref_Niveau")
                        .WithMany()
                        .HasForeignKey("Niveau_id_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HighSchoolManager.Data.Seance", b =>
                {
                    b.HasOne("HighSchoolManager.Data.Enseignant", "Ref_Enseignant")
                        .WithMany()
                        .HasForeignKey("Enseignant_id_FK");

                    b.HasOne("HighSchoolManager.Data.Groupe", "Ref_Groupe")
                        .WithMany()
                        .HasForeignKey("Groupe_id_FK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HighSchoolManager.Data.Matiere", "Ref_Matiere")
                        .WithMany()
                        .HasForeignKey("Matiere_id_FK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HighSchoolManager.Data.Salle", "Ref_Salle")
                        .WithMany()
                        .HasForeignKey("Salle_id_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HighSchoolManager.Data.TypeEquippement", b =>
                {
                    b.HasOne("HighSchoolManager.Data.Matiere")
                        .WithMany("Matiere_typeEquippements")
                        .HasForeignKey("Matiere_id");
                });

            modelBuilder.Entity("HighSchoolManager.Data.TypeEquippementMatiere", b =>
                {
                    b.HasOne("HighSchoolManager.Data.Matiere", "Ref_Matiere")
                        .WithMany()
                        .HasForeignKey("Matiere_FK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HighSchoolManager.Data.TypeEquippement", "Ref_TypeEquippement")
                        .WithMany()
                        .HasForeignKey("TypeEquippement_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
