using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public class RegraDistribuicaoOrgaoJulgadorGraphType : Softplan.Common.Graph.Types.ObjectGraphType<CriterioOrgaoJulgador>
    {
        public RegraDistribuicaoOrgaoJulgadorGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.IdOrigem);
            Field(x => x.IdOrgaoJulgador);
            Field(x => x.Id, true);
        }
    }
}