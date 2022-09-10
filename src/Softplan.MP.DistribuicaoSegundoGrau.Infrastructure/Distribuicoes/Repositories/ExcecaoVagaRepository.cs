using AutoMapper;
using Softplan.Common.Repositories.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Distribuicoes.Repositories
{
    class ExcecaoVagaRepository : DomainModelRepository<ExcecaoVaga, IdExcecaoVaga, ApplicationSajDsgDbContext>
    {
        public ExcecaoVagaRepository(IRepositoryService<ApplicationSajDsgDbContext> repositoryService, IMapper mapper, ApplicationSajDsgDbContext sajDsgDbContext)
            : base(repositoryService, mapper, sajDsgDbContext)
        {
        }
    }
}