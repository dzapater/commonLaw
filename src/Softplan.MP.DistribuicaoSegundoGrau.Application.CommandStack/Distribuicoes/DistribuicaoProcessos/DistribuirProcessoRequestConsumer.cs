using System.Threading;
using System.Threading.Tasks;
using Softplan.Common.MessageBus.Abstractions.Consumers;
using Softplan.Common.MessageBus.Abstractions.Consumers.Contexts;
using Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.DistributedTransactions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Events;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Distribuicoes.DistribuicaoProcessos
{
    class DistribuirProcessoRequestConsumer : IMessageBusConsumer<DistribuirProcessoRequest>
    {
        public async Task ConsumeAsync(IConsumerContext<DistribuirProcessoRequest> consumerContext, CancellationToken cancellationToken)
        {
            var distributedTransaction = new DistribuicaoProcessoDistributedTransaction(consumerContext.Message, new DistribuirProcessoResponse
            {
                RequestId = consumerContext.RequestId, ResponseAddress = consumerContext.ResponseAddress.ToString(),
                IdProcesso = consumerContext.Message.IdProcesso, TransactionId = consumerContext.Message.TransactionId
            });

            await consumerContext.MessageBusProducer.ExecuteDistributedTransactionAsync(
                consumerContext.Message.TransactionId, distributedTransaction, cancellationToken);
        }
    }
}