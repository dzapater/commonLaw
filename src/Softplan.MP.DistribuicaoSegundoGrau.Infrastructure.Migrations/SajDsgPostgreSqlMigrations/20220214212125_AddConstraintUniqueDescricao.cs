using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.SajDsgPostgreSqlMigrations
{
    public partial class AddConstraintUniqueDescricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_vaga_descricao",
                schema: "sajdsg",
                table: "vaga",
                column: "descricao",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_vaga_descricao",
                schema: "sajdsg",
                table: "vaga");
        }
    }
}
