using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class CreateVaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VAGA",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    ORGAO_ID = table.Column<long>(nullable: false),
                    TIPO_ORGAO_ID = table.Column<long>(nullable: false),
                    INSTALACAO_ID = table.Column<long>(nullable: false),
                    PROCURADOR_TITULAR_ID = table.Column<long>(nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 120, nullable: true),
                    AREA = table.Column<int>(nullable: false),
                    ATIVA = table.Column<bool>(nullable: false),
                    REU_PRESO = table.Column<bool>(nullable: false),
                    DISTRIBUICAO_MESMA_VAGA = table.Column<bool>(nullable: false),
                    CONFIGURACOES_PREVENCAO = table.Column<bool>(nullable: false),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAGA", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VAGA_METADATA_UUID",
                schema: "SAJ_DSG",
                table: "VAGA",
                column: "METADATA_UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VAGA",
                schema: "SAJ_DSG");
        }
    }
}
