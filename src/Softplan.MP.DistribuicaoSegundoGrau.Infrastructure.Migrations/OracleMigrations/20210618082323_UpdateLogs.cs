using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class UpdateLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DISTRIBUICAO_PROCESSO_LOG",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO_LOG");

            migrationBuilder.AlterColumn<string>(
                name: "PROCESSO_ID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO_LOG",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar2(200)",
                oldMaxLength: 200);
            
            migrationBuilder.AddPrimaryKey(
                name: "PK_DISTRIBUICAO_PROCESSO_LOG",
                schema: "SAJ_DSG",
                table: "SAJ_DSG.DISTRIBUICAO_PROCESSO_LOG",
                column: "LOG_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DISTRIBUICAO_PROCESSO_LOG",
                schema: "SAJ_DSG",
                table: "SAJ_DSG.DISTRIBUICAO_PROCESSO_LOG");
            
            migrationBuilder.AlterColumn<string>(
                name: "PROCESSO_ID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO_LOG",
                type: "nvarchar2(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DISTRIBUICAO_PROCESSO_LOG",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO_LOG",
                columns: new[] { "PROCESSO_ID", "LOG_ID" });
        }
    }
}
