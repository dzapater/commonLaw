using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Pages.Abstractions;
using Softplan.Common.Core.Extensions;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.ExcecaoVagas.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Factories;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.ExcecaoVagas
{
    public class ExcecaoVagaQueryService : IExcecaoVagaQueryService
    {
        private readonly QueryDbContext _dbContext;

        public ExcecaoVagaQueryService(QueryDbContext dbContext)
        {            
            _dbContext = dbContext;
        }

        public async Task<ICustomPagedList<ExcecaoVagaReadModel>> ListAsync(ExcecaoVagaFilter filter, ICollection<Sort> sorts)
        {
            var queryable = _dbContext.Set<ExcecaoVaga>()
             .AsNoTracking()
             .Where(ExcecaoVagaExtensionQueryBuilder.ListFilters(filter))
             .SortList(sorts)
             .Select(ExcecaoVagaReadModel.New).AsQueryable();

            return await CustomPagedListFactory<ExcecaoVagaReadModel>
                .CreateAsync(queryable, filter.PageNumber, filter.PageSize);
        }

    }
}