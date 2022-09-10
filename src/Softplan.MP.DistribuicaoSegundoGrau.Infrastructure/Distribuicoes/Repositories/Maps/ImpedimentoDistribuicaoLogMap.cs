using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Distribuicoes.Repositories.Maps
{
    class ImpedimentoDistribuicaoLogMap : MetadataMap<ImpedimentoDistribuicaoLog>
    {
        protected override void OnConfigure(EntityTypeBuilder<ImpedimentoDistribuicaoLog> builder)
        {
            builder.ToTable("IMPEDIMENTO_DISTRIBUICAO_LOG");

            builder.HasKey(x => x.IdLog)
                .HasName("PK_ID_IMP_DIST_LOG");
            
            builder.Property(x => x.IdLog)
                .HasColumnName("LOG_ID")
                .ValueGeneratedOnAdd()                
                .IsRequired();

            builder.HasIndex(e => new {e.IdProcesso})
                .HasName("IMP_DIST_LOG_ID_PROC");

            builder.HasIndex(e => new {e.IdProcesso, e.TransactionId})
                .HasName("IMP_DIST_LOG_ID_TRANSC");

            builder.Property(x => x.IdProcesso)
                .IsRequired()
                .HasColumnName("PROCESSO_ID")
                .HasMaxLength(200);

            builder.Property(x => x.TransactionId)
                .HasColumnName("TRANSACTION_ID")
                .IsRequired();

            builder.Property(x => x.TipoDistribuicao)
                .HasColumnName("TIPO_DISTRIBUICAO");

            builder.Property(x => x.PayloadType)
                .HasColumnName("PAYLOAD_TYPE")
                .HasMaxLength(200);

            builder.Property(x => x.PayloadSerialization)
                .HasColumnName("PAYLOAD_SRLZTION_TYPE");

            builder.Property(x => x.Payload)
                .HasColumnName("PAYLOAD");
        }
    }
}