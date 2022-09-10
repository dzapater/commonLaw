using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class UpdateVaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "compensacao",
                schema: "saj_dsg",
                table: "vaga",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "distribuicoes",
                schema: "saj_dsg",
                table: "vaga",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "compensacao",
                schema: "saj_dsg",
                table: "vaga");

            migrationBuilder.DropColumn(
                name: "distribuicoes",
                schema: "saj_dsg",
                table: "vaga");
        }
    }
}
