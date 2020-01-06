using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnemApp.API.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Candidatos");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Candidatos");

            migrationBuilder.RenameColumn(
                name: "Nota",
                table: "Candidatos",
                newName: "nota");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Candidatos",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Candidatos",
                newName: "id");

            migrationBuilder.AddColumn<bool>(
                name: "aprovado",
                table: "Candidatos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "cidade",
                table: "Candidatos",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aprovado",
                table: "Candidatos");

            migrationBuilder.DropColumn(
                name: "cidade",
                table: "Candidatos");

            migrationBuilder.RenameColumn(
                name: "nota",
                table: "Candidatos",
                newName: "Nota");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Candidatos",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Candidatos",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Candidatos",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Candidatos",
                type: "datetime2",
                nullable: true);
        }
    }
}
