using System.Threading.Tasks;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.MCD;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.MCD.ConsultaProcessoFactories;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.MCD
{
    public class McdTestGatewayService : IMcdGatewayService
    {
        public Task<ConsultaProcessoResponseMessage> GetProcessoById(string idProcesso)
            => Task.FromResult(ConsultaProcessoResponseMessageFactory.Create(idProcesso)?.GetConsultaProcessoResponseMessage());

        public Task<AreaAtuacao> GetAreaAtuacaoById(long idAreaAtuacao)
            => Task.FromResult(new AreaAtuacao
            {
                Id = 1,
                Nome = "Teste",
            });

        public Task<EspecialidadeResponseMessage> GetEspecialidadeById(long idEspecialidade)
            => Task.FromResult(new EspecialidadeResponseMessage
            {
                Id = idEspecialidade,
                Descricao = "Especialidade Teste"
            });

        public Task<LotacaoResponseMessage> GetIdLocalByLotacaoId(int idLotacao, string usuario)
            => Task.FromResult(new LotacaoResponseMessage
            {
                IdLocal = 1                
            });
    }
}