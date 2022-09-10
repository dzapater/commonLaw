using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoVagasRegrasDistribuicao.Types
{
    public class VinculoVagaRegraDistribuicaoGraphType : Softplan.Common.Graph.Types.ObjectGraphType<VinculoVagaRegraDistribuicao>
    {
        public VinculoVagaRegraDistribuicaoGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.IdVaga);
            Field(x => x.IdRegraDistribuicao);
        }
    }
}