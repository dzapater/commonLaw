using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class UpdateExcecaoVaga_AddField_IdTarja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "idtarja",
                schema: "saj_dsg",
                table: "excecao_vaga",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idtarja",
                schema: "saj_dsg",
                table: "excecao_vaga");
        }
    }
}
