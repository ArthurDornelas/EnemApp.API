using Microsoft.EntityFrameworkCore.Migrations;

namespace EnemApp.API.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatosConcursos_Candidatos_CandidatoId",
                table: "CandidatosConcursos");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatosConcursos_Concursos_ConcursoId",
                table: "CandidatosConcursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidatosConcursos",
                table: "CandidatosConcursos");

            migrationBuilder.RenameTable(
                name: "CandidatosConcursos",
                newName: "CandidatoConcurso");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatosConcursos_ConcursoId",
                table: "CandidatoConcurso",
                newName: "IX_CandidatoConcurso_ConcursoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidatoConcurso",
                table: "CandidatoConcurso",
                columns: new[] { "CandidatoId", "ConcursoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatoConcurso_Candidatos_CandidatoId",
                table: "CandidatoConcurso",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatoConcurso_Concursos_ConcursoId",
                table: "CandidatoConcurso",
                column: "ConcursoId",
                principalTable: "Concursos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatoConcurso_Candidatos_CandidatoId",
                table: "CandidatoConcurso");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatoConcurso_Concursos_ConcursoId",
                table: "CandidatoConcurso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidatoConcurso",
                table: "CandidatoConcurso");

            migrationBuilder.RenameTable(
                name: "CandidatoConcurso",
                newName: "CandidatosConcursos");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatoConcurso_ConcursoId",
                table: "CandidatosConcursos",
                newName: "IX_CandidatosConcursos_ConcursoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidatosConcursos",
                table: "CandidatosConcursos",
                columns: new[] { "CandidatoId", "ConcursoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatosConcursos_Candidatos_CandidatoId",
                table: "CandidatosConcursos",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatosConcursos_Concursos_ConcursoId",
                table: "CandidatosConcursos",
                column: "ConcursoId",
                principalTable: "Concursos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
