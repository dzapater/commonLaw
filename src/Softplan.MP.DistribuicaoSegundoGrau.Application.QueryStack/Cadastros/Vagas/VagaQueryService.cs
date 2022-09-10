using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Softplan.Common.Core.Entities;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Factories;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas
{
    class VagaQueryService : IVagaQueryService
    {
        private readonly QueryDbContext _dbContext;

        public VagaQueryService(QueryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ICustomPagedList<VagaReadModel>> ListAsync(VagaFilter filter, ICollection<Sort> sorts)
        {
            var queryable = _dbContext.Set<Vaga>().AsNoTracking()
                .Include(x => x.RegrasVinculadas).ThenInclude(x => x.RegraDistribuicao)
                .Where(x => x.CdLocal == filter.CdLocal)
                .Where(VagaExtensionFilterBuilder.ApplyListFilters(filter))
                .SortList(sorts)
                .LeftJoinVinculoMembroVaga(_dbContext)
                .Select(VagaReadModelExtension.SelectNew)
                .Where(VagaReadModelExtensionFilterBuilder.ApplyVagaReadModelListFilters(filter));
            
            var response = VerifyPending(queryable, CustomPagedListFactory<VagaReadModel>.CreateAsync(queryable, filter.PageNumber, filter.PageSize));

            return response;
        }

        private Task<ICustomPagedList<VagaReadModel>> VerifyPending(IQueryable<VagaReadModel> queryable, Task<ICustomPagedList<VagaReadModel>> response)
        {                        
            if (queryable.Any(x => x.MembroEmAtividade.Id == "-"))
            {
                foreach (var item in response.Result)
                {
                    item.ExisteVagaPendente = true;
                }
            }

            return response;
        }
    }
}