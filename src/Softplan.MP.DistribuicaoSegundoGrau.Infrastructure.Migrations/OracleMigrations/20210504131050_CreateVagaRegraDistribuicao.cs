using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class CreateVagaRegraDistribuicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VAGA_REGRA_DISTRIBUICAO",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    ID_VAGA = table.Column<int>(nullable: false),
                    ID_REGRADISTRIBUICAO = table.Column<int>(nullable: false),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAGA_REGRA_DISTRIBUICAO", x => new { x.ID_VAGA, x.ID_REGRADISTRIBUICAO });
                    table.ForeignKey(
                        name: "FK_VAGA_REGRA_DISTRIBUICAO_REGRA_DISTRIBUICAO_ID_REGRADISTRIBUICAO",
                        column: x => x.ID_REGRADISTRIBUICAO,
                        principalSchema: "SAJ_DSG",
                        principalTable: "REGRA_DISTRIBUICAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VAGA_REGRA_DISTRIBUICAO_VAGA_ID_VAGA",
                        column: x => x.ID_VAGA,
                        principalSchema: "SAJ_DSG",
                        principalTable: "VAGA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VAGA_REGRA_DISTRIBUICAO_ID_REGRADISTRIBUICAO",
                schema: "SAJ_DSG",
                table: "VAGA_REGRA_DISTRIBUICAO",
                column: "ID_REGRADISTRIBUICAO");

            migrationBuilder.CreateIndex(
                name: "IX_VAGA_REGRA_DISTRIBUICAO_METADATA_UUID",
                schema: "SAJ_DSG",
                table: "VAGA_REGRA_DISTRIBUICAO",
                column: "METADATA_UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VAGA_REGRA_DISTRIBUICAO",
                schema: "SAJ_DSG");
        }
    }
}
