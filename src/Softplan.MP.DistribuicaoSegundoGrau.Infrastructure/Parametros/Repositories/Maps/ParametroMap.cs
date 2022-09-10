using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Parametros;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Parametros.Repositories.Maps
{
    public class ParametroMap : IEntityTypeConfiguration<Parametro>
    {
        private readonly string _schema;

        public ParametroMap(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<Parametro> builder)
        {
            builder.ToTable("EPADDEFPARAMETRO", _schema);
        
            builder.HasKey(x => x.Id)
                .HasName("PK_ID_PARAMETRO");
        
            builder.Property(x => x.Id)
                .HasColumnName("CDPARAMETRO");
        
            builder.Property(x => x.Descricao)
                .HasColumnName("DEPARAMETRO")
                .HasMaxLength(200);

            builder.Property(x => x.Desvio)
                .HasColumnName("NUTAMANHO");
        }
    }
}