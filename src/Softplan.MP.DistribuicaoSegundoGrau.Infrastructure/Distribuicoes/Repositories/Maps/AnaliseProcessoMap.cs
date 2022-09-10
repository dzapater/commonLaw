using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Distribuicoes.Repositories.Maps
{
    class AnaliseProcessoMap : MetadataMap<AnaliseProcesso>
    {
        protected override void OnConfigure(EntityTypeBuilder<AnaliseProcesso> builder)
        {
            builder.ToTable("ANALISE_PROCESSO");

            builder.HasKey(x => x.IdProcesso)
                .HasName("PK_ID_ANAL_PROC");

            builder.Property(x => x.IdProcesso)
                .HasColumnName("PROCESSO_ID")
                .HasMaxLength(200);

            builder.Property(x => x.IdVaga)
                .HasColumnName("VAGA_ID");

            builder.Property(x => x.TipoDistribuicao)
                .HasColumnName("TIPO_DISTRIBUICAO");

            builder.OwnsOne(x => x.AreaAtuacao, properties =>
            {
                properties.Ignore(p => p.Nome);
                properties.Property(p => p.Id).HasColumnName("AREA_ATUACAO_ID").HasMaxLength(200);
                properties.Property<byte[]>("METADATA_ROW_VERSION").HasColumnName("METADATA_ROW_VERSION").IsRowVersion();
            });

            builder.Property(x => x.Motivo)
                .HasColumnName("MOTIVO")
                .HasMaxLength(2000);
        }
    }
}