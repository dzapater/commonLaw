﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.OracleMigrations
{
    [DbContext(typeof(OracleMigrationsDbContext))]
    [Migration("20210510133455_CreateImpedimentoProcesso")]
    partial class CreateImpedimentoProcesso
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("SAJ_DSG")
                .HasAnnotation("ProductVersion", "3.1.11");

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<int>("Area")
                        .HasColumnName("AREA")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnName("ATIVO")
                        .HasColumnType("bool");

                    b.Property<string>("Descricao")
                        .HasColumnName("DESCRICAO")
                        .HasColumnType("nvarchar2(120)")
                        .HasMaxLength(120);

                    b.Property<int>("EscopoEquilibrio")
                        .HasColumnName("ESCOPO_EQUILIBRIO")
                        .HasColumnType("int");

                    b.Property<int>("Especialidade")
                        .HasColumnName("ESPECIALIDADE_ID")
                        .HasColumnType("int");

                    b.Property<int>("TipoProcesso")
                        .HasColumnName("TIPO_PROCESSO")
                        .HasColumnType("int");

                    b.Property<int>("VariavelEquilibrio")
                        .HasColumnName("VARIAVEL_EQUILIBRIO")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("REGRA_DISTRIBUICAO");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoAssunto", b =>
                {
                    b.Property<int>("IdRegraDistribuicao")
                        .HasColumnName("REGRA_DISTRIBUICAO_ID")
                        .HasColumnType("int");

                    b.Property<int>("IdAssunto")
                        .HasColumnName("ASSUNTO_ID")
                        .HasColumnType("int");

                    b.HasKey("IdRegraDistribuicao", "IdAssunto");

                    b.ToTable("REGRA_DISTRIBUICAO_ASSUNTO");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoClasse", b =>
                {
                    b.Property<int>("IdRegraDistribuicao")
                        .HasColumnName("REGRA_DISTRIBUICAO_ID")
                        .HasColumnType("int");

                    b.Property<int>("IdClasse")
                        .HasColumnName("CLASSE_ID")
                        .HasColumnType("int");

                    b.Property<int>("IdOrigem")
                        .HasColumnName("ORIGEM_ID")
                        .HasColumnType("int");

                    b.HasKey("IdRegraDistribuicao", "IdClasse");

                    b.ToTable("REGRA_DISTRIBUICAO_CLASSE");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoOrgaoJulgador", b =>
                {
                    b.Property<int>("IdRegraDistribuicao")
                        .HasColumnName("REGRA_DISTRIBUICAO_ID")
                        .HasColumnType("int");

                    b.Property<int>("IdOrgaoJulgador")
                        .HasColumnName("ORGAO_JULGADOR_ID")
                        .HasColumnType("int");

                    b.Property<int>("IdOrigem")
                        .HasColumnName("ORIGEM_ID")
                        .HasColumnType("int");

                    b.HasKey("IdRegraDistribuicao", "IdOrgaoJulgador");

                    b.ToTable("REGRA_DISTRIBUICAO_ORGAO");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoTarja", b =>
                {
                    b.Property<int>("IdRegraDistribuicao")
                        .HasColumnName("REGRA_DISTRIBUICAO_ID")
                        .HasColumnType("int");

                    b.Property<int>("IdTarja")
                        .HasColumnName("TARJA_ID")
                        .HasColumnType("int");

                    b.HasKey("IdRegraDistribuicao", "IdTarja");

                    b.ToTable("REGRA_DISTRIBUICAO_TARJA");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoUnidade", b =>
                {
                    b.Property<int>("IdRegraDistribuicao")
                        .HasColumnName("REGRA_DISTRIBUICAO_ID")
                        .HasColumnType("int");

                    b.Property<int>("IdUnidade")
                        .HasColumnName("UNIDADE_ID")
                        .HasColumnType("int");

                    b.Property<int>("IdOrgaoJulgador")
                        .HasColumnName("ORGAO_JULGADOR_ID")
                        .HasColumnType("int");

                    b.Property<int>("IdOrigem")
                        .HasColumnName("ORIGEM_ID")
                        .HasColumnType("int");

                    b.HasKey("IdRegraDistribuicao", "IdUnidade");

                    b.ToTable("REGRA_DISTRIBUICAO_UNIDADE");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas.Vaga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<int>("Area")
                        .HasColumnName("AREA")
                        .HasColumnType("int");

                    b.Property<bool>("ConsiderarConfiguracoesPrevencao")
                        .HasColumnName("CONFIGURACOES_PREVENCAO")
                        .HasColumnType("bool");

                    b.Property<string>("Descricao")
                        .HasColumnName("DESCRICAO")
                        .HasColumnType("nvarchar2(120)")
                        .HasMaxLength(120);

                    b.Property<bool>("EstaAtiva")
                        .HasColumnName("ATIVA")
                        .HasColumnType("bool");

                    b.Property<long>("IdInstalacao")
                        .HasColumnName("INSTALACAO_ID")
                        .HasColumnType("int64");

                    b.Property<long>("IdOrgao")
                        .HasColumnName("ORGAO_ID")
                        .HasColumnType("int64");

                    b.Property<long>("IdProcuradorTitular")
                        .HasColumnName("PROCURADOR_TITULAR_ID")
                        .HasColumnType("int64");

                    b.Property<long>("IdTipoOrgao")
                        .HasColumnName("TIPO_ORGAO_ID")
                        .HasColumnType("int64");

                    b.Property<bool>("PermiteDistribuicaoMesmaVaga")
                        .HasColumnName("DISTRIBUICAO_MESMA_VAGA")
                        .HasColumnType("bool");

                    b.Property<bool>("PermiteReuPreso")
                        .HasColumnName("REU_PRESO")
                        .HasColumnType("bool");

                    b.HasKey("Id");

                    b.ToTable("VAGA");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao.VinculoVagaRegraDistribuicao", b =>
                {
                    b.Property<int>("IdVaga")
                        .HasColumnName("ID_VAGA")
                        .HasColumnType("int");

                    b.Property<int>("IdRegraDistribuicao")
                        .HasColumnName("ID_REGRADISTRIBUICAO")
                        .HasColumnType("int");

                    b.HasKey("IdVaga", "IdRegraDistribuicao");

                    b.HasIndex("IdRegraDistribuicao");

                    b.ToTable("VAGA_REGRA_DISTRIBUICAO");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos.ImpedimentoProcesso", b =>
                {
                    b.Property<int>("IdProcesso")
                        .HasColumnName("PROCESSO_ID")
                        .HasColumnType("int");

                    b.Property<int>("IdImpedimento")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IMPEDIMENTO_ID")
                        .HasColumnType("int");

                    b.Property<int>("IdVaga")
                        .HasColumnName("VAGA_ID")
                        .HasColumnType("int");

                    b.Property<string>("Motivo")
                        .HasColumnName("MOTIVO")
                        .HasColumnType("nvarchar2(2000)")
                        .HasMaxLength(2000);

                    b.HasKey("IdProcesso", "IdImpedimento");

                    b.HasIndex("IdVaga");

                    b.ToTable("IMPEDIMENTO_PROCESSO");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicao", b =>
                {
                    b.OwnsOne("Softplan.Common.Core.Entities.EntityMetadata", "Metadata", b1 =>
                        {
                            b1.Property<int>("RegraDistribuicaoId")
                                .HasColumnType("int");

                            b1.Property<DateTimeOffset>("DataAtualizacao")
                                .HasColumnName("METADATA_DATA_ATUALIZACAO")
                                .HasColumnType("datetimeoffset");

                            b1.Property<DateTimeOffset>("DataInclusao")
                                .HasColumnName("METADATA_DATA_INCLUSAO")
                                .HasColumnType("datetimeoffset");

                            b1.Property<byte[]>("RowVersion")
                                .IsConcurrencyToken()
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnName("METADATA_ROW_VERSION")
                                .HasColumnType("blob");

                            b1.Property<string>("UsuarioAtualizacao")
                                .HasColumnName("METADATA_USUARIO_ATUALIZACAO")
                                .HasColumnType("nclob");

                            b1.Property<string>("UsuarioInclusao")
                                .HasColumnName("METADATA_USUARIO_INCLUSAO")
                                .HasColumnType("nclob");

                            b1.Property<Guid>("Uuid")
                                .HasColumnName("METADATA_UUID")
                                .HasColumnType("guid");

                            b1.HasKey("RegraDistribuicaoId");

                            b1.HasIndex("Uuid")
                                .IsUnique();

                            b1.ToTable("REGRA_DISTRIBUICAO");

                            b1.WithOwner()
                                .HasForeignKey("RegraDistribuicaoId");
                        });
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoAssunto", b =>
                {
                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicao", null)
                        .WithMany("Assuntos")
                        .HasForeignKey("IdRegraDistribuicao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoClasse", b =>
                {
                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicao", null)
                        .WithMany("Classes")
                        .HasForeignKey("IdRegraDistribuicao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoOrgaoJulgador", b =>
                {
                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicao", null)
                        .WithMany("OrgaosJulgadores")
                        .HasForeignKey("IdRegraDistribuicao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoTarja", b =>
                {
                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicao", null)
                        .WithMany("Tarjas")
                        .HasForeignKey("IdRegraDistribuicao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicaoUnidade", b =>
                {
                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicao", null)
                        .WithMany("Unidades")
                        .HasForeignKey("IdRegraDistribuicao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas.Vaga", b =>
                {
                    b.OwnsOne("Softplan.Common.Core.Entities.EntityMetadata", "Metadata", b1 =>
                        {
                            b1.Property<int>("VagaId")
                                .HasColumnType("int");

                            b1.Property<DateTimeOffset>("DataAtualizacao")
                                .HasColumnName("METADATA_DATA_ATUALIZACAO")
                                .HasColumnType("datetimeoffset");

                            b1.Property<DateTimeOffset>("DataInclusao")
                                .HasColumnName("METADATA_DATA_INCLUSAO")
                                .HasColumnType("datetimeoffset");

                            b1.Property<byte[]>("RowVersion")
                                .IsConcurrencyToken()
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnName("METADATA_ROW_VERSION")
                                .HasColumnType("blob");

                            b1.Property<string>("UsuarioAtualizacao")
                                .HasColumnName("METADATA_USUARIO_ATUALIZACAO")
                                .HasColumnType("nclob");

                            b1.Property<string>("UsuarioInclusao")
                                .HasColumnName("METADATA_USUARIO_INCLUSAO")
                                .HasColumnType("nclob");

                            b1.Property<Guid>("Uuid")
                                .HasColumnName("METADATA_UUID")
                                .HasColumnType("guid");

                            b1.HasKey("VagaId");

                            b1.HasIndex("Uuid")
                                .IsUnique();

                            b1.ToTable("VAGA");

                            b1.WithOwner()
                                .HasForeignKey("VagaId");
                        });
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao.VinculoVagaRegraDistribuicao", b =>
                {
                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.RegraDistribuicao", "RegraDistribuicao")
                        .WithMany("VinculoVagas")
                        .HasForeignKey("IdRegraDistribuicao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas.Vaga", "Vaga")
                        .WithMany()
                        .HasForeignKey("IdVaga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Softplan.Common.Core.Entities.EntityMetadata", "Metadata", b1 =>
                        {
                            b1.Property<int>("VinculoVagaRegraDistribuicaoIdVaga")
                                .HasColumnType("int");

                            b1.Property<int>("VinculoVagaRegraDistribuicaoIdRegraDistribuicao")
                                .HasColumnType("int");

                            b1.Property<DateTimeOffset>("DataAtualizacao")
                                .HasColumnName("METADATA_DATA_ATUALIZACAO")
                                .HasColumnType("datetimeoffset");

                            b1.Property<DateTimeOffset>("DataInclusao")
                                .HasColumnName("METADATA_DATA_INCLUSAO")
                                .HasColumnType("datetimeoffset");

                            b1.Property<byte[]>("RowVersion")
                                .IsConcurrencyToken()
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnName("METADATA_ROW_VERSION")
                                .HasColumnType("blob");

                            b1.Property<string>("UsuarioAtualizacao")
                                .HasColumnName("METADATA_USUARIO_ATUALIZACAO")
                                .HasColumnType("nclob");

                            b1.Property<string>("UsuarioInclusao")
                                .HasColumnName("METADATA_USUARIO_INCLUSAO")
                                .HasColumnType("nclob");

                            b1.Property<Guid>("Uuid")
                                .HasColumnName("METADATA_UUID")
                                .HasColumnType("guid");

                            b1.HasKey("VinculoVagaRegraDistribuicaoIdVaga", "VinculoVagaRegraDistribuicaoIdRegraDistribuicao");

                            b1.HasIndex("Uuid")
                                .IsUnique();

                            b1.ToTable("VAGA_REGRA_DISTRIBUICAO");

                            b1.WithOwner()
                                .HasForeignKey("VinculoVagaRegraDistribuicaoIdVaga", "VinculoVagaRegraDistribuicaoIdRegraDistribuicao");
                        });
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos.ImpedimentoProcesso", b =>
                {
                    b.HasOne("Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas.Vaga", "Vaga")
                        .WithMany()
                        .HasForeignKey("IdVaga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Softplan.Common.Core.Entities.EntityMetadata", "Metadata", b1 =>
                        {
                            b1.Property<int>("ImpedimentoProcessoIdProcesso")
                                .HasColumnType("int");

                            b1.Property<int>("ImpedimentoProcessoIdImpedimento")
                                .HasColumnType("int");

                            b1.Property<DateTimeOffset>("DataAtualizacao")
                                .HasColumnName("METADATA_DATA_ATUALIZACAO")
                                .HasColumnType("datetimeoffset");

                            b1.Property<DateTimeOffset>("DataInclusao")
                                .HasColumnName("METADATA_DATA_INCLUSAO")
                                .HasColumnType("datetimeoffset");

                            b1.Property<byte[]>("RowVersion")
                                .IsConcurrencyToken()
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnName("METADATA_ROW_VERSION")
                                .HasColumnType("blob");

                            b1.Property<string>("UsuarioAtualizacao")
                                .HasColumnName("METADATA_USUARIO_ATUALIZACAO")
                                .HasColumnType("nclob");

                            b1.Property<string>("UsuarioInclusao")
                                .HasColumnName("METADATA_USUARIO_INCLUSAO")
                                .HasColumnType("nclob");

                            b1.Property<Guid>("Uuid")
                                .HasColumnName("METADATA_UUID")
                                .HasColumnType("guid");

                            b1.HasKey("ImpedimentoProcessoIdProcesso", "ImpedimentoProcessoIdImpedimento");

                            b1.HasIndex("Uuid")
                                .IsUnique();

                            b1.ToTable("IMPEDIMENTO_PROCESSO");

                            b1.WithOwner()
                                .HasForeignKey("ImpedimentoProcessoIdProcesso", "ImpedimentoProcessoIdImpedimento");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
