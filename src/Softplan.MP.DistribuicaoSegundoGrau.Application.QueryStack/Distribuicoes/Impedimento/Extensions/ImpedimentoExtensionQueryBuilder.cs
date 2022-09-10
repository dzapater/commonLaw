using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Softplan.Common.Core.Entities;
using Softplan.Common.Repositories.EntityFrameworkCore.Sort;
 
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Impedimento.Extensions
{
    public static class ImpedimentoExtensionQueryBuilder
    {         
        public static IOrderedQueryable<ImpedimentoProcesso> SortList(this IQueryable<ImpedimentoProcesso> queryable, ICollection<Sort> sorts)
            => sorts != null && sorts.Any()
                ? queryable.OrderBy(DynamicSortParser.OrderBy(typeof(ImpedimentoProcesso), sorts.ToArray()))
                : queryable.OrderByDescending(x => x.Metadata.DataAtualizacao);                    
    }
}