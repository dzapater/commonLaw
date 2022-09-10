using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Softplan.Common.Core.Entities;
using Softplan.Common.Repositories.EntityFrameworkCore.Sort;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Extensions
{
    public static class VagaExtensionQueryBuilder
    {
        public static IQueryable<VinculoMembroVaga> LeftJoinVinculoMembroVaga(this IQueryable<Vaga> queryable, QueryDbContext dbContext)
            => from vaga in queryable
                join membro in dbContext.Set<VinculoMembroVaga>().AsNoTracking().BuscarMembroVagaAtivo()
                    on vaga.Id equals membro.IdVaga into vinculoMembroVaga
                from ljMembro in vinculoMembroVaga.DefaultIfEmpty()
                select new VinculoMembroVaga
                {
                    IdMembro = ljMembro.IdMembro,
                    DataInicial = ljMembro.DataInicial,
                    DataFinal = ljMembro.DataFinal,
                    Vaga = vaga,
                    ProcuradorTitularId = vaga.ProcuradorTitular.Id
                };

        public static IOrderedQueryable<Vaga> SortList(this IQueryable<Vaga> queryable, ICollection<Sort> sorts)
            => sorts != null && sorts.Any()
                ? queryable.OrderBy(DynamicSortParser.OrderBy(typeof(Vaga), sorts.ToArray()))
                : queryable.OrderByDescending(x => x.Metadata.DataAtualizacao)
                    .ThenBy(x => x.Descricao);

        public static IQueryable<VagaReadModel> GetVagaReadModel(this QueryDbContext dbContext)
        => dbContext.Set<Vaga>().AsNoTracking()
                .Include(x => x.RegrasVinculadas).ThenInclude(x => x.RegraDistribuicao)
                .LeftJoinVinculoMembroVaga(dbContext)
                .Select(VagaReadModelExtension.SelectNew);
    }
}