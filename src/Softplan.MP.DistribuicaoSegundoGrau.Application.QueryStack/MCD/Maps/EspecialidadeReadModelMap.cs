using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.MCD.Maps
{
    class EspecialidadeReadModelMap : IEntityTypeConfiguration<EspecialidadeReadModel>
    {
        private readonly string _schema;

        public EspecialidadeReadModelMap(string schema)
        {
            _schema = schema;
        }
        
        public void Configure(EntityTypeBuilder<EspecialidadeReadModel> builder)
        {
            builder.ToTable("EFMPESPECIALIDADE", _schema);
        
            builder.HasKey(x => x.Id);
        
            builder.Property(x => x.Id)
                .HasColumnName("CDESPECIALIDADE");
        
            builder.Property(x => x.Descricao)
                .HasColumnName("DEESPECIALIDADE")
                .HasMaxLength(100);
        }
    }
}