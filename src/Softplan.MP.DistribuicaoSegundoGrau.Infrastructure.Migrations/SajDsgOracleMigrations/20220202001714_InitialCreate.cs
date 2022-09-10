using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.SajDsgOracleMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SAJDSG");

            migrationBuilder.CreateTable(
                name: "ANALISE_PROCESSO",
                schema: "SAJDSG",
                columns: table => new
                {
                    PROCESSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    VAGA_ID = table.Column<int>(nullable: true),
                    MOTIVO = table.Column<string>(maxLength: 2000, nullable: true),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(maxLength: 2000, nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(maxLength: 2000, nullable: true),
                    TIPO_DISTRIBUICAO = table.Column<int>(nullable: false),
                    AREA_ATUACAO_ID = table.Column<long>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => x.PROCESSO_ID);
                });

            migrationBuilder.CreateTable(
                name: "DISTRIBUICAO_PROCESSO",
                schema: "SAJDSG",
                columns: table => new
                {
                    DISTRIBUICAO_ID = table.Column<long>(nullable: false),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(maxLength: 2000, nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(maxLength: 2000, nullable: true),
                    PROCESSO_ID = table.Column<string>(maxLength: 200, nullable: true),
                    VAGA_ID = table.Column<int>(nullable: true),
                    MOTIVO = table.Column<string>(maxLength: 2000, nullable: true),
                    TIPODISTRIBUICAO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => x.DISTRIBUICAO_ID);
                });

            migrationBuilder.CreateTable(
                name: "EXCECAO_VAGA",
                schema: "SAJDSG",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(maxLength: 2000, nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(maxLength: 2000, nullable: true),
                    VAGA_ID = table.Column<int>(nullable: false),
                    CLASSE_ID = table.Column<int>(nullable: true),
                    ASSUNTO_ID = table.Column<int>(nullable: true),
                    ESPECIALIDADE_ID = table.Column<int>(nullable: true),
                    ORIGEM_ID = table.Column<int>(nullable: true),
                    UNIDADE_ID = table.Column<int>(nullable: true),
                    ORGAO_JULGADOR_ID = table.Column<int>(nullable: true),
                    MOTIVO = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IMPEDIMENTO_DISTRIBUICAO_LOG",
                schema: "SAJDSG",
                columns: table => new
                {
                    LOG_ID = table.Column<long>(nullable: false),
                    PROCESSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    TRANSACTION_ID = table.Column<Guid>(nullable: false),
                    TIPO_DISTRIBUICAO = table.Column<int>(nullable: false),
                    PAYLOAD_TYPE = table.Column<string>(maxLength: 200, nullable: true),
                    PAYLOAD_SRLZTION_TYPE = table.Column<int>(nullable: false),
                    PAYLOAD = table.Column<byte[]>(nullable: true),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(maxLength: 2000, nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => x.LOG_ID);
                });

            migrationBuilder.CreateTable(
                name: "JOBS",
                schema: "SAJDSG",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 200, nullable: true),
                    ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    PAYLOAD = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "REGRA_DISTRIBUICAO",
                schema: "SAJDSG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(maxLength: 2000, nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(maxLength: 2000, nullable: true),
                    TIPO_PROCESSO = table.Column<int>(nullable: true),
                    AREA = table.Column<int>(nullable: true),
                    VARIAVEL_EQUILIBRIO = table.Column<int>(nullable: false),
                    ESCOPO_EQUILIBRIO = table.Column<int>(nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 120, nullable: true),
                    ATIVO = table.Column<bool>(nullable: false),
                    CdLocal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VAGA",
                schema: "SAJDSG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    ORGAO_ID = table.Column<int>(nullable: true),
                    TIPO_ORGAO_ID = table.Column<int>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    INSTALACAO_ID = table.Column<int>(nullable: false),
                    PROCURADOR_TITULAR_ID = table.Column<string>(maxLength: 120, nullable: true),
                    DESCRICAO = table.Column<string>(maxLength: 120, nullable: true),
                    AREA = table.Column<int>(nullable: false),
                    ATIVA = table.Column<bool>(nullable: false),
                    REU_PRESO = table.Column<bool>(nullable: false),
                    DISTRIBUICAO_MESMA_VAGA = table.Column<bool>(nullable: false),
                    CONFIGURACOES_PREVENCAO = table.Column<bool>(nullable: false),
                    DISTRIBUICOES = table.Column<int>(nullable: false),
                    COMPENSACAO = table.Column<int>(nullable: false),
                    MOTIVO = table.Column<string>(maxLength: 2000, nullable: true),
                    DISTRIBUICAO_POR_VOLUME = table.Column<int>(nullable: false),
                    COMPENSACAO_POR_VOLUME = table.Column<int>(nullable: false),
                    CDLOCAL = table.Column<int>(nullable: false),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(maxLength: 2000, nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAGA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DISTRIBUICAO_PROCESSO_LOG",
                schema: "SAJDSG",
                columns: table => new
                {
                    LOG_ID = table.Column<long>(nullable: false),
                    PROCESSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    TRANSACTION_ID = table.Column<Guid>(nullable: false),
                    PAYLOAD_TYPE = table.Column<string>(maxLength: 200, nullable: true),
                    DISTRIBUICAO_ID = table.Column<long>(nullable: false),
                    PAYLOAD_SERIALIZATION_TYPE = table.Column<int>(nullable: false),
                    PAYLOAD = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => x.LOG_ID);
                    table.ForeignKey(
                        name: "FK_ID_LOGS_DIST",
                        column: x => x.DISTRIBUICAO_ID,
                        principalSchema: "SAJDSG",
                        principalTable: "DISTRIBUICAO_PROCESSO",
                        principalColumn: "DISTRIBUICAO_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REGRA_DISTRIBUICAO_ASSUNTO",
                schema: "SAJDSG",
                columns: table => new
                {
                    REGRA_DISTRIBUICAO_ID = table.Column<int>(nullable: false),
                    ASSUNTO_ID = table.Column<long>(nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_REGRA_DIST_ASTO", x => new { x.REGRA_DISTRIBUICAO_ID, x.ASSUNTO_ID });
                    table.ForeignKey(
                        name: "FK_ID_REGRA_DIST_ASSUNTO",
                        column: x => x.REGRA_DISTRIBUICAO_ID,
                        principalSchema: "SAJDSG",
                        principalTable: "REGRA_DISTRIBUICAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REGRA_DISTRIBUICAO_CLASSE",
                schema: "SAJDSG",
                columns: table => new
                {
                    REGRA_DISTRIBUICAO_ID = table.Column<int>(nullable: false),
                    CLASSE_ID = table.Column<long>(nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => new { x.REGRA_DISTRIBUICAO_ID, x.CLASSE_ID });
                    table.ForeignKey(
                        name: "FK_ID_REGRA_DIST_CLASSE",
                        column: x => x.REGRA_DISTRIBUICAO_ID,
                        principalSchema: "SAJDSG",
                        principalTable: "REGRA_DISTRIBUICAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REGRA_DISTRIBUICAO_ESPEC",
                schema: "SAJDSG",
                columns: table => new
                {
                    REGRA_DISTRIBUICAO_ID = table.Column<int>(nullable: false),
                    ESPECIALIDADE_ID = table.Column<long>(nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => new { x.REGRA_DISTRIBUICAO_ID, x.ESPECIALIDADE_ID });
                    table.ForeignKey(
                        name: "FK_ID_REGRA_DIST_ESPEC",
                        column: x => x.REGRA_DISTRIBUICAO_ID,
                        principalSchema: "SAJDSG",
                        principalTable: "REGRA_DISTRIBUICAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REGRA_DISTRIBUICAO_ORGAO",
                schema: "SAJDSG",
                columns: table => new
                {
                    REGRA_DISTRIBUICAO_ID = table.Column<int>(nullable: false),
                    ORGAO_JULGADOR_ID = table.Column<long>(nullable: false),
                    ORIGEM_ID = table.Column<int>(nullable: false),
                    UNIDADE_ID = table.Column<long>(nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => new { x.REGRA_DISTRIBUICAO_ID, x.ORGAO_JULGADOR_ID });
                    table.ForeignKey(
                        name: "FK_ID_REGRA_DIST_ORG_JUL",
                        column: x => x.REGRA_DISTRIBUICAO_ID,
                        principalSchema: "SAJDSG",
                        principalTable: "REGRA_DISTRIBUICAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REGRA_DISTRIBUICAO_TARJA",
                schema: "SAJDSG",
                columns: table => new
                {
                    REGRA_DISTRIBUICAO_ID = table.Column<int>(nullable: false),
                    TARJA_ID = table.Column<long>(nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => new { x.REGRA_DISTRIBUICAO_ID, x.TARJA_ID });
                    table.ForeignKey(
                        name: "FK_ID_REGRA_DIST_TARJA",
                        column: x => x.REGRA_DISTRIBUICAO_ID,
                        principalSchema: "SAJDSG",
                        principalTable: "REGRA_DISTRIBUICAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REGRA_DISTRIBUICAO_UNIDADE",
                schema: "SAJDSG",
                columns: table => new
                {
                    REGRA_DISTRIBUICAO_ID = table.Column<int>(nullable: false),
                    UNIDADE_ID = table.Column<long>(nullable: false),
                    ORIGEM_ID = table.Column<int>(nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => new { x.REGRA_DISTRIBUICAO_ID, x.UNIDADE_ID });
                    table.ForeignKey(
                        name: "FK_ID_REGRA_DIST_UNIDADE",
                        column: x => x.REGRA_DISTRIBUICAO_ID,
                        principalSchema: "SAJDSG",
                        principalTable: "REGRA_DISTRIBUICAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COMPENSACAO_LOG",
                schema: "SAJDSG",
                columns: table => new
                {
                    LOG_ID = table.Column<int>(nullable: false),
                    VAGA_ID = table.Column<int>(nullable: false),
                    MOTIVO = table.Column<string>(maxLength: 2000, nullable: true),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(maxLength: 2000, nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(maxLength: 2000, nullable: true),
                    VALOR = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => x.LOG_ID);
                    table.ForeignKey(
                        name: "FK_ID_VAGA_COMP_LOG",
                        column: x => x.VAGA_ID,
                        principalSchema: "SAJDSG",
                        principalTable: "VAGA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IMPEDIMENTO_PROCESSO",
                schema: "SAJDSG",
                columns: table => new
                {
                    PROCESSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    IMPEDIMENTO_ID = table.Column<int>(nullable: false),
                    VAGA_ID = table.Column<int>(nullable: false),
                    MOTIVO = table.Column<string>(maxLength: 2000, nullable: true),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(maxLength: 2000, nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => new { x.PROCESSO_ID, x.IMPEDIMENTO_ID });
                    table.ForeignKey(
                        name: "FK_ID_VAGA_IMP",
                        column: x => x.VAGA_ID,
                        principalSchema: "SAJDSG",
                        principalTable: "VAGA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MEMBRO_VAGA",
                schema: "SAJDSG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    ID_VAGA = table.Column<int>(nullable: false),
                    ID_MOTIVO_MEMBRO_VAGA = table.Column<int>(nullable: false),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(maxLength: 2000, nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(maxLength: 2000, nullable: true),
                    OBSERVACAO = table.Column<string>(maxLength: 2000, nullable: true),
                    ID_MEMBRO = table.Column<string>(maxLength: 120, nullable: true),
                    DATA_INICIAL = table.Column<DateTimeOffset>(nullable: false),
                    DATA_FINAL = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => new { x.ID, x.ID_VAGA });
                    table.ForeignKey(
                        name: "FK_ID_MEMBRO_VAGA",
                        column: x => x.ID_VAGA,
                        principalSchema: "SAJDSG",
                        principalTable: "VAGA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VAGA_REGRA_DISTRIBUICAO",
                schema: "SAJDSG",
                columns: table => new
                {
                    ID_VAGA = table.Column<int>(nullable: false),
                    ID_REGRADISTRIBUICAO = table.Column<int>(nullable: false),
                    METADATA_UUID = table.Column<Guid>(nullable: true),
                    METADATA_ROW_VERSION = table.Column<byte[]>(rowVersion: true, nullable: true),
                    METADATA_DATA_INCLUSAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_DATA_ATUALIZACAO = table.Column<DateTimeOffset>(nullable: true),
                    METADATA_USUARIO_INCLUSAO = table.Column<string>(maxLength: 2000, nullable: true),
                    METADATA_USUARIO_ATUALIZACAO = table.Column<string>(maxLength: 2000, nullable: true),
                    DISTRIBUICAO_POR_VOLUME = table.Column<int>(nullable: false),
                    COMPENSACAO_POR_VOLUME = table.Column<int>(nullable: false),
                    DISTRIBUICAO_POR_PROCESSO = table.Column<int>(nullable: false),
                    COMPENSACAO_POR_PROCESSO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => new { x.ID_VAGA, x.ID_REGRADISTRIBUICAO });
                    table.ForeignKey(
                        name: "FK_ID_REGRA_DISTRIBUICAO",
                        column: x => x.ID_REGRADISTRIBUICAO,
                        principalSchema: "SAJDSG",
                        principalTable: "REGRA_DISTRIBUICAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ID_VAGA_REGRA",
                        column: x => x.ID_VAGA,
                        principalSchema: "SAJDSG",
                        principalTable: "VAGA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ANALISE_PROCESSO_METADATA_UUID",
                schema: "SAJDSG",
                table: "ANALISE_PROCESSO",
                column: "METADATA_UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COMPENSACAO_LOG_VAGA_ID",
                schema: "SAJDSG",
                table: "COMPENSACAO_LOG",
                column: "VAGA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COMPENSACAO_LOG_METADATA_UUID",
                schema: "SAJDSG",
                table: "COMPENSACAO_LOG",
                column: "METADATA_UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DISTRIBUICAO_PROCESSO_METADATA_UUID",
                schema: "SAJDSG",
                table: "DISTRIBUICAO_PROCESSO",
                column: "METADATA_UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DISTRIBUICAO_PROCESSO_LOG_DISTRIBUICAO_ID",
                schema: "SAJDSG",
                table: "DISTRIBUICAO_PROCESSO_LOG",
                column: "DISTRIBUICAO_ID");

            migrationBuilder.CreateIndex(
                name: "DIST_PROC_LOG_ID",
                schema: "SAJDSG",
                table: "DISTRIBUICAO_PROCESSO_LOG",
                column: "PROCESSO_ID")
                .Annotation("Relational:Name", "DIST_PROC_LOG_ID");

            migrationBuilder.CreateIndex(
                name: "DIST_PROC_LOG_ID_TRANSC",
                schema: "SAJDSG",
                table: "DISTRIBUICAO_PROCESSO_LOG",
                columns: new[] { "PROCESSO_ID", "TRANSACTION_ID" })
                .Annotation("Relational:Name", "DIST_PROC_LOG_ID_TRANSC");

            migrationBuilder.CreateIndex(
                name: "IX_EXCECAO_VAGA_METADATA_UUID",
                schema: "SAJDSG",
                table: "EXCECAO_VAGA",
                column: "METADATA_UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IMP_DIST_LOG_ID_PROC",
                schema: "SAJDSG",
                table: "IMPEDIMENTO_DISTRIBUICAO_LOG",
                column: "PROCESSO_ID")
                .Annotation("Relational:Name", "IMP_DIST_LOG_ID_PROC");

            migrationBuilder.CreateIndex(
                name: "IMP_DIST_LOG_ID_TRANSC",
                schema: "SAJDSG",
                table: "IMPEDIMENTO_DISTRIBUICAO_LOG",
                columns: new[] { "PROCESSO_ID", "TRANSACTION_ID" })
                .Annotation("Relational:Name", "IMP_DIST_LOG_ID_TRANSC");

            migrationBuilder.CreateIndex(
                name: "IX_IMPEDIMENTO_DISTRIBUICAO_LOG_METADATA_UUID",
                schema: "SAJDSG",
                table: "IMPEDIMENTO_DISTRIBUICAO_LOG",
                column: "METADATA_UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IMPEDIMENTO_PROCESSO_VAGA_ID",
                schema: "SAJDSG",
                table: "IMPEDIMENTO_PROCESSO",
                column: "VAGA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_IMPEDIMENTO_PROCESSO_METADATA_UUID",
                schema: "SAJDSG",
                table: "IMPEDIMENTO_PROCESSO",
                column: "METADATA_UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MEMBRO_VAGA_ID_VAGA",
                schema: "SAJDSG",
                table: "MEMBRO_VAGA",
                column: "ID_VAGA");

            migrationBuilder.CreateIndex(
                name: "IX_MEMBRO_VAGA_METADATA_UUID",
                schema: "SAJDSG",
                table: "MEMBRO_VAGA",
                column: "METADATA_UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_REGRA_DISTRIBUICAO_METADATA_UUID",
                schema: "SAJDSG",
                table: "REGRA_DISTRIBUICAO",
                column: "METADATA_UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VAGA_METADATA_UUID",
                schema: "SAJDSG",
                table: "VAGA",
                column: "METADATA_UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VAGA_REGRA_DISTRIBUICAO_ID_REGRADISTRIBUICAO",
                schema: "SAJDSG",
                table: "VAGA_REGRA_DISTRIBUICAO",
                column: "ID_REGRADISTRIBUICAO");

            migrationBuilder.CreateIndex(
                name: "IX_VAGA_REGRA_DISTRIBUICAO_METADATA_UUID",
                schema: "SAJDSG",
                table: "VAGA_REGRA_DISTRIBUICAO",
                column: "METADATA_UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ANALISE_PROCESSO",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "COMPENSACAO_LOG",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "DISTRIBUICAO_PROCESSO_LOG",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "EXCECAO_VAGA",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "IMPEDIMENTO_DISTRIBUICAO_LOG",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "IMPEDIMENTO_PROCESSO",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "JOBS",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "MEMBRO_VAGA",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "REGRA_DISTRIBUICAO_ASSUNTO",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "REGRA_DISTRIBUICAO_CLASSE",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "REGRA_DISTRIBUICAO_ESPEC",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "REGRA_DISTRIBUICAO_ORGAO",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "REGRA_DISTRIBUICAO_TARJA",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "REGRA_DISTRIBUICAO_UNIDADE",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "VAGA_REGRA_DISTRIBUICAO",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "DISTRIBUICAO_PROCESSO",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "REGRA_DISTRIBUICAO",
                schema: "SAJDSG");

            migrationBuilder.DropTable(
                name: "VAGA",
                schema: "SAJDSG");
        }
    }
}
