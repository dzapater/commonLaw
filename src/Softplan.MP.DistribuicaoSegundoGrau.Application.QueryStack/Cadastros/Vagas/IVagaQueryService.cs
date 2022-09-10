using System.Collections.Generic;
using System.Threading.Tasks;
using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas
{
    public interface IVagaQueryService: IQueryService
    {
        Task<ICustomPagedList<VagaReadModel>> ListAsync(VagaFilter filter, ICollection<Sort> sorts);
    }
}