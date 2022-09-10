using Softplan.Common.Core.Entities.Pages.Abstractions;
using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.AnaliseProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.AnaliseProcessos.Types
{
    public class AnaliseProcessoFilterType : Softplan.Common.Graph.Types.InputObjectGraphType<AnaliseProcessoFilter>
    {
        public AnaliseProcessoFilterType(IDescriptionProvider provider) : base(provider)
        {
            Field(x => x.IdProcesso, true);            
        }
    }    
}