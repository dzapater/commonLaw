using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Extensions;
using Softplan.Common.Repositories.EntityFrameworkCore.Sort;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.ExcecaoVagas.Extensions
{
    public static class ExcecaoVagaExtensionQueryBuilder
    {
        
        public static IOrderedQueryable<ExcecaoVaga> SortList(this IQueryable<ExcecaoVaga> queryable, in ICollection<Sort> sorts)
            => sorts != null && sorts.Any()
                ? queryable.OrderBy(DynamicSortParser.OrderBy(typeof(ExcecaoVaga), sorts.ToArray()))
                : queryable.OrderBy(x => x.Metadata.DataAtualizacao)
                    .ThenBy(x => x.IdVaga);
        
        public static Expression<Func<ExcecaoVaga, bool>> ListFilters(ExcecaoVagaFilter filter)
            => FilterIdVaga(x => true, filter);

        public static Expression<Func<ExcecaoVaga, bool>> FilterIdVaga(Expression<Func<ExcecaoVaga, bool>> expression, ExcecaoVagaFilter filter)
            =>  expression.AndAlso(x
                => x.IdVaga == filter.IdVaga);
        
    }
}