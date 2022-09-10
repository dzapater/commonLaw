using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Distribuicoes.Repositories.Maps
{
    class ImpedimentoProcessoMap : MetadataMap<ImpedimentoProcesso>
    {
        protected override void OnConfigure(EntityTypeBuilder<ImpedimentoProcesso> builder)
        {
            builder.ToTable("IMPEDIMENTO_PROCESSO");

            builder.HasKey(x => new {x.IdProcesso, IdAnalise = x.IdImpedimento})
                .HasName("PK_ID_IMP_PROC");

            builder.Property(x => x.IdProcesso)
                .HasColumnName("PROCESSO_ID")
                .HasMaxLength(200);

            builder.Property(x => x.IdImpedimento)
                .HasColumnName("IMPEDIMENTO_ID")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdVaga)
                .HasColumnName("VAGA_ID");

            builder.Property(x => x.Motivo)
                .HasColumnName("MOTIVO")
                .HasMaxLength(2000);

            builder.HasOne(x => x.Vaga)
                .WithMany(x =>x.ImpedimentoProcesso)
                .HasForeignKey(x => x.IdVaga)
                .HasConstraintName("FK_ID_VAGA_IMP")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(x => x.Mensagens);
        }
    }
}