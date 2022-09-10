using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Cadastros.Repositories.Maps
{
    public class RegraDistribuicaoEspecialidadeMap : IEntityTypeConfiguration<CriterioEspecialidade>
    {
        public void Configure(EntityTypeBuilder<CriterioEspecialidade> builder)
        {
            builder.ToTable("REGRA_DISTRIBUICAO_ESPEC");

            builder.HasKey(x => new {IdRegraDistribuicao = x.Id, x.IdEspecialidade})
                .HasName("PK_ID_REGRA_DIST_ESPEC");

            builder.Property(x => x.Id)
                .HasColumnName("REGRA_DISTRIBUICAO_ID");
            
            builder.Property(x => x.IdEspecialidade)
                .HasColumnName("ESPECIALIDADE_ID");

            builder.Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(120);
        }
    }
}