using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Cadastros.Repositories.Maps
{
    class VinculoVagaRegraDistribuicaoMap : MetadataMap<VinculoVagaRegraDistribuicao>
    {
        protected override void OnConfigure(EntityTypeBuilder<VinculoVagaRegraDistribuicao> builder)
        {
            builder.ToTable("VAGA_REGRA_DISTRIBUICAO");

            builder.HasKey(x => new {x.IdVaga, x.IdRegraDistribuicao})
                .HasName("PK_ID_VAGA_REGRA_DIST");

            builder.Property(x => x.IdVaga)
                .HasColumnName("ID_VAGA");

            builder.Property(x => x.IdRegraDistribuicao)
                .HasColumnName("ID_REGRADISTRIBUICAO");
            
            builder.Property(x => x.DistribuicaoPorVolume)
                .HasColumnName("DISTRIBUICAO_POR_VOLUME");
            
            builder.Property(x => x.CompensacaoPorVolume)
                .HasColumnName("COMPENSACAO_POR_VOLUME");
            
            builder.Property(x => x.DistribuicaoPorProcesso)
                .HasColumnName("DISTRIBUICAO_POR_PROCESSO");
            
            builder.Property(x => x.CompensacaoPorProcesso)
                .HasColumnName("COMPENSACAO_POR_PROCESSO");

            builder.HasOne(x => x.Vaga)
                .WithMany(x => x.RegrasVinculadas as ICollection<VinculoVagaRegraDistribuicao>)
                .HasForeignKey(x => x.IdVaga)
                .HasConstraintName("FK_ID_VAGA_REGRA")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.RegraDistribuicao)
                .WithMany(x => x.VinculoVagas as ICollection<VinculoVagaRegraDistribuicao>)
                .HasForeignKey(x => x.IdRegraDistribuicao)
                .HasConstraintName("FK_ID_REGRA_DISTRIBUICAO")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}