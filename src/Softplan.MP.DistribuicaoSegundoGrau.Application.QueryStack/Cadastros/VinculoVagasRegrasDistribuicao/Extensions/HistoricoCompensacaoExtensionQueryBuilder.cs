using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Softplan.Common.Core.Entities;
using Softplan.Common.Repositories.EntityFrameworkCore.Sort;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao.Extensions
{
    public static class HistoricoCompensacaoExtensionQueryBuilder
    {
        public static IQueryable<CompensacaoLog> FilterList(this IQueryable<CompensacaoLog> queryable, 
            HistoricoCompensacaoRegraFilter filter, QueryDbContext dbContext)
            => filter.IdRegraDistribuicao == default
                ? queryable
                : from log in queryable
                join vagaRegra in dbContext.Set<VinculoVagaRegraDistribuicao>().AsNoTracking() on log.IdVaga equals
                    vagaRegra.IdVaga
                where vagaRegra.IdRegraDistribuicao == filter.IdRegraDistribuicao
                select log;
        
        public static IOrderedQueryable<HistoricoCompensacaoRegraReadModel> SortList(this IQueryable<HistoricoCompensacaoRegraReadModel> queryable, ICollection<Sort> sorts)
            => sorts != null && sorts.Any()
                ? queryable.OrderBy(DynamicSortParser.OrderBy(typeof(HistoricoCompensacaoRegraReadModel), sorts.ToArray()))
                : queryable.OrderByDescending(x => x.DataRegistro)
                    .ThenBy(x => x.Descricao);
    }
}