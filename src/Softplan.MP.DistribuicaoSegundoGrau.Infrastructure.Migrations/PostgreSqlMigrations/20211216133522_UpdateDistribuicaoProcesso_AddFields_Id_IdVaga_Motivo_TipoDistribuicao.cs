using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_distribuicao_processo_log_distribuicao_processo_processo_id",
                schema: "saj_dsg",
                table: "distribuicao_processo_log");

            migrationBuilder.DropPrimaryKey(
                name: "pk_distribuicao_processo",
                schema: "saj_dsg",
                table: "distribuicao_processo");


            migrationBuilder.AlterColumn<string>(
                name: "processo_id",
                schema: "saj_dsg",
                table: "distribuicao_processo_log",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "distribuicao_id",
                schema: "saj_dsg",
                table: "distribuicao_processo_log",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "processo_id",
                schema: "saj_dsg",
                table: "distribuicao_processo",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<long>(
                name: "distribuicao_id",
                schema: "saj_dsg",
                table: "distribuicao_processo",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "vaga_id",
                schema: "saj_dsg",
                table: "distribuicao_processo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "motivo",
                schema: "saj_dsg",
                table: "distribuicao_processo",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tipodistribuicao",
                schema: "saj_dsg",
                table: "distribuicao_processo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_distribuicao_processo",
                schema: "saj_dsg",
                table: "distribuicao_processo",
                column: "distribuicao_id");

            migrationBuilder.CreateIndex(
                name: "ix_distribuicao_processo_log_distribuicao_id",
                schema: "saj_dsg",
                table: "distribuicao_processo_log",
                column: "distribuicao_id");

            migrationBuilder.AddForeignKey(
                name: "fk_distribuicao_processo_log_distribuicao_processo_distribuica~",
                schema: "saj_dsg",
                table: "distribuicao_processo_log",
                column: "distribuicao_id",
                principalSchema: "saj_dsg",
                principalTable: "distribuicao_processo",
                principalColumn: "distribuicao_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_distribuicao_processo_log_distribuicao_processo_distribuica~",
                schema: "saj_dsg",
                table: "distribuicao_processo_log");

            migrationBuilder.DropIndex(
                name: "ix_distribuicao_processo_log_distribuicao_id",
                schema: "saj_dsg",
                table: "distribuicao_processo_log");

            migrationBuilder.DropPrimaryKey(
                name: "pk_distribuicao_processo",
                schema: "saj_dsg",
                table: "distribuicao_processo");

            migrationBuilder.DropSequence(
                name: "distribuicao_processo_id_seq",
                schema: "saj_dsg");

            migrationBuilder.DropColumn(
                name: "distribuicao_id",
                schema: "saj_dsg",
                table: "distribuicao_processo_log");

            migrationBuilder.DropColumn(
                name: "distribuicao_id",
                schema: "saj_dsg",
                table: "distribuicao_processo");

            migrationBuilder.DropColumn(
                name: "vaga_id",
                schema: "saj_dsg",
                table: "distribuicao_processo");

            migrationBuilder.DropColumn(
                name: "motivo",
                schema: "saj_dsg",
                table: "distribuicao_processo");

            migrationBuilder.DropColumn(
                name: "tipodistribuicao",
                schema: "saj_dsg",
                table: "distribuicao_processo");

            migrationBuilder.AlterColumn<string>(
                name: "processo_id",
                schema: "saj_dsg",
                table: "distribuicao_processo_log",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "processo_id",
                schema: "saj_dsg",
                table: "distribuicao_processo",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_distribuicao_processo",
                schema: "saj_dsg",
                table: "distribuicao_processo",
                column: "processo_id");

            migrationBuilder.AddForeignKey(
                name: "fk_distribuicao_processo_log_distribuicao_processo_processo_id",
                schema: "saj_dsg",
                table: "distribuicao_processo_log",
                column: "processo_id",
                principalSchema: "saj_dsg",
                principalTable: "distribuicao_processo",
                principalColumn: "processo_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
