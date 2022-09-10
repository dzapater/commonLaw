using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.AnaliseProcessos.Types
{
    public class AnalisarProcessoInputType : Softplan.Common.Graph.Types.InputObjectGraphType<AnaliseProcesso>
    {
        public AnalisarProcessoInputType(IDescriptionProvider provider) :
            base(provider)
        {
            Field(x => x.IdProcesso);
            Field(x => x.IdVaga, true);
            Field(x => x.Motivo, true);
            Field(x => x.AreaAtuacao, true, typeof(AreaAtuacaoInputType));
            Field(x => x.TipoDistribuicao, false, typeof(TipoDistribuicaoGraphType));
        }
    }
}