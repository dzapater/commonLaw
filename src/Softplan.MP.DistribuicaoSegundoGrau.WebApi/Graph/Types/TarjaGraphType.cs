using Softplan.Common.Graph.Types.Federation;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types
{
    public class TarjaGraphType : FederatedObjectGraphType<CriterioTarja>
    {
        public TarjaGraphType() : base("TAX")
        {
            Name = "TarjaResponseMessageGraphType";
            Key(x => x.IdTarja).Name("id");
        }
    }
}