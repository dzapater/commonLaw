using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class CreateDistribuicaoProcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DISTRIBUICAO_PROCESSO",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    PROCESSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DISTRIBUICAO_PROCESSO", x => x.PROCESSO_ID);
                });

            migrationBuilder.CreateTable(
                name: "DISTRIBUICAO_PROCESSO_LOG",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    PROCESSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    LOG_ID = table.Column<long>(nullable: false),
                    TRANSACTION_ID = table.Column<Guid>(nullable: false),
                    PAYLOAD_TYPE = table.Column<string>(maxLength: 200, nullable: true),
                    PAYLOAD_SERIALIZATION_TYPE = table.Column<int>(nullable: false),
                    PAYLOAD = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DISTRIBUICAO_PROCESSO_LOG", x => new { x.PROCESSO_ID, x.LOG_ID });
                    table.ForeignKey(
                        name: "FK_N1194527237",
                        column: x => x.PROCESSO_ID,
                        principalSchema: "SAJ_DSG",
                        principalTable: "DISTRIBUICAO_PROCESSO",
                        principalColumn: "PROCESSO_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DISTRIBUICAO_PROCESSO_METADATA_UUID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO",
                column: "METADATA_UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "distribuicao_processo_log_processo",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO_LOG",
                column: "PROCESSO_ID")
                .Annotation("Relational:Name", "distribuicao_processo_log_processo");

            migrationBuilder.CreateIndex(
                name: "distribuicao_processo_log_processo_transactionid",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO_LOG",
                columns: new[] { "PROCESSO_ID", "TRANSACTION_ID" })
                .Annotation("Relational:Name", "distribuicao_processo_log_processo_transactionid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DISTRIBUICAO_PROCESSO_LOG",
                schema: "SAJ_DSG");

            migrationBuilder.DropTable(
                name: "DISTRIBUICAO_PROCESSO",
                schema: "SAJ_DSG");
        }
    }
}
