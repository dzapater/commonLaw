using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public class RegraDistribuicaoClasseInputType : Softplan.Common.Graph.Types.InputObjectGraphType<CriterioClasse>
    {
        public RegraDistribuicaoClasseInputType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.IdClasse);
            Field(x => x.Id, true);
        }
    }
}