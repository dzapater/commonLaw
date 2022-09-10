using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public class RegraDistribuicaoFilterType : Softplan.Common.Graph.Types.InputObjectGraphType<RegraDistribuicaoFilter>
    {
        public RegraDistribuicaoFilterType(IDescriptionProvider provider) : base(provider)
        {
            Field(x => x.Busca, true);
            Field(x => x.Ativos, true);
            Field(x => x.PageNumber, true);
            Field(x => x.PageSize, true);
            Field(x => x.IdOrgao, true);
            Field(x => x.IdClasse, true);
            Field(x => x.IdEspecialidade, true);
            Field(x => x.IdOrigem, true);
            Field(x => x.IdUnidade, true);
            Field(x => x.IdTarja, true);
            Field(x => x.IdAssunto, true);
            Field(x => x.Area, true, typeof(AreaGraphType));
            Field(x => x.Situacao, true, typeof(SituacaoGraphType));
            Field(x => x.TipoProcesso, true, typeof(TipoProcessoGraphType));
            Field(x => x.EscopoEquilibrio, true, typeof(EscopoEquilibrioGraphType));
            Field(x => x.VariavelEquilibrio, true, typeof(VariavelEquilibrioGraphType));
            Field(x => x.Descricao, true);
        }
    }
}