using AutoMapper;
using Softplan.Common.Repositories.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Distribuicoes.Repositories
{
    class ImpedimentoDistribuicaoLogRepository : DomainModelRepository<ImpedimentoDistribuicaoLog, IdImpedimentoDistribuicaoLog, ApplicationSajDsgDbContext>
    {
        public ImpedimentoDistribuicaoLogRepository(IRepositoryService<ApplicationSajDsgDbContext> repositoryService, IMapper mapper, ApplicationSajDsgDbContext sajDsgDbContext)
            : base(repositoryService, mapper, sajDsgDbContext)
        {
        }
    }
}