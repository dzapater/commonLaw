using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class UpdateExcecaoVaga_AddField_IdTarja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdTarja",
                schema: "SAJ_DSG",
                table: "EXCECAO_VAGA",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTarja",
                schema: "SAJ_DSG",
                table: "EXCECAO_VAGA");
        }
    }
}
