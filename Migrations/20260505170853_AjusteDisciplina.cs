using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoEscola.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDisciplina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisciplinaId",
                table: "Matriculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_DisciplinaId",
                table: "Matriculas",
                column: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Disciplinas_DisciplinaId",
                table: "Matriculas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Disciplinas_DisciplinaId",
                table: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_DisciplinaId",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "Matriculas");
        }
    }
}
