using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Softplan.Common.Core.Extensions;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations
{
    public class PostgreSqlMigrationsDbContext : MigrationsDbContext
    {
        private readonly string _connectionString;

        public PostgreSqlMigrationsDbContext()
        {
            _connectionString = ConfigDbContext.LOCAL_SAJ_CONNECTION_STRING_POSTGRES;
        }

        public PostgreSqlMigrationsDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString, x =>
                x.MigrationsHistoryTable(MigrationHistoryTable, ApplicationSajDsgDbContext.DbSchema.ToLower()));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(ApplicationSajDsgDbContext.DbSchema.ToLower());
            ConvertModelBuilderCase(modelBuilder);
        }

        public static void ConvertModelBuilderCase(ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes()
                .ForEach(entity =>
                {
                    entity.SetTableName(ConvertCase(entity.GetTableName()));
                    ConvertIndexes(entity);
                    ConvertForeignKeys(entity);
                    ConvertKeys(entity);
                    ConvertColumns(entity);
                });
        }

        private static string ConvertCase(string value)
            => value.ToLower();

        private static void ConvertIndexes(IMutableEntityType entityType)
            => entityType.GetIndexes().ForEach(index => index.SetName(ConvertCase(index.GetName())));

        private static void ConvertForeignKeys(IMutableEntityType entityType)
            => entityType.GetForeignKeys().ForEach(index => index.SetConstraintName(ConvertCase(index.GetConstraintName())));

        private static void ConvertKeys(IMutableEntityType entityType)
            => entityType.GetKeys().ForEach(index => index.SetName(ConvertCase(index.GetName())));

        private static void ConvertColumns(IMutableEntityType entityType)
            => entityType.GetProperties().ForEach(index => index.SetColumnName(ConvertCase(index.GetColumnName())));
    }
}