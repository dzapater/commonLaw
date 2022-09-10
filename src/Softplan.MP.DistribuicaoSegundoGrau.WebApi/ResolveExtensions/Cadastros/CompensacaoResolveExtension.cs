using Microsoft.Extensions.DependencyInjection;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Cadastros
{
    public static class CompensacaoResolveExtension
    {
        public static ICrudService<CompensacaoLog, IdCompensacaoLog> CompensacaoCrudService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<ICrudService<CompensacaoLog, IdCompensacaoLog>>(); 
        
        public static IHistoricoCompensacaoRegraQueryService HistoricoCompensacaoQueryService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<IHistoricoCompensacaoRegraQueryService>();
    }
}