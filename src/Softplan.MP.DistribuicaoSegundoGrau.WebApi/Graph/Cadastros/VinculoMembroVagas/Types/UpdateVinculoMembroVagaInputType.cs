using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas.Types
{
    public class UpdateVinculoMembroVagaInputType : Softplan.Common.Graph.Types.InputObjectGraphType<VinculoMembroVaga>
    {
        public UpdateVinculoMembroVagaInputType(IDescriptionProvider provider) :
            base(provider) 
        {
            Field(x => x.Id);
            Field(x => x.IdVaga);
            Field(x => x.IdMembro, true);
            Field(x => x.IdMotivoMembroVaga);
            Field(x => x.Observacao, true);
            Field(x => x.DataInicial);
            Field(x => x.DataFinal,true);
        }
    }
}