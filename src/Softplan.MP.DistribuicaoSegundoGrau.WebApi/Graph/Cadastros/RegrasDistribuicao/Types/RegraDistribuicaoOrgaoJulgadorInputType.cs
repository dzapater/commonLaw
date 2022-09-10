using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public class RegraDistribuicaoOrgaoJulgadorInputType : Softplan.Common.Graph.Types.InputObjectGraphType<CriterioOrgaoJulgador>
    {
        public RegraDistribuicaoOrgaoJulgadorInputType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.IdOrigem);
            Field(x => x.IdUnidade);
            Field(x => x.IdOrgaoJulgador);
            Field(x => x.Id, true);
            Field(x => x.IdTipoCadastro, true);
        }
    }
}