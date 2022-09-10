using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;
using System;
using System.Threading.Tasks;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC;

namespace Softplan.MP.DistribuicaoSegundoGrau.Gateway.PTC
{
    public class PtcGatewayService : BaseGatewayService, IPtcGatewayService
    {
        public PtcGatewayService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
 
        private const string QueryOrigemById = @"query origem($filter: PTC_origem_get_by_id_filter!)
                                                        {
                                                            Value: origem(filter: $filter){
                                                                id 
                                                                descricao
                                                            }
                                                        }";      

        public async Task<OrigemResponseMessage> GetOrigemById(long idOrigem)
        {
            var client = GraphClientFactory.GetGraphClient(ServiceName);
            var data = await client.SendAsync<ResponseGatewayMessage<OrigemResponseMessage>>(QueryOrigemById, new
            {
                filter = new { id = idOrigem }
            });

            return data.Value;
        }
    }
}