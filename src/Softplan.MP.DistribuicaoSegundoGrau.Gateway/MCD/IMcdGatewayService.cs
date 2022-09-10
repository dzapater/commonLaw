using System.Threading.Tasks;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;

namespace Softplan.MP.DistribuicaoSegundoGrau.Gateway.MCD
{
    public interface IMcdGatewayService : IGatewayService
    {
        Task<ConsultaProcessoResponseMessage> GetProcessoById(string idProcesso);
        Task<AreaAtuacao> GetAreaAtuacaoById(long idAreaAtuacao);
        Task<EspecialidadeResponseMessage> GetEspecialidadeById(long idEspecialidade);
    }
}