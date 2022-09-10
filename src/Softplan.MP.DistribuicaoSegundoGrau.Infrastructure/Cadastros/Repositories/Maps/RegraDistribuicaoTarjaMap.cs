using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Cadastros.Repositories.Maps
{
    class RegraDistribuicaoTarjaMap : IEntityTypeConfiguration<CriterioTarja>
    {
        public void Configure(EntityTypeBuilder<CriterioTarja> builder)
        {
            builder.ToTable("REGRA_DISTRIBUICAO_TARJA");

            builder.HasKey(x => new {IdRegraDistribuicao = x.Id, x.IdTarja})
                .HasName("PK_ID_REGRA_DIST_TARJA");
            
            builder.Property(x => x.Id)
                .HasColumnName("REGRA_DISTRIBUICAO_ID");
            
            builder.Property(x => x.IdTarja)
                .HasColumnName("TARJA_ID");

            builder.Property(x => x.Descricao)
                .HasColumnName("DESCRICAO").HasMaxLength(120);
        }
    }
}