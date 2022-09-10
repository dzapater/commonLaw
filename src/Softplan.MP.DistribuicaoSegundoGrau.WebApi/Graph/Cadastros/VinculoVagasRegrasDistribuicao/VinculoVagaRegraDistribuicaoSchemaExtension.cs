using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Softplan.Common.Core.Entities;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Graph.SchemaExtension;
using Softplan.Common.Repositories.EntityFrameworkCore;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoVagasRegrasDistribuicao.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Cadastros;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoVagasRegrasDistribuicao
{
    public class VinculoVagaRegraDistribuicaoSchemaExtension : SchemaExtension<DistribuicaoSegundoGrauSchema>
    {
        private IExtensibleQueryType _query;
        private IExtensibleMutationType _mutation;
        private const string Compensacao = "Compensacao";
        private const string Motivo = "Motivo";
        private const string InputArgument = "input";
        private const string FilterArgument = "filter";
        private const string SortArgument = "sort";
        private const string Create = "create_vinculo_vaga_regra_distribuicao";
        private const string Delete = "delete_vinculo_vaga_regra_distribuicao";
        private const string List = "list_vinculo_vagas_regras_distribuicao";
        private const string ListHistoricoCompensacao = "list_historico_compensacao_regras_distribuicao";
        private const string RegistraCompensacao = "registra_compensacao";
        private const string IgualarDistribuicao = "igualar_distribuicao";
        private const string VerificaVinculoRegra = "valida_vinculo_vaga_regra_distribuicao";
        private const string PermiteVinculoRegraGlobal = "permite_vinculo_regra_global";

        protected override void OnExtend(IExtensibleMutationType mutation)
        {
            _mutation = mutation;
            _mutation
                .From<VinculoVagaRegraDistribuicao, IdVinculoVagaRegraDistribuicao>()
                .Custom<CreateVinculoVagaRegraDistribuicaoInputType, VinculoVagaRegraDistribuicaoGraphType>(Create, ResolveCreate)
                .Custom<DeleteVinculoVagaRegraDistribuicaoInputType, VinculoVagaRegraDistribuicaoGraphType>(Delete, ResolveDelete)
                .Custom<IgualarDistribuicaoInputType, CompensacaoGraphType>(IgualarDistribuicao, ResolveIgualarDistribuicao)
                .Custom<CompensacaoInputType, CompensacaoGraphType>(RegistraCompensacao, ResolveRegistraCompensacao);
        }

        protected override void OnExtend(IExtensibleQueryType query)
        {
            _query = query;
            _query.From<VinculoVagaRegraDistribuicao, IdVinculoVagaRegraDistribuicao, VinculoVagaRegraDistribuicaoGraphType>()
                .Custom<VinculoVagaRegraDistribuicaoFilterType, CustomGraphPagedListType<VinculoVagaRegraDistribuicaoListItemGraphType, VinculoVagaRegraDistribuicaoReadModel>>(List, ResolveList)
                .Custom<CreateVinculoVagaRegraDistribuicaoInputType, ValidaVinculoItemVagaGraphType>(VerificaVinculoRegra, ResolveVerificaVinculoRegra)
                .Custom<VinculoVagaRegraDistribuicaoFilterType, ValidaVinculoItemVagaGraphType>(PermiteVinculoRegraGlobal, ResolveVerificaVinculoRegraGlobal)
                .Custom<HistoricoCompensacaoRegraFilterType, CustomGraphPagedListType<HistoricoCompensacaoRegraListGraphType, HistoricoCompensacaoRegraReadModel>>(ListHistoricoCompensacao, ResolveListHistoricoCompensacao);
        }

        private async Task<object> ResolveCreate(IGraphBuilderResolve resolve)
        {
            var input = _mutation.ParseArgument<VinculoVagaRegraDistribuicao>(resolve.Context, new[] { InputArgument });
            await SetupInputAsync(input,
                resolve.RepositoryService(),
                resolve.VinculoVagaRegraDomainService(),
                resolve.VinculoVagaRegraQueryService(),
                resolve.RegraDistribuicaoReadService());
            await resolve.VinculoVagaRegraCrudService().AddAsync(input);
            return input;
        }

        private async Task<object> ResolveDelete(IGraphBuilderResolve resolve)
        {
            var input = _mutation.ParseArgument<VinculoVagaRegraDistribuicao>(resolve.Context, new[] { InputArgument });
            await resolve.VinculoVagaRegraCrudService().DeleteAsync(input);
            return input;
        }

        private async Task<object> ResolveList(IGraphBuilderResolve resolve)
        {
            var sorts = resolve.Context.GetArgument<ICollection<Sort>>(SortArgument);
            var filter = _query.ParseArgument<VinculoVagaRegraDistribuicaoFilter>(resolve.Context, new[] { FilterArgument });
            var response = await resolve.VinculoVagaRegraQueryService().ListAsync(filter, sorts);
            return new CustomGraphPagedList<VinculoVagaRegraDistribuicaoReadModel>(response);
        }

        private async Task<object> ResolveVerificaVinculoRegra(IGraphBuilderResolve resolve)
        {
            var response = new ValidaVinculoItemVaga();
            var input = _query.ParseArgument<VinculoVagaRegraDistribuicao>(resolve.Context, new[] { FilterArgument });

            await SetupInputAsync(input,
                resolve.RepositoryService(),
                resolve.VinculoVagaRegraDomainService(),
                resolve.VinculoVagaRegraQueryService(),
                resolve.RegraDistribuicaoReadService());

            var validation = await new VinculoVagaRegraDistribuicaoSaveValidator(resolve.Provider.GetRequiredService<IPropertyNameNormalizer>(), resolve.Provider.GetRequiredService<IStringLocalizer<DomainResources>>(), resolve.VinculoVagaRegraDomainService()).ValidateAsync(input);

            if (validation.IsValid)
                response.Status = true;
            else
            {
                response.Status = false;                
                foreach (var item in validation.Errors)                
                    response.Mensagens.Add(item.ErrorMessage);                
            }

            return response;
        }

        private async Task<object> ResolveVerificaVinculoRegraGlobal(IGraphBuilderResolve resolve)
        {
            var response = new ValidaVinculoItemVaga();
            
            var sorts = resolve.Context.GetArgument<ICollection<Sort>>(SortArgument);
            var filter = _query.ParseArgument<VinculoVagaRegraDistribuicaoFilter>(resolve.Context, new[] { FilterArgument });
            var existeRegraGlobal = await resolve.VinculoVagaRegraQueryService().GetRegraGlobalAsync(filter, sorts);

            if(existeRegraGlobal)
            {
                response.Status = false;
                response.Mensagens.Add(DomainResources.RegraGlobalJaVinculadas);
            }
            else
                response.Status = true;

            return response;
        }        

        private async Task<object> ResolveListHistoricoCompensacao(IGraphBuilderResolve resolve)
        {
            var filter = _query.ParseArgument<HistoricoCompensacaoRegraFilter>(resolve.Context, new[] { FilterArgument });
            var sorts = resolve.Context.GetArgument<ICollection<Sort>>(SortArgument);
            var response = await resolve.HistoricoCompensacaoQueryService().ListAsync(filter, sorts);
            return new CustomGraphPagedList<HistoricoCompensacaoRegraReadModel>(response);
        }

        private async Task<object> ResolveRegistraCompensacao(IGraphBuilderResolve resolve)
        {
            var input = _mutation.ParseArgument<Compensacao>(resolve.Context, new[] { InputArgument });

            var (vagas, logs) = await SetupRegistraCompensacaoAsync(
                resolve.RepositoryService(), 
                resolve.VinculoVagaRegraDomainService(),
                input);
            await resolve.VagaCrudService().PartialUpdateRangeAsync(vagas, Compensacao, Motivo);
            await resolve.CompensacaoCrudService().AddRangeAsync(logs);
            return input;
        }
        
        private async Task<object> ResolveIgualarDistribuicao(IGraphBuilderResolve resolve)
        {
            var input = _mutation.ParseArgument<Compensacao>(resolve.Context, new[] { InputArgument });
            var domainService = resolve.VinculoVagaRegraDomainService();
            var vinculos = await resolve.RepositoryService().GetQueryableAsync<VinculoVagaRegraDistribuicao>();
            var vagasCadastradas = resolve.VinculoVagaRegraDomainService().FiltrarVagasVinculadasPorIdRegra(vinculos, input.IdRegraDistribuicao);
            var vagasAtualizar = await vagasCadastradas.ToListAsync();
            if (vagasAtualizar.Any())
            {
                var maxDistribuicao = await vagasCadastradas.MaxAsync(x => x.Distribuicoes);
                vagasAtualizar.ForEach(x => { x.Compensacao = maxDistribuicao - x.Distribuicoes; x.Motivo = input.Motivo; });
            }
            if(string.IsNullOrWhiteSpace(input.Motivo))
                vagasAtualizar.ForEach(x => domainService.NotificarMotivoInvalido(x.Metadata.Uuid));
            var logs = SetUpCompensacaoLog(vagasAtualizar, vagasCadastradas);
            await resolve.VagaCrudService().PartialUpdateRangeAsync(vagasAtualizar, Compensacao, Motivo);
            await resolve.CompensacaoCrudService().AddRangeAsync(logs);
            return input;
        }

        private async Task SetupInputAsync(VinculoVagaRegraDistribuicao input, IRepositoryService<ApplicationSajDsgDbContext> repositoryService, VinculoVagaRegraDistribuicaoService domainService
        , IVinculoVagaRegraDistribuicaoQueryService readService, IReadService<RegraDistribuicao, IdRegraDistribuicao> readRegraService)
        {
            var query = await repositoryService.GetQueryableAsync<VinculoVagaRegraDistribuicao>();
            var any = await domainService.FiltrarInformacoesJaVinculadas(query, input).AnyAsync();
            if (any) domainService.NotificarInformacoesJaVinculadas(input.Metadata.Uuid);
            var regra = await readRegraService.GetAsync(new IdRegraDistribuicao { Id = input.IdRegraDistribuicao });
            if (domainService.FiltrarRegraGlobal(regra))
            {
                var vinculos = await readService.ListAsync(new VinculoVagaRegraDistribuicaoFilter { IdVaga = input.IdVaga }, default);
                var regrasIds = vinculos.Select(x => x.RegraDistribuicao.Id);
                var queryRegra = await repositoryService.GetQueryableAsync<RegraDistribuicao>();
                any = await domainService.FiltrarRegrasGlobaisJaVinculadas(queryRegra, regrasIds).AnyAsync();
                if (any) domainService.NotificarRegraGlobalJaVinculadas(input.Metadata.Uuid);
            }
        }


        private async Task<(ICollection<Vaga>, ICollection<CompensacaoLog>)> SetupRegistraCompensacaoAsync(IRepositoryService<ApplicationSajDsgDbContext> repositoryService, 
            VinculoVagaRegraDistribuicaoService domainService, Compensacao input)
        {
            var vinculoVagaRegra = await repositoryService.GetQueryableAsync<VinculoVagaRegraDistribuicao>();
            var vagasByIdRegra = domainService.FiltrarVagasVinculadasPorIdRegra(vinculoVagaRegra, input.IdRegraDistribuicao);
            var vagasCadastradas = await domainService.FiltrarVagasCadastradasPorIds(vagasByIdRegra, input).ToListAsync();
            if (!vagasCadastradas.Any())
                throw new Exception(DomainResources.RegraInvalida);
            var vagasAtualizar = SetUpVagasAtualizar(input, vagasCadastradas);
            if(string.IsNullOrWhiteSpace(input.Motivo))
                vagasAtualizar.ForEach(x => domainService.NotificarMotivoInvalido(x.Metadata.Uuid));
            var maxDistribuicao = await vagasByIdRegra.MaxAsync(x => x.Distribuicoes);
            var vagasCompensacaoInvalida = domainService.ValidaCompensacao(vagasAtualizar, maxDistribuicao);
            if(vagasCompensacaoInvalida.Any())
                vagasCompensacaoInvalida.ForEach(x => domainService.NotificarCompensacaoInvalida(x.Metadata.Uuid));
            var logs = SetUpCompensacaoLog(vagasAtualizar, vagasByIdRegra);
            return (vagasAtualizar, logs);
        }

        private ICollection<CompensacaoLog> SetUpCompensacaoLog(ICollection<Vaga> vagasAtualizar, IQueryable<Vaga> vagasCadastradas)
        {
            var logs = new List<CompensacaoLog>();
            foreach (var vaga in vagasAtualizar)
            {
                logs.Add(new CompensacaoLog(vagasCadastradas.First(c => c.Id == vaga.Id), vaga));
            }
            return logs;
        }
        
        private List<Vaga> SetUpVagasAtualizar(Compensacao input, List<Vaga> vagasCadastradas)
        {
            foreach (var vaga in vagasCadastradas)
            {
                vaga.Compensacao = input.Vagas.First(x => x.Id == vaga.Id).Compensacao;
                vaga.Motivo = input.Motivo;
            }
            return vagasCadastradas;
        }
    }
}