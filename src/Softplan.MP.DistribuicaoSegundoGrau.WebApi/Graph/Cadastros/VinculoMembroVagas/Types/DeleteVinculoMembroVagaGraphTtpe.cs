using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas.Types
{
    public class DeleteVinculoMembroVagaGraphTtpe : Softplan.Common.Graph.Types.InputObjectGraphType<VinculoMembroVaga>
    {
        public DeleteVinculoMembroVagaGraphTtpe(IDescriptionProvider provider) :
            base(provider)
        {
            Field(x => x.Id);
        }
    }
}