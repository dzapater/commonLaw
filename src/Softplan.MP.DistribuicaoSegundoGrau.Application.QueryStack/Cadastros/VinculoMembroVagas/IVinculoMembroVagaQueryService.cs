using System.Collections.Generic;
using System.Threading.Tasks;
using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas
{
    public interface IVinculoMembroVagaQueryService: IQueryService
    {
        Task<ICustomPagedList<VinculoMembroVagaReadModel>> ListAsync(VinculoMembroVagaFilter filter, ICollection<Sort> sorts);
    }
}