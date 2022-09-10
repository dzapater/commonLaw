using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure
{
    public class ApplicationSajDsgDbContext : QueryDbContext
    {
        public const string DbSchema = "SAJDSG";

        public ApplicationSajDsgDbContext(IServiceProvider provider, IConfiguration configuration) : base(provider, configuration)
        {
        }

        protected override void OnMultiTenancyModelCreating(ModelBuilder modelBuilder)
        {
            base.OnMultiTenancyModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(ShouldConvertToLowerCase ? DbSchema.ToLower(CultureInfo.InvariantCulture) : DbSchema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationSajDsgDbContext).Assembly);
        }
    }
}