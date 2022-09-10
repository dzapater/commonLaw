using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Cadastros.Repositories.Maps
{
    class RegraDistribuicaoOrgaoJulgadorMap : IEntityTypeConfiguration<CriterioOrgaoJulgador>
    {
        public void Configure(EntityTypeBuilder<CriterioOrgaoJulgador> builder)
        {
            builder.ToTable("REGRA_DISTRIBUICAO_ORGAO");

            builder.HasKey(x => new {IdRegraDistribuicao = x.Id, x.IdOrgaoJulgador})
                .HasName("PK_ID_REGRA_DIST_ORG");
            
            builder.Property(x => x.Id)
                .HasColumnName("REGRA_DISTRIBUICAO_ID");
            
            builder.Property(x => x.IdOrigem)
                .HasColumnName("ORIGEM_ID");
            
            builder.Property(x => x.IdUnidade)
                .HasColumnName("UNIDADE_ID");
            
            builder.Property(x => x.IdOrgaoJulgador)
                .HasColumnName("ORGAO_JULGADOR_ID");

            builder.Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(120);
        }
    }
}