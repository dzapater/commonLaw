using System.Threading.Tasks;
using Softplan.Common.Core.Entities.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.MPC
{
    public interface IMpcGatewayService : IGatewayService
    {
        Task<LoteDistribuicaoGraphType> AgendarRemessaProcesso(RemessaProcessoInputType input);
    }
}