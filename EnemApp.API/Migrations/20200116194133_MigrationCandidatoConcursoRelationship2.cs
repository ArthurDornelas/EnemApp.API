using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnemApp.API.Migrations
{
    public partial class MigrationCandidatoConcursoRelationship2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataConcurso",
                table: "CandidatosConcursos",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 16, 16, 41, 32, 899, DateTimeKind.Local).AddTicks(5456));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataConcurso",
                table: "CandidatosConcursos");
        }
    }
}
