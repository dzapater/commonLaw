using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleSajMigrations
{
    public partial class UpdateRegraClasse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CDVARA",
                schema: "SAJ",
                table: "EFMPTJVARA",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
            
            migrationBuilder.AlterColumn<long>(
                name: "CDFORO",
                schema: "SAJ",
                table: "EFMPTJVARA",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
            
            migrationBuilder.AlterColumn<long>(
                name: "CDFORO",
                schema: "SAJ",
                table: "EFMPTJFORO",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CDVARA",
                schema: "SAJ",
                table: "EFMPTJVARA",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "CDFORO",
                schema: "SAJ",
                table: "EFMPTJVARA",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "CDFORO",
                schema: "SAJ",
                table: "EFMPTJFORO",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
