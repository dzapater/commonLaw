using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "area",
                schema: "saj_dsg",
                table: "analise_processo");

            migrationBuilder.AddColumn<int>(
                name: "compensacao_por_processo",
                schema: "saj_dsg",
                table: "vaga_regra_distribuicao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "compensacao_por_volume",
                schema: "saj_dsg",
                table: "vaga_regra_distribuicao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "distribuicao_por_processo",
                schema: "saj_dsg",
                table: "vaga_regra_distribuicao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "distribuicao_por_volume",
                schema: "saj_dsg",
                table: "vaga_regra_distribuicao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "motivo",
                schema: "saj_dsg",
                table: "vaga",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "compensacao_por_volume",
                schema: "saj_dsg",
                table: "vaga",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "distribuicao_por_volume",
                schema: "saj_dsg",
                table: "vaga",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "area_atuacao_id",
                schema: "saj_dsg",
                table: "analise_processo",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "compensacao_por_processo",
                schema: "saj_dsg",
                table: "vaga_regra_distribuicao");

            migrationBuilder.DropColumn(
                name: "compensacao_por_volume",
                schema: "saj_dsg",
                table: "vaga_regra_distribuicao");

            migrationBuilder.DropColumn(
                name: "distribuicao_por_processo",
                schema: "saj_dsg",
                table: "vaga_regra_distribuicao");

            migrationBuilder.DropColumn(
                name: "distribuicao_por_volume",
                schema: "saj_dsg",
                table: "vaga_regra_distribuicao");

            migrationBuilder.DropColumn(
                name: "compensacao_por_volume",
                schema: "saj_dsg",
                table: "vaga");

            migrationBuilder.DropColumn(
                name: "distribuicao_por_volume",
                schema: "saj_dsg",
                table: "vaga");

            migrationBuilder.DropColumn(
                name: "area_atuacao_id",
                schema: "saj_dsg",
                table: "analise_processo");

            migrationBuilder.AlterColumn<int>(
                name: "motivo",
                schema: "saj_dsg",
                table: "vaga",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "origem_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_classe",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "area",
                schema: "saj_dsg",
                table: "analise_processo",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
