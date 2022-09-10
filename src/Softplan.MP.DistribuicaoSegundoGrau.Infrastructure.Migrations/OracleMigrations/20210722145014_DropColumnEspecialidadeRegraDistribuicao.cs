using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class DropColumnEspecialidadeRegraDistribuicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ESPECIALIDADE_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ESPECIALIDADE_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO",
                type: "int64",
                nullable: true);
        }
    }
}
