using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public class RegraDistribuicaoAssuntoGraphType : Softplan.Common.Graph.Types.ObjectGraphType<CriterioAssunto>
    {
        public RegraDistribuicaoAssuntoGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.IdAssunto);
            Field(x => x.Id, true);
        }
    }
}