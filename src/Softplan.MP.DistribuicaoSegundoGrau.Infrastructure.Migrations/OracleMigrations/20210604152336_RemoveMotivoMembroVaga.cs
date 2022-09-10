using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class RemoveMotivoMembroVaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MEMBRO_VAGA_MOTIVO_MEMBRO_VAGA_ID_MOTIVO_MEMBRO_VAGA",
                schema: "SAJ_DSG",
                table: "MEMBRO_VAGA");

            migrationBuilder.DropTable(
                name: "MOTIVO_MEMBRO_VAGA",
                schema: "SAJ_DSG");

            migrationBuilder.DropIndex(
                name: "IX_MEMBRO_VAGA_ID_MOTIVO_MEMBRO_VAGA",
                schema: "SAJ_DSG",
                table: "MEMBRO_VAGA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MOTIVO_MEMBRO_VAGA",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ATIVO = table.Column<bool>(type: "bool", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar2(120)", maxLength: 120, nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(type: "blob", rowVersion: true, nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(type: "nclob", nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(type: "nclob", nullable: true),
                    METADATA_UUID = table.Column<Guid>(type: "guid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOTIVO_MEMBRO_VAGA", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MEMBRO_VAGA_ID_MOTIVO_MEMBRO_VAGA",
                schema: "SAJ_DSG",
                table: "MEMBRO_VAGA",
                column: "ID_MOTIVO_MEMBRO_VAGA");

            migrationBuilder.CreateIndex(
                name: "IX_MOTIVO_MEMBRO_VAGA_METADATA_UUID",
                schema: "SAJ_DSG",
                table: "MOTIVO_MEMBRO_VAGA",
                column: "METADATA_UUID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MEMBRO_VAGA_MOTIVO_MEMBRO_VAGA_ID_MOTIVO_MEMBRO_VAGA",
                schema: "SAJ_DSG",
                table: "MEMBRO_VAGA",
                column: "ID_MOTIVO_MEMBRO_VAGA",
                principalSchema: "SAJ_DSG",
                principalTable: "MOTIVO_MEMBRO_VAGA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
