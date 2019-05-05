using Microsoft.EntityFrameworkCore.Migrations;

namespace HighSchoolManager.Migrations
{
    public partial class fixsalleequip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equippement_Salle_Salle_id",
                table: "Equippement");

            migrationBuilder.DropIndex(
                name: "IX_Equippement_Salle_id",
                table: "Equippement");

            migrationBuilder.DropColumn(
                name: "Salle_id",
                table: "Equippement");

            migrationBuilder.AddColumn<int>(
                name: "Salle_id_FK_equip",
                table: "Equippement",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Equippement_Salle_id_FK_equip",
                table: "Equippement",
                column: "Salle_id_FK_equip");

            migrationBuilder.AddForeignKey(
                name: "FK_Equippement_Salle_Salle_id_FK_equip",
                table: "Equippement",
                column: "Salle_id_FK_equip",
                principalTable: "Salle",
                principalColumn: "Salle_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equippement_Salle_Salle_id_FK_equip",
                table: "Equippement");

            migrationBuilder.DropIndex(
                name: "IX_Equippement_Salle_id_FK_equip",
                table: "Equippement");

            migrationBuilder.DropColumn(
                name: "Salle_id_FK_equip",
                table: "Equippement");

            migrationBuilder.AddColumn<int>(
                name: "Salle_id",
                table: "Equippement",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equippement_Salle_id",
                table: "Equippement",
                column: "Salle_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equippement_Salle_Salle_id",
                table: "Equippement",
                column: "Salle_id",
                principalTable: "Salle",
                principalColumn: "Salle_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
