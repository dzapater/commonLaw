using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class CreateRegraDistribuicaoEspec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "REGRA_DISTRIBUICAO_ESPEC",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    REGRA_DISTRIBUICAO_ID = table.Column<int>(nullable: false),
                    ESPECIALIDADE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGRA_DISTRIBUICAO_ESPEC", x => new { x.REGRA_DISTRIBUICAO_ID, x.ESPECIALIDADE_ID });
                    table.ForeignKey(
                        name: "FK_REGRA_DISTRIBUICAO_ESPEC_REGRA_DISTRIBUICAO_REGRA_DISTRIBUICAO_ID",
                        column: x => x.REGRA_DISTRIBUICAO_ID,
                        principalSchema: "SAJ_DSG",
                        principalTable: "REGRA_DISTRIBUICAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "REGRA_DISTRIBUICAO_ESPEC",
                schema: "SAJ_DSG");
        }
    }
}
