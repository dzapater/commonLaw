using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoVagasRegrasDistribuicao.Types
{
    public class HistoricoCompensacaoRegraFilterType : Softplan.Common.Graph.Types.InputObjectGraphType<HistoricoCompensacaoRegraFilter>
    {
        public HistoricoCompensacaoRegraFilterType(IDescriptionProvider provider) : base(provider)
        {
            Field(x => x.IdRegraDistribuicao, true);
            Field(x => x.PageNumber, true);
            Field(x => x.PageSize, true);
        }
    }
}