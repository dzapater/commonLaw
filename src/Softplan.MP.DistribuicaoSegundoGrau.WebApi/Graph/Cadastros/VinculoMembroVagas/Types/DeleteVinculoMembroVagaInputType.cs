using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas.Types
{
   public class DeleteVinculoMembroVagaInputType : Softplan.Common.Graph.Types.InputObjectGraphType<VinculoMembroVaga>
    {
        public DeleteVinculoMembroVagaInputType(IDescriptionProvider provider) :
            base(provider)
        {
            Field(x => x.Id);
            Field(x => x.IdVaga);
            Field(x => x.IdMembro, true);
        }
    }
}