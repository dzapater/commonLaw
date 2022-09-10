using System.Collections.Generic;
using System.Reflection;
using Softplan.Common.MessageBus.Abstractions.Bpmn.Components;
using Softplan.Common.MessageBus.Abstractions.Bpmn.DistributedTransactions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Events;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.DistributedTransactions
{
    class DistribuicaoProcessoDistributedTransaction : BpmnMessageBusDistributedTransaction
    {
        private readonly DistribuirProcessoRequest _request;
        private readonly DistribuirProcessoResponse _response;

        public DistribuicaoProcessoDistributedTransaction(DistribuirProcessoRequest request, DistribuirProcessoResponse response)
            : base(Assembly.GetExecutingAssembly(), $"{nameof(DistribuicaoProcessoDistributedTransaction)}.bpmn")
        {
            _request = request;
            _response = response;
        }

        protected override Dictionary<string, object> Variables => new Dictionary<string, object>
        {
            [nameof(_request.TransactionId)] = _request.TransactionId,
            [nameof(_request.IdProcesso)] = _request.IdProcesso,
            [nameof(_request.IdVaga)] = _request.IdVaga,
            [nameof(_request.TipoDistribuicao)] = _request.TipoDistribuicao,
            [nameof(_request.AreaProcesso)] = _request.AreaProcesso,
            [nameof(_request.CodigoForoDestino)] = _request.CodigoForoDestino,
            [nameof(_request.CodigoLocalDestino)] = _request.CodigoLocalDestino,
            [nameof(_request.CodigoTipoLocalDestino)] = _request.CodigoTipoLocalDestino,
            [nameof(_request.Volumes)] = _request.Volumes,
            [nameof(_request.IdRegraDistribuicao)] = _request.IdRegraDistribuicao
        };

        protected override Dictionary<string, BpmnMessageFactory> MapMessages => new Dictionary<string, BpmnMessageFactory>
        {
            ["Agendar Remessa Processo"] = BpmnMessageFactory.Create(new AgendarRemessaProcessoCommand()),
            ["Logar Distribução Processo"] = BpmnMessageFactory.Create(new LogarDistribuicaoProcessoCommand()),
            ["Completed"] = BpmnMessageFactory.Create(_response),
            ["Faulted"] = BpmnMessageFactory.Create(_response)
        };
    }
}