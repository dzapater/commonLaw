using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class CreateImpedimentoDistribuicaoLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "impedimento_distribuicao_log",
                schema: "saj_dsg",
                columns: table => new
                {
                    log_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    processo_id = table.Column<string>(maxLength: 200, nullable: false),
                    transaction_id = table.Column<Guid>(nullable: false),
                    tipo_distribuicao = table.Column<int>(nullable: false),
                    payload_type = table.Column<string>(maxLength: 200, nullable: true),
                    payload_serialization_type = table.Column<int>(nullable: false),
                    payload = table.Column<byte[]>(nullable: true),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_impedimento_distribuicao_log", x => x.log_id);
                });

            migrationBuilder.CreateIndex(
                name: "impedimento_distribuicao_log_processo",
                schema: "saj_dsg",
                table: "impedimento_distribuicao_log",
                column: "processo_id");

            migrationBuilder.CreateIndex(
                name: "impedimento_distribuicao_log_processo_transactionid",
                schema: "saj_dsg",
                table: "impedimento_distribuicao_log",
                columns: new[] { "processo_id", "transaction_id" });

            migrationBuilder.CreateIndex(
                name: "ix_impedimento_distribuicao_log_metadata_uuid",
                schema: "saj_dsg",
                table: "impedimento_distribuicao_log",
                column: "metadata_uuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "impedimento_distribuicao_log",
                schema: "saj_dsg");
        }
    }
}
