using AutoMapper;
using Softplan.Common.Repositories.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Distribuicoes.Repositories
{
    class AnaliseProcessoRepository : DomainModelRepository<AnaliseProcesso, IdAnaliseProcesso, ApplicationSajDsgDbContext>
    {
        public AnaliseProcessoRepository(IRepositoryService<ApplicationSajDsgDbContext> repositoryService, IMapper mapper, ApplicationSajDsgDbContext sajDsgDbContext)
            : base(repositoryService, mapper, sajDsgDbContext)
        {
        }
    }
}