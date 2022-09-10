using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class UpdateRegraClasse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "origem_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_classe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "origem_id",
                schema: "saj_dsg",
                table: "regra_distribuicao_classe",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
