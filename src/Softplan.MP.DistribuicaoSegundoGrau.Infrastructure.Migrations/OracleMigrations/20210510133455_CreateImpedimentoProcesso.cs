using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class CreateImpedimentoProcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IMPEDIMENTO_PROCESSO",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    PROCESSO_ID = table.Column<int>(nullable: false),
                    IMPEDIMENTO_ID = table.Column<int>(nullable: false),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(nullable: true),
                    VAGA_ID = table.Column<int>(nullable: false),
                    MOTIVO = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMPEDIMENTO_PROCESSO", x => new { x.PROCESSO_ID, x.IMPEDIMENTO_ID });
                    table.ForeignKey(
                        name: "FK_IMPEDIMENTO_PROCESSO_VAGA_VAGA_ID",
                        column: x => x.VAGA_ID,
                        principalSchema: "SAJ_DSG",
                        principalTable: "VAGA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IMPEDIMENTO_PROCESSO_VAGA_ID",
                schema: "SAJ_DSG",
                table: "IMPEDIMENTO_PROCESSO",
                column: "VAGA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_IMPEDIMENTO_PROCESSO_METADATA_UUID",
                schema: "SAJ_DSG",
                table: "IMPEDIMENTO_PROCESSO",
                column: "METADATA_UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IMPEDIMENTO_PROCESSO",
                schema: "SAJ_DSG");
        }
    }
}
