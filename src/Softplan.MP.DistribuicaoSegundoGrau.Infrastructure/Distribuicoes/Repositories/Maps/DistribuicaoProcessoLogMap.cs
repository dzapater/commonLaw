using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Distribuicoes.Repositories.Maps
{
    class DistribuicaoProcessoLogMap : IEntityTypeConfiguration<DistribuicaoProcessoLog>
    {
        public void Configure(EntityTypeBuilder<DistribuicaoProcessoLog> builder)
        {
            builder.ToTable("DISTRIBUICAO_PROCESSO_LOG");

            builder.HasKey(x => x.IdLog)
                .HasName("PK_ID_DIST_PROC_LOG");

            builder.HasIndex(e => new { e.IdProcesso })
                .HasName("DIST_PROC_LOG_ID");
                

            builder.HasIndex(e => new {e.IdProcesso, e.TransactionId})
                .HasName("DIST_PROC_LOG_ID_TRANSC");

            builder.Property(x => x.IdProcesso)
                .IsRequired()
                .HasColumnName("PROCESSO_ID")
                .HasMaxLength(200);

            builder.Property(x => x.IdLog)
                .HasColumnName("LOG_ID")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.TransactionId)
                .HasColumnName("TRANSACTION_ID");

            builder.Property(x => x.PayloadType)
                .HasColumnName("PAYLOAD_TYPE")
                .HasMaxLength(200);

            builder.Property(x => x.PayloadSerialization)
                .HasColumnName("PAYLOAD_SERIALIZATION_TYPE");

            builder.Property(x => x.Payload)
                .HasColumnName("PAYLOAD");

            builder.Property(x => x.DistribuicaoId)
                .HasColumnName("DISTRIBUICAO_ID");

        }
    }
}