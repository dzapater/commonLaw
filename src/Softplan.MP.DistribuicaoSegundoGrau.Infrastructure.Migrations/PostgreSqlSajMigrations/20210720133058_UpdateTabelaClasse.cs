using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlSajMigrations
{
    public partial class UpdateTabelaClasse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_efmptjclasse",
                schema: "saj",
                table: "efmptjclasse");

            migrationBuilder.DropColumn(
                name: "cdorigem",
                schema: "saj",
                table: "efmptjclasse");

            migrationBuilder.RenameTable(
                name: "efmptjclasse",
                schema: "saj",
                newName: "esajclasse",
                newSchema: "saj");

            migrationBuilder.AlterColumn<long>(
                name: "cdvara",
                schema: "saj",
                table: "efmptjvara",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "cdforo",
                schema: "saj",
                table: "efmptjvara",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "cdforo",
                schema: "saj",
                table: "efmptjforo",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "desitoficiante",
                schema: "saj",
                table: "efmpsitoficiante",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "flsitoficiante",
                schema: "saj",
                table: "efmpsitoficiante",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "cdclasse",
                schema: "saj",
                table: "esajclasse",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "pk_esajclasse",
                schema: "saj",
                table: "esajclasse",
                column: "cdclasse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_esajclasse",
                schema: "saj",
                table: "esajclasse");

            migrationBuilder.RenameTable(
                name: "esajclasse",
                schema: "saj",
                newName: "efmptjclasse",
                newSchema: "saj");

            migrationBuilder.AlterColumn<int>(
                name: "cdvara",
                schema: "saj",
                table: "efmptjvara",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "cdforo",
                schema: "saj",
                table: "efmptjvara",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "cdforo",
                schema: "saj",
                table: "efmptjforo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "desitoficiante",
                schema: "saj",
                table: "efmpsitoficiante",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "flsitoficiante",
                schema: "saj",
                table: "efmpsitoficiante",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "cdclasse",
                schema: "saj",
                table: "efmptjclasse",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "cdorigem",
                schema: "saj",
                table: "efmptjclasse",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_efmptjclasse",
                schema: "saj",
                table: "efmptjclasse",
                columns: new[] { "cdorigem", "cdclasse" });
        }
    }
}
