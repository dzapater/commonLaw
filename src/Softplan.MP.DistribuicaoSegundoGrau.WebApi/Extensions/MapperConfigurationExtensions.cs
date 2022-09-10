using AutoMapper;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Extensions
{
    public static class MapperConfigurationExtensions
    {
        public static void ConfigureApplication(this IMapperConfigurationExpression configuration)
            => configuration.AddMaps(new[]
            {
                typeof(QueryDbContext).Assembly
            });
    }
}