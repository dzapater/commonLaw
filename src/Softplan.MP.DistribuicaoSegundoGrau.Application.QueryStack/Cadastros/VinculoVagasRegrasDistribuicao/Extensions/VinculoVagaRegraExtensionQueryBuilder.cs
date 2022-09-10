using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Softplan.Common.Core.Entities;
using Softplan.Common.Repositories.EntityFrameworkCore.Sort;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao.Extensions
{
    public static class VinculoVagaRegraExtensionQueryBuilder
    {
        public static IQueryable<VinculoVagaRegraDistribuicao> ApplyListOrdering(this IQueryable<VinculoVagaRegraDistribuicao> queryable, VinculoVagaRegraDistribuicaoFilter filter, 
            ICollection<Sort> sorts)
        {
            if(sorts != null && sorts.Any())
                return queryable.OrderBy(DynamicSortParser.OrderBy(typeof(VinculoVagaRegraDistribuicao), sorts.ToArray()))
                    .ThenBy(x => x.Vaga.Descricao);
            
            if (filter.IdVaga != default)
                return queryable.OrderBy(x => x.RegraDistribuicao.Descricao);

            return filter.IdRegraDistribuicao == default
                ? queryable
                : queryable.OrderBy(x => x.Vaga.Descricao);
        }

        public static IQueryable<VinculoVagaRegraDistribuicao> ApplyListFilters(
            this IQueryable<VinculoVagaRegraDistribuicao> queryable, VinculoVagaRegraDistribuicaoFilter filter)
            => queryable.Where(VinculoVagaRegraExtensionFilterBuilder.ApplyListFilter(filter));

        public static IQueryable<VinculoVagaRegraDistribuicaoReadModel> LeftJoinVinculoMembroVaga(
            this IQueryable<VinculoVagaRegraDistribuicao> queryable, QueryDbContext dbContext)
        {
            return from vinculo in queryable
                join vaga in dbContext.GetVagaReadModel()
                    on vinculo.IdVaga equals vaga.Id
                join regra in dbContext.GetRegraDistribuicaoReadModel()
                    on vinculo.IdRegraDistribuicao equals regra.Id
                select new VinculoVagaRegraDistribuicaoReadModel
                {
                    Vaga = vaga, RegraDistribuicao = regra
                };
        }
    }
}