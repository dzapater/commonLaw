﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    public partial class UpdateRegraDistEspecialidade_addFieldDescricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DESCRICAO",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_ESPEC",
                maxLength: 120,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DESCRICAO",
                schema: "SAJ_DSG",
                table: "REGRA_DISTRIBUICAO_ESPEC");
        }
    }
}
