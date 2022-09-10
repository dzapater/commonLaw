﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    [DbContext(typeof(PostgreSqlMigrationsDbContext))]
    [Migration("20210519210319_IdEspecialidade")]
    partial class IdEspecialidade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("saj_dsg")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Area")
                        .HasColumnName("area")
                        .HasColumnType("integer");

                    b.Property<bool>("Ativo")
                        .HasColumnName("ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Descricao")
                        .HasColumnName("descricao")
                        .HasColumnType("character varying(120)")
                        .HasMaxLength(120);

                    b.Property<int>("EscopoEquilibrio")
                        .HasColumnName("escopo_equilibrio")
                        .HasColumnType("integer");

                    b.Property<int?>("IdEspecialidade")
                        .HasColumnName("especialidade_id")
                        .HasColumnType("integer");

                    b.Property<int>("TipoProcesso")
                        .HasColumnName("tipo_processo")
                        .HasColumnType("integer");

                    b.Property<int>("VariavelEquilibrio")
                        .HasColumnName("variavel_equilibrio")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_regra_distribuicao");

                    b.ToTable("regra_distribuicao");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoAssunto", b =>
                {
                    b.Property<int>("IdRegraDistribuicao")
                        .HasColumnName("regra_distribuicao_id")
                        .HasColumnType("integer");

                    b.Property<int>("IdAssunto")
                        .HasColumnName("assunto_id")
                        .HasColumnType("integer");

                    b.HasKey("IdRegraDistribuicao", "IdAssunto")
                        .HasName("pk_regra_distribuicao_assunto");

                    b.ToTable("regra_distribuicao_assunto");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoClasse", b =>
                {
                    b.Property<int>("IdRegraDistribuicao")
                        .HasColumnName("regra_distribuicao_id")
                        .HasColumnType("integer");

                    b.Property<int>("IdClasse")
                        .HasColumnName("classe_id")
                        .HasColumnType("integer");

                    b.Property<int>("IdOrigem")
                        .HasColumnName("origem_id")
                        .HasColumnType("integer");

                    b.HasKey("IdRegraDistribuicao", "IdClasse")
                        .HasName("pk_regra_distribuicao_classe");

                    b.ToTable("regra_distribuicao_classe");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoOrgaoJulgador", b =>
                {
                    b.Property<int>("IdRegraDistribuicao")
                        .HasColumnName("regra_distribuicao_id")
                        .HasColumnType("integer");

                    b.Property<int>("IdOrgaoJulgador")
                        .HasColumnName("orgao_julgador_id")
                        .HasColumnType("integer");

                    b.Property<int>("IdOrigem")
                        .HasColumnName("origem_id")
                        .HasColumnType("integer");

                    b.HasKey("IdRegraDistribuicao", "IdOrgaoJulgador")
                        .HasName("pk_regra_distribuicao_orgao");

                    b.ToTable("regra_distribuicao_orgao");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoTarja", b =>
                {
                    b.Property<int>("IdRegraDistribuicao")
                        .HasColumnName("regra_distribuicao_id")
                        .HasColumnType("integer");

                    b.Property<int>("IdTarja")
                        .HasColumnName("tarja_id")
                        .HasColumnType("integer");

                    b.HasKey("IdRegraDistribuicao", "IdTarja")
                        .HasName("pk_regra_distribuicao_tarja");

                    b.ToTable("regra_distribuicao_tarja");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoUnidade", b =>
                {
                    b.Property<int>("IdRegraDistribuicao")
                        .HasColumnName("regra_distribuicao_id")
                        .HasColumnType("integer");

                    b.Property<int>("IdUnidade")
                        .HasColumnName("unidade_id")
                        .HasColumnType("integer");

                    b.Property<int>("IdOrgaoJulgador")
                        .HasColumnName("orgao_julgador_id")
                        .HasColumnType("integer");

                    b.Property<int>("IdOrigem")
                        .HasColumnName("origem_id")
                        .HasColumnType("integer");

                    b.HasKey("IdRegraDistribuicao", "IdUnidade")
                        .HasName("pk_regra_distribuicao_unidade");

                    b.ToTable("regra_distribuicao_unidade");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas.Vaga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Area")
                        .HasColumnName("area")
                        .HasColumnType("integer");

                    b.Property<bool>("ConsiderarConfiguracoesPrevencao")
                        .HasColumnName("configuracoes_prevencao")
                        .HasColumnType("boolean");

                    b.Property<string>("Descricao")
                        .HasColumnName("descricao")
                        .HasColumnType("character varying(120)")
                        .HasMaxLength(120);

                    b.Property<bool>("EstaAtiva")
                        .HasColumnName("ativa")
                        .HasColumnType("boolean");

                    b.Property<long>("IdInstalacao")
                        .HasColumnName("instalacao_id")
                        .HasColumnType("bigint");

                    b.Property<long>("IdOrgao")
                        .HasColumnName("orgao_id")
                        .HasColumnType("bigint");

                    b.Property<long>("IdProcuradorTitular")
                        .HasColumnName("procurador_titular_id")
                        .HasColumnType("bigint");

                    b.Property<long>("IdTipoOrgao")
                        .HasColumnName("tipo_orgao_id")
                        .HasColumnType("bigint");

                    b.Property<bool>("PermiteDistribuicaoMesmaVaga")
                        .HasColumnName("distribuicao_mesma_vaga")
                        .HasColumnType("boolean");

                    b.Property<bool>("PermiteReuPreso")
                        .HasColumnName("reu_preso")
                        .HasColumnType("boolean");

                    b.HasKey("Id")
                        .HasName("pk_vaga");

                    b.ToTable("vaga");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao.VinculoVagaRegraDistribuicao", b =>
                {
                    b.Property<int>("IdVaga")
                        .HasColumnName("id_vaga")
                        .HasColumnType("integer");

                    b.Property<int>("IdRegraDistribuicao")
                        .HasColumnName("id_regradistribuicao")
                        .HasColumnType("integer");

                    b.HasKey("IdVaga", "IdRegraDistribuicao")
                        .HasName("pk_vaga_regra_distribuicao");

                    b.HasIndex("IdRegraDistribuicao")
                        .HasName("ix_vaga_regra_distribuicao_id_regradistribuicao");

                    b.ToTable("vaga_regra_distribuicao");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos.AnaliseProcesso", b =>
                {
                    b.Property<string>("IdProcesso")
                        .HasColumnName("processo_id")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<int>("Area")
                        .HasColumnName("area")
                        .HasColumnType("integer");

                    b.Property<int?>("IdVaga")
                        .HasColumnName("vaga_id")
                        .HasColumnType("integer");

                    b.Property<string>("Motivo")
                        .HasColumnName("motivo")
                        .HasColumnType("character varying(2000)")
                        .HasMaxLength(2000);

                    b.Property<int>("TipoDistribuicao")
                        .HasColumnName("tipo_distribuicao")
                        .HasColumnType("integer");

                    b.HasKey("IdProcesso")
                        .HasName("pk_analise_processo");

                    b.ToTable("analise_processo");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos.DistribuicaoProcesso", b =>
                {
                    b.Property<string>("IdProcesso")
                        .HasColumnName("processo_id")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("IdProcesso")
                        .HasName("pk_distribuicao_processo");

                    b.ToTable("distribuicao_processo");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos.DistribuicaoProcessoLog", b =>
                {
                    b.Property<string>("IdProcesso")
                        .HasColumnName("processo_id")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<long>("IdLog")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("log_id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("Payload")
                        .HasColumnName("payload")
                        .HasColumnType("bytea");

                    b.Property<int>("PayloadSerialization")
                        .HasColumnName("payload_serialization_type")
                        .HasColumnType("integer");

                    b.Property<string>("PayloadType")
                        .HasColumnName("payload_type")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<Guid>("TransactionId")
                        .HasColumnName("transaction_id")
                        .HasColumnType("uuid");

                    b.HasKey("IdProcesso", "IdLog")
                        .HasName("pk_distribuicao_processo_log");

                    b.HasIndex("IdProcesso")
                        .HasName("distribuicao_processo_log_processo");

                    b.HasIndex("IdProcesso", "TransactionId")
                        .HasName("distribuicao_processo_log_processo_transactionid");

                    b.ToTable("distribuicao_processo_log");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos.ImpedimentoProcesso", b =>
                {
                    b.Property<string>("IdProcesso")
                        .HasColumnName("processo_id")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<int>("IdImpedimento")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("impedimento_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IdVaga")
                        .HasColumnName("vaga_id")
                        .HasColumnType("integer");

                    b.Property<string>("Motivo")
                        .HasColumnName("motivo")
                        .HasColumnType("character varying(2000)")
                        .HasMaxLength(2000);

                    b.HasKey("IdProcesso", "IdImpedimento")
                        .HasName("pk_impedimento_processo");

                    b.HasIndex("IdVaga")
                        .HasName("ix_impedimento_processo_vaga_id");

                    b.ToTable("impedimento_processo");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicao", b =>
                {
                    b.OwnsOne("Softplan.Common.Core.Entities.EntityMetadata", "Metadata", b1 =>
                        {
                            b1.Property<int>("RegraDistribuicaoId")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("id")
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<DateTimeOffset>("DataAtualizacao")
                                .HasColumnName("metadata_data_atualizacao")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTimeOffset>("DataInclusao")
                                .HasColumnName("metadata_data_inclusao")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<byte[]>("RowVersion")
                                .IsConcurrencyToken()
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnName("metadata_row_version")
                                .HasColumnType("bytea");

                            b1.Property<string>("UsuarioAtualizacao")
                                .HasColumnName("metadata_usuario_atualizacao")
                                .HasColumnType("text");

                            b1.Property<string>("UsuarioInclusao")
                                .HasColumnName("metadata_usuario_inclusao")
                                .HasColumnType("text");

                            b1.Property<Guid>("Uuid")
                                .HasColumnName("metadata_uuid")
                                .HasColumnType("uuid");

                            b1.HasKey("RegraDistribuicaoId")
                                .HasName("pk_regra_distribuicao");

                            b1.HasIndex("Uuid")
                                .IsUnique()
                                .HasName("ix_regra_distribuicao_metadata_uuid");

                            b1.ToTable("regra_distribuicao");

                            b1.WithOwner()
                                .HasForeignKey("RegraDistribuicaoId")
                                .HasConstraintName("fk_regra_distribuicao_regra_distribuicao_id");
                        });
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoAssunto", b =>
                {
                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicao", null)
                        .WithMany("Assuntos")
                        .HasForeignKey("IdRegraDistribuicao")
                        .HasConstraintName("fk_regra_distribuicao_assunto_regra_distribuicao_regra_distrib~")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoClasse", b =>
                {
                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicao", null)
                        .WithMany("Classes")
                        .HasForeignKey("IdRegraDistribuicao")
                        .HasConstraintName("fk_regra_distribuicao_classe_regra_distribuicao_regra_distribu~")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoOrgaoJulgador", b =>
                {
                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicao", null)
                        .WithMany("OrgaosJulgadores")
                        .HasForeignKey("IdRegraDistribuicao")
                        .HasConstraintName("fk_regra_distribuicao_orgao_regra_distribuicao_regra_distribui~")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoTarja", b =>
                {
                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicao", null)
                        .WithMany("Tarjas")
                        .HasForeignKey("IdRegraDistribuicao")
                        .HasConstraintName("fk_regra_distribuicao_tarja_regra_distribuicao_regra_distribui~")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoUnidade", b =>
                {
                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicao", null)
                        .WithMany("Unidades")
                        .HasForeignKey("IdRegraDistribuicao")
                        .HasConstraintName("fk_regra_distribuicao_unidade_regra_distribuicao_regra_distrib~")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas.Vaga", b =>
                {
                    b.OwnsOne("Softplan.Common.Core.Entities.EntityMetadata", "Metadata", b1 =>
                        {
                            b1.Property<int>("VagaId")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("id")
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<DateTimeOffset>("DataAtualizacao")
                                .HasColumnName("metadata_data_atualizacao")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTimeOffset>("DataInclusao")
                                .HasColumnName("metadata_data_inclusao")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<byte[]>("RowVersion")
                                .IsConcurrencyToken()
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnName("metadata_row_version")
                                .HasColumnType("bytea");

                            b1.Property<string>("UsuarioAtualizacao")
                                .HasColumnName("metadata_usuario_atualizacao")
                                .HasColumnType("text");

                            b1.Property<string>("UsuarioInclusao")
                                .HasColumnName("metadata_usuario_inclusao")
                                .HasColumnType("text");

                            b1.Property<Guid>("Uuid")
                                .HasColumnName("metadata_uuid")
                                .HasColumnType("uuid");

                            b1.HasKey("VagaId")
                                .HasName("pk_vaga");

                            b1.HasIndex("Uuid")
                                .IsUnique()
                                .HasName("ix_vaga_metadata_uuid");

                            b1.ToTable("vaga");

                            b1.WithOwner()
                                .HasForeignKey("VagaId")
                                .HasConstraintName("fk_vaga_vaga_id");
                        });
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao.VinculoVagaRegraDistribuicao", b =>
                {
                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicao", "RegraDistribuicao")
                        .WithMany("VinculoVagas")
                        .HasForeignKey("IdRegraDistribuicao")
                        .HasConstraintName("fk_vaga_regra_distribuicao_regra_distribuicao_id_regradistribu~")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas.Vaga", "Vaga")
                        .WithMany()
                        .HasForeignKey("IdVaga")
                        .HasConstraintName("fk_vaga_regra_distribuicao_vaga_id_vaga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Softplan.Common.Core.Entities.EntityMetadata", "Metadata", b1 =>
                        {
                            b1.Property<int>("VinculoVagaRegraDistribuicaoIdVaga")
                                .HasColumnName("id_vaga")
                                .HasColumnType("integer");

                            b1.Property<int>("VinculoVagaRegraDistribuicaoIdRegraDistribuicao")
                                .HasColumnName("id_regradistribuicao")
                                .HasColumnType("integer");

                            b1.Property<DateTimeOffset>("DataAtualizacao")
                                .HasColumnName("metadata_data_atualizacao")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTimeOffset>("DataInclusao")
                                .HasColumnName("metadata_data_inclusao")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<byte[]>("RowVersion")
                                .IsConcurrencyToken()
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnName("metadata_row_version")
                                .HasColumnType("bytea");

                            b1.Property<string>("UsuarioAtualizacao")
                                .HasColumnName("metadata_usuario_atualizacao")
                                .HasColumnType("text");

                            b1.Property<string>("UsuarioInclusao")
                                .HasColumnName("metadata_usuario_inclusao")
                                .HasColumnType("text");

                            b1.Property<Guid>("Uuid")
                                .HasColumnName("metadata_uuid")
                                .HasColumnType("uuid");

                            b1.HasKey("VinculoVagaRegraDistribuicaoIdVaga", "VinculoVagaRegraDistribuicaoIdRegraDistribuicao")
                                .HasName("pk_vaga_regra_distribuicao");

                            b1.HasIndex("Uuid")
                                .IsUnique()
                                .HasName("ix_vaga_regra_distribuicao_metadata_uuid");

                            b1.ToTable("vaga_regra_distribuicao");

                            b1.WithOwner()
                                .HasForeignKey("VinculoVagaRegraDistribuicaoIdVaga", "VinculoVagaRegraDistribuicaoIdRegraDistribuicao")
                                .HasConstraintName("fk_vaga_regra_distribuicao_vaga_regra_distribuicao_id_vaga_id_~");
                        });
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos.AnaliseProcesso", b =>
                {
                    b.OwnsOne("Softplan.Common.Core.Entities.EntityMetadata", "Metadata", b1 =>
                        {
                            b1.Property<string>("AnaliseProcessoIdProcesso")
                                .HasColumnName("processo_id")
                                .HasColumnType("character varying(200)");

                            b1.Property<DateTimeOffset>("DataAtualizacao")
                                .HasColumnName("metadata_data_atualizacao")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTimeOffset>("DataInclusao")
                                .HasColumnName("metadata_data_inclusao")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<byte[]>("RowVersion")
                                .IsConcurrencyToken()
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnName("metadata_row_version")
                                .HasColumnType("bytea");

                            b1.Property<string>("UsuarioAtualizacao")
                                .HasColumnName("metadata_usuario_atualizacao")
                                .HasColumnType("text");

                            b1.Property<string>("UsuarioInclusao")
                                .HasColumnName("metadata_usuario_inclusao")
                                .HasColumnType("text");

                            b1.Property<Guid>("Uuid")
                                .HasColumnName("metadata_uuid")
                                .HasColumnType("uuid");

                            b1.HasKey("AnaliseProcessoIdProcesso")
                                .HasName("pk_analise_processo");

                            b1.HasIndex("Uuid")
                                .IsUnique()
                                .HasName("ix_analise_processo_metadata_uuid");

                            b1.ToTable("analise_processo");

                            b1.WithOwner()
                                .HasForeignKey("AnaliseProcessoIdProcesso")
                                .HasConstraintName("fk_analise_processo_analise_processo_processo_id");
                        });
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos.DistribuicaoProcesso", b =>
                {
                    b.OwnsOne("Softplan.Common.Core.Entities.EntityMetadata", "Metadata", b1 =>
                        {
                            b1.Property<string>("DistribuicaoProcessoIdProcesso")
                                .HasColumnName("processo_id")
                                .HasColumnType("character varying(200)");

                            b1.Property<DateTimeOffset>("DataAtualizacao")
                                .HasColumnName("metadata_data_atualizacao")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTimeOffset>("DataInclusao")
                                .HasColumnName("metadata_data_inclusao")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<byte[]>("RowVersion")
                                .IsConcurrencyToken()
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnName("metadata_row_version")
                                .HasColumnType("bytea");

                            b1.Property<string>("UsuarioAtualizacao")
                                .HasColumnName("metadata_usuario_atualizacao")
                                .HasColumnType("text");

                            b1.Property<string>("UsuarioInclusao")
                                .HasColumnName("metadata_usuario_inclusao")
                                .HasColumnType("text");

                            b1.Property<Guid>("Uuid")
                                .HasColumnName("metadata_uuid")
                                .HasColumnType("uuid");

                            b1.HasKey("DistribuicaoProcessoIdProcesso")
                                .HasName("pk_distribuicao_processo");

                            b1.HasIndex("Uuid")
                                .IsUnique()
                                .HasName("ix_distribuicao_processo_metadata_uuid");

                            b1.ToTable("distribuicao_processo");

                            b1.WithOwner()
                                .HasForeignKey("DistribuicaoProcessoIdProcesso")
                                .HasConstraintName("fk_distribuicao_processo_distribuicao_processo_processo_id");
                        });
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos.DistribuicaoProcessoLog", b =>
                {
                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos.DistribuicaoProcesso", null)
                        .WithMany("Logs")
                        .HasForeignKey("IdProcesso")
                        .HasConstraintName("fk_distribuicao_processo_log_distribuicao_processo_processo_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos.ImpedimentoProcesso", b =>
                {
                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas.Vaga", "Vaga")
                        .WithMany()
                        .HasForeignKey("IdVaga")
                        .HasConstraintName("fk_impedimento_processo_vaga_vaga_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Softplan.Common.Core.Entities.EntityMetadata", "Metadata", b1 =>
                        {
                            b1.Property<string>("ImpedimentoProcessoIdProcesso")
                                .HasColumnName("processo_id")
                                .HasColumnType("character varying(200)");

                            b1.Property<int>("ImpedimentoProcessoIdImpedimento")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("impedimento_id")
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<DateTimeOffset>("DataAtualizacao")
                                .HasColumnName("metadata_data_atualizacao")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTimeOffset>("DataInclusao")
                                .HasColumnName("metadata_data_inclusao")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<byte[]>("RowVersion")
                                .IsConcurrencyToken()
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnName("metadata_row_version")
                                .HasColumnType("bytea");

                            b1.Property<string>("UsuarioAtualizacao")
                                .HasColumnName("metadata_usuario_atualizacao")
                                .HasColumnType("text");

                            b1.Property<string>("UsuarioInclusao")
                                .HasColumnName("metadata_usuario_inclusao")
                                .HasColumnType("text");

                            b1.Property<Guid>("Uuid")
                                .HasColumnName("metadata_uuid")
                                .HasColumnType("uuid");

                            b1.HasKey("ImpedimentoProcessoIdProcesso", "ImpedimentoProcessoIdImpedimento")
                                .HasName("pk_impedimento_processo");

                            b1.HasIndex("Uuid")
                                .IsUnique()
                                .HasName("ix_impedimento_processo_metadata_uuid");

                            b1.ToTable("impedimento_processo");

                            b1.WithOwner()
                                .HasForeignKey("ImpedimentoProcessoIdProcesso", "ImpedimentoProcessoIdImpedimento")
                                .HasConstraintName("fk_impedimento_processo_impedimento_processo_processo_id_imped~");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}