﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlSajMigrations
{
    [DbContext(typeof(PostgreSqlSajMigrationsDbContext))]
    [Migration("20210520131146_CreateEspecialidade")]
    partial class CreateEspecialidade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.MCD.EspecialidadeReadModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cdespecialidade")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descricao")
                        .HasColumnName("deespecialidade")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id")
                        .HasName("pk_efmpespecialidade");

                    b.ToTable("efmpespecialidade","saj");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.TAX.AssuntoReadModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cdassunto")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descricao")
                        .HasColumnName("deassunto")
                        .HasColumnType("character varying(120)")
                        .HasMaxLength(120);

                    b.HasKey("Id")
                        .HasName("pk_esajassunto");

                    b.ToTable("esajassunto","saj");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.TAX.ClasseReadModel", b =>
                {
                    b.Property<int>("IdOrigem")
                        .HasColumnName("cdorigem")
                        .HasColumnType("integer");

                    b.Property<int>("IdClasse")
                        .HasColumnName("cdclasse")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .HasColumnName("declasse")
                        .HasColumnType("character varying(120)")
                        .HasMaxLength(120);

                    b.HasKey("IdOrigem", "IdClasse")
                        .HasName("pk_efmptjclasse");

                    b.ToTable("efmptjclasse","saj");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.TAX.ForoReadModel", b =>
                {
                    b.Property<int>("IdOrigem")
                        .HasColumnName("cdorigem")
                        .HasColumnType("integer");

                    b.Property<int>("IdForo")
                        .HasColumnName("cdforo")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .HasColumnName("nmforo")
                        .HasColumnType("character varying(120)")
                        .HasMaxLength(120);

                    b.HasKey("IdOrigem", "IdForo")
                        .HasName("pk_efmptjforo");

                    b.ToTable("efmptjforo","saj");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.TAX.TarjaReadModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cdtarja")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descricao")
                        .HasColumnName("detarja")
                        .HasColumnType("character varying(120)")
                        .HasMaxLength(120);

                    b.HasKey("Id")
                        .HasName("pk_esajtarja");

                    b.ToTable("esajtarja","saj");
                });

            modelBuilder.Entity("Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.TAX.VaraReadModel", b =>
                {
                    b.Property<int>("IdOrigem")
                        .HasColumnName("cdorigem")
                        .HasColumnType("integer");

                    b.Property<int>("IdForo")
                        .HasColumnName("cdforo")
                        .HasColumnType("integer");

                    b.Property<int>("IdVara")
                        .HasColumnName("cdvara")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .HasColumnName("nmvara")
                        .HasColumnType("character varying(120)")
                        .HasMaxLength(120);

                    b.HasKey("IdOrigem", "IdForo", "IdVara")
                        .HasName("pk_efmptjvara");

                    b.ToTable("efmptjvara","saj");
                });
#pragma warning restore 612, 618
        }
    }
}
