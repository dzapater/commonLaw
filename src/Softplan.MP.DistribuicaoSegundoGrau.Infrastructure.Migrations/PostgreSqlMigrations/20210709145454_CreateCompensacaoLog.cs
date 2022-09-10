using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class CreateCompensacaoLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "tipo_orgao_id",
                schema: "saj_dsg",
                table: "vaga",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "orgao_id",
                schema: "saj_dsg",
                table: "vaga",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "compensacao_log",
                schema: "saj_dsg",
                columns: table => new
                {
                    log_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vaga_id = table.Column<int>(nullable: false),
                    motivo = table.Column<string>(maxLength: 2000, nullable: true),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(nullable: true),
                    valor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_compensacao_log", x => x.log_id);
                    table.ForeignKey(
                        name: "fk_compensacao_log_vaga_vaga_id",
                        column: x => x.vaga_id,
                        principalSchema: "saj_dsg",
                        principalTable: "vaga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_compensacao_log_vaga_id",
                schema: "saj_dsg",
                table: "compensacao_log",
                column: "vaga_id");

            migrationBuilder.CreateIndex(
                name: "ix_compensacao_log_metadata_uuid",
                schema: "saj_dsg",
                table: "compensacao_log",
                column: "metadata_uuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "compensacao_log",
                schema: "saj_dsg");

            migrationBuilder.AlterColumn<int>(
                name: "tipo_orgao_id",
                schema: "saj_dsg",
                table: "vaga",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "orgao_id",
                schema: "saj_dsg",
                table: "vaga",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
