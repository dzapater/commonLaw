using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleSajMigrations
{
    public partial class CreateTaxonomia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SAJ");

            migrationBuilder.CreateTable(
                name: "ESAJCLASSE",
                schema: "SAJ",
                columns: table => new
                {
                    CDCLASSE = table.Column<long>(nullable: false),
                    DECLASSE = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESAJCLASSE", x => x.CDCLASSE);
                });

            migrationBuilder.CreateTable(
                name: "EFMPTJFORO",
                schema: "SAJ",
                columns: table => new
                {
                    CDORIGEM = table.Column<int>(nullable: false),
                    CDFORO = table.Column<int>(nullable: false),
                    NMFORO = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EFMPTJFORO", x => new { x.CDORIGEM, x.CDFORO });
                });

            migrationBuilder.CreateTable(
                name: "EFMPTJVARA",
                schema: "SAJ",
                columns: table => new
                {
                    CDORIGEM = table.Column<int>(nullable: false),
                    CDFORO = table.Column<int>(nullable: false),
                    CDVARA = table.Column<int>(nullable: false),
                    NMVARA = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EFMPTJVARA", x => new { x.CDORIGEM, x.CDFORO, x.CDVARA });
                });

            migrationBuilder.CreateTable(
                name: "ESAJASSUNTO",
                schema: "SAJ",
                columns: table => new
                {
                    CDASSUNTO = table.Column<int>(nullable: false),
                    DEASSUNTO = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESAJASSUNTO", x => x.CDASSUNTO);
                });

            migrationBuilder.CreateTable(
                name: "ESAJTARJA",
                schema: "SAJ",
                columns: table => new
                {
                    CDTARJA = table.Column<int>(nullable: false),
                    DETARJA = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESAJTARJA", x => x.CDTARJA);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EFMPTJCLASSE",
                schema: "SAJ");

            migrationBuilder.DropTable(
                name: "EFMPTJFORO",
                schema: "SAJ");

            migrationBuilder.DropTable(
                name: "EFMPTJVARA",
                schema: "SAJ");

            migrationBuilder.DropTable(
                name: "ESAJASSUNTO",
                schema: "SAJ");

            migrationBuilder.DropTable(
                name: "ESAJTARJA",
                schema: "SAJ");
        }
    }
}
