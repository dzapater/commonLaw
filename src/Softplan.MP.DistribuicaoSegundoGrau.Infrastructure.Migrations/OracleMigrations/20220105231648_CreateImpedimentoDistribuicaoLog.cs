using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class CreateImpedimentoDistribuicaoLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IMPEDIMENTO_DISTRIBUICAO_LOG",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    LOG_ID = table.Column<long>(nullable: false),
                    PROCESSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    TRANSACTION_ID = table.Column<Guid>(nullable: false),
                    TIPO_DISTRIBUICAO = table.Column<int>(nullable: false),
                    PAYLOAD_TYPE = table.Column<string>(maxLength: 200, nullable: true),
                    PAYLOAD_SERIALIZATION_TYPE = table.Column<int>(nullable: false),
                    PAYLOAD = table.Column<byte[]>(nullable: true),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMPEDIMENTO_DISTRIBUICAO_LOG", x => x.LOG_ID);
                });

            migrationBuilder.CreateIndex(
                name: "impedimento_distribuicao_log_processo",
                schema: "SAJ_DSG",
                table: "IMPEDIMENTO_DISTRIBUICAO_LOG",
                column: "PROCESSO_ID")
                .Annotation("Relational:Name", "impedimento_distribuicao_log_processo");

            migrationBuilder.CreateIndex(
                name: "impedimento_distribuicao_log_processo_transactionid",
                schema: "SAJ_DSG",
                table: "IMPEDIMENTO_DISTRIBUICAO_LOG",
                columns: new[] { "PROCESSO_ID", "TRANSACTION_ID" })
                .Annotation("Relational:Name", "impedimento_distribuicao_log_processo_transactionid");

            migrationBuilder.CreateIndex(
                name: "IX_IMPEDIMENTO_DISTRIBUICAO_LOG_METADATA_UUID",
                schema: "SAJ_DSG",
                table: "IMPEDIMENTO_DISTRIBUICAO_LOG",
                column: "METADATA_UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IMPEDIMENTO_DISTRIBUICAO_LOG",
                schema: "SAJ_DSG");
        }
    }
}
