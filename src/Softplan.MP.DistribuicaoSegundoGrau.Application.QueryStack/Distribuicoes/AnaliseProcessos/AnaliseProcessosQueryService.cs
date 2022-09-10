using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.AnaliseProcessos
{
    [ExcludeFromCodeCoverage]
    public class AnaliseProcessosQueryService : IAnaliseProcessosQueryService
    {
        private readonly QueryDbContext _dbContext;

        public AnaliseProcessosQueryService(QueryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<AnaliseProcessoReadModel> GetAnaliseById(AnaliseProcessoFilter filter)
            =>  (from analise in _dbContext.Set<AnaliseProcesso>().AsNoTracking()
                            where analise.IdProcesso.Equals(filter.IdProcesso)
                            join vaga in _dbContext.Set<Vaga>().AsNoTracking()
                            on analise.IdVaga equals vaga.Id into Vagas
                            from vagalj in Vagas.DefaultIfEmpty()
                            select new AnaliseProcessoReadModel
                            {
                                AreaAtuacao = analise.AreaAtuacao,
                                IdProcesso = analise.IdProcesso,
                                Motivo = analise.Motivo,
                                TipoDistribuicao = analise.TipoDistribuicao,
                                Vaga = vagalj
                            }).FirstOrDefaultAsync();
    }
}