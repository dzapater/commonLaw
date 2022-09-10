using System.Threading.Tasks;
using Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.MPC;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.MCP
{
    public class MPCTestGatewayService : IMpcGatewayService
    {
        public Task<LoteDistribuicaoGraphType> AgendarRemessaProcesso(RemessaProcessoInputType input)
            => Task.FromResult(new LoteDistribuicaoGraphType
            {
                Id = input.CodigoProcesso.GetHashCode()
            });
    }
}