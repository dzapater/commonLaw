using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Cadastros.Repositories.Maps
{
    class VinculoMembroVagaMap : MetadataMap<VinculoMembroVaga>
    {
        protected override void OnConfigure(EntityTypeBuilder<VinculoMembroVaga> builder)
        {
            builder.ToTable("MEMBRO_VAGA");

            builder.HasKey(x => new {x.Id, x.IdVaga})
                .HasName(("PK_ID_MEMBRO_VAGA"));

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();
            
            builder.Property(x => x.IdVaga)
                .HasColumnName("ID_VAGA");

            builder.Property(x => x.IdMembro)
                .HasColumnName("ID_MEMBRO")
                .HasMaxLength(120);

            builder.Property(x => x.IdMotivoMembroVaga)
                .HasColumnName("ID_MOTIVO_MEMBRO_VAGA");
        
            builder.Property(x => x.Observacao)
                .HasColumnName("OBSERVACAO")
                .HasMaxLength(2000);
            
            builder.Property(x => x.DataInicial)
                .HasColumnName("DATA_INICIAL");
            
            builder.Property(x => x.DataFinal)
                .HasColumnName("DATA_FINAL");
            
            builder.HasOne(x => x.Vaga)
                .WithMany()
                .HasForeignKey(x=>x.IdVaga)
                .HasConstraintName("FK_ID_MEMBRO_VAGA")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(x => x.RegraDistribuicao);
            builder.Ignore(x => x.ProcuradorTitularId);
        }
    }
}