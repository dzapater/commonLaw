using AutoMapper;
using Softplan.Common.Repositories.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Jobs;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Jobs.Distribuicoes;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Jobs.Repositories.Maps
{
    class DistribuicaoVagaJobRepository : ModelRepository<DistribuicaoVagaJob, IdJob, ApplicationSajDsgDbContext>
    {
        private readonly ApplicationSajDsgDbContext _context;

        public DistribuicaoVagaJobRepository(IRepositoryService<ApplicationSajDsgDbContext> repositoryService, IMapper mapper,
            ApplicationSajDsgDbContext sajDsgDbContext)
            : base(repositoryService, mapper) => _context = sajDsgDbContext;
    }
}