using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class CreateCompensacaoLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TIPO_ORGAO_ID",
                schema: "SAJ_DSG",
                table: "VAGA",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ORGAO_ID",
                schema: "SAJ_DSG",
                table: "VAGA",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "COMPENSACAO_LOG",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    LOG_ID = table.Column<int>(nullable: false),
                    VAGA_ID = table.Column<int>(nullable: false),
                    MOTIVO = table.Column<string>(maxLength: 2000, nullable: true),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(nullable: true),
                    VALOR = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPENSACAO_LOG", x => x.LOG_ID);
                    table.ForeignKey(
                        name: "FK_COMPENSACAO_LOG_VAGA_VAGA_ID",
                        column: x => x.VAGA_ID,
                        principalSchema: "SAJ_DSG",
                        principalTable: "VAGA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COMPENSACAO_LOG_VAGA_ID",
                schema: "SAJ_DSG",
                table: "COMPENSACAO_LOG",
                column: "VAGA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COMPENSACAO_LOG_METADATA_UUID",
                schema: "SAJ_DSG",
                table: "COMPENSACAO_LOG",
                column: "METADATA_UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMPENSACAO_LOG",
                schema: "SAJ_DSG");

            migrationBuilder.AlterColumn<int>(
                name: "TIPO_ORGAO_ID",
                schema: "SAJ_DSG",
                table: "VAGA",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ORGAO_ID",
                schema: "SAJ_DSG",
                table: "VAGA",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
