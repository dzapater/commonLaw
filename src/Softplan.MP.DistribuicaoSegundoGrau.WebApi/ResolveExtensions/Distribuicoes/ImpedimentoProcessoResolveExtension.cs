using GraphQL.Utilities;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Impedimento;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Distribuicoes
{
    public static class ImpedimentoProcessoResolveExtension
    {
        public static ImpedimentoProcessoService ImpedimentoProcessoDomainService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<ImpedimentoProcessoService>();

        public static ICrudService<ImpedimentoProcesso, IdImpedimentoProcesso> ImpedimentoProcessoCrudService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<ICrudService<ImpedimentoProcesso, IdImpedimentoProcesso>>();

        public static IReadService<ImpedimentoProcesso, IdImpedimentoProcesso> ImpedimentoProcessoReadService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<IReadService<ImpedimentoProcesso, IdImpedimentoProcesso>>();

        public static IImpedimentoProcessoQueryService ImpedimentoVagaQueryService(this IGraphBuilderResolve resolve)
          => resolve.Provider.GetRequiredService<IImpedimentoProcessoQueryService>();
    }
}