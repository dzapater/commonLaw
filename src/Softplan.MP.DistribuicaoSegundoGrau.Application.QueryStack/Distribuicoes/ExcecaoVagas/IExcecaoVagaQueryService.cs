using System.Collections.Generic;
using System.Threading.Tasks;
using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.Common.Core.Entities.Pages.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.ExcecaoVagas
{
    public interface IExcecaoVagaQueryService : IQueryService
    {
        Task<ICustomPagedList<ExcecaoVagaReadModel>> ListAsync(ExcecaoVagaFilter filter, ICollection<Sort> sorts);
    }
}