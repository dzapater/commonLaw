using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public class RegraDistribuicaoClasseGraphType : Softplan.Common.Graph.Types.ObjectGraphType<CriterioClasse>
    {
        public RegraDistribuicaoClasseGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.IdClasse);
            Field(x => x.Id, true);
        }
    }
}