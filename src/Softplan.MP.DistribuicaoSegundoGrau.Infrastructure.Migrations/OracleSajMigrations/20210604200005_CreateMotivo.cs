using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleSajMigrations
{
    public partial class CreateMotivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EFMPESPECIALIDADE",
                schema: "SAJ",
                columns: table => new
                {
                    CDESPECIALIDADE = table.Column<int>(nullable: false),
                    DEESPECIALIDADE = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EFMPESPECIALIDADE", x => x.CDESPECIALIDADE);
                });

            migrationBuilder.CreateTable(
                name: "EFMPSITOFICIANTE",
                schema: "SAJ",
                columns: table => new
                {
                    CDSITOFICIANTE = table.Column<int>(nullable: false),
                    DESITOFICIANTE = table.Column<string>(maxLength: 40, nullable: true),
                    FLSITOFICIANTE = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EFMPSITOFICIANTE", x => x.CDSITOFICIANTE);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EFMPESPECIALIDADE",
                schema: "SAJ");

            migrationBuilder.DropTable(
                name: "EFMPSITOFICIANTE",
                schema: "SAJ");
        }
    }
}
