using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Distribuicoes.Repositories.Maps
{
    class ExcecaoVagaMap : MetadataMap<ExcecaoVaga>
    {
        protected override void OnConfigure(EntityTypeBuilder<ExcecaoVaga> builder)
        {
            builder.ToTable("EXCECAO_VAGA");

            builder.HasKey(x => x.Id)
                .HasName("PK_ID_EXC_VAGA");

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdVaga)
                            .HasColumnName("VAGA_ID");

            builder.Property(x => x.IdClasse)
                            .HasColumnName("CLASSE_ID");
            
            builder.Property(x => x.IdAssunto)
                            .HasColumnName("ASSUNTO_ID");

            builder.Property(x => x.IdEspecialidade)
                .HasColumnName("ESPECIALIDADE_ID");

            builder.Property(x => x.IdOrigem)
                .HasColumnName("ORIGEM_ID");

            builder.Property(x => x.IdUnidade)
                .HasColumnName("UNIDADE_ID");

            builder.Property(x => x.IdOrgaoJulgador)
                .HasColumnName("ORGAO_JULGADOR_ID");
            
            builder.Property(x => x.Motivo)
                .HasColumnName("MOTIVO")
                .HasMaxLength(2000);
            
            builder.Ignore(p => p.Assunto);
            builder.Ignore(p => p.Classe);
            builder.Ignore(p => p.Especialidade);
            builder.Ignore(p => p.Unidade);
            builder.Ignore(p => p.OrgaoJulgador);
            builder.Ignore(p => p.Mensagens);
        }
    }
}