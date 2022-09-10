using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Jobs.Distribuicoes;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Jobs.Repositories.Maps
{
    public class JobMap : IEntityTypeConfiguration<DistribuicaoVagaJob>
    {
        public void Configure(EntityTypeBuilder<DistribuicaoVagaJob> builder)
        {
            builder.ToTable("JOBS");
            
            builder.HasKey(x => x.Id)
                .HasName("PK_ID_JOBS");

            builder.Property(x => x.Id)
                .HasColumnName("ID");
            
            builder.Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(200);
            
            builder.Property(x => x.PayLoad)
                .HasColumnName("PAYLOAD")
                .HasMaxLength(200);
            
            builder.Property(x => x.RowVersion)
                .IsRowVersion();
            
            builder.Property(x => x.RowVersion).HasColumnName("ROW_VERSION");

            builder.HasDiscriminator(x => x.Id)
                .HasValue(value: nameof(DistribuicaoVagaJob));
        }
    }
}