using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Softplan.Common.MessageBus.Abstractions.DistributedTransactions.Contexts;
using Softplan.Common.MessageBus.Abstractions.DistributedTransactions.Contexts.Notifications;
using Softplan.Common.MessageBus.Messages.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.DistributedTransactions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Documents;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Events;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Test.DistributedTransactions

{
    public class DistribuicaoProcessoDistributedTransactionTest
    {
        [Fact]
        public async Task Should_Parse_Bpmn()
        {
            var builder = new Mock<IDistributedTransactionBuilder>(MockBehavior.Strict);
            var notificationBuilder = new Mock<IDistributedTransactionNotificationBuilder>();
            var builderSequence = new MockSequence();
            var request = new DistribuirProcessoRequest
            {
                IdProcesso = "processo", Volumes = 1, IdRegraDistribuicao = 1, 
                IdVaga = 1, CodigoForoDestino = 2,
                CodigoLocalDestino = 3, CodigoTipoLocalDestino = 4
            };
            var response = new DistribuirProcessoResponse
            {
                RequestId = Guid.NewGuid(), ResponseAddress = new Uri("somequeue:").ToString(),
                IdProcesso = "processo", TransactionId = request.TransactionId
            };
            var transaction = new DistribuicaoProcessoDistributedTransaction(request, response);

            builder.InSequence(builderSequence).Setup(x => x.AddVariable("TransactionId", request.TransactionId))
                .Returns(builder.Object);
            builder.InSequence(builderSequence).Setup(x => x.AddVariable("IdProcesso", request.IdProcesso))
                .Returns(builder.Object);
            builder.InSequence(builderSequence).Setup(x => x.AddVariable("IdVaga", request.IdVaga))
                .Returns(builder.Object);
            builder.InSequence(builderSequence).Setup(x => x.AddVariable("TipoDistribuicao", request.TipoDistribuicao))
                .Returns(builder.Object);
            builder.InSequence(builderSequence).Setup(x => x.AddVariable("AreaProcesso", request.AreaProcesso))
                .Returns(builder.Object);
            builder.InSequence(builderSequence).Setup(x => x.AddVariable("CodigoForoDestino", request.CodigoForoDestino))
                .Returns(builder.Object);
            builder.InSequence(builderSequence).Setup(x => x.AddVariable("CodigoLocalDestino", request.CodigoLocalDestino))
                .Returns(builder.Object);
            builder.InSequence(builderSequence).Setup(x => x.AddVariable("CodigoTipoLocalDestino", request.CodigoTipoLocalDestino))
                .Returns(builder.Object);
            builder.InSequence(builderSequence).Setup(x => x.AddVariable("Volumes", request.Volumes))
                .Returns(builder.Object);
            builder.InSequence(builderSequence).Setup(x => x.AddVariable("IdRegraDistribuicao", request.IdRegraDistribuicao))
                .Returns(builder.Object);

            builder.InSequence(builderSequence).Setup(x => x.AddStep(It.IsAny<ICommandMessage>(), It.IsAny<Action<IDistributedTransactionNotificationBuilder>>()))
                .Callback<ICommandMessage, Action<IDistributedTransactionNotificationBuilder>>((message, notification) =>
                {
                    message.Should().BeAssignableTo<AgendarRemessaProcessoCommand>();
                    notification(notificationBuilder.Object);
                }).Returns(builder.Object);

            builder.InSequence(builderSequence).Setup(x => x.AddStep(It.IsAny<ICommandMessage>(), It.IsAny<Action<IDistributedTransactionNotificationBuilder>>()))
                .Callback<ICommandMessage, Action<IDistributedTransactionNotificationBuilder>>((message, notification) =>
                {
                    message.Should().BeAssignableTo<LogarDistribuicaoProcessoCommand>();
                    notification(notificationBuilder.Object);
                }).Returns(builder.Object);

            builder.InSequence(builderSequence).Setup(x => x.AddOnCompletedNotification(It.IsAny<IMessage>()))
                .Callback<IMessage>(message => { message.Should().BeEquivalentTo(response); })
                .Returns(builder.Object);

            builder.InSequence(builderSequence).Setup(x => x.AddOnFaultedNotification(It.IsAny<IMessage>()))
                .Callback<IMessage>(message => { message.Should().BeEquivalentTo(response); })
                .Returns(builder.Object);

            (await transaction.Setup()).Invoke(builder.Object);

            builder.VerifyAll();
            notificationBuilder.VerifyAll();
        }
    }
}