using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.AnaliseProcessos.Types
{
    public class AnaliseProcessoFormatadoGraphType : Softplan.Common.Graph.Types.ObjectGraphType<AnaliseProcessoFormatado>
    {
        public AnaliseProcessoFormatadoGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.IdProcesso);
            Field(x => x.IdVaga, true);
            Field(x => x.Motivo, true);
            Field(x => x.AreaAtuacao, true, typeof(AreaAtuacaoGraphType));
            Field(x => x.TipoDistribuicao, false, typeof(TipoDistribuicaoGraphType));
            Field(x => x.Processo, true, typeof(ProcessoGraphType));
        }
    }
}