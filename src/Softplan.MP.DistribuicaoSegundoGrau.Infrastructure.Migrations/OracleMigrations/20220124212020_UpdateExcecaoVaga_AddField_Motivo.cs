using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class UpdateExcecaoVaga_AddField_Motivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MOTIVO",
                schema: "SAJ_DSG",
                table: "EXCECAO_VAGA",
                maxLength: 2000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MOTIVO",
                schema: "SAJ_DSG",
                table: "EXCECAO_VAGA");
        }
    }
}
