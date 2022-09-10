using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;
using System.Threading.Tasks;

namespace Softplan.MP.DistribuicaoSegundoGrau.Gateway.PTC
{
    public interface IPtcGatewayService : IGatewayService
    {
        Task<OrigemResponseMessage> GetOrigemById(long idOrigem);
    }
}