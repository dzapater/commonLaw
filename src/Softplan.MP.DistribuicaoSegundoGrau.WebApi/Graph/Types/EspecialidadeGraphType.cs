using Softplan.Common.Graph.Types.Federation;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types
{
    public class EspecialidadeGraphType : FederatedObjectGraphType<CriterioEspecialidade>
    {
        public EspecialidadeGraphType() : base("MCD")
        {
            Name = "EspecialidadeResponseMessageGraphType";
            Key(x => x.IdEspecialidade).Name("id");
            
        }
    }
}