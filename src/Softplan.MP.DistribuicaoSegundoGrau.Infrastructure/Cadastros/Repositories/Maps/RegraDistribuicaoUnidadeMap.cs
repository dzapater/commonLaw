using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Cadastros.Repositories.Maps
{
    class RegraDistribuicaoUnidadeMap : IEntityTypeConfiguration<CriterioUnidade>
    {
        public void Configure(EntityTypeBuilder<CriterioUnidade> builder)
        {
            builder.ToTable("REGRA_DISTRIBUICAO_UNIDADE");

            builder.HasKey(x => new {IdRegraDistribuicao = x.Id, x.IdUnidade})
                .HasName("PK_ID_REGRA_DIST_UNID");
            
            builder.Property(x => x.Id)
                .HasColumnName("REGRA_DISTRIBUICAO_ID");
          
            builder.Property(x => x.IdOrigem)
                .HasColumnName("ORIGEM_ID");
            
            builder.Property(x => x.IdUnidade)
                .HasColumnName("UNIDADE_ID");
            
            builder.Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(120);
        }
    }
}