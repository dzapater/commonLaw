using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Softplan.Common.Core.Entities;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Graph.SchemaExtension;
using Softplan.Common.Repositories.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.ExcecaoVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.PTC;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.ExcecaoVagas.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Cadastros;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.ExcecaoVagas
{
    public class ExcecaoVagaSchemaExtension : SchemaExtension<DistribuicaoSegundoGrauSchema>
    {
        private IExtensibleQueryType _query;
        private IExtensibleMutationType _mutation;
        private const string InputArgument = "input";
        private const string Create = "create_excecao_vaga";
        private const string Update = "update_excecao_vaga";
        private const string Delete = "delete_excecao_vaga";
        private const string List = "list_excecao_vaga";
        private const string ValidaExcecaoVaga = "valida_excecao_vaga";


        private const string FilterArgument = "filter";
        private const string SortArgument = "sort";

        protected override void OnExtend(IExtensibleMutationType mutation)
        {
            _mutation = mutation;
            _mutation
                .From<ExcecaoVaga, IdExcecaoVaga>()
                .Custom<CreateExcecaoVagaInputType, ExcecaoVagaGraphType>(Create, ResolveCreate)
                .Custom<UpdateExcecaoVagaInputType, ExcecaoVagaGraphType>(Update, ResolveUpdate)
                .Custom<DeleteExcecaoVagaInputType, ExcecaoVagaGraphType>(Delete, ResolveDelete);
        }

        protected override void OnExtend(IExtensibleQueryType query)
        {
            _query = query;
            _query.From<ExcecaoVaga, IdExcecaoVaga, ExcecaoVagaGraphType>()
                .GetById()
                .Custom<ExcecaoVagaFilterType, CustomGraphPagedListType<ExcecaoVagaListItemGraphType, ExcecaoVagaReadModel>>(List, ResolveListExcecaoVaga)
                .Custom<CreateExcecaoVagaInputType, ValidaVinculoItemVagaGraphType>(ValidaExcecaoVaga, ResolveVerificaExcecaoVaga);

        }

        private async Task<object> ResolveListExcecaoVaga(IGraphBuilderResolve resolve)
        {
            var filter = _query.ParseArgument<ExcecaoVagaFilter>(resolve.Context, new[] { FilterArgument });
            var sorts = resolve.Context.GetArgument<ICollection<Sort>>(SortArgument);
            var response = await resolve.ExcecaoVagaQueryService().ListAsync(filter, sorts);

            response = await ObterOrigem(resolve, response);
            return new CustomGraphPagedList<ExcecaoVagaReadModel>(response);

        }

        private async Task<object> ResolveVerificaExcecaoVaga(IGraphBuilderResolve resolve)
        {
            var response = new ValidaVinculoItemVaga();
            var input = _query.ParseArgument<ExcecaoVaga>(resolve.Context, new[] { FilterArgument });

            await SetupInputAsync(input, resolve.RepositoryService(), resolve.ExcecaoVagaDomainService());

            var validation = await new ExcecaoVagaSaveValidator(resolve.Provider.GetRequiredService<IPropertyNameNormalizer>(), resolve.Provider.GetRequiredService<IStringLocalizer<DomainResources>>(), resolve.ExcecaoVagaDomainService()).ValidateAsync(input);

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

        private async Task<ICustomPagedList<ExcecaoVagaReadModel>> ObterOrigem(IGraphBuilderResolve resolve, ICustomPagedList<ExcecaoVagaReadModel> excecoes)
        {
            foreach(var excecao in excecoes)
            {
                if (excecao.ExcecaoVaga?.IdOrigem != null)
                {
                    var origem = await BuscarDadosOrigem(resolve, excecao.ExcecaoVaga.IdOrigem.Value);
                    excecao.ExcecaoVaga.Origem = new CriterioOrigem { Id = origem.Id, Descricao = origem.Descricao };
                }                
            }

            return excecoes;
        }

        private async Task<object> ResolveCreate(IGraphBuilderResolve resolve)
        {            
            var input = _mutation.ParseArgument<ExcecaoVaga>(resolve.Context, new[] {InputArgument});                        
            await SetupInputAsync(input, resolve.RepositoryService(), resolve.ExcecaoVagaDomainService());
            await resolve.ExcecaoVagaCrudService().AddAsync(input);            

            return input;
        }              

        private async Task<object> ResolveUpdate(IGraphBuilderResolve resolve)
        {
            var input = _mutation.ParseArgument<ExcecaoVaga>(resolve.Context, new[] { InputArgument });
            var excecaoVagaCadastrada = await resolve.ExcecaoVagaReadService().GetAsync(new IdExcecaoVaga { Id = input.Id });
            var excecaoVaga = SetPartialUpdate(input, excecaoVagaCadastrada);
            await SetupInputAsync(excecaoVaga, resolve.RepositoryService(), resolve.ExcecaoVagaDomainService());            
            await resolve.ExcecaoVagaCrudService().UpdateAsync(excecaoVaga);            

            return input;
        }

        private async Task<object> ResolveDelete(IGraphBuilderResolve resolve)
        {
            var input = _mutation.ParseArgument<ExcecaoVaga>(resolve.Context, new[] { InputArgument });
            var result = await resolve.RepositoryService().GetAsync<ExcecaoVaga>(x => x.Id == input.Id);
            if (result is null)
            {
                var service = resolve.Provider.GetRequiredService<ExcecaoVagaService>();
                service.NotificarNenhumaExcecaoCadastrada(input.Metadata.Uuid);
                var validation =
                    await new ExcecaoVagaDeleteValidator(resolve.Provider.GetRequiredService<IPropertyNameNormalizer>(), resolve.Provider.GetRequiredService<IStringLocalizer<DomainResources>>(), resolve.ExcecaoVagaDomainService()).ValidateAsync(input);
                foreach (var item in validation.Errors)
                    input.Mensagens.Add(item.ErrorMessage);
                return input;
            }

            await resolve.ExcecaoVagaCrudService().DeleteAsync(input);             
            return input;
        }        
 
        private async Task SetupInputAsync(ExcecaoVaga input, IRepositoryService<ApplicationSajDsgDbContext> repositoryService, ExcecaoVagaService domainService)
        {

            var query = await repositoryService.GetQueryableAsync<ExcecaoVaga>();
            var any = await domainService.FiltrarCriteriosJaCadastrados(query, input).AnyAsync();
            if (any) domainService.NotificarCriteriosJaCadastrados(input.Metadata.Uuid);
            
            any = domainService.ExisteExcecaoCadastrada(input);
            if (any) domainService.NotificarNenhumaExcecaoCadastrada(input.Metadata.Uuid);
        }        

        private ExcecaoVaga SetPartialUpdate(ExcecaoVaga input, ExcecaoVaga excecaoVagaCadastrada)
        {
            excecaoVagaCadastrada.IdOrgaoJulgador = input.IdOrgaoJulgador;
            excecaoVagaCadastrada.IdAssunto = input.IdAssunto;
            excecaoVagaCadastrada.IdClasse = input.IdClasse;
            excecaoVagaCadastrada.IdEspecialidade = input.IdEspecialidade;
            excecaoVagaCadastrada.IdOrigem = input.IdOrigem;
            excecaoVagaCadastrada.IdUnidade = input.IdUnidade;                        
            excecaoVagaCadastrada.Motivo = input.Motivo;

            return excecaoVagaCadastrada;
        }

        private async Task<OrigemResponseMessage> BuscarDadosOrigem(IGraphBuilderResolve resolve, int idOrigem)
        {
            var ptcGateway = resolve.Provider.GetRequiredService<IPtcGatewayService>();
            return await ptcGateway.GetOrigemById(idOrigem);
        }

    }
}