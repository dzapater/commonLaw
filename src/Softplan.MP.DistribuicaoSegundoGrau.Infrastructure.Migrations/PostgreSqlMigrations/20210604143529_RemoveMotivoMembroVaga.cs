using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class RemoveMotivoMembroVaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_membro_vaga_motivo_membro_vaga_id_motivo_membro_vaga",
                schema: "saj_dsg",
                table: "membro_vaga");

            migrationBuilder.DropTable(
                name: "motivo_membro_vaga",
                schema: "saj_dsg");

            migrationBuilder.DropIndex(
                name: "ix_membro_vaga_id_motivo_membro_vaga",
                schema: "saj_dsg",
                table: "membro_vaga");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "motivo_membro_vaga",
                schema: "saj_dsg",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    descricao = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    metadata_row_version = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(type: "text", nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(type: "text", nullable: true),
                    metadata_uuid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_motivo_membro_vaga", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_membro_vaga_id_motivo_membro_vaga",
                schema: "saj_dsg",
                table: "membro_vaga",
                column: "id_motivo_membro_vaga");

            migrationBuilder.CreateIndex(
                name: "ix_motivo_membro_vaga_metadata_uuid",
                schema: "saj_dsg",
                table: "motivo_membro_vaga",
                column: "metadata_uuid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_membro_vaga_motivo_membro_vaga_id_motivo_membro_vaga",
                schema: "saj_dsg",
                table: "membro_vaga",
                column: "id_motivo_membro_vaga",
                principalSchema: "saj_dsg",
                principalTable: "motivo_membro_vaga",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
