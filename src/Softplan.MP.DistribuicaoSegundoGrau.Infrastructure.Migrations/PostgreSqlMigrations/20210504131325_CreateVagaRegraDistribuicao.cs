using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class CreateVagaRegraDistribuicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vaga_regra_distribuicao",
                schema: "saj_dsg",
                columns: table => new
                {
                    id_vaga = table.Column<int>(nullable: false),
                    id_regradistribuicao = table.Column<int>(nullable: false),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vaga_regra_distribuicao", x => new { x.id_vaga, x.id_regradistribuicao });
                    table.ForeignKey(
                        name: "fk_vaga_regra_distribuicao_regra_distribuicao_id_regradistribu~",
                        column: x => x.id_regradistribuicao,
                        principalSchema: "saj_dsg",
                        principalTable: "regra_distribuicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vaga_regra_distribuicao_vaga_id_vaga",
                        column: x => x.id_vaga,
                        principalSchema: "saj_dsg",
                        principalTable: "vaga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_vaga_regra_distribuicao_id_regradistribuicao",
                schema: "saj_dsg",
                table: "vaga_regra_distribuicao",
                column: "id_regradistribuicao");

            migrationBuilder.CreateIndex(
                name: "ix_vaga_regra_distribuicao_metadata_uuid",
                schema: "saj_dsg",
                table: "vaga_regra_distribuicao",
                column: "metadata_uuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vaga_regra_distribuicao",
                schema: "saj_dsg");
        }
    }
}
