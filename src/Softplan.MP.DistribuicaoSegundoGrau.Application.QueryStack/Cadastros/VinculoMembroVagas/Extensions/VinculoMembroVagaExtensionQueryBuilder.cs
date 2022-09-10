using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Softplan.Common.Core.Entities;
using Softplan.Common.Repositories.EntityFrameworkCore.Sort;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Extensions
{
    public static class VinculoMembroVagaExtensionQueryBuilder
    {
        public static IQueryable<VinculoMembroVagaReadModel> SelectList(this IQueryable<VinculoMembroVaga> queryable, QueryDbContext dbContext,
            ICollection<MotivoMembroVagaReadModel> motivos)
            => (from vinculo in queryable
                select new VinculoMembroVagaMotivo
                {
                    Vinculo = vinculo,
                    Motivos = motivos
                }).Select(VinculoMembroVagaReadModel.SelectNew);
        
        public static IQueryable<VinculoMembroVaga> ApplyListFilters(this IQueryable<VinculoMembroVaga> queryable,
            VinculoMembroVagaFilter filter)
            => queryable.Where(
                Specification<VinculoMembroVaga>.All
                    .FiltrarPorId(filter)
                    .FiltrarPorIdVaga(filter)
                    .FiltrarPorMembroAtivo(filter)
                    .FiltrarPorIdMembro(filter)
                    .FiltrarPorIdMotivoMembroVaga(filter)
                    .FiltrarPorDescricaoVaga(filter).ToExpression());
        
        public static IQueryable<VinculoMembroVaga> ApplyListOrdering(this IQueryable<VinculoMembroVaga> queryable, ICollection<Sort> sorts)
            => sorts != null && sorts.Any()
                ? queryable.OrderBy(DynamicSortParser.OrderBy(typeof(VinculoMembroVaga), sorts.ToArray()))
                : queryable.OrderByDescending(x => x.Metadata.DataAtualizacao)
                    .ThenBy(x => x.Observacao);
        
        public static IQueryable<VinculoMembroVaga> BuscarMembroVagaAtivo(this IQueryable<VinculoMembroVaga> queryable)
        {
            var dateTimeNow = DateTimeOffset.Now.Date;
            return queryable.Where(x => x.DataInicial <= dateTimeNow)
                .Where(x => x.DataFinal >= dateTimeNow || x.DataFinal == null);
        }
    }
}