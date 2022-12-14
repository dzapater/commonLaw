using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class UpdateRegraDistTarja_addFieldDescricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "descricao",
                schema: "saj_dsg",
                table: "regra_distribuicao_tarja",
                maxLength: 120,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descricao",
                schema: "saj_dsg",
                table: "regra_distribuicao_tarja");
        }
    }
}
