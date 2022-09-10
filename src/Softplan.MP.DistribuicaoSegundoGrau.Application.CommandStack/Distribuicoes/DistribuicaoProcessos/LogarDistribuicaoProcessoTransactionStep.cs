using System.Threading.Tasks;
using Softplan.Common.MessageBus.Abstractions.Attributes;
using Softplan.Common.MessageBus.Abstractions.DistributedTransactions;
using Softplan.Common.MessageBus.Abstractions.DistributedTransactions.Contexts;
using Softplan.Common.Repositories.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;
using Softplan.Common.Core.Entities;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Distribuicoes.DistribuicaoProcessos
{
    class LogarDistribuicaoProcessoTransactionStep : IdempotentTransactionStep<LogarDistribuicaoProcessoCommand>
    {
        private readonly IReadRepository<DistribuicaoProcesso, SimpleId<long>> _deduplicationRepository;
        private readonly DistribuicaoProcessoApplicationService _applicationService;
        private DistribuicaoProcesso _entity;

        public LogarDistribuicaoProcessoTransactionStep(IReadRepository<DistribuicaoProcesso, SimpleId<long>> deduplicationRepository, DistribuicaoProcessoApplicationService applicationService)
        {
            _deduplicationRepository = deduplicationRepository;
            _applicationService = applicationService;
        }

        protected override async ValueTask<bool> IsDuplicatedMessage(IDistributedTransactionContext<LogarDistribuicaoProcessoCommand> context)
        {
            _entity = await _deduplicationRepository.GetFirstAsync(
                DistribuicaoProcessoSpecifications.DistribuicaoProcessoPorTransactionId(
                    context.Message.IdProcesso, context.Message.TransactionId));

            return _entity != default;
        }

        [ScheduledMessageRedelivery(RedeliveryMeasure.Minutes, 1, 5, 15, 30, 60)]
        protected override async ValueTask<DistributedTransactionStepResult> OnConsumeNewMessage(IDistributedTransactionContext<LogarDistribuicaoProcessoCommand> context)
        {
            await _applicationService.LogarDistribuicaoProcessoAsync(context.Message);

            return context.ResultBuilder.Build();
        }

        protected override ValueTask<DistributedTransactionStepResult> OnConsumeDuplicatedMessage(IDistributedTransactionContext<LogarDistribuicaoProcessoCommand> context)
            => new ValueTask<DistributedTransactionStepResult>(context.ResultBuilder.Build());
    }
}