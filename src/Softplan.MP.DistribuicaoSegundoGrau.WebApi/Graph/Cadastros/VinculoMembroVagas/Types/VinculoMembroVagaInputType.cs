using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas.Types
{
    public class VinculoMembroVagaInputType : Softplan.Common.Graph.Types.InputObjectGraphType<VinculoMembroVaga>
    {
        protected VinculoMembroVagaInputType(IDescriptionProvider provider) :
            base(provider)
        {
            Field(x => x.IdVaga);
            Field(x => x.IdMembro);
            Field(x => x.IdMotivoMembroVaga);
            Field(x => x.DataInial);
            Field(x => x.DataFinal);
        }
    }
}