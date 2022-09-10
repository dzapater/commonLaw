using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.TAX.Maps
{
    class TarjaReadModelMap : IEntityTypeConfiguration<TarjaReadModel>
    {
        private readonly string _schema;

        public TarjaReadModelMap(string schema)
        {
            _schema = schema;
        }
        
        public void Configure(EntityTypeBuilder<TarjaReadModel> builder)
        {
            builder.ToTable("ESAJTARJA", _schema);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("CDTARJA");
            
            builder.Property(x => x.Descricao)
                .HasColumnName("DETARJA")
                .HasMaxLength(120);
        }
    }
}