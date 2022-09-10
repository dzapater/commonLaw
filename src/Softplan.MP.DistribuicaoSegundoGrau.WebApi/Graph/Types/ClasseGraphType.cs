using Softplan.Common.Graph.Types.Federation;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types
{
    public class ClasseGraphType : FederatedObjectGraphType<CriterioClasse>
    {
        public ClasseGraphType() : base("TAX")
        {
            Name = "ClasseResponseMessageGraphType";
            Key(x => x.IdClasse).Name("id");
        }
    }
}