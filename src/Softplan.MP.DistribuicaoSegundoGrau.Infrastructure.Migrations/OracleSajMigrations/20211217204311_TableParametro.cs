using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleSajMigrations
{
    public partial class TableParametro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EPADDEFPARAMETRO",
                schema: "SAJ",
                columns: table => new
                {
                    CDPARAMETRO = table.Column<long>(nullable: false),
                    DEPARAMETRO = table.Column<string>(maxLength: 200, nullable: true),
                    NUTAMANHO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPADDEFPARAMETRO", x => x.CDPARAMETRO);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EPADDEFPARAMETRO",
                schema: "SAJ");
        }
    }
}
