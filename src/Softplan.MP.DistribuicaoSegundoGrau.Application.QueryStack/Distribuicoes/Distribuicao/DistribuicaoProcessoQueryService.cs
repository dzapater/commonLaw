using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Factories;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Distribuicao
{
    public class DistribuicaoProcessoQueryService : IDistribuicaoProcessoQueryService
    {
        
        private readonly QueryDbContext _dbContext;
        
        public DistribuicaoProcessoQueryService(QueryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ICustomPagedList<DistribuicaoProcessoReadModel>> GetDistribuicaoProcessoById(
            DistribuicaoProcessoFilter filter)
        {
            var query =
                _dbContext.Set<DistribuicaoProcesso>()
                    .AsNoTracking()
                    .Where(distribuicao => distribuicao.IdProcesso.Equals(filter.IdProcesso))
                    .GroupJoin(_dbContext.Set<DistribuicaoProcessoLog>().AsNoTracking(),
                        distribuicao => distribuicao.IdProcesso, distribuicaoLog => distribuicaoLog.IdProcesso,
                        (distribuicao, Distribuicoes) => new {distribuicao, Distribuicoes})
                    .SelectMany(@t => @t.Distribuicoes.DefaultIfEmpty(),
                        (@t, distroLog) => new DistribuicaoProcessoReadModel
                        {
                            DistribuicaoProcesso = @t.distribuicao,
                            DistribuicaoProcessoLog = new List<DistribuicaoProcessoLog> {distroLog}
                        }).Select(DistribuicaoProcessoReadModel.New).AsQueryable();
            
            var response = CustomPagedListFactory<DistribuicaoProcessoReadModel>.CreateAsync(query, filter.PageNumber,
                filter.PageSize);
            return response;
        }

    }
}