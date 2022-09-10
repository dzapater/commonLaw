using System.Collections.Generic;
using System.Threading.Tasks;
using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao
{
    public interface IRegraDistribuicaoQueryService : IQueryService
    {
        Task<ICustomPagedList<RegraDistribuicaoReadModel>> ListAsync(RegraDistribuicaoFilter filter, ICollection<Sort> sorts);
        Task<List<RegraDistribuicao>> ListAsync(int [] regraIds);
    }
}