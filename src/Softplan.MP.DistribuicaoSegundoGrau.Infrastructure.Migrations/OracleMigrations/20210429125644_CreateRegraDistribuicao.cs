using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class CreateRegraDistribuicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SAJ_DSG");

            migrationBuilder.CreateTable(
                name: "REGRA_DISTRIBUICAO",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(nullable: true),
                    TIPO_PROCESSO = table.Column<int>(nullable: false),
                    AREA = table.Column<int>(nullable: false),
                    VARIAVEL_EQUILIBRIO = table.Column<int>(nullable: false),
                    ESCOPO_EQUILIBRIO = table.Column<int>(nullable: false),
                    ESPECIALIDADE_ID = table.Column<int>(nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 120, nullable: true),
                    ATIVO = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGRA_DISTRIBUICAO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "REGRA_DISTRIBUICAO_ASSUNTO",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    REGRA_DISTRIBUICAO_ID = table.Column<int>(nullable: false),
                    ASSUNTO_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGRA_DISTRIBUICAO_ASSUNTO", x => new { x.REGRA_DISTRIBUICAO_ID, x.ASSUNTO_ID });
                    table.ForeignKey(
                        name: "FK_REGRA_DISTRIBUICAO_ASSUNTO_REGRA_DISTRIBUICAO_REGRA_DISTRIBUICAO_ID",
                        column: x => x.REGRA_DISTRIBUICAO_ID,
                        principalSchema: "SAJ_DSG",
                        principalTable: "REGRA_DISTRIBUICAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REGRA_DISTRIBUICAO_CLASSE",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    REGRA_DISTRIBUICAO_ID = table.Column<int>(nullable: false),
                    CLASSE_ID = table.Column<int>(nullable: false),
                    ORIGEM_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGRA_DISTRIBUICAO_CLASSE", x => new { x.REGRA_DISTRIBUICAO_ID, x.CLASSE_ID });
                    table.ForeignKey(
                        name: "FK_REGRA_DISTRIBUICAO_CLASSE_REGRA_DISTRIBUICAO_REGRA_DISTRIBUICAO_ID",
                        column: x => x.REGRA_DISTRIBUICAO_ID,
                        principalSchema: "SAJ_DSG",
                        principalTable: "REGRA_DISTRIBUICAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REGRA_DISTRIBUICAO_ORGAO",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    REGRA_DISTRIBUICAO_ID = table.Column<int>(nullable: false),
                    ORGAO_JULGADOR_ID = table.Column<int>(nullable: false),
                    ORIGEM_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGRA_DISTRIBUICAO_ORGAO", x => new { x.REGRA_DISTRIBUICAO_ID, x.ORGAO_JULGADOR_ID });
                    table.ForeignKey(
                        name: "FK_REGRA_DISTRIBUICAO_ORGAO_REGRA_DISTRIBUICAO_REGRA_DISTRIBUICAO_ID",
                        column: x => x.REGRA_DISTRIBUICAO_ID,
                        principalSchema: "SAJ_DSG",
                        principalTable: "REGRA_DISTRIBUICAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REGRA_DISTRIBUICAO_TARJA",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    REGRA_DISTRIBUICAO_ID = table.Column<int>(nullable: false),
                    TARJA_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGRA_DISTRIBUICAO_TARJA", x => new { x.REGRA_DISTRIBUICAO_ID, x.TARJA_ID });
                    table.ForeignKey(
                        name: "FK_REGRA_DISTRIBUICAO_TARJA_REGRA_DISTRIBUICAO_REGRA_DISTRIBUICAO_ID",
                        column: x => x.REGRA_DISTRIBUICAO_ID,
                        principalSchema: "SAJ_DSG",
                        principalTable: "REGRA_DISTRIBUICAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REGRA_DISTRIBUICAO_UNIDADE",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    REGRA_DISTRIBUICAO_ID = table.Column<int>(nullable: false),
                    UNIDADE_ID = table.Column<int>(nullable: false),
                    ORIGEM_ID = table.Column<int>(nullable: false),
                    ORGAO_JULGADOR_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGRA_DISTRIBUICAO_UNIDADE", x => new { x.REGRA_DISTRIBUICAO_ID, x.UNIDADE_ID });
                    table.ForeignKey(
                        name: "FK_REGRA_DISTRIBUICAO_UNIDADE_REGRA_DISTRIBUICAO_REGRA_DISTRIBUICAO_ID",
                        column: x => x.REGRA_DISTRIBUICAO_ID,
                        principalSchema: "SAJ_DSG",
                        principalTable: "REGRA_DISTRIBUICAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_REGRA_DISTRIBUICAO_METADATA_UUID",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO",
                column: "METADATA_UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "REGRA_DISTRIBUICAO_ASSUNTO",
                schema: "SAJ_DSG");

            migrationBuilder.DropTable(
                name: "REGRA_DISTRIBUICAO_CLASSE",
                schema: "SAJ_DSG");

            migrationBuilder.DropTable(
                name: "REGRA_DISTRIBUICAO_ORGAO",
                schema: "SAJ_DSG");

            migrationBuilder.DropTable(
                name: "REGRA_DISTRIBUICAO_TARJA",
                schema: "SAJ_DSG");

            migrationBuilder.DropTable(
                name: "REGRA_DISTRIBUICAO_UNIDADE",
                schema: "SAJ_DSG");

            migrationBuilder.DropTable(
                name: "REGRA_DISTRIBUICAO",
                schema: "SAJ_DSG");
        }
    }
}
