using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class UpdateVinculoMembroVaga_DropPk_IdMembro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_membro_vaga",
                schema: "saj_dsg",
                table: "membro_vaga");

            migrationBuilder.AlterColumn<string>(
                name: "id_membro",
                schema: "saj_dsg",
                table: "membro_vaga",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(120)",
                oldMaxLength: 120);

            migrationBuilder.AddPrimaryKey(
                name: "pk_membro_vaga",
                schema: "saj_dsg",
                table: "membro_vaga",
                columns: new[] { "id", "id_vaga" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_membro_vaga",
                schema: "saj_dsg",
                table: "membro_vaga");

            migrationBuilder.AlterColumn<string>(
                name: "id_membro",
                schema: "saj_dsg",
                table: "membro_vaga",
                type: "character varying(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_membro_vaga",
                schema: "saj_dsg",
                table: "membro_vaga",
                columns: new[] { "id", "id_vaga", "id_membro" });
        }
    }
}
