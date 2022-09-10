using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Factories;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas
{
    public class MotivoMembroVagaQueryService : IMotivoMembroVagaQueryService
    {
        private readonly QuerySajDbContext _dbContext;

        public MotivoMembroVagaQueryService(QuerySajDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ICustomPagedList<MotivoMembroVagaReadModel>> ListAsync(MotivoMembroVagaFilter filter)
            => CustomPagedListFactory<MotivoMembroVagaReadModel>.CreateAsync(
                SelectList(filter), filter.PageNumber, filter.PageSize);

        private IQueryable<MotivoMembroVagaReadModel> SelectList(MotivoMembroVagaFilter filter)
            => _dbContext.Set<MotivoMembroVagaReadModel>().AsNoTracking()
                .ApplyListFilters(filter);
    }
}