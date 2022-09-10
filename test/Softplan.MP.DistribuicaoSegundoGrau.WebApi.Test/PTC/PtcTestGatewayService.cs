using System.Threading.Tasks;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.PTC;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.PTC
{
    public class PtcTestGatewayService : IPtcGatewayService
    {
            public Task<OrigemResponseMessage> GetOrigemById(long idOrigem)
                => Task.FromResult(new OrigemResponseMessage
                {
                    Id = 2,
                    Descricao = "teste"
                });
    }
}