using Microsoft.EntityFrameworkCore.Migrations;

namespace HighSchoolManager.Migrations
{
    public partial class init_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_AspNetUsers_Etudiant_FK",
                table: "Absence");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Specialite_Specialite_id_FK",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groupes_Groupe_id_FK",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Seance_AspNetUsers_Enseignant_id_FK",
                table: "Seance");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Specialite_id_FK",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Groupe_id_FK",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Enseignant_nom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Enseignant_prenom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Specialite_id_FK",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Etudiant_contact_parent",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Etudiant_nom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Etudiant_prenom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Groupe_id_FK",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Enseignant",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Enseignant_nom = table.Column<string>(nullable: true),
                    Enseignant_prenom = table.Column<string>(nullable: true),
                    Specialite_id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enseignant_Specialite_Specialite_id_FK",
                        column: x => x.Specialite_id_FK,
                        principalTable: "Specialite",
                        principalColumn: "Specialite_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etudiant",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Etudiant_nom = table.Column<string>(nullable: true),
                    Etudiant_prenom = table.Column<string>(nullable: true),
                    Etudiant_contact_parent = table.Column<string>(nullable: true),
                    Groupe_id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etudiant_Groupes_Groupe_id_FK",
                        column: x => x.Groupe_id_FK,
                        principalTable: "Groupes",
                        principalColumn: "Groupe_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enseignant_Specialite_id_FK",
                table: "Enseignant",
                column: "Specialite_id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiant_Groupe_id_FK",
                table: "Etudiant",
                column: "Groupe_id_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_Etudiant_Etudiant_FK",
                table: "Absence",
                column: "Etudiant_FK",
                principalTable: "Etudiant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_Enseignant_Enseignant_id_FK",
                table: "Seance",
                column: "Enseignant_id_FK",
                principalTable: "Enseignant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_Etudiant_Etudiant_FK",
                table: "Absence");

            migrationBuilder.DropForeignKey(
                name: "FK_Seance_Enseignant_Enseignant_id_FK",
                table: "Seance");

            migrationBuilder.DropTable(
                name: "Enseignant");

            migrationBuilder.DropTable(
                name: "Etudiant");

            migrationBuilder.AddColumn<string>(
                name: "Enseignant_nom",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Enseignant_prenom",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Specialite_id_FK",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Etudiant_contact_parent",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Etudiant_nom",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Etudiant_prenom",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Groupe_id_FK",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Specialite_id_FK",
                table: "AspNetUsers",
                column: "Specialite_id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Groupe_id_FK",
                table: "AspNetUsers",
                column: "Groupe_id_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_AspNetUsers_Etudiant_FK",
                table: "Absence",
                column: "Etudiant_FK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Specialite_Specialite_id_FK",
                table: "AspNetUsers",
                column: "Specialite_id_FK",
                principalTable: "Specialite",
                principalColumn: "Specialite_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Groupes_Groupe_id_FK",
                table: "AspNetUsers",
                column: "Groupe_id_FK",
                principalTable: "Groupes",
                principalColumn: "Groupe_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_AspNetUsers_Enseignant_id_FK",
                table: "Seance",
                column: "Enseignant_id_FK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
