using System;
using System.Linq;
using System.Linq.Expressions;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos
{
    public static class DistribuicaoProcessoSpecifications
    {
        public static Expression<Func<DistribuicaoProcesso, bool>> DistribuicaoProcessoPorTransactionId(string idProcesso, Guid transactionId)
            => x => x.Logs.Any(l
                => l.IdProcesso.Equals(idProcesso) && l.TransactionId.Equals(transactionId));
    }
}