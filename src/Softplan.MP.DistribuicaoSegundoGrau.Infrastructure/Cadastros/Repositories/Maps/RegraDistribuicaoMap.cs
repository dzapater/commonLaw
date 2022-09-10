using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Cadastros.Repositories.Maps
{
    class RegraDistribuicaoMap : MetadataMap<RegraDistribuicao>
    {
        protected override void OnConfigure(EntityTypeBuilder<RegraDistribuicao> builder)
        {
            builder.ToTable("REGRA_DISTRIBUICAO");

            builder.HasKey(x => x.Id)
                .HasName("PK_ID_REGRA_DIST");

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(120);

            builder.Property(x => x.Ativo)
                .HasColumnName("ATIVO");

            builder.Property(x => x.TipoProcesso)
                .HasColumnName("TIPO_PROCESSO");

            builder.Property(x => x.Area)
                .HasColumnName("AREA")
                .IsRequired(false);

            builder.Property(x => x.VariavelEquilibrio)
                .HasColumnName("VARIAVEL_EQUILIBRIO");

            builder.Property(x => x.EscopoEquilibrio)
                .HasColumnName("ESCOPO_EQUILIBRIO");

            builder.HasMany(x => x.Especialidades)
                .WithOne()
                .HasForeignKey(x => x.Id)
                .HasConstraintName("FK_ID_REGRA_DIST_ESPEC")
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasMany(x => x.Assuntos)
                .WithOne()
                .HasForeignKey(x => x.Id)
                .HasConstraintName("FK_ID_REGRA_DIST_ASSUNTO")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Classes)
                .WithOne()
                .HasForeignKey(x => x.Id)
                .HasConstraintName("FK_ID_REGRA_DIST_CLASSE")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tarjas)
                .WithOne()
                .HasForeignKey(x => x.Id)
                .HasConstraintName("FK_ID_REGRA_DIST_TARJA")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Unidades)
                .WithOne()
                .HasForeignKey(x => x.Id)
                .HasConstraintName("FK_ID_REGRA_DIST_UNIDADE")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.OrgaosJulgadores)
                .WithOne()
                .HasForeignKey(x => x.Id)
                .HasConstraintName("FK_ID_REGRA_DIST_ORG_JUL")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}