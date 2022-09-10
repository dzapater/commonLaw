using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Parametros.Repositories.Maps;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure
{
    public class ApplicationDbContext : QuerySajDbContext
    {
        public const string DbSchema = "SAJ";

        public ApplicationDbContext(IServiceProvider provider, IConfiguration configuration) : base(provider, configuration)
        {
        }

        protected override void OnMultiTenancyModelCreating(ModelBuilder modelBuilder)
        {
            base.OnMultiTenancyModelCreating(modelBuilder);
            modelBuilder.ApplyParametroConfigurations(ShouldConvertToLowerCase);
            modelBuilder.HasDefaultSchema(ShouldConvertToLowerCase ? DbSchema.ToLower(CultureInfo.InvariantCulture) : DbSchema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}