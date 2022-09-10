using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class DropColumnEspecialidadeRegraDistribuicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "especialidade_id",
                schema: "saj_dsg",
                table: "regra_distribuicao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "especialidade_id",
                schema: "saj_dsg",
                table: "regra_distribuicao",
                type: "bigint",
                nullable: true);
        }
    }
}
