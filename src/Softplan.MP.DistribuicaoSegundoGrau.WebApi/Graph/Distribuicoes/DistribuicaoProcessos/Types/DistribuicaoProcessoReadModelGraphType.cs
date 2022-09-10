using GraphQL.Types;
using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Distribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.DistribuicaoProcessos.Types
{
    public class DistribuicaoProcessoReadModelGraphType : Softplan.Common.Graph.Types.ObjectGraphType<DistribuicaoProcessoReadModel>
    {
        public DistribuicaoProcessoReadModelGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.DistribuicaoProcesso.Id);
            Field(x => x.DistribuicaoProcesso.IdProcesso, true);
            Field(x => x.DistribuicaoProcesso.IdVaga, true);
            Field(x => x.DistribuicaoProcesso.Motivo, true);
            Field(x => x.DistribuicaoProcesso.TipoDistribuicao, true, typeof(TipoDistribuicaoGraphType));
            Field(x => x.DistribuicaoProcesso.Logs, true, typeof(ListGraphType<DistribuicaoProcessoLogGraphType>));
        }
    }
}