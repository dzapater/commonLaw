using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class UpdateRegraUnidadeOrgao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ORGAO_JULGADOR_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_UNIDADE");

            migrationBuilder.AlterColumn<long>(
                name: "UNIDADE_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_UNIDADE",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "TARJA_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_TARJA",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ORGAO_JULGADOR_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_ORGAO",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "UNIDADE_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_ORGAO",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "CLASSE_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_CLASSE",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ASSUNTO_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_ASSUNTO",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ESPECIALIDADE_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UNIDADE_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_ORGAO");

            migrationBuilder.AlterColumn<int>(
                name: "UNIDADE_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_UNIDADE",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<int>(
                name: "ORGAO_JULGADOR_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_UNIDADE",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TARJA_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_TARJA",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ORGAO_JULGADOR_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_ORGAO",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "CLASSE_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_CLASSE",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ASSUNTO_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_ASSUNTO",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ESPECIALIDADE_ID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistribuicaoVagaJob_ID",
                schema: "SAJ_DSG",
                table: "JOBS",
                type: "nclob",
                nullable: false,
                defaultValue: "");
        }
    }
}
