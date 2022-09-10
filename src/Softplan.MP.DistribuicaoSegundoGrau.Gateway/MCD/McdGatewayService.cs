using System;
using System.Threading.Tasks;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC;

namespace Softplan.MP.DistribuicaoSegundoGrau.Gateway.MCD
{
    public class McdGatewayService : BaseGatewayService, IMcdGatewayService
    {
        public McdGatewayService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            
        }

        private const string QueryProcessoById = @"query consulta_processo($filter: MCD_processo_request_message_graph_type_input!)
                                                    {
                                                      Value: consulta_processo(filter: $filter){
                                                          id
                                                          status
                                                          volumes                                                          
                                                          classe {
                                                              id
                                                              descricao
                                                          }
                                                          especialidade {
                                                              id
                                                          }
                                                          orgao_julgador: vara {
                                                              id
                                                              id_origem : id_tipo_cadastro
                                                              id_unidade: id_foro
                                                          }
                                                          assunto {
                                                              id
                                                          }
                                                          areas {
                                                              selecionado
                                                              tipo_area
                                                           }
                                                           tarjas {
                                                              id
                                                              descricao
                                                              prioridade
                                                              codigo_tarja_cor
                                                              cor
                                                           }
                                                      }
                                                    }";

        private const string QueryAreaAtucaoById = @"query area_atuacao($filter: MCD_area_atuacao_request_message_filter_type_input!)
                                                        {
                                                            Value: area_atuacao(filter: $filter){
                                                                id 
                                                                nome
                                                            }
                                                        }";

        private const string QueryEspecialidade = @"query especialidade($filter: MCD_especialidade_por_id_request_message_filter_type!)
                                                    {
                                                      Value: especialidade(filter: $filter){
                                                            id
		                                                    descricao
                                                      }
                                                    }";
        
        public async Task<EspecialidadeResponseMessage> GetEspecialidadeById(long idEspecialidade)
        {
            var client = GraphClientFactory.GetGraphClient(ServiceName);
            var data = await client.SendAsync<ResponseGatewayMessage<EspecialidadeResponseMessage>>(QueryEspecialidade, new
            {
                filter = new { id = idEspecialidade }
            });
            return data.Value;
        }
        
        public async Task<ConsultaProcessoResponseMessage> GetProcessoById(string idProcesso)
        {
            var client = GraphClientFactory.GetGraphClient(ServiceName);
            var data = await client.SendAsync<ResponseGatewayMessage<ConsultaProcessoResponseMessage>>(QueryProcessoById, new
            {
                filter = new { id = idProcesso }
            });
            return data.Value;
        }

        public async Task<AreaAtuacao> GetAreaAtuacaoById(long idAreaAtuacao)
        {
            var client = GraphClientFactory.GetGraphClient(ServiceName);
            var data = await client.SendAsync<ResponseGatewayMessage<AreaAtuacao>>(QueryAreaAtucaoById, new
            {
                filter = new { id = idAreaAtuacao }
            });

            return data.Value;
        }
    }
}