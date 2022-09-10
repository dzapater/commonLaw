using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class CreateMembroVaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TIPO_ORGAO_ID",
                schema: "SAJ_DSG",
                table: "VAGA",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "int64");

            migrationBuilder.AlterColumn<string>(
                name: "PROCURADOR_TITULAR_ID",
                schema: "SAJ_DSG",
                table: "VAGA",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(long),
                oldType: "int64");

            migrationBuilder.AlterColumn<int>(
                name: "ORGAO_ID",
                schema: "SAJ_DSG",
                table: "VAGA",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "int64");

            migrationBuilder.AlterColumn<int>(
                name: "INSTALACAO_ID",
                schema: "SAJ_DSG",
                table: "VAGA",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "int64");

            migrationBuilder.CreateTable(
                name: "MOTIVO_MEMBRO_VAGA",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 120, nullable: true),
                    ATIVO = table.Column<bool>(nullable: false),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOTIVO_MEMBRO_VAGA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MEMBRO_VAGA",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    ID_VAGA = table.Column<int>(nullable: false),
                    ID_MEMBRO = table.Column<string>(maxLength: 120, nullable: false),
                    ID_MOTIVO_MEMBRO_VAGA = table.Column<int>(nullable: false),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(nullable: true),
                    OBSERVACAO = table.Column<string>(maxLength: 2000, nullable: true),
                    DATA_INICIAL = table.Column<DateTimeOffset>(nullable: false),
                    DATA_FINAL = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEMBRO_VAGA", x => new { x.ID, x.ID_VAGA, x.ID_MEMBRO });
                    table.ForeignKey(
                        name: "FK_MEMBRO_VAGA_MOTIVO_MEMBRO_VAGA_ID_MOTIVO_MEMBRO_VAGA",
                        column: x => x.ID_MOTIVO_MEMBRO_VAGA,
                        principalSchema: "SAJ_DSG",
                        principalTable: "MOTIVO_MEMBRO_VAGA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MEMBRO_VAGA_VAGA_ID_VAGA",
                        column: x => x.ID_VAGA,
                        principalSchema: "SAJ_DSG",
                        principalTable: "VAGA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MEMBRO_VAGA_ID_MOTIVO_MEMBRO_VAGA",
                schema: "SAJ_DSG",
                table: "MEMBRO_VAGA",
                column: "ID_MOTIVO_MEMBRO_VAGA");

            migrationBuilder.CreateIndex(
                name: "IX_MEMBRO_VAGA_ID_VAGA",
                schema: "SAJ_DSG",
                table: "MEMBRO_VAGA",
                column: "ID_VAGA");

            migrationBuilder.CreateIndex(
                name: "IX_MEMBRO_VAGA_METADATA_UUID",
                schema: "SAJ_DSG",
                table: "MEMBRO_VAGA",
                column: "METADATA_UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MOTIVO_MEMBRO_VAGA_METADATA_UUID",
                schema: "SAJ_DSG",
                table: "MOTIVO_MEMBRO_VAGA",
                column: "METADATA_UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MEMBRO_VAGA",
                schema: "SAJ_DSG");

            migrationBuilder.DropTable(
                name: "MOTIVO_MEMBRO_VAGA",
                schema: "SAJ_DSG");

            migrationBuilder.AlterColumn<long>(
                name: "TIPO_ORGAO_ID",
                schema: "SAJ_DSG",
                table: "VAGA",
                type: "int64",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "PROCURADOR_TITULAR_ID",
                schema: "SAJ_DSG",
                table: "VAGA",
                type: "int64",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ORGAO_ID",
                schema: "SAJ_DSG",
                table: "VAGA",
                type: "int64",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "INSTALACAO_ID",
                schema: "SAJ_DSG",
                table: "VAGA",
                type: "int64",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
