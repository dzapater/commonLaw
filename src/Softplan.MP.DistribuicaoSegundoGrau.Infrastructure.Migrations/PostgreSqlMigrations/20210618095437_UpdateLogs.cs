using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class UpdateLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_distribuicao_processo_log",
                schema: "saj_dsg",
                table: "distribuicao_processo_log");

            migrationBuilder.AlterColumn<string>(
                name: "processo_id",
                schema: "saj_dsg",
                table: "distribuicao_processo_log",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "pk_distribuicao_processo_log",
                schema: "saj_dsg",
                table: "distribuicao_processo_log",
                column: "log_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_distribuicao_processo_log",
                schema: "saj_dsg",
                table: "distribuicao_processo_log");

            migrationBuilder.AlterColumn<string>(
                name: "processo_id",
                schema: "saj_dsg",
                table: "distribuicao_processo_log",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_distribuicao_processo_log",
                schema: "saj_dsg",
                table: "distribuicao_processo_log",
                columns: new[] { "processo_id", "log_id" });
        }
    }
}
