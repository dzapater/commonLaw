using Microsoft.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Maps;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.MCD.Maps;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.TAX.Maps;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Parametros.Repositories.Maps;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations
{
    public class OracleSajMigrationsDbContext : DbContext
    {
        private readonly string _connectionString;
        private readonly string _licenseKey;

        public OracleSajMigrationsDbContext()
        {
            _connectionString = ConfigDbContext.LOCAL_SAJ_CONNECTION_STRING_ORACLE;
            _licenseKey = ConfigDbContext.DEVART_ORACLE_LICENSE;
        }

        public OracleSajMigrationsDbContext(string connectionString, string licenseKey)
        {
            _connectionString = connectionString;
            _licenseKey = licenseKey;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle($"{_connectionString};License Key={_licenseKey}; Direct=True", x =>
                x.MigrationsHistoryTable(MigrationsDbContext.MigrationHistoryTable, "SAJ"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyTaxonomiaConfigurations(false);
            modelBuilder.ApplyMcdConfigurations(false);
            modelBuilder.ApplyVinculoMembroVagaConfigurations(false);
            modelBuilder.ApplyParametroConfigurations(false);
        }
    }
}