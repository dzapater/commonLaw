using Softplan.Common.Core.Entities.Abstractions;
using System.Threading.Tasks;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.AnaliseProcessos
{
    public interface IAnaliseProcessosQueryService : IQueryService
    {
        Task<AnaliseProcessoReadModel> GetAnaliseById(AnaliseProcessoFilter filter);
    }
}