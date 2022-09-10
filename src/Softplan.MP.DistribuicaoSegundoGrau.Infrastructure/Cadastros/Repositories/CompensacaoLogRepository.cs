using AutoMapper;
using Softplan.Common.Repositories.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Cadastros.Repositories
{
    class CompensacaoLogRepository : DomainModelRepository<CompensacaoLog, IdCompensacaoLog, ApplicationSajDsgDbContext>
    {
        public CompensacaoLogRepository(IRepositoryService<ApplicationSajDsgDbContext> repositoryService, IMapper mapper, ApplicationSajDsgDbContext sajDsgDbContext)
            : base(repositoryService, mapper, sajDsgDbContext)
        {
        }
    }
}