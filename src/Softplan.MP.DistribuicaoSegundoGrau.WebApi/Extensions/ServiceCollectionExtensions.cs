using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Softplan.Common.Core.Extensions;
using Softplan.Common.EntityFrameworkCore.Abstractions.Extensions;
using Softplan.Common.Search.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC.Cache.Redis;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC.Cache.Redis.Interfaces;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC.Constantes;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Providers;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Providers.Interfaces;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSearchServices(configuration);
            services.AddApplicationDbContext(configuration);
            services.AddApplicationSajDsgDbContext(configuration);
            services.AddQueryDbContext(configuration);
            services.AddQueryDbContext2(configuration);
            services.AddUtils();
            services.AddConfigureCacheRedis(configuration);
        }

        private static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
            => services.AddMultiTenancyDbContext<ApplicationDbContext>(defaultConnectionOnly: true,
                lifeTime: configuration.GetValue("DATABASE_PROVIDER", "InMemory")
                    .EqualsIgnoringCase("InMemory")
                    ? ServiceLifetime.Singleton
                    : ServiceLifetime.Scoped);
        
        private static void AddApplicationSajDsgDbContext(this IServiceCollection services, IConfiguration configuration)
            => services.AddMultiTenancyDbContext<ApplicationSajDsgDbContext>(defaultConnectionOnly: false,
                lifeTime: configuration.GetValue("DATABASE_PROVIDER", "InMemory")
                    .EqualsIgnoringCase("InMemory")
                    ? ServiceLifetime.Singleton
                    : ServiceLifetime.Scoped, prefix: "SAJDSG");

        private static void AddQueryDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue("DATABASE_PROVIDER", "InMemory").EqualsIgnoringCase("InMemory"))
                services.AddSingleton<QueryDbContext>(x => x.GetRequiredService<ApplicationSajDsgDbContext>());
            else
                services.AddScoped<QueryDbContext>(x => x.GetRequiredService<ApplicationSajDsgDbContext>());
        }
        
        private static void AddQueryDbContext2(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue("DATABASE_PROVIDER", "InMemory").EqualsIgnoringCase("InMemory"))
                services.AddSingleton<QuerySajDbContext>(x => x.GetRequiredService<ApplicationDbContext>());
            else
                services.AddScoped<QuerySajDbContext>(x => x.GetRequiredService<ApplicationDbContext>());
        }

        private static void AddUtils(this IServiceCollection services)
        {
            services
                .AddScoped(prov => new LotacaoUsuarioLogadoProvider(prov.GetService<IHttpContextAccessor>()))
                .AddScoped<ILotacaoUsuarioLogadoProvider>(prov => prov.GetService<LotacaoUsuarioLogadoProvider>())
                .AddScoped<ILotacaoUsuarioLogadoSetter>(prov => prov.GetService<LotacaoUsuarioLogadoProvider>())
                .AddScoped<IContentCache, ContentCache>();
        }
        
        private static void AddConfigureCacheRedis(this IServiceCollection services, IConfiguration configuration)
        {
            var tempoAtualizacaoCache = configuration.GetValue<long>("CACHE_REDIS_TIMEOUT_SECONDS", 30);
            services.Configure<CacheTimeRedisConfiguration>(options =>
            {
                options.CacheRedisTimeoutSeconds = tempoAtualizacaoCache;
            });
        }
    }
}