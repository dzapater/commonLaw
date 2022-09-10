using Softplan.Common.Graph.Types.Federation;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types
{
    public class AssuntoGraphType : FederatedObjectGraphType<CriterioAssunto>
    {
        public AssuntoGraphType() : base("TAX")
        {
            Name = "AssuntoResponseMessageGraphType";
            Key(x => x.IdAssunto).Name("id");
        }
    }
}