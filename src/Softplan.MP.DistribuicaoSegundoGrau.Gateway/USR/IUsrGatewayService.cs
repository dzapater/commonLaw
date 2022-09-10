using System.Threading.Tasks;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;

namespace Softplan.MP.DistribuicaoSegundoGrau.Gateway.USR
{
    public interface IUsrGatewayService : IGatewayService
    {
        Task<LotacaoResponseMessage> GetIdLocalByLotacaoId(int idLotacao, string usuario);
    }
}