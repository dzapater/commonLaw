using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AREA",
                schema: "SAJ_DSG",
                table: "ANALISE_PROCESSO");

            migrationBuilder.AddColumn<int>(
                name: "COMPENSACAO_POR_PROCESSO",
                schema: "SAJ_DSG",
                table: "VAGA_REGRA_DISTRIBUICAO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "COMPENSACAO_POR_VOLUME",
                schema: "SAJ_DSG",
                table: "VAGA_REGRA_DISTRIBUICAO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DISTRIBUICAO_POR_PROCESSO",
                schema: "SAJ_DSG",
                table: "VAGA_REGRA_DISTRIBUICAO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DISTRIBUICAO_POR_VOLUME",
                schema: "SAJ_DSG",
                table: "VAGA_REGRA_DISTRIBUICAO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "COMPENSACAO_POR_VOLUME",
                schema: "SAJ_DSG",
                table: "VAGA",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DISTRIBUICAO_POR_VOLUME",
                schema: "SAJ_DSG",
                table: "VAGA",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "AREA_ATUACAO_ID",
                schema: "SAJ_DSG",
                table: "ANALISE_PROCESSO",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "COMPENSACAO_POR_PROCESSO",
                schema: "SAJ_DSG",
                table: "VAGA_REGRA_DISTRIBUICAO");

            migrationBuilder.DropColumn(
                name: "COMPENSACAO_POR_VOLUME",
                schema: "SAJ_DSG",
                table: "VAGA_REGRA_DISTRIBUICAO");

            migrationBuilder.DropColumn(
                name: "DISTRIBUICAO_POR_PROCESSO",
                schema: "SAJ_DSG",
                table: "VAGA_REGRA_DISTRIBUICAO");

            migrationBuilder.DropColumn(
                name: "DISTRIBUICAO_POR_VOLUME",
                schema: "SAJ_DSG",
                table: "VAGA_REGRA_DISTRIBUICAO");

            migrationBuilder.DropColumn(
                name: "COMPENSACAO_POR_VOLUME",
                schema: "SAJ_DSG",
                table: "VAGA");

            migrationBuilder.DropColumn(
                name: "DISTRIBUICAO_POR_VOLUME",
                schema: "SAJ_DSG",
                table: "VAGA");

            migrationBuilder.DropColumn(
                name: "AREA_ATUACAO_ID",
                schema: "SAJ_DSG",
                table: "ANALISE_PROCESSO");

            migrationBuilder.AddColumn<int>(
                name: "AREA",
                schema: "SAJ_DSG",
                table: "ANALISE_PROCESSO",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
