using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoVagasRegrasDistribuicao.Types
{
    public class CreateVinculoVagaRegraDistribuicaoInputType : Softplan.Common.Graph.Types.InputObjectGraphType<VinculoVagaRegraDistribuicao>
    {
        public CreateVinculoVagaRegraDistribuicaoInputType(IDescriptionProvider provider) :
            base(provider)
        {
            Field(x => x.IdVaga);
            Field(x => x.IdRegraDistribuicao);
        }
    }
}