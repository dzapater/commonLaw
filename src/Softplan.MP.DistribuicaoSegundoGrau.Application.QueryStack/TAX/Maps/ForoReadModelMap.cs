using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.TAX.Maps
{
    class ForoReadModelMap : IEntityTypeConfiguration<ForoReadModel>
    {
        private readonly string _schema;

        public ForoReadModelMap(string schema)
        {
            _schema = schema;
        }
        
        public void Configure(EntityTypeBuilder<ForoReadModel> builder)
        {
            builder.ToTable("EFMPTJFORO", _schema);

            builder.HasKey(x => new {x.IdOrigem, x.IdForo});

            builder.Property(x => x.IdOrigem)
                .HasColumnName("CDORIGEM");

            builder.Property(x => x.IdForo)
                .HasColumnName("CDFORO");

            builder.Property(x => x.Descricao)
                .HasColumnName("NMFORO")
                .HasMaxLength(120);
        }
    }
}