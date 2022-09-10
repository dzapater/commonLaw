using System.Threading.Tasks;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas
{
    public interface IMotivoMembroVagaQueryService: IQueryService
    {
        Task<ICustomPagedList<MotivoMembroVagaReadModel>> ListAsync(MotivoMembroVagaFilter filter);
    }
}