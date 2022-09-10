using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Cadastros.Repositories.Maps
{
    class VagaMap : MetadataMap<Vaga>
    {
        protected override void OnConfigure(EntityTypeBuilder<Vaga> builder)
        {
            builder.ToTable("VAGA");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(120);

            builder.HasIndex(x => x.Descricao).IsUnique();
            
            builder.OwnsOne(x => x.ProcuradorTitular, properties =>
            {
                properties.Property(p => p.Id).HasColumnName("PROCURADOR_TITULAR_ID").HasMaxLength(120);
                properties.Property<byte[]>("METADATA_ROW_VERSION").HasColumnName("METADATA_ROW_VERSION").IsRowVersion();
                properties.Property<int>("VagaId").HasColumnName("ID").ValueGeneratedOnAdd();
            });

            builder.Property(x => x.IdInstalacao)
                .HasColumnName("INSTALACAO_ID");

            builder.Property(x => x.ConsiderarConfiguracoesPrevencao)
                .HasColumnName("CONFIGURACOES_PREVENCAO");

            builder.Property(x => x.PermiteReuPreso)
                .HasColumnName("REU_PRESO");

            builder.Property(x => x.EstaAtiva)
                .HasColumnName("ATIVA");

            builder.Property(x => x.PermiteDistribuicaoMesmaVaga)
                .HasColumnName("DISTRIBUICAO_MESMA_VAGA");

            builder.Property(x => x.Area)
                .HasColumnName("AREA");
            
            builder.Property(x => x.Distribuicoes)
                .HasColumnName("DISTRIBUICOES");
            
            builder.Property(x => x.Compensacao)
                .HasColumnName("COMPENSACAO");
            
            builder.Property(x => x.DistribuicaoPorVolume)
               .HasColumnName("DISTRIBUICAO_POR_VOLUME");
            
            builder.Property(x => x.CompensacaoPorVolume)
               .HasColumnName("COMPENSACAO_POR_VOLUME");

            builder.Property(x => x.Motivo)
               .HasColumnName("MOTIVO")
               .HasMaxLength(2000);

            builder.Property(x => x.CdLocal)
                .HasColumnName("CDLOCAL");

            builder.OwnsOne(x => x.Orgao, properties =>
            {
                properties.Property(p => p.Id).HasColumnName("ORGAO_ID");
                properties.Property(p => p.IdTipoOrgao).HasColumnName("TIPO_ORGAO_ID");
                properties.Ignore(p => p.IdForo);
                properties.Property<byte[]>("METADATA_ROW_VERSION").HasColumnName("METADATA_ROW_VERSION").IsRowVersion();
                properties.Property<int>("VagaId").HasColumnName("ID").ValueGeneratedOnAdd();
            });

            builder.Ignore(x => x.Mensagens);

        }
    }
}