using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public class DeleteRegraDistribuicaoInputType : Softplan.Common.Graph.Types.InputObjectGraphType<RegraDistribuicao>
    {
        public DeleteRegraDistribuicaoInputType(IDescriptionProvider provider) :
            base(provider)
        {
            Field(x => x.Id);
        }
    }
}