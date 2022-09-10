using System;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Softplan.Common.Core;
using Softplan.Common.Core.Entities;
using Softplan.Common.EntityFrameworkCore.Abstractions.UnitOfWorks;
using Softplan.Common.MessageBus.Abstractions.DistributedTransactions;
using Softplan.Common.MessageBus.Abstractions.DistributedTransactions.Contexts;
using Softplan.Common.MessageBus.Abstractions.Producers;
using Softplan.Common.Repositories.Abstractions;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Test.Distribuicoes.DistribuicaoProcessos
{
    public class LogarDistribuicaoProcessoTransactionStepTest
    {
        [Fact]
        public async Task Should_Consume_New_Message()
        {
            var consumerContext = new Mock<IDistributedTransactionContext<LogarDistribuicaoProcessoCommand>>();
            var messageProducer = new Mock<IMessageBusProducer>();
            var deduplicationRepository = new Mock<IReadRepository<DistribuicaoProcesso, SimpleId<long>>>();
            var crudService = new Mock<ICrudService<DistribuicaoProcesso, SimpleId<long>>>();
            var unit = new Mock<IUnitOfWork>();
            var principal = new Mock<ISoftplanPrincipal>();
            var applicationService = new DistribuicaoProcessoApplicationService(unit.Object, principal.Object, crudService.Object, deduplicationRepository.Object);
            var consumer = new LogarDistribuicaoProcessoTransactionStep(deduplicationRepository.Object, applicationService);
            var message = new LogarDistribuicaoProcessoCommand
            {
                TransactionId = Guid.NewGuid(), IdProcesso = "Processo", TipoDistribuicao = TipoDistribuicao.Prevencao,
                Motivo = "motivo", IdVaga = 1, CodigoForoDestino = 2, CodigoLocalDestino = 3, CodigoTipoLocalDestino = 4,
                IdLoteDistribuicao = 5
            };

            principal.Setup(x => x.Identity).Returns(new GenericIdentity("principal"));
            consumerContext.Setup(x => x.Message).Returns(message);
            consumerContext.Setup(x => x.MessageBusProducer).Returns(messageProducer.Object);
            consumerContext.Setup(x => x.ResultBuilder).Returns(new DistributedTransactionStepResultBuilder());

            unit.Setup(x => x.ExecuteAsync(It.IsAny<Func<Task>>()))
                .Returns<Func<Task>>(onExecute => onExecute());

            var result = await consumer.ExecuteAsync(consumerContext.Object, CancellationToken.None);

            crudService.Verify(x => x.AddAsync(It.IsAny<DistribuicaoProcesso>()), Times.Once);

            result.Error.Should().BeNull();
        }

        [Fact]
        public async Task Should_Consume_Duplicated_Message()
        {
            var consumerContext = new Mock<IDistributedTransactionContext<LogarDistribuicaoProcessoCommand>>();
            var messageProducer = new Mock<IMessageBusProducer>();
            var deduplicationRepository = new Mock<IReadRepository<DistribuicaoProcesso, SimpleId<long>>>();
            var crudService = new Mock<ICrudService<DistribuicaoProcesso, SimpleId<long>>>();
            var unit = new Mock<IUnitOfWork>();
            var applicationService = new DistribuicaoProcessoApplicationService(unit.Object, Mock.Of<ISoftplanPrincipal>(), crudService.Object, deduplicationRepository.Object);
            var consumer = new LogarDistribuicaoProcessoTransactionStep(deduplicationRepository.Object, applicationService);
            var message = new LogarDistribuicaoProcessoCommand
            {
                TransactionId = Guid.NewGuid(), IdProcesso = "Processo", TipoDistribuicao = TipoDistribuicao.Prevencao,
                Motivo = "motivo", IdVaga = 1, CodigoForoDestino = 2, CodigoLocalDestino = 3, CodigoTipoLocalDestino = 4,
                IdLoteDistribuicao = 5
            };

            consumerContext.Setup(x => x.Message).Returns(message);
            consumerContext.Setup(x => x.MessageBusProducer).Returns(messageProducer.Object);
            consumerContext.Setup(x => x.ResultBuilder).Returns(new DistributedTransactionStepResultBuilder());

            unit.Setup(x => x.ExecuteAsync(It.IsAny<Func<Task>>()))
                .Returns<Func<Task>>(onExecute => onExecute());

            deduplicationRepository.Setup(x => x.GetFirstAsync(
                    It.IsAny<Expression<Func<DistribuicaoProcesso, bool>>>()))
                .ReturnsAsync(DistribuicaoProcesso.Create(consumerContext.Object.Message));

            var result = await consumer.ExecuteAsync(consumerContext.Object, CancellationToken.None);

            crudService.Verify(x => x.AddAsync(It.IsAny<DistribuicaoProcesso>()), Times.Never);

            result.Error.Should().BeNull();
        }
    }
}