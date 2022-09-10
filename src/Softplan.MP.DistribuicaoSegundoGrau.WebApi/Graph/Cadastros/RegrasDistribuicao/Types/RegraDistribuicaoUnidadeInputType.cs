using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public class RegraDistribuicaoUnidadeInputType : Softplan.Common.Graph.Types.InputObjectGraphType<CriterioUnidade>
    {
        public RegraDistribuicaoUnidadeInputType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.IdOrigem);
            Field(x => x.IdUnidade);
            Field(x => x.Id, true);
            Field(x => x.IdTipoCadastro, true);
        }
    }
}