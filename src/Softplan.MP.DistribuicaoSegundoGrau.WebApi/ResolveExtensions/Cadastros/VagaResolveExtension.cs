using Microsoft.Extensions.DependencyInjection;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Cadastros
{
    public static class VagaResolveExtension
    {
        public static VagaService VagaDomainService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<VagaService>();

        public static ICrudService<Vaga, IdVaga> VagaCrudService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<ICrudService<Vaga, IdVaga>>();

        public static IVagaQueryService VagaQueryService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<IVagaQueryService>();
        
        public static IReadService<Vaga, IdVaga> VagaReadService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<IReadService<Vaga, IdVaga>>();
    }
}