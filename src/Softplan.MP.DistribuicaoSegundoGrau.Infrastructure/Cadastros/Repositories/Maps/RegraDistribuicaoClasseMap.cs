using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Cadastros.Repositories.Maps
{
    class RegraDistribuicaoClasseMap : IEntityTypeConfiguration<CriterioClasse>
    {
        public void Configure(EntityTypeBuilder<CriterioClasse> builder)
        {
            builder.ToTable("REGRA_DISTRIBUICAO_CLASSE");

            builder.HasKey(x => new {IdRegraDistribuicao = x.Id, x.IdClasse})
                .HasName("PK_ID_REGRA_DIST_CLAS");

            builder.Property(x => x.Id)
                .HasColumnName("REGRA_DISTRIBUICAO_ID");

            builder.Property(x => x.IdClasse)
                .HasColumnName("CLASSE_ID");

            builder.Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(120);
        }
    }
}