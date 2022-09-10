using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.Common.Core.Entities.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure
{
    public abstract class MetadataMap<T> : IEntityTypeConfiguration<T>
        where T : class, IDomainModel
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            OnConfigure(builder);

            builder.OwnsOne(x => x.Metadata, properties =>
            {
                properties.HasIndex(x => x.Uuid)
                    .IsUnique();

                properties.Property(x => x.RowVersion)
                    .IsRowVersion();

                properties.Property(x => x.Uuid).HasColumnName("METADATA_UUID");

                properties.Property(x => x.RowVersion).HasColumnName("METADATA_ROW_VERSION");

                properties.Property(x => x.DataInclusao).HasColumnName("METADATA_DATA_INCLUSAO");

                properties.Property(x => x.DataAtualizacao).HasColumnName("METADATA_DATA_ATUALIZACAO");

                properties.Property(x => x.UsuarioInclusao).HasColumnName("METADATA_USUARIO_INCLUSAO")
                    .HasMaxLength(2000);

                properties.Property(x => x.UsuarioAtualizacao).HasColumnName("METADATA_USUARIO_ATUALIZACAO")
                    .HasMaxLength(2000);
            });
        }

        protected abstract void OnConfigure(EntityTypeBuilder<T> builder);
    }
}