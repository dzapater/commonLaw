using Microsoft.EntityFrameworkCore;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations
{
    public class SajDsgOracleMigrationsDbContext : MigrationsDbContext
    {
        private readonly string _connectionString;
        private readonly string _licenseKey;

        public SajDsgOracleMigrationsDbContext()
        {
            _connectionString = ConfigDbContext.LOCAL_DSG_CONNECTION_STRING_ORACLE;
            _licenseKey = ConfigDbContext.DEVART_ORACLE_LICENSE;
        }

        public SajDsgOracleMigrationsDbContext(string connectionString, string licenseKey)
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