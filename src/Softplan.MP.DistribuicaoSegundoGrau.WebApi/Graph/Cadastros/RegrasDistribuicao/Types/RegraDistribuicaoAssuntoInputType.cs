using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public class RegraDistribuicaoAssuntoInputType : Softplan.Common.Graph.Types.InputObjectGraphType<CriterioAssunto>
    {
        public RegraDistribuicaoAssuntoInputType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.IdAssunto);
            Field(x => x.Id, true);
        }
    }
}