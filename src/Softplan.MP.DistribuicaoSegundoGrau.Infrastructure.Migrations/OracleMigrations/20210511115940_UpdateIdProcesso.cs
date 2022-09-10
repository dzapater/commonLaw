using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class UpdateIdProcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PROCESSO_ID",
                schema: "SAJ_DSG",
                table: "IMPEDIMENTO_PROCESSO",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PROCESSO_ID",
                schema: "SAJ_DSG",
                table: "ANALISE_PROCESSO",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar2(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PROCESSO_ID",
                schema: "SAJ_DSG",
                table: "IMPEDIMENTO_PROCESSO",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "PROCESSO_ID",
                schema: "SAJ_DSG",
                table: "ANALISE_PROCESSO",
                type: "nvarchar2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}
