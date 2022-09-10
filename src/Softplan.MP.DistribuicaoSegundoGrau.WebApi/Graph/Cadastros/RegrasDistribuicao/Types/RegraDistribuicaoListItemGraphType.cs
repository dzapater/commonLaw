using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public class RegraDistribuicaoListItemGraphType : Softplan.Common.Graph.Types.ObjectGraphType<RegraDistribuicaoReadModel>
    {
        public RegraDistribuicaoListItemGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.Id);
            Field(x => x.Descricao);
            Field(x => x.Criterios);
            Field(x => x.Ativo);
            Field(x => x.ExisteRegraPendente);
            Field(x => x.DataAtualizacao);
            Field(x => x.QuantidadeVagasVinculadas);
            Field(x => x.QuantidadeVagasVinculadasAtivas);
            Field(x => x.Area,true, type: typeof(AreaGraphType));
            Field(x => x.VariavelEquilibrio, type: typeof(VariavelEquilibrioGraphType));
            Field(x => x.EscopoEquilibrio, type: typeof(EscopoEquilibrioGraphType));
            Field(x => x.TipoProcesso,true, type: typeof(TipoProcessoGraphType));
            Field(x => x.Situacao, type: typeof(SituacaoGraphType));
            Field(x => x.CdLocal);
        }
    }
}