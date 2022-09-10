using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Softplan.Common.Core.Entities;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Impedimento.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Factories;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Impedimento
{
    public class ImpedimentoProcessoQueryService : IImpedimentoProcessoQueryService
    {
        private readonly QueryDbContext _dbContext;

        public ImpedimentoProcessoQueryService(QueryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ICustomPagedList<ImpedimentoProcesso>> ListAsync(ImpedimentoFilter filter, ICollection<Sort> sorts)
        {
            var queryable = _dbContext.Set<ImpedimentoProcesso>().AsNoTracking()
                .Include(nameof(Vaga))
                .Where(ImpedimentoExtensionFilterBuilder.ApplyListFilters(filter))
                .SortList(sorts);             


            return CustomPagedListFactory<ImpedimentoProcesso>.CreateAsync(queryable, filter.PageNumber, filter.PageSize);

        }

    }
}