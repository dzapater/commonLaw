using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoVagasRegrasDistribuicao.Types
{
    public class VinculoVagaRegraDistribuicaoFilterType : Softplan.Common.Graph.Types.InputObjectGraphType<VinculoVagaRegraDistribuicaoFilter>
    {
        public VinculoVagaRegraDistribuicaoFilterType(IDescriptionProvider provider) : base(provider)
        {
            Field(x => x.IdVaga, true);
            Field(x => x.IdRegraDistribuicao, true);
            Field(x => x.Busca, true);
            Field(x => x.PageNumber, true);
            Field(x => x.PageSize, true);
        }
    }
}