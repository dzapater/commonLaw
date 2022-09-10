using Microsoft.Extensions.DependencyInjection;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.ExcecaoVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Cadastros
{
    public static class ExcecaoVagaResolveExtension
    {
        public static ExcecaoVagaService ExcecaoVagaDomainService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<ExcecaoVagaService>();

        public static ICrudService<ExcecaoVaga, IdExcecaoVaga> ExcecaoVagaCrudService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<ICrudService<ExcecaoVaga, IdExcecaoVaga>>();

        public static IExcecaoVagaQueryService ExcecaoVagaQueryService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<IExcecaoVagaQueryService>();               
        
        public static IReadService<ExcecaoVaga, IdExcecaoVaga> ExcecaoVagaReadService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<IReadService<ExcecaoVaga, IdExcecaoVaga>>();
    }
}