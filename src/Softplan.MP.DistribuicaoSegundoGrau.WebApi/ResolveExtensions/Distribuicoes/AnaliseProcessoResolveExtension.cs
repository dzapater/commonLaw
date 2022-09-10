using Microsoft.Extensions.DependencyInjection;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Repositories.Abstractions;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Impedimento;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.MCD;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Distribuicoes
{
    public static class AnaliseProcessoResolveExtension
    {
        public static ICrudService<AnaliseProcesso, IdAnaliseProcesso> AnaliseProcessoCrudService(this IGraphBuilderResolve resolve)
        => resolve.Provider.GetRequiredService<ICrudService<AnaliseProcesso, IdAnaliseProcesso>>();

        public static AnalisarProcessoService AnaliseProcessoDomainService(this IGraphBuilderResolve resolve)
        => resolve.Provider.GetRequiredService<AnalisarProcessoService>();
        
        public static IAnaliseProcessosQueryService AnaliseProcessosQueryService(this IGraphBuilderResolve resolve)
        => resolve.Provider.GetRequiredService<IAnaliseProcessosQueryService>();
        
        public static IReadService<AnaliseProcesso, IdAnaliseProcesso> AnaliseProcessoReadService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<IReadService<AnaliseProcesso, IdAnaliseProcesso>>();
    }
}