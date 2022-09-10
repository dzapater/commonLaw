using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types
{
    public class OrigemGraphType : Softplan.Common.Graph.Types.ObjectGraphType<CriterioOrigem>
    {
        public OrigemGraphType() 
        {
            Field(x => x.Id);
            Field(x => x.Descricao);           
        }
    }
}