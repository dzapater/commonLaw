using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class UpdateRegraUnidadeOrgao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orgao_julgador_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_unidade");

            migrationBuilder.AlterColumn<long>(
                name: "unidade_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_unidade",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "tarja_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_tarja",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "orgao_julgador_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_orgao",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<long>(
                name: "unidade_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_orgao",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "classe_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_classe",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "assunto_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_assunto",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "especialidade_id",
                schema: "saj_dsg",
                table: "regra_distribuicao",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "unidade_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_orgao");

            migrationBuilder.AlterColumn<int>(
                name: "unidade_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_unidade",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<int>(
                name: "orgao_julgador_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_unidade",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "tarja_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_tarja",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "orgao_julgador_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_orgao",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "classe_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_classe",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "assunto_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_assunto",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "especialidade_id",
                schema: "saj_dsg",
                table: "regra_distribuicao",
                type: "integer",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}
