using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_N1194527237",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO_LOG");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DISTRIBUICAO_PROCESSO",
                schema: "SAJ_DSG",
                table: "SAJ_DSG.DISTRIBUICAO_PROCESSO");

            migrationBuilder.CreateSequence(
                name: "DISTRIBUICAO_PROCESSO_ID_SEQ",
                schema: "SAJ_DSG",
                incrementBy: 1,
                startValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "PROCESSO_ID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO_LOG",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar2(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DISTRIBUICAO_ID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO_LOG",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "PROCESSO_ID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar2(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<long>(
                name: "DISTRIBUICAO_ID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.Sql(
                @"CREATE OR REPLACE TRIGGER SAJ_DSG.TRG_DISTRIBUICAO_ID
                      BEFORE INSERT ON SAJ_DSG.DISTRIBUICAO_PROCESSO
                      FOR EACH ROW
                        BEGIN
                          SELECT SAJ_DSG.DISTRIBUICAO_PROCESSO_ID_SEQ.NEXTVAL INTO :NEW.DISTRIBUICAO_ID FROM DUAL;
                        END;");

            migrationBuilder.AddColumn<int>(
                name: "VAGA_ID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MOTIVO",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TIPODISTRIBUICAO",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DISTRIBUICAO_PROCESSO",
                schema: "SAJ_DSG",
                table: "SAJ_DSG.DISTRIBUICAO_PROCESSO",
                column: "DISTRIBUICAO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DISTRIBUICAO_PROCESSO_LOG_DISTRIBUICAO_ID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO_LOG",
                column: "DISTRIBUICAO_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DISTRIBUICAO_PROCESSO_LOG_DISTRIBUICAO_PROCESSO_DISTRIBUICAO_ID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO_LOG",
                column: "DISTRIBUICAO_ID",
                principalSchema: "SAJ_DSG",
                principalTable: "DISTRIBUICAO_PROCESSO",
                principalColumn: "DISTRIBUICAO_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DISTRIBUICAO_PROCESSO_LOG_DISTRIBUICAO_PROCESSO_DISTRIBUICAO_ID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO_LOG");

            migrationBuilder.DropIndex(
                name: "IX_DISTRIBUICAO_PROCESSO_LOG_DISTRIBUICAO_ID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO_LOG");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DISTRIBUICAO_PROCESSO",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO");

            migrationBuilder.DropSequence(
                name: "DISTRIBUICAO_PROCESSO_ID_SEQ",
                schema: "SAJ_DSG");

            migrationBuilder.DropColumn(
                name: "DISTRIBUICAO_ID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO_LOG");

            migrationBuilder.DropColumn(
                name: "DISTRIBUICAO_ID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO");

            migrationBuilder.DropColumn(
                name: "VAGA_ID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO");

            migrationBuilder.DropColumn(
                name: "MOTIVO",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO");

            migrationBuilder.DropColumn(
                name: "TIPODISTRIBUICAO",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO");

            migrationBuilder.AlterColumn<string>(
                name: "PROCESSO_ID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO_LOG",
                type: "nvarchar2(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "PROCESSO_ID",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO",
                type: "nvarchar2(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DISTRIBUICAO_PROCESSO",
                schema: "SAJ_DSG",
                table: "SAJ_DSG.DISTRIBUICAO_PROCESSO",
                column: "PROCESSO_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_N1194527237",
                schema: "SAJ_DSG",
                table: "DISTRIBUICAO_PROCESSO_LOG",
                column: "PROCESSO_ID",
                principalSchema: "SAJ_DSG",
                principalTable: "DISTRIBUICAO_PROCESSO",
                principalColumn: "PROCESSO_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
