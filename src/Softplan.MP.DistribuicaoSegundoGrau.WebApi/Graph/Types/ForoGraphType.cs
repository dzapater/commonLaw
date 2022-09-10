using Softplan.Common.Graph.Types;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.TAX;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types
{
    public class ForoGraphType: ObjectGraphType<ForoReadModel>
    {
        public ForoGraphType()
        {
            Field(x => x.IdOrigem);
            Field(x => x.IdForo);
        }
    }
}