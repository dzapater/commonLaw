using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class UpdateRegraDistribuicao_AddField_CdLocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CdLocal",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CdLocal",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO");
        }
    }
}
