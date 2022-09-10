using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class CreateDistribuicaoProcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "distribuicao_processo",
                schema: "saj_dsg",
                columns: table => new
                {
                    processo_id = table.Column<string>(maxLength: 200, nullable: false),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_distribuicao_processo", x => x.processo_id);
                });

            migrationBuilder.CreateTable(
                name: "distribuicao_processo_log",
                schema: "saj_dsg",
                columns: table => new
                {
                    processo_id = table.Column<string>(maxLength: 200, nullable: false),
                    log_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    transaction_id = table.Column<Guid>(nullable: false),
                    payload_type = table.Column<string>(maxLength: 200, nullable: true),
                    payload_serialization_type = table.Column<int>(nullable: false),
                    payload = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_distribuicao_processo_log", x => new { x.processo_id, x.log_id });
                    table.ForeignKey(
                        name: "fk_distribuicao_processo_log_distribuicao_processo_processo_id",
                        column: x => x.processo_id,
                        principalSchema: "saj_dsg",
                        principalTable: "distribuicao_processo",
                        principalColumn: "processo_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_distribuicao_processo_metadata_uuid",
                schema: "saj_dsg",
                table: "distribuicao_processo",
                column: "metadata_uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "distribuicao_processo_log_processo",
                schema: "saj_dsg",
                table: "distribuicao_processo_log",
                column: "processo_id");

            migrationBuilder.CreateIndex(
                name: "distribuicao_processo_log_processo_transactionid",
                schema: "saj_dsg",
                table: "distribuicao_processo_log",
                columns: new[] { "processo_id", "transaction_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "distribuicao_processo_log",
                schema: "saj_dsg");

            migrationBuilder.DropTable(
                name: "distribuicao_processo",
                schema: "saj_dsg");
        }
    }
}
