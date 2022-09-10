using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.SajDsgPostgreSqlMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sajdsg");

            migrationBuilder.CreateTable(
                name: "analise_processo",
                schema: "sajdsg",
                columns: table => new
                {
                    processo_id = table.Column<string>(maxLength: 200, nullable: false),
                    vaga_id = table.Column<int>(nullable: true),
                    motivo = table.Column<string>(maxLength: 2000, nullable: true),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(maxLength: 2000, nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(maxLength: 2000, nullable: true),
                    tipo_distribuicao = table.Column<int>(nullable: false),
                    area_atuacao_id = table.Column<long>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_anal_proc", x => x.processo_id);
                });

            migrationBuilder.CreateTable(
                name: "distribuicao_processo",
                schema: "sajdsg",
                columns: table => new
                {
                    distribuicao_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(maxLength: 2000, nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(maxLength: 2000, nullable: true),
                    processo_id = table.Column<string>(maxLength: 200, nullable: true),
                    vaga_id = table.Column<int>(nullable: true),
                    motivo = table.Column<string>(maxLength: 2000, nullable: true),
                    tipodistribuicao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_dist_proc", x => x.distribuicao_id);
                });

            migrationBuilder.CreateTable(
                name: "excecao_vaga",
                schema: "sajdsg",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(maxLength: 2000, nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(maxLength: 2000, nullable: true),
                    vaga_id = table.Column<int>(nullable: false),
                    classe_id = table.Column<int>(nullable: true),
                    assunto_id = table.Column<int>(nullable: true),
                    especialidade_id = table.Column<int>(nullable: true),
                    origem_id = table.Column<int>(nullable: true),
                    unidade_id = table.Column<int>(nullable: true),
                    orgao_julgador_id = table.Column<int>(nullable: true),
                    motivo = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_exc_vaga", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "impedimento_distribuicao_log",
                schema: "sajdsg",
                columns: table => new
                {
                    log_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    processo_id = table.Column<string>(maxLength: 200, nullable: false),
                    transaction_id = table.Column<Guid>(nullable: false),
                    tipo_distribuicao = table.Column<int>(nullable: false),
                    payload_type = table.Column<string>(maxLength: 200, nullable: true),
                    payload_srlztion_type = table.Column<int>(nullable: false),
                    payload = table.Column<byte[]>(nullable: true),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(maxLength: 2000, nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_imp_dist_log", x => x.log_id);
                });

            migrationBuilder.CreateTable(
                name: "jobs",
                schema: "sajdsg",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    descricao = table.Column<string>(maxLength: 200, nullable: true),
                    row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    payload = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_jobs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "regra_distribuicao",
                schema: "sajdsg",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(maxLength: 2000, nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(maxLength: 2000, nullable: true),
                    tipo_processo = table.Column<int>(nullable: true),
                    area = table.Column<int>(nullable: true),
                    variavel_equilibrio = table.Column<int>(nullable: false),
                    escopo_equilibrio = table.Column<int>(nullable: false),
                    descricao = table.Column<string>(maxLength: 120, nullable: true),
                    ativo = table.Column<bool>(nullable: false),
                    cdlocal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_regra_dist", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vaga",
                schema: "sajdsg",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orgao_id = table.Column<int>(nullable: true),
                    tipo_orgao_id = table.Column<int>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    instalacao_id = table.Column<int>(nullable: false),
                    procurador_titular_id = table.Column<string>(maxLength: 120, nullable: true),
                    descricao = table.Column<string>(maxLength: 120, nullable: true),
                    area = table.Column<int>(nullable: false),
                    ativa = table.Column<bool>(nullable: false),
                    reu_preso = table.Column<bool>(nullable: false),
                    distribuicao_mesma_vaga = table.Column<bool>(nullable: false),
                    configuracoes_prevencao = table.Column<bool>(nullable: false),
                    distribuicoes = table.Column<int>(nullable: false),
                    compensacao = table.Column<int>(nullable: false),
                    motivo = table.Column<string>(maxLength: 2000, nullable: true),
                    distribuicao_por_volume = table.Column<int>(nullable: false),
                    compensacao_por_volume = table.Column<int>(nullable: false),
                    cdlocal = table.Column<int>(nullable: false),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(maxLength: 2000, nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vaga", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "distribuicao_processo_log",
                schema: "sajdsg",
                columns: table => new
                {
                    log_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    processo_id = table.Column<string>(maxLength: 200, nullable: false),
                    transaction_id = table.Column<Guid>(nullable: false),
                    payload_type = table.Column<string>(maxLength: 200, nullable: true),
                    distribuicao_id = table.Column<long>(nullable: false),
                    payload_serialization_type = table.Column<int>(nullable: false),
                    payload = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_dist_proc_log", x => x.log_id);
                    table.ForeignKey(
                        name: "fk_id_logs_dist",
                        column: x => x.distribuicao_id,
                        principalSchema: "sajdsg",
                        principalTable: "distribuicao_processo",
                        principalColumn: "distribuicao_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "regra_distribuicao_assunto",
                schema: "sajdsg",
                columns: table => new
                {
                    regra_distribuicao_id = table.Column<int>(nullable: false),
                    assunto_id = table.Column<long>(nullable: false),
                    descricao = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_regra_dist_asto", x => new { x.regra_distribuicao_id, x.assunto_id });
                    table.ForeignKey(
                        name: "fk_id_regra_dist_assunto",
                        column: x => x.regra_distribuicao_id,
                        principalSchema: "sajdsg",
                        principalTable: "regra_distribuicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "regra_distribuicao_classe",
                schema: "sajdsg",
                columns: table => new
                {
                    regra_distribuicao_id = table.Column<int>(nullable: false),
                    classe_id = table.Column<long>(nullable: false),
                    descricao = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_regra_dist_clas", x => new { x.regra_distribuicao_id, x.classe_id });
                    table.ForeignKey(
                        name: "fk_id_regra_dist_classe",
                        column: x => x.regra_distribuicao_id,
                        principalSchema: "sajdsg",
                        principalTable: "regra_distribuicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "regra_distribuicao_espec",
                schema: "sajdsg",
                columns: table => new
                {
                    regra_distribuicao_id = table.Column<int>(nullable: false),
                    especialidade_id = table.Column<long>(nullable: false),
                    descricao = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_regra_dist_espec", x => new { x.regra_distribuicao_id, x.especialidade_id });
                    table.ForeignKey(
                        name: "fk_id_regra_dist_espec",
                        column: x => x.regra_distribuicao_id,
                        principalSchema: "sajdsg",
                        principalTable: "regra_distribuicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "regra_distribuicao_orgao",
                schema: "sajdsg",
                columns: table => new
                {
                    regra_distribuicao_id = table.Column<int>(nullable: false),
                    orgao_julgador_id = table.Column<long>(nullable: false),
                    origem_id = table.Column<int>(nullable: false),
                    unidade_id = table.Column<long>(nullable: false),
                    descricao = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_regra_dist_org", x => new { x.regra_distribuicao_id, x.orgao_julgador_id });
                    table.ForeignKey(
                        name: "fk_id_regra_dist_org_jul",
                        column: x => x.regra_distribuicao_id,
                        principalSchema: "sajdsg",
                        principalTable: "regra_distribuicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "regra_distribuicao_tarja",
                schema: "sajdsg",
                columns: table => new
                {
                    regra_distribuicao_id = table.Column<int>(nullable: false),
                    tarja_id = table.Column<long>(nullable: false),
                    descricao = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_regra_dist_tarja", x => new { x.regra_distribuicao_id, x.tarja_id });
                    table.ForeignKey(
                        name: "fk_id_regra_dist_tarja",
                        column: x => x.regra_distribuicao_id,
                        principalSchema: "sajdsg",
                        principalTable: "regra_distribuicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "regra_distribuicao_unidade",
                schema: "sajdsg",
                columns: table => new
                {
                    regra_distribuicao_id = table.Column<int>(nullable: false),
                    unidade_id = table.Column<long>(nullable: false),
                    origem_id = table.Column<int>(nullable: false),
                    descricao = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_regra_dist_unid", x => new { x.regra_distribuicao_id, x.unidade_id });
                    table.ForeignKey(
                        name: "fk_id_regra_dist_unidade",
                        column: x => x.regra_distribuicao_id,
                        principalSchema: "sajdsg",
                        principalTable: "regra_distribuicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "compensacao_log",
                schema: "sajdsg",
                columns: table => new
                {
                    log_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vaga_id = table.Column<int>(nullable: false),
                    motivo = table.Column<string>(maxLength: 2000, nullable: true),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(maxLength: 2000, nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(maxLength: 2000, nullable: true),
                    valor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_comp_log", x => x.log_id);
                    table.ForeignKey(
                        name: "fk_id_vaga_comp_log",
                        column: x => x.vaga_id,
                        principalSchema: "sajdsg",
                        principalTable: "vaga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "impedimento_processo",
                schema: "sajdsg",
                columns: table => new
                {
                    processo_id = table.Column<string>(maxLength: 200, nullable: false),
                    impedimento_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vaga_id = table.Column<int>(nullable: false),
                    motivo = table.Column<string>(maxLength: 2000, nullable: true),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(maxLength: 2000, nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_imp_proc", x => new { x.processo_id, x.impedimento_id });
                    table.ForeignKey(
                        name: "fk_id_vaga_imp",
                        column: x => x.vaga_id,
                        principalSchema: "sajdsg",
                        principalTable: "vaga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "membro_vaga",
                schema: "sajdsg",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_vaga = table.Column<int>(nullable: false),
                    id_motivo_membro_vaga = table.Column<int>(nullable: false),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(maxLength: 2000, nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(maxLength: 2000, nullable: true),
                    observacao = table.Column<string>(maxLength: 2000, nullable: true),
                    id_membro = table.Column<string>(maxLength: 120, nullable: true),
                    data_inicial = table.Column<DateTimeOffset>(nullable: false),
                    data_final = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_membro_vaga", x => new { x.id, x.id_vaga });
                    table.ForeignKey(
                        name: "fk_id_membro_vaga",
                        column: x => x.id_vaga,
                        principalSchema: "sajdsg",
                        principalTable: "vaga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vaga_regra_distribuicao",
                schema: "sajdsg",
                columns: table => new
                {
                    id_vaga = table.Column<int>(nullable: false),
                    id_regradistribuicao = table.Column<int>(nullable: false),
                    metadata_uuid = table.Column<Guid>(nullable: true),
                    metadata_row_version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    metadata_data_inclusao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_data_atualizacao = table.Column<DateTimeOffset>(nullable: true),
                    metadata_usuario_inclusao = table.Column<string>(maxLength: 2000, nullable: true),
                    metadata_usuario_atualizacao = table.Column<string>(maxLength: 2000, nullable: true),
                    distribuicao_por_volume = table.Column<int>(nullable: false),
                    compensacao_por_volume = table.Column<int>(nullable: false),
                    distribuicao_por_processo = table.Column<int>(nullable: false),
                    compensacao_por_processo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_vaga_regra_dist", x => new { x.id_vaga, x.id_regradistribuicao });
                    table.ForeignKey(
                        name: "fk_id_regra_distribuicao",
                        column: x => x.id_regradistribuicao,
                        principalSchema: "sajdsg",
                        principalTable: "regra_distribuicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_id_vaga_regra",
                        column: x => x.id_vaga,
                        principalSchema: "sajdsg",
                        principalTable: "vaga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_analise_processo_metadata_uuid",
                schema: "sajdsg",
                table: "analise_processo",
                column: "metadata_uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_compensacao_log_vaga_id",
                schema: "sajdsg",
                table: "compensacao_log",
                column: "vaga_id");

            migrationBuilder.CreateIndex(
                name: "ix_compensacao_log_metadata_uuid",
                schema: "sajdsg",
                table: "compensacao_log",
                column: "metadata_uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_distribuicao_processo_metadata_uuid",
                schema: "sajdsg",
                table: "distribuicao_processo",
                column: "metadata_uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_distribuicao_processo_log_distribuicao_id",
                schema: "sajdsg",
                table: "distribuicao_processo_log",
                column: "distribuicao_id");

            migrationBuilder.CreateIndex(
                name: "dist_proc_log_id",
                schema: "sajdsg",
                table: "distribuicao_processo_log",
                column: "processo_id");

            migrationBuilder.CreateIndex(
                name: "dist_proc_log_id_transc",
                schema: "sajdsg",
                table: "distribuicao_processo_log",
                columns: new[] { "processo_id", "transaction_id" });

            migrationBuilder.CreateIndex(
                name: "ix_excecao_vaga_metadata_uuid",
                schema: "sajdsg",
                table: "excecao_vaga",
                column: "metadata_uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "imp_dist_log_id_proc",
                schema: "sajdsg",
                table: "impedimento_distribuicao_log",
                column: "processo_id");

            migrationBuilder.CreateIndex(
                name: "imp_dist_log_id_transc",
                schema: "sajdsg",
                table: "impedimento_distribuicao_log",
                columns: new[] { "processo_id", "transaction_id" });

            migrationBuilder.CreateIndex(
                name: "ix_impedimento_distribuicao_log_metadata_uuid",
                schema: "sajdsg",
                table: "impedimento_distribuicao_log",
                column: "metadata_uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_impedimento_processo_vaga_id",
                schema: "sajdsg",
                table: "impedimento_processo",
                column: "vaga_id");

            migrationBuilder.CreateIndex(
                name: "ix_impedimento_processo_metadata_uuid",
                schema: "sajdsg",
                table: "impedimento_processo",
                column: "metadata_uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_membro_vaga_id_vaga",
                schema: "sajdsg",
                table: "membro_vaga",
                column: "id_vaga");

            migrationBuilder.CreateIndex(
                name: "ix_membro_vaga_metadata_uuid",
                schema: "sajdsg",
                table: "membro_vaga",
                column: "metadata_uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_regra_distribuicao_metadata_uuid",
                schema: "sajdsg",
                table: "regra_distribuicao",
                column: "metadata_uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vaga_metadata_uuid",
                schema: "sajdsg",
                table: "vaga",
                column: "metadata_uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vaga_regra_distribuicao_id_regradistribuicao",
                schema: "sajdsg",
                table: "vaga_regra_distribuicao",
                column: "id_regradistribuicao");

            migrationBuilder.CreateIndex(
                name: "ix_vaga_regra_distribuicao_metadata_uuid",
                schema: "sajdsg",
                table: "vaga_regra_distribuicao",
                column: "metadata_uuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "analise_processo",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "compensacao_log",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "distribuicao_processo_log",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "excecao_vaga",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "impedimento_distribuicao_log",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "impedimento_processo",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "jobs",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "membro_vaga",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "regra_distribuicao_assunto",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "regra_distribuicao_classe",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "regra_distribuicao_espec",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "regra_distribuicao_orgao",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "regra_distribuicao_tarja",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "regra_distribuicao_unidade",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "vaga_regra_distribuicao",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "distribuicao_processo",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "regra_distribuicao",
                schema: "sajdsg");

            migrationBuilder.DropTable(
                name: "vaga",
                schema: "sajdsg");
        }
    }
}
