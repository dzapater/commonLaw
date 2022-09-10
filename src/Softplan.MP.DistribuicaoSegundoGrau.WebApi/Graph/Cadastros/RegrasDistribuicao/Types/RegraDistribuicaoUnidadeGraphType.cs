using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public class RegraDistribuicaoUnidadeGraphType : Softplan.Common.Graph.Types.ObjectGraphType<CriterioUnidade>
    {
        public RegraDistribuicaoUnidadeGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.IdOrigem);
            Field(x => x.IdUnidade);
            Field(x => x.Id, true);
        }
    }
}