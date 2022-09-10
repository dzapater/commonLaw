using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class CreateMembroVaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "tipo_orgao_id",
                schema: "saj_dsg",
                table: "vaga",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "procurador_titular_id",
                schema: "saj_dsg",
                table: "vaga",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "orgao_id",
                schema: "saj_dsg",
                table: "vaga",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "instalacao_id",
                schema: "saj_dsg",
                table: "vaga",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "motivo_membro_vaga",
                schema: "saj_dsg",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(maxLength: 120, nullable: true),
                    ativo = table.Column<bool>(nullable: false),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_motivo_membro_vaga", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "membro_vaga",
                schema: "saj_dsg",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_vaga = table.Column<int>(nullable: false),
                    id_membro = table.Column<string>(maxLength: 120, nullable: false),
                    id_motivo_membro_vaga = table.Column<int>(nullable: false),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(nullable: true),
                    observacao = table.Column<string>(maxLength: 2000, nullable: true),
                    data_inicial = table.Column<DateTimeOffset>(nullable: false),
                    data_final = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_membro_vaga", x => new { x.id, x.id_vaga, x.id_membro });
                    table.ForeignKey(
                        name: "fk_membro_vaga_motivo_membro_vaga_id_motivo_membro_vaga",
                        column: x => x.id_motivo_membro_vaga,
                        principalSchema: "saj_dsg",
                        principalTable: "motivo_membro_vaga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_membro_vaga_vaga_id_vaga",
                        column: x => x.id_vaga,
                        principalSchema: "saj_dsg",
                        principalTable: "vaga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_membro_vaga_id_motivo_membro_vaga",
                schema: "saj_dsg",
                table: "membro_vaga",
                column: "id_motivo_membro_vaga");

            migrationBuilder.CreateIndex(
                name: "ix_membro_vaga_id_vaga",
                schema: "saj_dsg",
                table: "membro_vaga",
                column: "id_vaga");

            migrationBuilder.CreateIndex(
                name: "ix_membro_vaga_metadata_uuid",
                schema: "saj_dsg",
                table: "membro_vaga",
                column: "metadata_uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_motivo_membro_vaga_metadata_uuid",
                schema: "saj_dsg",
                table: "motivo_membro_vaga",
                column: "metadata_uuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "membro_vaga",
                schema: "saj_dsg");

            migrationBuilder.DropTable(
                name: "motivo_membro_vaga",
                schema: "saj_dsg");

            migrationBuilder.AlterColumn<long>(
                name: "tipo_orgao_id",
                schema: "saj_dsg",
                table: "vaga",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "procurador_titular_id",
                schema: "saj_dsg",
                table: "vaga",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "orgao_id",
                schema: "saj_dsg",
                table: "vaga",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "instalacao_id",
                schema: "saj_dsg",
                table: "vaga",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
