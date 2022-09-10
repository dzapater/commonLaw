using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Softplan.Common.Core.Entities;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Factories;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao
{
    class VinculoVagaRegraDistribuicaoQueryService : IVinculoVagaRegraDistribuicaoQueryService
    {
        private readonly QueryDbContext _dbContext;

        public VinculoVagaRegraDistribuicaoQueryService(QueryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ICustomPagedList<VinculoVagaRegraDistribuicaoReadModel>> ListAsync(
            VinculoVagaRegraDistribuicaoFilter filter, ICollection<Sort> sorts)
            => CustomPagedListFactory<VinculoVagaRegraDistribuicaoReadModel>.CreateAsync(
                _dbContext.Set<VinculoVagaRegraDistribuicao>().AsNoTracking()
                    .ApplyListOrdering(filter, sorts)
                    .ApplyListFilters(filter)
                    .LeftJoinVinculoMembroVaga(_dbContext), filter.PageNumber, filter.PageSize);

        public Task<bool> GetRegraGlobalAsync(
            VinculoVagaRegraDistribuicaoFilter filter, ICollection<Sort> sorts)
            => _dbContext.Set<VinculoVagaRegraDistribuicao>().AsNoTracking()
                    .ApplyListOrdering(filter, sorts)
                    .ApplyListFilters(filter)
                    .Where(x => x.RegraDistribuicao.EscopoEquilibrio == Domain.Valores.EscopoEquilibrio.Global).AnyAsync();

    }
}