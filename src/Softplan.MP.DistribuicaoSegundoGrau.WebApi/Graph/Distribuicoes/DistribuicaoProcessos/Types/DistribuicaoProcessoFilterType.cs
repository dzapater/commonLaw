using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Distribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.DistribuicaoProcessos.Types
{
    public class DistribuicaoProcessoFilterType: Softplan.Common.Graph.Types.InputObjectGraphType<DistribuicaoProcessoFilter>
    {
        
        public DistribuicaoProcessoFilterType(IDescriptionProvider provider) : base(provider)
        {
            Field(x => x.Id, true);
            Field(x => x.IdProcesso, true);
            Field(x => x.PageNumber, true); 
            Field(x => x.PageSize, true); 
        }
        
    }
}