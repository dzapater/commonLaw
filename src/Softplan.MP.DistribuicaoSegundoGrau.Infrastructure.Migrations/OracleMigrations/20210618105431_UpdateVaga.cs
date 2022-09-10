using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class UpdateVaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "COMPENSACAO",
                schema: "SAJ_DSG",
                table: "VAGA",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DISTRIBUICOES",
                schema: "SAJ_DSG",
                table: "VAGA",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "COMPENSACAO",
                schema: "SAJ_DSG",
                table: "VAGA");

            migrationBuilder.DropColumn(
                name: "DISTRIBUICOES",
                schema: "SAJ_DSG",
                table: "VAGA");
        }
    }
}
