using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class CreateRegraDistribuicaoEspec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "regra_distribuicao_espec",
                schema: "saj_dsg",
                columns: table => new
                {
                    regra_distribuicao_id = table.Column<int>(nullable: false),
                    especialidade_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regra_distribuicao_espec", x => new { x.regra_distribuicao_id, x.especialidade_id });
                    table.ForeignKey(
                        name: "fk_regra_distribuicao_espec_regra_distribuicao_regra_distribui~",
                        column: x => x.regra_distribuicao_id,
                        principalSchema: "saj_dsg",
                        principalTable: "regra_distribuicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "regra_distribuicao_espec",
                schema: "saj_dsg");
        }
    }
}
