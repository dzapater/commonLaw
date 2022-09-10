using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoVagasRegrasDistribuicao.Types
{
    public class CompensacaoGraphType : Softplan.Common.Graph.Types.ObjectGraphType<Compensacao>
    {
        public CompensacaoGraphType(IDescriptionProvider provider) :
            base(provider)
        {
            Field(x => x.IdRegraDistribuicao);
            Field(x => x.Motivo);
        }
    }
}