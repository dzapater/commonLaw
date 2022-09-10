using Microsoft.EntityFrameworkCore;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations
{
    public class OracleMigrationsDbContext : MigrationsDbContext
    {
        private readonly string _connectionString;
        private readonly string _licenseKey;

        public OracleMigrationsDbContext()
        {
            _connectionString = ConfigDbContext.LOCAL_DSG_CONNECTION_STRING_ORACLE;
            _licenseKey = ConfigDbContext.DEVART_ORACLE_LICENSE;
        }

        public OracleMigrationsDbContext(string connectionString, string licenseKey)
        {
            _connectionString = connectionString;
            _licenseKey = licenseKey;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle($"{_connectionString};License Key={_licenseKey}; Direct=True", x =>
                x.MigrationsHistoryTable(MigrationHistoryTable, ApplicationSajDsgDbContext.DbSchema));
            base.OnConfiguring(optionsBuilder);
        }
    }
}