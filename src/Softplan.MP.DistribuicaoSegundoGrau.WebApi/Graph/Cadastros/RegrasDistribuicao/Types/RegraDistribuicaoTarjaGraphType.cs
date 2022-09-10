using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public class RegraDistribuicaoTarjaGraphType : Softplan.Common.Graph.Types.ObjectGraphType<CriterioTarja>
    {
        public RegraDistribuicaoTarjaGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.IdTarja);
            Field(x => x.Id, true);
        }
    }
}