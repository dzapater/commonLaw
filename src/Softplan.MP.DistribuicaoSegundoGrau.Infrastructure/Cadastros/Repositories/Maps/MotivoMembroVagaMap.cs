using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;


namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Cadastros.Repositories.Maps
{
    class MotivoMembroVagaMap : MetadataMap<MotivoMembroVaga>
    {
        protected override void OnConfigure(EntityTypeBuilder<MotivoMembroVaga> builder)
        {
            builder.ToTable("EFMPSITOFICIANTE");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("CDSITOFICIANTE")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Descricao)
                .HasColumnName("DESITOFICIANTE")
                .HasMaxLength(40);
            
            builder.Property(x => x.Ativo)
                .HasColumnName("FLSITOFICIANTE");

            
        }
    }
}