using Microsoft.EntityFrameworkCore.Migrations;

namespace EnemApp.API.Migrations
{
    public partial class AddNomeConcurso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "Concursos",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nome",
                table: "Concursos");
        }
    }
}
