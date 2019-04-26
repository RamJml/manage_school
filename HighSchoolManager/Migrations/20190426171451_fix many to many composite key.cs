using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HighSchoolManager.Migrations
{
    public partial class fixmanytomanycompositekey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Niveaux",
                columns: table => new
                {
                    Niveau_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Niveau_designation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveaux", x => x.Niveau_id);
                });

            migrationBuilder.CreateTable(
                name: "Salle",
                columns: table => new
                {
                    Salle_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Salle_designation = table.Column<string>(nullable: true),
                    Salle_Capacite = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salle", x => x.Salle_id);
                });

            migrationBuilder.CreateTable(
                name: "Specialite",
                columns: table => new
                {
                    Specialite_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Specialite_designation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialite", x => x.Specialite_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Option_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Option_designation = table.Column<string>(nullable: true),
                    Niveau_id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Option_id);
                    table.ForeignKey(
                        name: "FK_Options_Niveaux_Niveau_id_FK",
                        column: x => x.Niveau_id_FK,
                        principalTable: "Niveaux",
                        principalColumn: "Niveau_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matiere",
                columns: table => new
                {
                    Matiere_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Matiere_designation = table.Column<string>(nullable: true),
                    Specialite_id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matiere", x => x.Matiere_id);
                    table.ForeignKey(
                        name: "FK_Matiere_Specialite_Specialite_id_FK",
                        column: x => x.Specialite_id_FK,
                        principalTable: "Specialite",
                        principalColumn: "Specialite_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    Groupe_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Groupe_designation = table.Column<string>(nullable: true),
                    Option_id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.Groupe_id);
                    table.ForeignKey(
                        name: "FK_Groupes_Options_Option_id_FK",
                        column: x => x.Option_id_FK,
                        principalTable: "Options",
                        principalColumn: "Option_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeEquippement",
                columns: table => new
                {
                    Type_Equippement_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type_Equippement_designation = table.Column<string>(nullable: true),
                    Matiere_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEquippement", x => x.Type_Equippement_id);
                    table.ForeignKey(
                        name: "FK_TypeEquippement_Matiere_Matiere_id",
                        column: x => x.Matiere_id,
                        principalTable: "Matiere",
                        principalColumn: "Matiere_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Enseignant_nom = table.Column<string>(nullable: true),
                    Enseignant_prenom = table.Column<string>(nullable: true),
                    Specialite_id_FK = table.Column<int>(nullable: true),
                    Etudiant_nom = table.Column<string>(nullable: true),
                    Etudiant_prenom = table.Column<string>(nullable: true),
                    Etudiant_contact_parent = table.Column<string>(nullable: true),
                    Groupe_id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Specialite_Specialite_id_FK",
                        column: x => x.Specialite_id_FK,
                        principalTable: "Specialite",
                        principalColumn: "Specialite_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Groupes_Groupe_id_FK",
                        column: x => x.Groupe_id_FK,
                        principalTable: "Groupes",
                        principalColumn: "Groupe_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equippement",
                columns: table => new
                {
                    Equippement_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Equippement_designation = table.Column<string>(nullable: true),
                    TypeEquippement_id_FK = table.Column<int>(nullable: false),
                    Salle_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equippement", x => x.Equippement_id);
                    table.ForeignKey(
                        name: "FK_Equippement_Salle_Salle_id",
                        column: x => x.Salle_id,
                        principalTable: "Salle",
                        principalColumn: "Salle_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equippement_TypeEquippement_TypeEquippement_id_FK",
                        column: x => x.TypeEquippement_id_FK,
                        principalTable: "TypeEquippement",
                        principalColumn: "Type_Equippement_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeEquippementMatiere",
                columns: table => new
                {
                    TypeEquippement_FK = table.Column<int>(nullable: false),
                    Matiere_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEquippementMatiere", x => new { x.Matiere_FK, x.TypeEquippement_FK });
                    table.ForeignKey(
                        name: "FK_TypeEquippementMatiere_Matiere_Matiere_FK",
                        column: x => x.Matiere_FK,
                        principalTable: "Matiere",
                        principalColumn: "Matiere_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeEquippementMatiere_TypeEquippement_TypeEquippement_FK",
                        column: x => x.TypeEquippement_FK,
                        principalTable: "TypeEquippement",
                        principalColumn: "Type_Equippement_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seance",
                columns: table => new
                {
                    Seance_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Seance_Jour = table.Column<string>(nullable: true),
                    Seance_Heure = table.Column<string>(nullable: true),
                    Enseignant_id_FK = table.Column<string>(nullable: true),
                    Matiere_id_FK = table.Column<int>(nullable: false),
                    Salle_id_FK = table.Column<int>(nullable: false),
                    Groupe_id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seance", x => x.Seance_id);
                    table.ForeignKey(
                        name: "FK_Seance_AspNetUsers_Enseignant_id_FK",
                        column: x => x.Enseignant_id_FK,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seance_Groupes_Groupe_id_FK",
                        column: x => x.Groupe_id_FK,
                        principalTable: "Groupes",
                        principalColumn: "Groupe_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seance_Matiere_Matiere_id_FK",
                        column: x => x.Matiere_id_FK,
                        principalTable: "Matiere",
                        principalColumn: "Matiere_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seance_Salle_Salle_id_FK",
                        column: x => x.Salle_id_FK,
                        principalTable: "Salle",
                        principalColumn: "Salle_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absence",
                columns: table => new
                {
                    Absence_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Etudiant_FK = table.Column<string>(nullable: true),
                    Seance_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absence", x => x.Absence_id);
                    table.ForeignKey(
                        name: "FK_Absence_AspNetUsers_Etudiant_FK",
                        column: x => x.Etudiant_FK,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Absence_Seance_Seance_FK",
                        column: x => x.Seance_FK,
                        principalTable: "Seance",
                        principalColumn: "Seance_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absence_Etudiant_FK",
                table: "Absence",
                column: "Etudiant_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Absence_Seance_FK",
                table: "Absence",
                column: "Seance_FK");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Specialite_id_FK",
                table: "AspNetUsers",
                column: "Specialite_id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Groupe_id_FK",
                table: "AspNetUsers",
                column: "Groupe_id_FK");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Equippement_Salle_id",
                table: "Equippement",
                column: "Salle_id");

            migrationBuilder.CreateIndex(
                name: "IX_Equippement_TypeEquippement_id_FK",
                table: "Equippement",
                column: "TypeEquippement_id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_Option_id_FK",
                table: "Groupes",
                column: "Option_id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Matiere_Specialite_id_FK",
                table: "Matiere",
                column: "Specialite_id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Options_Niveau_id_FK",
                table: "Options",
                column: "Niveau_id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_Enseignant_id_FK",
                table: "Seance",
                column: "Enseignant_id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_Groupe_id_FK",
                table: "Seance",
                column: "Groupe_id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_Matiere_id_FK",
                table: "Seance",
                column: "Matiere_id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_Salle_id_FK",
                table: "Seance",
                column: "Salle_id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_TypeEquippement_Matiere_id",
                table: "TypeEquippement",
                column: "Matiere_id");

            migrationBuilder.CreateIndex(
                name: "IX_TypeEquippementMatiere_TypeEquippement_FK",
                table: "TypeEquippementMatiere",
                column: "TypeEquippement_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absence");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Equippement");

            migrationBuilder.DropTable(
                name: "TypeEquippementMatiere");

            migrationBuilder.DropTable(
                name: "Seance");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TypeEquippement");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Salle");

            migrationBuilder.DropTable(
                name: "Matiere");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.DropTable(
                name: "Specialite");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Niveaux");
        }
    }
}
