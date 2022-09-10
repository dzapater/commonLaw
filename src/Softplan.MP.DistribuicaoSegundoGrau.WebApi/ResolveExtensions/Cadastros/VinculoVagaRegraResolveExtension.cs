using Microsoft.Extensions.DependencyInjection;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Cadastros
{
    public static class VinculoVagaRegraResolveExtension
    {
        public static VinculoVagaRegraDistribuicaoService VinculoVagaRegraDomainService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<VinculoVagaRegraDistribuicaoService>();
        
        public static ICrudService<VinculoVagaRegraDistribuicao, IdVinculoVagaRegraDistribuicao> VinculoVagaRegraCrudService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<ICrudService<VinculoVagaRegraDistribuicao, IdVinculoVagaRegraDistribuicao>>();
        
        public static IVinculoVagaRegraDistribuicaoQueryService VinculoVagaRegraQueryService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<IVinculoVagaRegraDistribuicaoQueryService>();
    }
}