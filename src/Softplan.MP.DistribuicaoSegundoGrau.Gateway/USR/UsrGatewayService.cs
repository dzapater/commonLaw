using System;
using System.Threading.Tasks;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC;

namespace Softplan.MP.DistribuicaoSegundoGrau.Gateway.USR
{
    public class UsrGatewayService : BaseGatewayService, IUsrGatewayService
    {
        public UsrGatewayService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private const string QueryIdLocalByLotacaoId = @"query usuario_lotacao($filter: USR_usuario_lotacao_get_by_id_filter!)
                                                        {
                                                            Value: usuario_lotacao(filter: $filter){
                                                                id_local                                                                
                                                            }
                                                        }";

        public async Task<LotacaoResponseMessage> GetIdLocalByLotacaoId(int idLotacao, string usuario)
        {
            var client = GraphClientFactory.GetGraphClient(ServiceName);
            var data = await client.SendAsync<ResponseGatewayMessage<LotacaoResponseMessage>>(QueryIdLocalByLotacaoId, new
            {
                filter = new { id_usuario = usuario, numero_sequencial_lotacao = idLotacao}
            });

            return data.Value;
        }
    }
}