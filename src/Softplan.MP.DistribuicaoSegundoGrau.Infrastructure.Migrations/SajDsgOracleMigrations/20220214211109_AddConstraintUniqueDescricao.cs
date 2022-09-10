using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.SajDsgOracleMigrations
{
    public partial class AddConstraintUniqueDescricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VAGA_DESCRICAO",
                schema: "SAJDSG",
                table: "VAGA",
                column: "DESCRICAO",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VAGA_DESCRICAO",
                schema: "SAJDSG",
                table: "VAGA");
        }
    }
}
