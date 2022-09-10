using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Softplan.Common.DistributedLock.Abstractions;
using Softplan.Common.MessageBus.Abstractions.DistributedTransactions;
using Softplan.Common.MessageBus.Abstractions.DistributedTransactions.Contexts;
using Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.MPC;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Distribuicoes.DistribuicaoProcessos
{
    class AgendarRemessaProcessoTransactionStep : IMessageBusDistributedTransactionStep<AgendarRemessaProcessoCommand>
    {
        private readonly IMpcGatewayService _gatewayService;
        private readonly IDistributedLock _distributedLock;

        public AgendarRemessaProcessoTransactionStep(IServiceProvider provider)
        {
            _distributedLock = provider.GetService<IDistributedLock>();
            _gatewayService = provider.GetRequiredService<IMpcGatewayService>();
        }

        public async Task<DistributedTransactionStepResult> ExecuteAsync(IDistributedTransactionContext<AgendarRemessaProcessoCommand> context, CancellationToken cancellationToken)
        {
            var idLoteDistribuicao = await (_distributedLock != default
                ? AgendarRemessaProcessoWithLockAsync(context.Message)
                : AgendarRemessaProcessoAsync(context.Message));

            return context.ResultBuilder
                .AddVariable("IdLoteDistribuicao", idLoteDistribuicao)
                .Build();
        }

        private async Task<long> AgendarRemessaProcessoWithLockAsync(AgendarRemessaProcessoCommand message)
        {
            var id = default(long);

            await _distributedLock.LockAsync($"{nameof(AgendarRemessaProcessoTransactionStep)}:{message.IdProcesso}",
                async () => { id = await AgendarRemessaProcessoAsync(message); });

            return id;
        }

        private async Task<long> AgendarRemessaProcessoAsync(AgendarRemessaProcessoCommand message)
            => (await _gatewayService.AgendarRemessaProcesso(new RemessaProcessoInputType
            {
                CodigoProcesso = message.IdProcesso, CodigoForoDestino = message.CodigoForoDestino,
                CodigoLocalDestino = message.CodigoLocalDestino, CodigoTipoLocalDestino = message.CodigoTipoLocalDestino
            })).Id;
    }
}