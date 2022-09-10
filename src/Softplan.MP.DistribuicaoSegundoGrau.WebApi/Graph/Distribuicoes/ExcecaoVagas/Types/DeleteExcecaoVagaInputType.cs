using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.ExcecaoVagas.Types
{
    public class DeleteExcecaoVagaInputType : Softplan.Common.Graph.Types.InputObjectGraphType<ExcecaoVaga>
    {
        public DeleteExcecaoVagaInputType(IDescriptionProvider provider) :
            base(provider)
        {
            Field(x => x.Id);
        }
    }
}