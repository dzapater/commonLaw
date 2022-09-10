using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class Create_Excecao_Vaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EXCECAO_VAGA",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(nullable: true),
                    VAGA_ID = table.Column<int>(nullable: false),
                    CLASSE_ID = table.Column<int>(nullable: true),
                    ASSUNTO_ID = table.Column<int>(nullable: true),
                    ESPECIALIDADE_ID = table.Column<int>(nullable: true),
                    ORIGEM_ID = table.Column<int>(nullable: true),
                    UNIDADE_ID = table.Column<int>(nullable: true),
                    ORGAO_JULGADOR_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXCECAO_VAGA", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EXCECAO_VAGA_METADATA_UUID",
                schema: "SAJ_DSG",
                table: "EXCECAO_VAGA",
                column: "METADATA_UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EXCECAO_VAGA",
                schema: "SAJ_DSG");
        }
    }
}
