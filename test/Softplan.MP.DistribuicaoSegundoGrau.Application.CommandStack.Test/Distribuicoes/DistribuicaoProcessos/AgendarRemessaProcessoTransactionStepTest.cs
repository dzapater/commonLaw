using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Softplan.Common.DistributedLock.Abstractions;
using Softplan.Common.MessageBus.Abstractions.DistributedTransactions;
using Softplan.Common.MessageBus.Abstractions.DistributedTransactions.Contexts;
using Softplan.Common.MessageBus.Abstractions.Producers;
using Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.MPC;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Test.Distribuicoes.DistribuicaoProcessos
{
    public class AgendarRemessaProcessoTransactionStepTest
    {
        [Fact]
        public async Task Should_Consume_New_Message()
        {
            var consumerContext = new Mock<IDistributedTransactionContext<AgendarRemessaProcessoCommand>>();
            var messageProducer = new Mock<IMessageBusProducer>();
            var distributedLock = new Mock<IDistributedLock>();
            var mcpGatewayService = new Mock<IMpcGatewayService>();
            var provider = new Mock<IServiceProvider>();
            provider.Setup(x => x.GetService(typeof(IDistributedLock))).Returns(distributedLock.Object);
            provider.Setup(x => x.GetService(typeof(IMpcGatewayService))).Returns(mcpGatewayService.Object);
            
            var consumer = new AgendarRemessaProcessoTransactionStep(provider.Object);
            var message = new AgendarRemessaProcessoCommand
            {
                IdProcesso = "Processo"
            };
            
            consumerContext.Setup(x => x.Message).Returns(message);
            consumerContext.Setup(x => x.MessageBusProducer).Returns(messageProducer.Object);
            consumerContext.Setup(x => x.ResultBuilder).Returns(new DistributedTransactionStepResultBuilder());

            mcpGatewayService.Setup(x => x.AgendarRemessaProcesso(It.IsAny<RemessaProcessoInputType>()))
                .ReturnsAsync(new LoteDistribuicaoGraphType
                {
                    Id = 9999
                });

            distributedLock.Setup(x => x.LockAsync("AgendarRemessaProcessoTransactionStep:Processo", It.IsAny<Func<Task>>(), It.IsAny<Func<Task>>()))
                .Returns<string, Func<Task>, Func<Task>>((key, onExecute, onTimedOut) => onExecute());

            var result = await consumer.ExecuteAsync(consumerContext.Object, CancellationToken.None);
            result.Error.Should().BeNull();
            result.Variables.Should().ContainKey("IdLoteDistribuicao");
            result.Variables["IdLoteDistribuicao"].Should().Be(9999);
        }
    }
}