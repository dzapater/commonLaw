using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Cadastros.Repositories.Maps
{
    class RegraDistribuicaoAssuntoMap : IEntityTypeConfiguration<CriterioAssunto>
    {
        public void Configure(EntityTypeBuilder<CriterioAssunto> builder)
        {
            builder.ToTable("REGRA_DISTRIBUICAO_ASSUNTO");

            builder.HasKey(x => new {IdRegraDistribuicao = x.Id, x.IdAssunto})
                .HasName("PK_ID_REGRA_DIST_ASTO");

            builder.Property(x => x.Id)
                .HasColumnName("REGRA_DISTRIBUICAO_ID");
            
            builder.Property(x => x.IdAssunto)
                .HasColumnName("ASSUNTO_ID");

            builder.Property(x => x.Descricao)
                .HasColumnName("DESCRICAO").HasMaxLength(120);
        }
    }
}