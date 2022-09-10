using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC;

namespace Softplan.MP.DistribuicaoSegundoGrau.Gateway.TAX
{
    public class TaxGatewayService : BaseGatewayService, ITaxGatewayService
    {
        public TaxGatewayService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        
        private const string QueryAssuntos = @"query assuntos($filter: TAX_assuntos_list_filter!)
                                                    {
                                                      Value: assuntos(filter: $filter){
                                                            items{
                                                              id
                                                              descricao
                                                            }
                                                      }
                                                    }";
        
        private const string QueryClasse = @"query classe($filter: TAX_classe_request_message_filter_type!)
                                                    {
                                                      Value: classe(filter: $filter){
                                                            id
                                                            descricao
                                                      }
                                                    }";
        
        private const string QueryTarja = @"query tarja($filter: TAX_tarja_por_id_request_message_filter_type!)
                                                    {
                                                      Value: tarja(filter: $filter){
                                                            id
                                                            descricao
                                                      }
                                                    }";
        
        private const string QueryOrgaoJulgador = @"query vara($filter: TAX_vara_request_message_filter_type!)
                                                    {
                                                      Value: vara(filter: $filter){
                                                            descricao: nome
                                                      }
                                                    }";
        
        private const string QueryUnidade = @"query foro($filter: TAX_foro_por_id_request_message_filter_type!)
                                                    {
                                                      Value: foro(filter: $filter){
                                                            descricao: nome
                                                      }
                                                    }";
        
        public async Task<ICollection<AssuntoResponseMessage>> GetAssuntosByIds(params long[] idsAssunto)
        {
            var client = GraphClientFactory.GetGraphClient(ServiceName);
            var data = await client.SendAsync<ResponseGatewayMessage<ItemsResponseMessage<AssuntoResponseMessage>>>(QueryAssuntos, new
            {
                filter = new { ids = idsAssunto }
            });
            return data.Value.Items;
        }

        public async Task<ClasseResponseMessage> GetClasseById(long idClasse)
        {
            var client = GraphClientFactory.GetGraphClient(ServiceName);
            var data = await client.SendAsync<ResponseGatewayMessage<ClasseResponseMessage>>(QueryClasse, new
            {
                filter = new { id = idClasse }
            });
            return data.Value;
        }

        public async Task<TarjaResponseMessage> GetTarjaById(long idTarja)
        {
            var client = GraphClientFactory.GetGraphClient(ServiceName);
            var data = await client.SendAsync<ResponseGatewayMessage<TarjaResponseMessage>>(QueryTarja, new
            {
                filter = new { id = idTarja }
            });
            return data.Value;
        }

        public async Task<OrgaoJulgadorResponseMessage> GetOrgaoJulgadorById(string idTipoCadastro, long idUnidade, long idOrgaoJulgador)
        {
            var client = GraphClientFactory.GetGraphClient(ServiceName);
            var data = await client.SendAsync<ResponseGatewayMessage<OrgaoJulgadorResponseMessage>>(QueryOrgaoJulgador, new
            {
                filter = new
                {
                    id = idOrgaoJulgador,
                    id_foro = idUnidade,
                    id_tipo_cadastro = idTipoCadastro
                }
            });
            return data.Value;
        }

        public async Task<UnidadeResponseMessage> GetUnidadeById(string idTipoCadastro, long idUnidade)
        {
            var client = GraphClientFactory.GetGraphClient(ServiceName);
            var data = await client.SendAsync<ResponseGatewayMessage<UnidadeResponseMessage>>(QueryUnidade, new
            {
                filter = new
                {
                    id = idUnidade,
                    id_tipo_cadastro = idTipoCadastro
                }
            });
            return data.Value;
        }
    }
}