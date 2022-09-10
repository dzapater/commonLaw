using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Softplan.Common.EntityFrameworkCore.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Maps;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.MCD.Maps;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.TAX.Maps;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack
{
    public class QueryDbContext : MultiTenancyDbContext
    {
        private const string DatabasePropertiesConvertCaseTo = "DATABASE_PROPERTIES_CONVERT_CASE_TO";
        private const string DatabaseProvider = "DATABASE_PROVIDER";
        private const string PostgreSqlProvider = "PostgreSql";
        protected readonly bool ShouldConvertToLowerCase;

        public QueryDbContext(IServiceProvider serviceProvider, IConfiguration configuration) : base(serviceProvider)
        {
            var isLowerCase = configuration
                .GetValue(DatabasePropertiesConvertCaseTo, string.Empty)
                .Equals("Lowercase", StringComparison.OrdinalIgnoreCase);

            var provider = configuration.GetValue(DatabaseProvider, string.Empty);

            ShouldConvertToLowerCase = isLowerCase && provider.Equals(PostgreSqlProvider, StringComparison.OrdinalIgnoreCase);
        }

        protected override void OnMultiTenancyModelCreating(ModelBuilder modelBuilder)
        {
            base.OnMultiTenancyModelCreating(modelBuilder);
            modelBuilder.ApplyTaxonomiaConfigurations(ShouldConvertToLowerCase);
            modelBuilder.ApplyMcdConfigurations(ShouldConvertToLowerCase);
        }
    }
}