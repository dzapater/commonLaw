using System.Threading.Tasks;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.USR;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.USR
{
    public class UsrTestGatewayService : IUsrGatewayService
    {
        public Task<LotacaoResponseMessage> GetIdLocalByLotacaoId(int idLotacao, string usuario)
            => Task.FromResult(new LotacaoResponseMessage
            {
                IdLocal = 2                
            });
    }
}