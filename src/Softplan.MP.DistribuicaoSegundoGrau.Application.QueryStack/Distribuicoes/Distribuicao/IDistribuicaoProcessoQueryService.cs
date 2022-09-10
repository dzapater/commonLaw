using System.Threading.Tasks;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Distribuicao
{
    public interface IDistribuicaoProcessoQueryService : IQueryService
    {
        Task<ICustomPagedList<DistribuicaoProcessoReadModel>> GetDistribuicaoProcessoById(DistribuicaoProcessoFilter filter);
    }
}