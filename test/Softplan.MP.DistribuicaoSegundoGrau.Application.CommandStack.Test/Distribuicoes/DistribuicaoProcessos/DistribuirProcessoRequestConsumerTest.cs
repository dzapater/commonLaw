using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Softplan.Common.MessageBus.Abstractions.Consumers.Contexts;
using Softplan.Common.MessageBus.Abstractions.Producers;
using Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.DistributedTransactions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Test.Distribuicoes.DistribuicaoProcessos
{
    public class DistribuirProcessoRequestConsumerTest
    {
        [Fact]
        public async Task Should_Consume_New_Message()
        {
            var consumerContext = new Mock<IConsumerContext<DistribuirProcessoRequest>>();
            var messageProducer = new Mock<IMessageBusProducer>();
            var consumer = new DistribuirProcessoRequestConsumer();
            var message = new DistribuirProcessoRequest
            {
                IdProcesso = "Nome"
            };

            consumerContext.Setup(x => x.Message).Returns(message);
            consumerContext.Setup(x => x.MessageBusProducer).Returns(messageProducer.Object);
            consumerContext.Setup(x => x.RequestId).Returns(Guid.NewGuid);
            consumerContext.Setup(x => x.ResponseAddress).Returns(new Uri("queue:x"));
            
            await consumer.ConsumeAsync(consumerContext.Object, CancellationToken.None);

            messageProducer.Verify(x
                => x.ExecuteDistributedTransactionAsync(message.TransactionId, It.IsAny<DistribuicaoProcessoDistributedTransaction>(),
                    It.IsAny<CancellationToken>()));
        }
    }
}