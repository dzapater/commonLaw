using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Distribuicoes.Repositories.Maps
{
    class DistribuicaoProcessoMap : MetadataMap<DistribuicaoProcesso>
    {
        protected override void OnConfigure(EntityTypeBuilder<DistribuicaoProcesso> builder)
        {
            builder.ToTable("DISTRIBUICAO_PROCESSO");

            builder.HasKey(x => x.Id)
                .HasName("PK_ID_DIST_PROC");

            builder.Property(x => x.Id)
                .HasColumnName("DISTRIBUICAO_ID")
                .ValueGeneratedOnAdd()                
                .IsRequired();

            builder.Property(x => x.IdProcesso)
                .HasColumnName("PROCESSO_ID")
                .HasMaxLength(200);

            builder.Property(x => x.IdVaga)
                .HasColumnName("VAGA_ID");

            builder.Property(x => x.TipoDistribuicao)
                .HasColumnName("TIPODISTRIBUICAO");

            builder.Property(x => x.Motivo)
                .HasColumnName("MOTIVO")
                .HasMaxLength(2000);

            builder.HasMany(x => x.Logs)
                .WithOne()
                .HasForeignKey(x => x.DistribuicaoId)
                .HasConstraintName("FK_ID_LOGS_DIST")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}