using Microsoft.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Cadastros.Repositories.Maps;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Distribuicoes.Repositories.Maps;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Jobs.Repositories.Maps;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations
{
    public abstract class MigrationsDbContext : DbContext
    {
        public const string MigrationHistoryTable = "__MigrationsHistory";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(ApplicationSajDsgDbContext.DbSchema);
            modelBuilder.ApplyConfiguration(new RegraDistribuicaoMap());
            modelBuilder.ApplyConfiguration(new RegraDistribuicaoAssuntoMap());
            modelBuilder.ApplyConfiguration(new RegraDistribuicaoClasseMap());
            modelBuilder.ApplyConfiguration(new RegraDistribuicaoTarjaMap());
            modelBuilder.ApplyConfiguration(new RegraDistribuicaoOrgaoJulgadorMap());
            modelBuilder.ApplyConfiguration(new RegraDistribuicaoUnidadeMap());
            modelBuilder.ApplyConfiguration(new VagaMap());
            modelBuilder.ApplyConfiguration(new ExcecaoVagaMap());
            modelBuilder.ApplyConfiguration(new VinculoVagaRegraDistribuicaoMap());
            modelBuilder.ApplyConfiguration(new ImpedimentoProcessoMap());
            modelBuilder.ApplyConfiguration(new AnaliseProcessoMap());
            modelBuilder.ApplyConfiguration(new DistribuicaoProcessoMap());
            modelBuilder.ApplyConfiguration(new DistribuicaoProcessoLogMap());
            modelBuilder.ApplyConfiguration(new JobMap());
            modelBuilder.ApplyConfiguration(new VinculoMembroVagaMap());
            modelBuilder.ApplyConfiguration(new CompensacaoLogMap());
            modelBuilder.ApplyConfiguration(new RegraDistribuicaoEspecialidadeMap());
            modelBuilder.ApplyConfiguration(new ImpedimentoDistribuicaoLogMap());
        }
    }
}
