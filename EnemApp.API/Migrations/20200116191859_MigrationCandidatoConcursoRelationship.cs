using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnemApp.API.Migrations
{
    public partial class MigrationCandidatoConcursoRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(maxLength: 100, nullable: false),
                    cidade = table.Column<string>(maxLength: 100, nullable: false),
                    aprovado = table.Column<bool>(nullable: false, defaultValue: false),
                    nota = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Concursos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(maxLength: 100, nullable: false),
                    data_realizacao = table.Column<DateTime>(nullable: false),
                    numero_vagas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concursos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidatosConcursos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidatoId = table.Column<int>(nullable: false),
                    ConcursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatosConcursos", x => x.id);
                    table.ForeignKey(
                        name: "FK_CandidatosConcursos_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatosConcursos_Concursos_ConcursoId",
                        column: x => x.ConcursoId,
                        principalTable: "Concursos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatosConcursos_CandidatoId",
                table: "CandidatosConcursos",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatosConcursos_ConcursoId",
                table: "CandidatosConcursos",
                column: "ConcursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatosConcursos");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Concursos");
        }
    }
}
