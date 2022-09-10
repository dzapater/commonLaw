using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Softplan.Common.Core.Entities;
using Softplan.Common.Repositories.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Distribuicoes.Repositories
{
    class DistribuicaoProcessoRepository : DomainModelRepository<DistribuicaoProcesso, SimpleId<long>, ApplicationSajDsgDbContext>, IDistribuicaoProcessoRepository
    {
        public DistribuicaoProcessoRepository(IRepositoryService<ApplicationSajDsgDbContext> repositoryService, IMapper mapper, ApplicationSajDsgDbContext sajDsgDbContext)
            : base(repositoryService, mapper, sajDsgDbContext)
        {
        }

        public Task<DistribuicaoProcessoLog[]> LoadLogsAsync(Expression<Func<DistribuicaoProcessoLog, bool>> expression)
        {
            return DbContext.Set<DistribuicaoProcessoLog>().AsNoTracking().Where(expression).OrderBy(log => log.IdLog).Take(500).ToArrayAsync();
        }
    }
}