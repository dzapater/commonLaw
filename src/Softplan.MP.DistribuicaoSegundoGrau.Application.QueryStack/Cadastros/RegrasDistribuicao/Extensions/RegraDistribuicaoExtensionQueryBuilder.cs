using Microsoft.EntityFrameworkCore;
using Softplan.Common.Core.Entities;
using Softplan.Common.Repositories.EntityFrameworkCore.Sort;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Softplan.Common.Core.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Extensions
{
    public static class RegraDistribuicaoExtensionQueryBuilder
    {        
        public static IQueryable<RegraDistribuicao> LeftJoinUnidade(this IQueryable<RegraDistribuicao> queryable, QueryDbContext dbContext)
            => from regra in queryable
                join unidade in dbContext.Set<CriterioUnidade>().AsNoTracking()
                    on regra.Id equals unidade.Id into joinEq
                from lj in joinEq.DefaultIfEmpty()
                select regra;
        
        public static IQueryable<RegraDistribuicao> LeftJoinClasse(this IQueryable<RegraDistribuicao> queryable, QueryDbContext dbContext)
            => from regra in queryable
                join classe in dbContext.Set<CriterioClasse>().AsNoTracking()
                    on regra.Id equals classe.Id into joinEq
                from lj in joinEq.DefaultIfEmpty()
                select regra;
        
        public static IQueryable<RegraDistribuicao> LeftJoinAssunto(this IQueryable<RegraDistribuicao> queryable, QueryDbContext dbContext)
            => from regra in queryable
                join assunto in dbContext.Set<CriterioAssunto>().AsNoTracking()
                    on regra.Id equals assunto.Id into joinEq
                from lj in joinEq.DefaultIfEmpty()
                select regra;
        
        public static IQueryable<RegraDistribuicao> LeftJoinTarja(this IQueryable<RegraDistribuicao> queryable, QueryDbContext dbContext)
            => from regra in queryable
                join tarja in dbContext.Set<CriterioTarja>().AsNoTracking()
                    on regra.Id equals tarja.Id into joinEq
                from lj in joinEq.DefaultIfEmpty()
                select regra;
        
        public static IQueryable<RegraDistribuicao> LeftJoinOrgaoJulgador(this IQueryable<RegraDistribuicao> queryable, QueryDbContext dbContext)
            => from regra in queryable
                join orgao in dbContext.Set<CriterioOrgaoJulgador>().AsNoTracking()
                    on regra.Id equals orgao.Id into joinEq
                from lj in joinEq.DefaultIfEmpty()
                select regra;
        
        public static IQueryable<RegraDistribuicao> LeftJoinEspecialidade(this IQueryable<RegraDistribuicao> queryable, QueryDbContext dbContext)
            => from regra in queryable
                join especialidade in dbContext.Set<CriterioEspecialidade>().AsNoTracking()
                    on regra.Id equals especialidade.Id into joinEq
                from lj in joinEq.DefaultIfEmpty()
                select regra;
        
        public static IOrderedQueryable<RegraDistribuicao> SortList(this IQueryable<RegraDistribuicao> queryable, ICollection<Sort> sorts)
            => sorts != null && sorts.Any()
                ? queryable.OrderBy(DynamicSortParser.OrderBy(typeof(RegraDistribuicao), sorts.ToArray()))
                : queryable.OrderByDescending(x => x.Metadata.DataAtualizacao)
                    .ThenBy(x => x.Descricao);

        public static IQueryable<RegraDistribuicaoReadModel> SelectList(this IQueryable<RegraDistribuicao> queryable, 
            QueryDbContext dbContext, RegraDistribuicaoFilter filter)
        => (from regra in queryable
            join vinculoVagaTotal in dbContext.GetVinculoMembroVagaTotal()
                on regra.Id equals vinculoVagaTotal.IdRegraDistribuicao into vinculoVagasTotal
            from vinculoVagaTotalLj in vinculoVagasTotal.DefaultIfEmpty()
            join vinculoVagaAtiva in dbContext.GetVinculoMembroVagaAtivo()
                on regra.Id equals vinculoVagaAtiva.IdRegraDistribuicao into vinculoVagas
            from vinculoVagaLj in vinculoVagas.DefaultIfEmpty()
            select new RegraDistribuicaoEspecialidadeReadModel
            {
                Regra = regra,
                Especialidade = regra.Especialidades.First(),
                QuantidadeVinculosAtivos = vinculoVagaLj.QuantidadeVagas ?? 0, 
                QuantidadeVinculosTotal = vinculoVagaTotalLj.QuantidadeVagas ?? 0
            }).FilterBySituacao(filter).Select(RegraDistribuicaoReadModel.SelectNew);

        private static IQueryable<RegraDistribuicaoEspecialidadeReadModel> FilterBySituacao(
            this IQueryable<RegraDistribuicaoEspecialidadeReadModel> queryable, RegraDistribuicaoFilter filter)
            => queryable.Where(RegraDistribuicaoExtensionFilterBuilder.ApplyFilterPorSituacao(filter));

        private static IQueryable<VinculoVagaRegraAgrupado> GetVinculoMembroVagaAtivo(this QueryDbContext dbContext)
        {
            var dateTimeNow = DateTimeOffset.Now.Date;
            return (from vinculoVagaRegra in dbContext.Set<VinculoVagaRegraDistribuicao>().Include(nameof(Vaga)).AsNoTracking()
                    join vinculoMembroVaga in dbContext.Set<VinculoMembroVaga>().AsNoTracking()
                        on vinculoVagaRegra.IdVaga equals vinculoMembroVaga.IdVaga
                    where vinculoVagaRegra.Vaga.EstaAtiva 
                          && vinculoMembroVaga.IdMembro != null 
                          && vinculoMembroVaga.IdMembro != Situacao.DesativacaoPlanejada.ToString() 
                          && (vinculoMembroVaga.DataInicial <= dateTimeNow
                          && vinculoMembroVaga.DataFinal >= dateTimeNow
                          || vinculoMembroVaga.DataFinal == null)
                    select vinculoVagaRegra)
                .GroupBy(x => x.IdRegraDistribuicao)
                .Select(x => new VinculoVagaRegraAgrupado
                {   
                    IdRegraDistribuicao = x.Key, QuantidadeVagas = x.Count()
                });
        }

        private static IQueryable<VinculoVagaRegraAgrupado> GetVinculoMembroVagaTotal(this QueryDbContext dbContext)
        {
            return (from vinculoVagaRegra in dbContext.Set<VinculoVagaRegraDistribuicao>().AsNoTracking()                 
                    select vinculoVagaRegra)
                .GroupBy(x => x.IdRegraDistribuicao)
                .Select(x => new VinculoVagaRegraAgrupado
                {
                    IdRegraDistribuicao = x.Key,
                    QuantidadeVagas = x.Count()
                });
        }

        public static Task<ICustomPagedList<RegraDistribuicaoReadModel>> VerifyPending(this Task<ICustomPagedList<RegraDistribuicaoReadModel>> dataPaged, IQueryable<RegraDistribuicaoReadModel> queryable)
        {
            if (queryable.Any(x => x.QuantidadeVagasVinculadasAtivas == 0))
                dataPaged.Result.ForEach(x => x.ExisteRegraPendente = true);
            
            return dataPaged;
        }

        public static IQueryable<RegraDistribuicaoReadModel> GetRegraDistribuicaoReadModel(
            this QueryDbContext dbContext)
            => dbContext.Set<RegraDistribuicao>().AsNoTracking()
                .SelectList(dbContext, RegraDistribuicaoFilter.Empty());
    }
}