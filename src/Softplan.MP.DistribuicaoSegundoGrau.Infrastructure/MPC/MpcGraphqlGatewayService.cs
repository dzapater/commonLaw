using System.Threading.Tasks;
using Softplan.Common.Graph.Client.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.MPC;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.MPC
{
    public class MpcGraphqlGatewayService : IMpcGatewayService
    {
        private readonly IGraphClientFactory _graphClientFactory;
        private const string ServiceName = "APOLLO";

        private const string Query = @"mutation agendar_remessa_processo($input: MPC_remessa_processo_input_graph_type!){
                                          agendar_remessa_processo(
                                            input: $input
                                          ) {
                                            id
                                          }
                                        }";

        public MpcGraphqlGatewayService(IGraphClientFactory graphClientFactory)
        {
            _graphClientFactory = graphClientFactory;
        }

        public async Task<LoteDistribuicaoGraphType> AgendarRemessaProcesso(RemessaProcessoInputType input)
        {
            using (var client = _graphClientFactory.GetGraphClient(ServiceName))
                return await client.SendAsync<LoteDistribuicaoGraphType>(Query, new
                {
                    input = new
                    {
                        id_processo = input.CodigoProcesso, codigo_foro_destino = input.CodigoForoDestino,
                        codigo_tipo_local_destino = input.CodigoTipoLocalDestino, codigo_local_destino = input.CodigoLocalDestino
                    }
                });
        }
    }
}