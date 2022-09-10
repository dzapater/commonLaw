using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public class RegraDistribuicaoTarjaInputGraphType : Softplan.Common.Graph.Types.InputObjectGraphType<CriterioTarja>
    {
        public RegraDistribuicaoTarjaInputGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.IdTarja);
            Field(x => x.Id, true);
        }
    }
}