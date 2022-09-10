using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;
using Softplan.SAJ.Core.Entities.Lotacoes;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types
{
    public class VagaFilterType : Softplan.Common.Graph.Types.InputObjectGraphType<VagaFilter>
    {
        public VagaFilterType(IDescriptionProvider provider) : base(provider)
        {
            Field(x => x.Id, true);
            Field(x => x.Busca, true);
            Field(x => x.Ativos, true);
            Field(x => x.IdOrgao, true);
            Field(x => x.IdArea, true, typeof(AreaGraphType));
            Field(x => x.Situacao, true, typeof(SituacaoGraphType));
            Field(x => x.IdProcuradorTitular, true);
            Field(x => x.IdMembroAtividade, true);
            Field(x => x.PermiteReuPreso, true);
            Field(x => x.PermiteDistribuicao, true);
            Field(x => x.ConsiderarConfiguracoes, true);
            Field(x => x.PageNumber, true);
            Field(x => x.PageSize, true);
            Field(x => x.Vinculadas, true);
            Field(x => x.EscopoEquilibrio, true, typeof(EscopoEquilibrioGraphType));
            Field(x => x.EscopoEquilibrioLocalOuIndefinido, true);
        }
    }
}