using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class CreateAnaliseProceso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "analise_processo",
                schema: "saj_dsg",
                columns: table => new
                {
                    processo_id = table.Column<string>(nullable: false),
                    vaga_id = table.Column<int>(nullable: true),
                    motivo = table.Column<string>(maxLength: 2000, nullable: true),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(nullable: true),
                    tipo_distribuicao = table.Column<int>(nullable: false),
                    area = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_analise_processo", x => x.processo_id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_analise_processo_metadata_uuid",
                schema: "saj_dsg",
                table: "analise_processo",
                column: "metadata_uuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "analise_processo",
                schema: "saj_dsg");
        }
    }
}
