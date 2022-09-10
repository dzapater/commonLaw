using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Softplan.Common.Core.Entities;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Factories;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas
{
    public class VinculoMembroVagaQueryService: IVinculoMembroVagaQueryService
    {
        private readonly QueryDbContext _dbContext;
        private readonly QuerySajDbContext _sajSajDbContext;

        public VinculoMembroVagaQueryService(QueryDbContext dbContext, QuerySajDbContext sajSajDbContext)
        {
            _dbContext = dbContext;
            _sajSajDbContext = sajSajDbContext;
        }
        
        public Task<ICustomPagedList<VinculoMembroVagaReadModel>> ListAsync(VinculoMembroVagaFilter filter, ICollection<Sort> sorts)
            => CustomPagedListFactory<VinculoMembroVagaReadModel>.CreateAsync(BuildQuery(filter, sorts), filter.PageNumber, filter.PageSize);

        private IQueryable<VinculoMembroVagaReadModel> BuildQuery(VinculoMembroVagaFilter filter,
            ICollection<Sort> sorts)
        {
            var membroVagaRM = _sajSajDbContext.Set<MotivoMembroVagaReadModel>().AsNoTracking().ToList();
            
            return _dbContext.Set<VinculoMembroVaga>().AsNoTracking()
                .ApplyListOrdering(sorts)
                .ApplyListFilters(filter)
                .SelectList(_dbContext, membroVagaRM);
        }
    }
}