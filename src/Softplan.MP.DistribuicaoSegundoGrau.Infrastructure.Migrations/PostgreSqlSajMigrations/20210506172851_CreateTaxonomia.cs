using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlSajMigrations
{
    public partial class CreateTaxonomia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "saj");

            migrationBuilder.CreateTable(
                name: "efmptjclasse",
                schema: "saj",
                columns: table => new
                {
                    cdorigem = table.Column<int>(nullable: false),
                    cdclasse = table.Column<int>(nullable: false),
                    declasse = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_efmptjclasse", x => new { x.cdorigem, x.cdclasse });
                });

            migrationBuilder.CreateTable(
                name: "efmptjforo",
                schema: "saj",
                columns: table => new
                {
                    cdorigem = table.Column<int>(nullable: false),
                    cdforo = table.Column<int>(nullable: false),
                    nmforo = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_efmptjforo", x => new { x.cdorigem, x.cdforo });
                });

            migrationBuilder.CreateTable(
                name: "efmptjvara",
                schema: "saj",
                columns: table => new
                {
                    cdorigem = table.Column<int>(nullable: false),
                    cdforo = table.Column<int>(nullable: false),
                    cdvara = table.Column<int>(nullable: false),
                    nmvara = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_efmptjvara", x => new { x.cdorigem, x.cdforo, x.cdvara });
                });

            migrationBuilder.CreateTable(
                name: "esajassunto",
                schema: "saj",
                columns: table => new
                {
                    cdassunto = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    deassunto = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_esajassunto", x => x.cdassunto);
                });

            migrationBuilder.CreateTable(
                name: "esajtarja",
                schema: "saj",
                columns: table => new
                {
                    cdtarja = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    detarja = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_esajtarja", x => x.cdtarja);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "efmptjclasse",
                schema: "saj");

            migrationBuilder.DropTable(
                name: "efmptjforo",
                schema: "saj");

            migrationBuilder.DropTable(
                name: "efmptjvara",
                schema: "saj");

            migrationBuilder.DropTable(
                name: "esajassunto",
                schema: "saj");

            migrationBuilder.DropTable(
                name: "esajtarja",
                schema: "saj");
        }
    }
}
