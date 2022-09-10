using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Softplan.Common.Core.Entities;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Factories;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao
{
    class RegraDistribuicaoQueryService : IRegraDistribuicaoQueryService
    {
        private readonly QueryDbContext _dbContext;

        public RegraDistribuicaoQueryService(QueryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ICustomPagedList<RegraDistribuicaoReadModel>> ListAsync(RegraDistribuicaoFilter filter, ICollection<Sort> sorts)
        {
            var queryable = FilterList(filter)
                .Where(x => x.CdLocal == filter.CdLocal)
                .SortList(sorts)
                .SelectList(_dbContext, filter);
            
            return CustomPagedListFactory<RegraDistribuicaoReadModel>
                .CreateAsync(queryable, filter.PageNumber, filter.PageSize)
                .VerifyPending(queryable);
        }

        public Task<List<RegraDistribuicao>> ListAsync(int[] regraIds)
        => _dbContext.Set<RegraDistribuicao>().AsNoTracking()
            .LeftJoinUnidade(_dbContext)
            .LeftJoinClasse(_dbContext)
            .LeftJoinAssunto(_dbContext)
            .LeftJoinTarja(_dbContext)
            .LeftJoinOrgaoJulgador(_dbContext)
            .LeftJoinEspecialidade(_dbContext)
            .Where(x => regraIds.Contains(x.Id))
            .ToListAsync();

        private IQueryable<RegraDistribuicao> FilterList(RegraDistribuicaoFilter filter)
        {
            var regrasFiltradas = _dbContext.Set<RegraDistribuicao>()
                .AsNoTracking().Where(RegraDistribuicaoExtensionFilterBuilder.ApplyListFilters(filter));

            if (string.IsNullOrWhiteSpace(filter.Busca)) return regrasFiltradas;

            return regrasFiltradas
                .Union(RegrasPorAssunto(filter))
                .Union(RegrasPorClasse(filter))
                .Union(RegrasPorTarja(filter))
                .Union(RegrasPorOrgaoJulgador(filter))
                .Union(RegrasPorUnidade(filter))
                .Union(RegrasPorEspecialidade(filter));
        }

        private IQueryable<RegraDistribuicao> RegrasPorAssunto(RegraDistribuicaoFilter filter)
            => from regraAssunto in _dbContext.Set<CriterioAssunto>().AsNoTracking()
                join regra in _dbContext.Set<RegraDistribuicao>().AsNoTracking()
                    on regraAssunto.Id equals regra.Id
                where regraAssunto.Descricao.ToLower().Equals(filter.Busca.ToLower())
                select regra;

        private IQueryable<RegraDistribuicao> RegrasPorClasse(RegraDistribuicaoFilter filter)
            => from regraClasse in _dbContext.Set<CriterioClasse>().AsNoTracking()
                join regra in _dbContext.Set<RegraDistribuicao>().AsNoTracking()
                    on regraClasse.Id equals regra.Id
                where regraClasse.Descricao.ToLower().Equals(filter.Busca.ToLower())
                select regra;

        private IQueryable<RegraDistribuicao> RegrasPorTarja(RegraDistribuicaoFilter filter)
            => from regraTarja in _dbContext.Set<CriterioTarja>().AsNoTracking()
                join regra in _dbContext.Set<RegraDistribuicao>().AsNoTracking()
                    on regraTarja.Id equals regra.Id
                where regraTarja.Descricao.ToLower().Equals(filter.Busca.ToLower())
                select regra;

        private IQueryable<RegraDistribuicao> RegrasPorOrgaoJulgador(RegraDistribuicaoFilter filter)
            => from regraOrgao in _dbContext.Set<CriterioOrgaoJulgador>().AsNoTracking()
                join regra in _dbContext.Set<RegraDistribuicao>().AsNoTracking()
                    on regraOrgao.Id equals regra.Id
                where regraOrgao.Descricao.ToLower().Equals(filter.Busca.ToLower())
                select regra;

        private IQueryable<RegraDistribuicao> RegrasPorUnidade(RegraDistribuicaoFilter filter)
            => from regraUnidade in _dbContext.Set<CriterioUnidade>().AsNoTracking()
                join regra in _dbContext.Set<RegraDistribuicao>().AsNoTracking()
                    on regraUnidade.Id equals regra.Id
                where regraUnidade.Descricao.ToLower().Equals(filter.Busca.ToLower())
                select regra;
        
        private IQueryable<RegraDistribuicao> RegrasPorEspecialidade(RegraDistribuicaoFilter filter)
            => from regraEspecialidade in _dbContext.Set<CriterioEspecialidade>().AsNoTracking()
                join regra in _dbContext.Set<RegraDistribuicao>().AsNoTracking()
                    on regraEspecialidade.Id equals regra.Id
                where regraEspecialidade.Descricao.ToLower().Equals(filter.Busca.ToLower())
                select regra;
    }
}