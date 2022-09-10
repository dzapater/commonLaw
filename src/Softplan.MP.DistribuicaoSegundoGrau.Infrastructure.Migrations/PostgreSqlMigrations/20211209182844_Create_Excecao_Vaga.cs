using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class Create_Excecao_Vaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "excecao_vaga",
                schema: "saj_dsg",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(nullable: true),
                    vaga_id = table.Column<int>(nullable: false),
                    classe_id = table.Column<int>(nullable: true),
                    assunto_id = table.Column<int>(nullable: true),
                    especialidade_id = table.Column<int>(nullable: true),
                    origem_id = table.Column<int>(nullable: true),
                    unidade_id = table.Column<int>(nullable: true),
                    orgao_julgador_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_excecao_vaga", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_excecao_vaga_metadata_uuid",
                schema: "saj_dsg",
                table: "excecao_vaga",
                column: "metadata_uuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "excecao_vaga",
                schema: "saj_dsg");
        }
    }
}
