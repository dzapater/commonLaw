using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class CreateVaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vaga",
                schema: "saj_dsg",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orgao_id = table.Column<long>(nullable: false),
                    tipo_orgao_id = table.Column<long>(nullable: false),
                    instalacao_id = table.Column<long>(nullable: false),
                    procurador_titular_id = table.Column<long>(nullable: false),
                    descricao = table.Column<string>(maxLength: 120, nullable: true),
                    area = table.Column<int>(nullable: false),
                    ativa = table.Column<bool>(nullable: false),
                    reu_preso = table.Column<bool>(nullable: false),
                    distribuicao_mesma_vaga = table.Column<bool>(nullable: false),
                    configuracoes_prevencao = table.Column<bool>(nullable: false),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vaga", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_vaga_metadata_uuid",
                schema: "saj_dsg",
                table: "vaga",
                column: "metadata_uuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vaga",
                schema: "saj_dsg");
        }
    }
}
