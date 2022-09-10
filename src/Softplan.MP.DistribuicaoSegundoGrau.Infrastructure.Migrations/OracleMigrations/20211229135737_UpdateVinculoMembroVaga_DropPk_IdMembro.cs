using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class UpdateVinculoMembroVaga_DropPk_IdMembro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MEMBRO_VAGA",
                schema: "SAJ_DSG",
                table: "SAJ_DSG.MEMBRO_VAGA");

            migrationBuilder.AlterColumn<string>(
                name: "ID_MEMBRO",
                schema: "SAJ_DSG",
                table: "MEMBRO_VAGA",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar2(120)",
                oldMaxLength: 120);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MEMBRO_VAGA",
                schema: "SAJ_DSG",
                table: "SAJ_DSG.MEMBRO_VAGA",
                columns: new[] { "ID", "ID_VAGA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MEMBRO_VAGA",
                schema: "SAJ_DSG",
                table: "MEMBRO_VAGA");

            migrationBuilder.AlterColumn<string>(
                name: "ID_MEMBRO",
                schema: "SAJ_DSG",
                table: "MEMBRO_VAGA",
                type: "nvarchar2(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MEMBRO_VAGA",
                schema: "SAJ_DSG",
                table: "MEMBRO_VAGA",
                columns: new[] { "ID", "ID_VAGA", "ID_MEMBRO" });
        }
    }
}
