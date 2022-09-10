using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class UpdateExcecaoVaga_RemoveField_IdTarja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTarja",
                schema: "SAJ_DSG",
                table: "EXCECAO_VAGA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdTarja",
                schema: "SAJ_DSG",
                table: "EXCECAO_VAGA",
                type: "int64",
                nullable: true);
        }
    }
}
