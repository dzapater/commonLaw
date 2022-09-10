using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.TAX.Maps
{
    class AssuntoReadModelMap : IEntityTypeConfiguration<AssuntoReadModel>
    {
        private readonly string _schema;

        public AssuntoReadModelMap(string schema)
        {
            _schema = schema;
        }
        
        public void Configure(EntityTypeBuilder<AssuntoReadModel> builder)
        {
            builder.ToTable("ESAJASSUNTO", _schema);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("CDASSUNTO");
            
            builder.Property(x => x.Descricao)
                .HasColumnName("DEASSUNTO")
                .HasMaxLength(120);
        }
    }
}