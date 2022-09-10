using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class UpdateRegraClasse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ORIGEM_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_CLASSE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ORIGEM_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_CLASSE",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
