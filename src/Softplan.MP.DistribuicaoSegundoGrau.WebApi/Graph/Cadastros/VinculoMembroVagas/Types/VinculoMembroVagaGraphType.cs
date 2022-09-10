using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas.Types
{
    public class VinculoMembroVagaGraphType : Softplan.Common.Graph.Types.ObjectGraphType<VinculoMembroVaga>
    {
        public VinculoMembroVagaGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.Id);
            Field(x => x.IdVaga);
            Field(x => x.IdMembro);
            Field(x => x.IdMotivoMembroVaga);
            Field(x => x.Observacao,true);
            Field(x => x.DataInicial);
            Field(x => x.DataFinal,true);
        }
    }
}
