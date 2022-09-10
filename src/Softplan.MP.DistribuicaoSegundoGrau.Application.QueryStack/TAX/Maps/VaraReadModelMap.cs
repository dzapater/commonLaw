using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.TAX.Maps
{
    class VaraReadModelMap : IEntityTypeConfiguration<VaraReadModel>
    {
        private readonly string _schema;

        public VaraReadModelMap(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<VaraReadModel> builder)
        {
            builder.ToTable("EFMPTJVARA", _schema);

            builder.HasKey(x => new {x.IdOrigem, x.IdForo, Id = x.IdVara});

            builder.Property(x => x.IdOrigem)
                .HasColumnName("CDORIGEM");

            builder.Property(x => x.IdForo)
                .HasColumnName("CDFORO");

            builder.Property(x => x.IdVara)
                .HasColumnName("CDVARA");

            builder.Property(x => x.Descricao)
                .HasColumnName("NMVARA")
                .HasMaxLength(120);
        }
    }
}