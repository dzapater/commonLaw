using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Jobs.Distribuicoes;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class CreateJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JOBS",
                schema: "SAJ_DSG",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 200, nullable: true),
                    ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    PAYLOAD = table.Column<string>(maxLength: 200, nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOBS", x => x.ID);
                });
            
            migrationBuilder.InsertData(
                table: "JOBS",
                columns: new string[] { "ID", "DESCRICAO",  "PAYLOAD" } ,
                values: new object[] { nameof(DistribuicaoVagaJob), nameof(DistribuicaoVagaJob), JsonConvert.SerializeObject(new DistVagaJobPayload())},
                schema:"SAJ_DSG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JOBS",
                schema: "SAJ_DSG");
        }
    }
}
