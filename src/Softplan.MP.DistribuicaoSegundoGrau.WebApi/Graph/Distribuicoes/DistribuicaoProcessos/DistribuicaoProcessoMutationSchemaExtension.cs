using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Graph.SchemaExtension;
using Softplan.Common.MessageBus.Abstractions.Producers;
using Softplan.Common.Repositories.EntityFrameworkCore;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Distribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Documents;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Events;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.Distribuicoes.Factories;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Parametros;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.ValueObjects;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.MCD;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.DistribuicaoProcessos.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.DistribuicaoProcessos.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Cadastros;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Distribuicoes;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.DistribuicaoProcessos
{
    public class DistribuicaoProcessoMutationSchemaExtension : SchemaExtension<DistribuicaoSegundoGrauSchema>
    {
        private const string InputArgument = "input";
        private const string RequestDistribuirProcesso = "distribuir_processo";
        private const string ConsultaDistribuicaoProcesso = "consulta_distribuicao_processo";
        private static readonly TimeSpan RequestTimeout = TimeSpan.FromSeconds(90);
        private const string FilterArgument = "filter";

        private IExtensibleMutationType _mutation;
        private IExtensibleQueryType _query;

        protected override void OnExtend(IExtensibleMutationType mutation)
        {
            _mutation = mutation;
            _mutation
                .Custom<RequestDistribuirProcessoInputType, ResponseDistribuirProcessoGraphType>(RequestDistribuirProcesso, resolve: ResolveRequest);
        }

        protected override void OnExtend(IExtensibleQueryType query)
        {
            _query = query;
            _query.Custom<DistribuicaoProcessoFilterType, CustomGraphPagedListType<DistribuicaoProcessoReadModelGraphType, DistribuicaoProcessoReadModel>>(ConsultaDistribuicaoProcesso, ResolveDistribuicaoProcessoById);
        }
        
        private async Task<object> ResolveDistribuicaoProcessoById(IGraphBuilderResolve resolve)
        {
            var filter = _query.ParseArgument<DistribuicaoProcessoFilter>(resolve.Context, new[] { FilterArgument });
            var response = await resolve.DistribuicaoProcessoQueryService().GetDistribuicaoProcessoById(filter);
            return new CustomGraphPagedList<DistribuicaoProcessoReadModel>(response);
            
        }

        private async Task<object> ResolveRequest(IGraphBuilderResolve resolve)
        {
            var command = _mutation.ParseArgument<DistribuirProcessoRequest>(resolve.Context, new[] { InputArgument });
            var processo = await BuscarDadosDoProcesso(resolve, command.IdProcesso);
            command.Volumes = processo.Volumes;
            command.AreaProcesso = processo.Areas.FirstOrDefault(x => x.Selecionado)?.TipoArea ?? Area.Indefinida;
            command.Processo = MapProcessoDocument(in processo);
            var consultaDistribuicaoProcesso = await resolve.RepositoryService().GetQueryableAsync<DistribuicaoProcesso>();

            if (!VerificaTipoDeDistribuicao(consultaDistribuicaoProcesso, command.IdProcesso) && command.TipoDistribuicao.Equals(TipoDistribuicao.Sorteio))
            {
                if(VerificaPrimeiraDistribuicao(consultaDistribuicaoProcesso, command.IdProcesso) && await VerificarDistribuicaoDireta(consultaDistribuicaoProcesso, command.IdProcesso, resolve))
                    DistribuirProcessoPorPrevencao(command, consultaDistribuicaoProcesso);
                else 
                    await SetupDistribuirPorSorteio(command, resolve);
            }
            else 
                DistribuirProcessoPorPrevencao(command, consultaDistribuicaoProcesso);

            var response = await resolve.Provider.GetRequiredService<IMessageBusProducer>().SendRequestAsync<DistribuirProcessoRequest, DistribuirProcessoResponse>(command, RequestTimeout);
            return ObterVagaRegraDistribuida(response, command, resolve);
        }

        private DistribuirProcessoResponse ObterVagaRegraDistribuida(DistribuirProcessoResponse response, DistribuirProcessoRequest command, IGraphBuilderResolve resolve)
        {
            response.Vaga = resolve.RepositoryService().GetQueryableAsync<Vaga>().ConfigureAwait(false).GetAwaiter().GetResult().Where(x => x.Id == command.IdVaga).FirstOrDefault();                        
            if (command.IdRegraDistribuicao != null)
                response.RegraDistribuicao = resolve.RepositoryService().GetQueryableAsync<RegraDistribuicao>().ConfigureAwait(false).GetAwaiter().GetResult().Where(x => x.Id == command.IdRegraDistribuicao).FirstOrDefault();
            
            return response;
        }

        private ProcessoDocument MapProcessoDocument(in ConsultaProcessoResponseMessage processo)
            => new ProcessoDocument
                {
                    Volumes = processo.Volumes,
                    IdAssunto = processo.Assunto?.Id,
                    IdClasse = processo.Classe?.Id,
                    IdEspecialidade = processo.Especialidade?.Id,
                    IdOrgaoJulgador = processo.OrgaoJulgador?.Id,
                    IdOrigem = ToNullableInt(processo.OrgaoJulgador?.IdOrigem),
                    IdUnidade = processo.OrgaoJulgador?.IdUnidade,
                    IdTarja = processo.Tarjas?.Select(x => x.Id),
                    Area = processo.Areas.FirstOrDefault( x=>x.Selecionado).TipoArea
                    
                };        

        private void DistribuirProcessoPorPrevencao(DistribuirProcessoRequest command, IQueryable<DistribuicaoProcesso> consultaDistribuicaoProcesso)
        {
            command.IdVaga = consultaDistribuicaoProcesso.Where(x => x.IdProcesso.Contains(command.IdProcesso) && x.TipoDistribuicao.Equals(TipoDistribuicao.Prevencao)).Select(x => x.IdVaga).FirstOrDefault() ?? command.IdVaga;
            command.TipoDistribuicao = TipoDistribuicao.Prevencao;
        }

        private async Task SetupDistribuirPorSorteio(DistribuirProcessoRequest command, IGraphBuilderResolve resolve)
        {
            var service = resolve.Provider.GetRequiredService<DistribuicaoProcessoService>();
            var regraDistribuicao = await BuscaRegraDistribuicaoMaisEspecificaVaga(command, resolve);
                        
            if (!regraDistribuicao.Any()) throw new Exception("Nenhuma Regra Disponível"); 

            var regraDistribuicaoMaisEspecifica = await
                service.ObtemRegraDistribuicaoMaisEspecificaProcesso(regraDistribuicao, command.Processo);
            
            await SetupExecutarDistribuicaoSorteio(command, resolve, regraDistribuicaoMaisEspecifica);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private async Task SetupExecutarDistribuicaoSorteio(DistribuirProcessoRequest command,
            IGraphBuilderResolve resolve, IOrderedEnumerable<KeyValuePair<RegraDistribuicao, int>> regraDistribuicaoMaisEspecifica)
        {
            foreach (var regra in regraDistribuicaoMaisEspecifica)
            {
                var vagasVinculadasSemImpedimento = await FiltrarVagasComImpedimentoAsync(resolve, command, regra.Key);
                if (!vagasVinculadasSemImpedimento.Any()) continue;
                var vagasSemExcecao = await FiltrarVagasComExcecoes(vagasVinculadasSemImpedimento, resolve, command);
                if (!vagasSemExcecao.Any()) continue;
                var vagasSemDistMesmaVaga = await FiltrarVagasDistribuicaoMesmaVaga(vagasSemExcecao, resolve, command);
                if (!vagasSemDistMesmaVaga.Any()) continue;
                var vagasDesvioValido = await FiltrarVagasComDistribuicaoAcimaDoDesvio(vagasSemDistMesmaVaga, regra.Key, command, resolve);
                command.IdRegraDistribuicao = regra.Key.Id;
                await SaveLogs(resolve, command);
                if (!vagasDesvioValido.Any()) continue;
                command.IdVaga = vagasDesvioValido.ExecutaProcessoSorteioRandom().ConfigureAwait(false).GetAwaiter().GetResult().Id;
                break;
            }
        }

        private async Task<IQueryable<Vaga>> FiltrarVagasComImpedimentoAsync(IGraphBuilderResolve resolve, DistribuirProcessoRequest command, RegraDistribuicao regra)
        {
            var vinculoVagaRegra =
                await resolve.RepositoryService().GetQueryableAsync<VinculoVagaRegraDistribuicao>();
            var impedimentos = await VerificaImpedimentos(command.IdProcesso, resolve);

            if (impedimentos.Any())
            {
                var domainEvent = MessageFactory.Create(impedimentos.ToList()).DomainEvent;
                command.Logs.Add(ImpedimentoDistribuicaoLog.Create(command, domainEvent));                
            }
            return vinculoVagaRegra.RetornaVagasVinculadas(regra).ConfigureAwait(false).GetAwaiter().GetResult()
                    .RetornaVagasVinculadasSemImpedimento(impedimentos).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        
        private async Task<IQueryable<ImpedimentoProcesso>> VerificaImpedimentos(string idProcesso,
            IGraphBuilderResolve resolve)
        {
            var repositoryService = await resolve.RepositoryService().GetQueryableAsync<ImpedimentoProcesso>();
            return repositoryService.Include(x => x.Vaga).Where(x => x.IdProcesso.Equals(idProcesso));
        }
        
        private async Task<List<RegraDistribuicao>> BuscaRegraDistribuicaoMaisEspecificaVaga(DistribuirProcessoRequest command, IGraphBuilderResolve resolve)
        {
            var service = resolve.Provider.GetRequiredService<RegraDistribuicaoService>();
            var regras = await resolve.RepositoryService().GetQueryableAsync<RegraDistribuicao>(nameof(RegraDistribuicao.Assuntos), nameof(RegraDistribuicao.Classes), nameof(RegraDistribuicao.Especialidades), nameof(RegraDistribuicao.OrgaosJulgadores),nameof(RegraDistribuicao.Tarjas));
            return service.ObterRegrasAtivasCompativeis(regras, command.Processo).ToList();
        }

        private async Task<ConsultaProcessoResponseMessage> BuscarDadosDoProcesso(IGraphBuilderResolve resolve, string idProcesso)
        {
            var mcdGateway = resolve.Provider.GetRequiredService<IMcdGatewayService>();
            return await mcdGateway.GetProcessoById(idProcesso);
        }

        private async Task<IQueryable<Vaga>> FiltrarVagasComExcecoes(IQueryable<Vaga> vagasElegiveis, IGraphBuilderResolve resolve, DistribuirProcessoRequest command)
        {
            var excecaoVaga = await resolve.RepositoryService().GetQueryableAsync<ExcecaoVaga>();            
            var vagasComExcecoes = resolve.DistribuicaoProcessoService().FiltrarVagasComExcecao(excecaoVaga, vagasElegiveis, command.Processo);
            var vagasSemExcecoes = vagasElegiveis.Except(vagasComExcecoes);
             
            if(vagasComExcecoes.Any())
                AddLog(vagasComExcecoes, command, DomainResources.VagasRemovidasExcecaoDistribuicao);

            return vagasSemExcecoes;
        }

        private async Task<IQueryable<Vaga>> FiltrarVagasDistribuicaoMesmaVaga(IQueryable<Vaga> vagasVinculadasSemImpedimento,  
                                                                        IGraphBuilderResolve resolve, DistribuirProcessoRequest command) 
        {
            var distribuicaoProcesso =  await resolve.RepositoryService().GetQueryableAsync<DistribuicaoProcesso>();
            var analiseProcesso = await resolve.RepositoryService().GetQueryableAsync<AnaliseProcesso>();            
            var vagasParaRemocao = resolve.DistribuicaoProcessoService().FiltrarVagasDistribuicaoMesmaVaga(distribuicaoProcesso, analiseProcesso, vagasVinculadasSemImpedimento);
            var vagasElegiveis = vagasVinculadasSemImpedimento.Except(vagasParaRemocao);

            if(vagasParaRemocao.Any())
                AddLog(vagasParaRemocao, command, DomainResources.VagasRemovidasDistribuicaoMesmaVaga);
            
            return vagasElegiveis;
        }
        
        public async Task<IQueryable<Vaga>> FiltrarVagasComDistribuicaoAcimaDoDesvio(IQueryable<Vaga> vagas, RegraDistribuicao regra
            , DistribuirProcessoRequest command, IGraphBuilderResolve resolve)
        {
            var domainService = resolve.DistribuicaoProcessoService();
            var repositoryService = resolve.Provider.GetRequiredService<IRepositoryService<ApplicationDbContext>>();
            var repositoryServiceSajDsg = resolve.RepositoryService();
            var queryParam = await repositoryService.GetQueryableAsync<Parametro>();
            var descricaoParam = regra.VariavelEquilibrio.Equals(VariavelEquilibrio.Volume)
                ? VariavelEquilibrio.Volume.ToString()
                : regra.EscopoEquilibrio.ToString();

            var parametro = queryParam.FirstOrDefault(x => x.Descricao.Equals(Parametro.GetDescriptionValue(descricaoParam)));
            var distribuicoes = await BuscarDistribuicaoTotal(regra, vagas, domainService, repositoryServiceSajDsg);
            var vagasRemovidas = domainService.BuscarIdVagasARemoverDesvioInvalido(distribuicoes, parametro?.Desvio);
            
            if(vagasRemovidas.Any())
                AddLog(vagasRemovidas.Select(x => x.Vaga), command, DomainResources.VagasRemovidasDesvioInvalido);
            
            return vagas.Where(x => !vagasRemovidas.Select(r => r.IdVaga).Contains(x.Id));
        }
        
        private static async Task<IQueryable<DistribuicaoVagaDocument>> BuscarDistribuicaoTotal(RegraDistribuicao regra, IQueryable<Vaga> vagas, 
            DistribuicaoProcessoService domainService, IRepositoryService<ApplicationSajDsgDbContext> repository)
        {
            var vinculos = await repository.GetQueryableAsync<VinculoVagaRegraDistribuicao>();
            return domainService.BuscarDadosDistribuicao(vinculos, regra.Id, vagas.Select(x => x.Id), regra.EscopoEquilibrio.Equals(EscopoEquilibrio.Global) 
                ? DistribuicaoVagaDocument.SelectNewGlobal 
                : DistribuicaoVagaDocument.SelectNewLocal);
        }

        private bool VerificaTipoDeDistribuicao(IQueryable<DistribuicaoProcesso> consultaDistribuicaoProcesso, string idProcesso)
            =>consultaDistribuicaoProcesso.Where(x => x.IdProcesso.Contains(idProcesso)).Any(x => x.TipoDistribuicao.Equals(TipoDistribuicao.Prevencao));           
        
        private bool VerificaPrimeiraDistribuicao(IQueryable<DistribuicaoProcesso> consultaDistribuicaoProcesso, string idProcesso)
             => !consultaDistribuicaoProcesso.Where(x => x.IdProcesso.Contains(idProcesso)).Any();  
            
        private async Task<bool> VerificarDistribuicaoDireta(IQueryable<DistribuicaoProcesso> consultaDistribuicaoProcesso, string idProcesso, IGraphBuilderResolve resolve)
        {
            var ultimaDistribuicao = consultaDistribuicaoProcesso.AsEnumerable().LastOrDefault(x => x.IdProcesso.Equals(idProcesso));
            
            if (ultimaDistribuicao is null) return false;

            var vagas = await resolve.RepositoryService().GetQueryableAsync<Vaga>();                        

            var ultimaVaga = vagas.LastOrDefault(c => c.Id == ultimaDistribuicao.IdVaga && c.ConsiderarConfiguracoesPrevencao);

            if (ultimaVaga != null && !ultimaVaga.ConsiderarConfiguracoesPrevencao) 
                return false;

            var impedimentos = await  VerificaImpedimentos(idProcesso, resolve);
            return impedimentos.All(x => x.IdVaga != ultimaVaga.Id);
        }

        private void AddLog(IQueryable<Vaga> vagas, DistribuirProcessoRequest command, string domainResources)
        {
            var domainEvent = MessageFactory.Create(vagas.ToList(), domainResources).DomainEvent;
            var log = ImpedimentoDistribuicaoLog.Create(command, domainEvent);
            command.Logs.Add(log);
        }
        
        private async Task SaveLogs(IGraphBuilderResolve resolve, DistribuirProcessoRequest command)
        {
            if (command.Logs.Any())
            {
                var crudService = resolve.Provider.GetRequiredService<ICrudService<ImpedimentoDistribuicaoLog, IdImpedimentoDistribuicaoLog>>();
                await crudService.AddRangeAsync(command.Logs);
            }
        }
        
        private static int? ToNullableInt(string s)
        {
            if (int.TryParse(s, out var i)) return i;
            return null;
        }
    }
}