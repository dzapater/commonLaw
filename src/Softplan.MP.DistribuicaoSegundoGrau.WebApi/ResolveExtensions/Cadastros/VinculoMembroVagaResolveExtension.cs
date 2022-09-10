using Microsoft.Extensions.DependencyInjection;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Cadastros
{
    public static class VinculoMembroVagaResolveExtension
    {
        public static  VinculoMembroVagaService VinculoMembroVagaDomainService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<VinculoMembroVagaService>();

        public static  ICrudService<VinculoMembroVaga, IdVinculoMembroVaga> VinculoMembroVagaCrudService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<ICrudService<VinculoMembroVaga, IdVinculoMembroVaga>>();

        public static  IVinculoMembroVagaQueryService VinculoMembroVagaQueryService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<IVinculoMembroVagaQueryService>();
    }
}