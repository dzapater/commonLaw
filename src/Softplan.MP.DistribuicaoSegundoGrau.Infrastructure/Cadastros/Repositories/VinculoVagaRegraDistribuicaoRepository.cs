using AutoMapper;
using Softplan.Common.Repositories.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Cadastros.Repositories
{
    class VinculoVagaRegraDistribuicaoRepository : DomainModelRepository<VinculoVagaRegraDistribuicao, IdVinculoVagaRegraDistribuicao, ApplicationSajDsgDbContext>
    {
        public VinculoVagaRegraDistribuicaoRepository(IRepositoryService<ApplicationSajDsgDbContext> repositoryService, IMapper mapper, ApplicationSajDsgDbContext sajDsgDbContext)
            : base(repositoryService, mapper, sajDsgDbContext)
        {
        }
    }
}