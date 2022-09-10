using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.TAX.Maps
{
    class ClasseReadModelMap : IEntityTypeConfiguration<ClasseReadModel>
    {
        private readonly string _schema;

        public ClasseReadModelMap(string schema)
        {
            _schema = schema;
        }
        
        public void Configure(EntityTypeBuilder<ClasseReadModel> builder)
        {
            builder.ToTable("ESAJCLASSE", _schema);

            builder.HasKey(x => x.IdClasse);

            builder.Property(x => x.IdClasse)
                .HasColumnName("CDCLASSE");
            
            builder.Property(x => x.Descricao)
                .HasColumnName("DECLASSE")
                .HasMaxLength(120);
        }
    }
}