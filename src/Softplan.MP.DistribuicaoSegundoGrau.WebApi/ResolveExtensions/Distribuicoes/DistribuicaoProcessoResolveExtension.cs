using Microsoft.Extensions.DependencyInjection;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Impedimento;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.MCD;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Distribuicoes
{
    public static class DistribuicaoProcessoResolveExtension
    {        
        public static DistribuicaoProcessoService DistribuicaoProcessoService(this IGraphBuilderResolve resolve)
        => resolve.Provider.GetRequiredService<DistribuicaoProcessoService>();      
 
    }
}