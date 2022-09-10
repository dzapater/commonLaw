using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class CreateImpedimentoProcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "impedimento_processo",
                schema: "saj_dsg",
                columns: table => new
                {
                    processo_id = table.Column<int>(nullable: false),
                    impedimento_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(nullable: true),
                    vaga_id = table.Column<int>(nullable: false),
                    motivo = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_impedimento_processo", x => new { x.processo_id, x.impedimento_id });
                    table.ForeignKey(
                        name: "fk_impedimento_processo_vaga_vaga_id",
                        column: x => x.vaga_id,
                        principalSchema: "saj_dsg",
                        principalTable: "vaga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_impedimento_processo_vaga_id",
                schema: "saj_dsg",
                table: "impedimento_processo",
                column: "vaga_id");

            migrationBuilder.CreateIndex(
                name: "ix_impedimento_processo_metadata_uuid",
                schema: "saj_dsg",
                table: "impedimento_processo",
                column: "metadata_uuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "impedimento_processo",
                schema: "saj_dsg");
        }
    }
}
