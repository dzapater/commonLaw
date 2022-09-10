using Microsoft.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Maps;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.MCD.Maps;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.TAX.Maps;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Parametros.Repositories.Maps;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations
{
    public class PostgreSqlSajMigrationsDbContext : DbContext
    {
        private readonly string _connectionString;
        
        public PostgreSqlSajMigrationsDbContext()
        {
            _connectionString = ConfigDbContext.LOCAL_SAJ_CONNECTION_STRING_POSTGRES;
        }

        public PostgreSqlSajMigrationsDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString, x =>
                x.MigrationsHistoryTable(MigrationsDbContext.MigrationHistoryTable, "saj"));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyTaxonomiaConfigurations(true);
            
            modelBuilder.ApplyMcdConfigurations(true);
            
            modelBuilder.ApplyVinculoMembroVagaConfigurations(true);
            
            modelBuilder.ApplyParametroConfigurations(true);

            PostgreSqlMigrationsDbContext.ConvertModelBuilderCase(modelBuilder);
        }
    }
}