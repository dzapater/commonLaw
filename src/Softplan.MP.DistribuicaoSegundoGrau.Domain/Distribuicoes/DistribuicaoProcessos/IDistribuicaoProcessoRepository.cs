using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos
{
    public interface IDistribuicaoProcessoRepository
    {
        Task<DistribuicaoProcessoLog[]> LoadLogsAsync(Expression<Func<DistribuicaoProcessoLog, bool>> expression);
    }
}