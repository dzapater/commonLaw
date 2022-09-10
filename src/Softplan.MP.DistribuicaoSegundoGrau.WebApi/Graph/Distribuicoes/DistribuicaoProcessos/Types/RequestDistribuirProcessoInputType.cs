using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.DistribuicaoProcessos.Types
{
    public class RequestDistribuirProcessoInputType : Softplan.Common.Graph.Types.InputObjectGraphType<DistribuirProcessoRequest>
    {
        public RequestDistribuirProcessoInputType(IDescriptionProvider provider) : base(provider)
        {
            Field(x => x.IdProcesso);
            Field(x => x.TipoDistribuicao, false, typeof(TipoDistribuicaoGraphType));
            Field(x => x.IdVaga, true);
            Field(x => x.Motivo, true);
        }
    }
}