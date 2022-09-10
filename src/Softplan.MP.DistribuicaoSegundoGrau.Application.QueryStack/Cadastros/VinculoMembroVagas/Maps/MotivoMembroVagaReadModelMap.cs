using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Maps
{
        class MotivoMembroVagaReadModelMap  : IEntityTypeConfiguration<MotivoMembroVagaReadModel>
        {
            private readonly string _schema;

            public MotivoMembroVagaReadModelMap (string schema)
            {
                _schema = schema;
            }

            public void Configure(EntityTypeBuilder<MotivoMembroVagaReadModel> builder)
            {
                builder.ToTable("EFMPSITOFICIANTE", _schema);

                builder.HasKey(x => new {x.Id});

                builder.Property(x => x.Id)
                    .HasColumnName("CDSITOFICIANTE");

                builder.Property(x => x.Descricao)
                    .HasColumnName("DESITOFICIANTE")
                    .HasMaxLength(40);

                builder.Property(x => x.Ativo)
                    .HasColumnName("FLSITOFICIANTE")
                    .HasMaxLength(1);

            }
        }

}