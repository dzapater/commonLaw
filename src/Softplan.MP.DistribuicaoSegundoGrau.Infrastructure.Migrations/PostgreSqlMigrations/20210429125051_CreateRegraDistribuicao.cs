using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class CreateRegraDistribuicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "saj_dsg");

            migrationBuilder.CreateTable(
                name: "regra_distribuicao",
                schema: "saj_dsg",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(nullable: true),
                    tipo_processo = table.Column<int>(nullable: false),
                    area = table.Column<int>(nullable: false),
                    variavel_equilibrio = table.Column<int>(nullable: false),
                    escopo_equilibrio = table.Column<int>(nullable: false),
                    especialidade_id = table.Column<int>(nullable: false),
                    descricao = table.Column<string>(maxLength: 120, nullable: true),
                    ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regra_distribuicao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "regra_distribuicao_assunto",
                schema: "saj_dsg",
                columns: table => new
                {
                    regra_distribuicao_id = table.Column<int>(nullable: false),
                    assunto_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regra_distribuicao_assunto", x => new { x.regra_distribuicao_id, x.assunto_id });
                    table.ForeignKey(
                        name: "fk_regra_distribuicao_assunto_regra_distribuicao_regra_distrib~",
                        column: x => x.regra_distribuicao_id,
                        principalSchema: "saj_dsg",
                        principalTable: "regra_distribuicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "regra_distribuicao_classe",
                schema: "saj_dsg",
                columns: table => new
                {
                    regra_distribuicao_id = table.Column<int>(nullable: false),
                    classe_id = table.Column<int>(nullable: false),
                    origem_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regra_distribuicao_classe", x => new { x.regra_distribuicao_id, x.classe_id });
                    table.ForeignKey(
                        name: "fk_regra_distribuicao_classe_regra_distribuicao_regra_distribu~",
                        column: x => x.regra_distribuicao_id,
                        principalSchema: "saj_dsg",
                        principalTable: "regra_distribuicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "regra_distribuicao_orgao",
                schema: "saj_dsg",
                columns: table => new
                {
                    regra_distribuicao_id = table.Column<int>(nullable: false),
                    orgao_julgador_id = table.Column<int>(nullable: false),
                    origem_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regra_distribuicao_orgao", x => new { x.regra_distribuicao_id, x.orgao_julgador_id });
                    table.ForeignKey(
                        name: "fk_regra_distribuicao_orgao_regra_distribuicao_regra_distribui~",
                        column: x => x.regra_distribuicao_id,
                        principalSchema: "saj_dsg",
                        principalTable: "regra_distribuicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "regra_distribuicao_tarja",
                schema: "saj_dsg",
                columns: table => new
                {
                    regra_distribuicao_id = table.Column<int>(nullable: false),
                    tarja_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regra_distribuicao_tarja", x => new { x.regra_distribuicao_id, x.tarja_id });
                    table.ForeignKey(
                        name: "fk_regra_distribuicao_tarja_regra_distribuicao_regra_distribui~",
                        column: x => x.regra_distribuicao_id,
                        principalSchema: "saj_dsg",
                        principalTable: "regra_distribuicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "regra_distribuicao_unidade",
                schema: "saj_dsg",
                columns: table => new
                {
                    regra_distribuicao_id = table.Column<int>(nullable: false),
                    unidade_id = table.Column<int>(nullable: false),
                    origem_id = table.Column<int>(nullable: false),
                    orgao_julgador_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regra_distribuicao_unidade", x => new { x.regra_distribuicao_id, x.unidade_id });
                    table.ForeignKey(
                        name: "fk_regra_distribuicao_unidade_regra_distribuicao_regra_distrib~",
                        column: x => x.regra_distribuicao_id,
                        principalSchema: "saj_dsg",
                        principalTable: "regra_distribuicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_regra_distribuicao_metadata_uuid",
                schema: "saj_dsg",
                table: "regra_distribuicao",
                column: "metadata_uuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "regra_distribuicao_assunto",
                schema: "saj_dsg");

            migrationBuilder.DropTable(
                name: "regra_distribuicao_classe",
                schema: "saj_dsg");

            migrationBuilder.DropTable(
                name: "regra_distribuicao_orgao",
                schema: "saj_dsg");

            migrationBuilder.DropTable(
                name: "regra_distribuicao_tarja",
                schema: "saj_dsg");

            migrationBuilder.DropTable(
                name: "regra_distribuicao_unidade",
                schema: "saj_dsg");

            migrationBuilder.DropTable(
                name: "regra_distribuicao",
                schema: "saj_dsg");
        }
    }
}
