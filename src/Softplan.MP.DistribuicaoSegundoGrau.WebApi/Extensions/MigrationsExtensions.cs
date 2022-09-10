using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class MigrationsExtensions
    {
        private static readonly object MigrationsLock = new object();
        private const string EnableSeed = "ENABLE_SEED";
        private const string DatabaseProvider = "DATABASE_PROVIDER";
        private const string OracleProvider = "Oracle";
        private const string PostgreSqlProvider = "PostgreSql";
        private const string ConnectionString = "CONNECTION_STRING";
        private const string SajDsgConnectionString = "SAJDSG_CONNECTION_STRING";
        private const string DevartOracleLicense = "DEVART_ORACLE_LICENSE";

        public static void RunMigrationsWhenSeedIsEnabled(this IConfiguration configuration)
        {
            var seedEnabled = configuration.GetValue(EnableSeed, false);
            var provider = configuration.GetValue(DatabaseProvider, string.Empty);
            if (!seedEnabled) return;

            Action<IConfiguration> runMigration = provider switch
            {
                OracleProvider => RunOracleMigrations,
                PostgreSqlProvider => RunPostgreSqlMigrations,
                _ => __ => { }
            };
            runMigration(configuration);
        }

        public static void RunSajMigrationsWhenSeedIsEnabled(this IConfiguration configuration)
        {
            var seedEnabled = configuration.GetValue(EnableSeed, false);
            var provider = configuration.GetValue(DatabaseProvider, string.Empty);
            if (!seedEnabled) return;

            Action<IConfiguration> runMigration = provider switch
            {
                OracleProvider => RunOracleSajMigrations,
                PostgreSqlProvider => RunPostgreSajSqlMigrations,
                _ => __ => { }
            };
            runMigration(configuration);
        }

        private static void RunOracleMigrations(IConfiguration configuration)
        {
            lock (MigrationsLock)
            {
                var connectionString = configuration.GetValue(SajDsgConnectionString, string.Empty);
                var licenseKey = configuration.GetValue(DevartOracleLicense, string.Empty);
                var dbContext = new SajDsgOracleMigrationsDbContext(connectionString, licenseKey);
                dbContext.Database.Migrate();
            }
        }

        private static void RunOracleSajMigrations(IConfiguration configuration)
        {
            lock (MigrationsLock)
            {
                var connectionString = configuration.GetValue(ConnectionString, string.Empty);
                var licenseKey = configuration.GetValue(DevartOracleLicense, string.Empty);
                var dbContext = new OracleSajMigrationsDbContext(connectionString, licenseKey);
                dbContext.Database.Migrate();
            }
        }

        private static void RunPostgreSqlMigrations(IConfiguration configuration)
        {
            lock (MigrationsLock)
            {
                var connectionString = configuration.GetValue(ConnectionString, string.Empty);
                var dbContext = new SajDsgPostgreSqlMigrationsDbContext(connectionString);
                dbContext.Database.Migrate();
            }
        }

        private static void RunPostgreSajSqlMigrations(IConfiguration configuration)
        {
            lock (MigrationsLock)
            {
                var connectionString = configuration.GetValue(ConnectionString, string.Empty);
                var dbContext = new PostgreSqlSajMigrationsDbContext(connectionString);
                dbContext.Database.Migrate();
            }
        }
    }
}