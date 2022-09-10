using System.Threading.Tasks;
using AutoMapper;
using Softplan.Common.Repositories.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Cadastros.Repositories
{
    class RegraDistribuicaoRepository : DomainModelRepository<RegraDistribuicao, IdRegraDistribuicao, ApplicationSajDsgDbContext>
    {
        public RegraDistribuicaoRepository(IRepositoryService<ApplicationSajDsgDbContext> repositoryService, IMapper mapper, ApplicationSajDsgDbContext sajDsgDbContext) : base(repositoryService, mapper, sajDsgDbContext)
        {
        }

        protected override Task<RegraDistribuicao> OnGetByIdAsync(IdRegraDistribuicao id, string[] selected, string[] expands)
            => base.OnGetByIdAsync(id, selected, new[]
                {
                    nameof(RegraDistribuicao.Assuntos), nameof(RegraDistribuicao.Classes),
                    nameof(RegraDistribuicao.Unidades), nameof(RegraDistribuicao.Tarjas),
                    nameof(RegraDistribuicao.OrgaosJulgadores), nameof(RegraDistribuicao.Especialidades)
                }
            );
        
        protected override async Task OnDeleteAsync(RegraDistribuicao domainModel)
        {
            var entry = await base.OnGetByIdAsync(domainModel);
            domainModel.Metadata = entry.Metadata;
            await base.OnDeleteAsync(domainModel);
        }

        protected override async Task OnUpdateAsync(RegraDistribuicao domainModel)
        {
            var entry = await OnGetByIdAsync(domainModel);
            DbContext.Set<CriterioAssunto>().RemoveRange(entry.Assuntos);
            DbContext.Set<CriterioTarja>().RemoveRange(entry.Tarjas);
            DbContext.Set<CriterioUnidade>().RemoveRange(entry.Unidades);
            DbContext.Set<CriterioClasse>().RemoveRange(entry.Classes);
            DbContext.Set<CriterioOrgaoJulgador>().RemoveRange(entry.OrgaosJulgadores);
            DbContext.Set<CriterioAssunto>().RemoveRange(entry.Assuntos);
            DbContext.Set<CriterioEspecialidade>().RemoveRange(entry.Especialidades);
            await  base.OnUpdateAsync(domainModel);
        }
    }
}