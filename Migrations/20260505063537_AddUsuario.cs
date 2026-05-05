using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoEscola.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Disciplinas_Alunos_AlunoId",
                table: "Matricula_Disciplinas");

            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Disciplinas_Turmas_TurmaId",
                table: "Matricula_Disciplinas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matricula_Disciplinas",
                table: "Matricula_Disciplinas");

            migrationBuilder.RenameTable(
                name: "Matricula_Disciplinas",
                newName: "Matriculas");

            migrationBuilder.RenameIndex(
                name: "IX_Matricula_Disciplinas_TurmaId",
                table: "Matriculas",
                newName: "IX_Matriculas_TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_Matricula_Disciplinas_AlunoId",
                table: "Matriculas",
                newName: "IX_Matriculas_AlunoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matriculas",
                table: "Matriculas",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Alunos_AlunoId",
                table: "Matriculas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Turmas_TurmaId",
                table: "Matriculas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Alunos_AlunoId",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Turmas_TurmaId",
                table: "Matriculas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matriculas",
                table: "Matriculas");

            migrationBuilder.RenameTable(
                name: "Matriculas",
                newName: "Matricula_Disciplinas");

            migrationBuilder.RenameIndex(
                name: "IX_Matriculas_TurmaId",
                table: "Matricula_Disciplinas",
                newName: "IX_Matricula_Disciplinas_TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_Matriculas_AlunoId",
                table: "Matricula_Disciplinas",
                newName: "IX_Matricula_Disciplinas_AlunoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matricula_Disciplinas",
                table: "Matricula_Disciplinas",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Disciplinas_Alunos_AlunoId",
                table: "Matricula_Disciplinas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Disciplinas_Turmas_TurmaId",
                table: "Matricula_Disciplinas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
