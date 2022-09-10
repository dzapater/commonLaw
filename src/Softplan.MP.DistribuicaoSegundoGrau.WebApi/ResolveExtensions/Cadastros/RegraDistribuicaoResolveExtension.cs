using Microsoft.Extensions.DependencyInjection;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Cadastros
{
    public static class RegraDistribuicaoResolveExtension
    {
        public static  RegraDistribuicaoService RegraDistribuicaoDomainService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<RegraDistribuicaoService>();

        public static  ICrudService<RegraDistribuicao, IdRegraDistribuicao> RegraDistribuicaoCrudService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<ICrudService<RegraDistribuicao, IdRegraDistribuicao>>();

        public static  IRegraDistribuicaoQueryService RegraDistribuicaoQueryService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<IRegraDistribuicaoQueryService>();
        
        public static IReadService<RegraDistribuicao, IdRegraDistribuicao> RegraDistribuicaoReadService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<IReadService<RegraDistribuicao, IdRegraDistribuicao>>();
    }
}