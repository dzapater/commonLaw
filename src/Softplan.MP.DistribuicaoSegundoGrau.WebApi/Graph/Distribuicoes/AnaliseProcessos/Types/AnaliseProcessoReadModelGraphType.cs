using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.AnaliseProcessos.Types
{
    public class AnaliseProcessoReadModelGraphType : Softplan.Common.Graph.Types.ObjectGraphType<AnaliseProcessoReadModel>
    {
        public AnaliseProcessoReadModelGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.IdProcesso);
            Field(x => x.Vaga, true, typeof(VagaGraphType));
            Field(x => x.Motivo, true);
            Field(x => x.AreaAtuacao, true, typeof(AreaAtuacaoGraphType));
            Field(x => x.TipoDistribuicao, false, typeof(TipoDistribuicaoGraphType));
            Field(x => x.Processo, true, typeof(ProcessoGraphType));
        }
    }
}