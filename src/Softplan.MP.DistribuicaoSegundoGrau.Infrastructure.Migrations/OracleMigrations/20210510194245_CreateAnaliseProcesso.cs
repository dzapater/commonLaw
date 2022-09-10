using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class CreateAnaliseProcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ANALISE_PROCESSO",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    PROCESSO_ID = table.Column<string>(nullable: false),
                    VAGA_ID = table.Column<int>(nullable: true),
                    MOTIVO = table.Column<string>(maxLength: 2000, nullable: true),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(nullable: true),
                    TIPO_DISTRIBUICAO = table.Column<int>(nullable: false),
                    AREA = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANALISE_PROCESSO", x => x.PROCESSO_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ANALISE_PROCESSO_METADATA_UUID",
                schema: "SAJ_DSG",
                table: "ANALISE_PROCESSO",
                column: "METADATA_UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ANALISE_PROCESSO",
                schema: "SAJ_DSG");
        }
    }
}
