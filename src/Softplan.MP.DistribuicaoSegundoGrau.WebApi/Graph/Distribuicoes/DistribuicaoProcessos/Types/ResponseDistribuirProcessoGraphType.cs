using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Events;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.DistribuicaoProcessos.Types
{
    public class ResponseDistribuirProcessoGraphType : Softplan.Common.Graph.Types.ObjectGraphType<DistribuirProcessoResponse>
    {
        public ResponseDistribuirProcessoGraphType(IDescriptionProvider provider) : base(provider)
        {
            Field(x => x.IdProcesso);
            Field(x => x.TransactionId);
            Field(x => x.RegraDistribuicao, true, typeof(RegraDistribuicaoGraphType));
            Field(x => x.Vaga, type: typeof(VagaGraphType));
        }
    }
}