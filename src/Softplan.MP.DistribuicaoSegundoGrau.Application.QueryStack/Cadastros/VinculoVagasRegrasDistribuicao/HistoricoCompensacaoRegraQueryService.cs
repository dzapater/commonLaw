using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Softplan.Common.Core.Entities;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Factories;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao
{
    class HistoricoCompensacaoRegraQueryService : IHistoricoCompensacaoRegraQueryService
    {
        private readonly QueryDbContext _dbContext;

        public HistoricoCompensacaoRegraQueryService(QueryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
   
        public Task<ICustomPagedList<HistoricoCompensacaoRegraReadModel>> ListAsync(HistoricoCompensacaoRegraFilter filter,
            ICollection<Sort> sorts)
            => CustomPagedListFactory<HistoricoCompensacaoRegraReadModel>.CreateAsync(
                _dbContext.Set<CompensacaoLog>().AsNoTracking()
                    .FilterList(filter, _dbContext)
                    .Select(HistoricoCompensacaoRegraReadModel.SelectNew)
                    .SortList(sorts), filter.PageNumber, filter.PageSize);
    }
}