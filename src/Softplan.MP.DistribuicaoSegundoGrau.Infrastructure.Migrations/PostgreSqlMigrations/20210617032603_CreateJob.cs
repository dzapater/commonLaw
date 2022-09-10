using System;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Jobs.Distribuicoes;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    public partial class CreateJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jobs",
                schema: "saj_dsg",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    descricao = table.Column<string>(maxLength: 200, nullable: true),
                    row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    payload = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_jobs", x => x.id);
                });
            
              migrationBuilder.InsertData(
                table: "jobs",
                columns: new string[] { "id", "descricao",  "payload" } ,
                values: new object[] { nameof(DistribuicaoVagaJob), nameof(DistribuicaoVagaJob), JsonConvert.SerializeObject(new DistVagaJobPayload())},
                schema:"saj_dsg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jobs",
                schema: "saj_dsg");
        }
    }
}
