using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Cadastros.Repositories.Maps
{
    class CompensacaoLogMap : MetadataMap<CompensacaoLog>
    {
        protected override void OnConfigure(EntityTypeBuilder<CompensacaoLog> builder)
        {
            builder.ToTable("COMPENSACAO_LOG");

            builder.HasKey(x => new {x.Id})
                .HasName("PK_ID_COMP_LOG");

            builder.Property(x => x.Id)
                .HasColumnName("LOG_ID")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdVaga)
                .HasColumnName("VAGA_ID");

            builder.Property(x => x.Motivo)
                .HasColumnName("MOTIVO")
                .HasMaxLength(2000);

            builder.Property(x => x.Valor)
                .HasColumnName("VALOR");

            builder.HasOne(x => x.Vaga)
                .WithMany()
                .HasForeignKey(x => x.IdVaga)
                .HasConstraintName("FK_ID_VAGA_COMP_LOG");
        }
    }
}