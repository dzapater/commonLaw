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
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Cadastros;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Softplan.Common.Core.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas
{
    public class VinculoMembroVagaSchemaExtension : SchemaExtension<DistribuicaoSegundoGrauSchema>
    {
        private IExtensibleQueryType _query;
        private IExtensibleMutationType _mutation;
        private const string InputArgument = "input";
        private const string FilterArgument = "filter";
        private const string SortArgument = "sort";
        private const string Create = "create_vinculo_membro_vaga";
        private const string Update = "update_vinculo_membro_vaga";
        private const string Delete = "delete_vinculo_membro_vaga";
        private const string List = "list_vinculo_membro_vaga";
        private const string VerificaVinculoMembro = "valida_vinculo_membro_vaga";
        
        protected override void OnExtend(IExtensibleMutationType mutation)
        {
            _mutation = mutation;
            _mutation
                .From<VinculoMembroVaga, IdVinculoMembroVaga>()
                .Custom<CreateVinculoMembroVagaInputType, VinculoMembroVagaGraphType>(Create, ResolveCreate)
                .Custom<UpdateVinculoMembroVagaInputType, VinculoMembroVagaGraphType>(Update, ResolveUpdate)
                .Custom<DeleteVinculoMembroVagaInputType, VinculoMembroVagaGraphType>(Delete, ResolveDelete);
        }
        
        protected override void OnExtend(IExtensibleQueryType query)
        {
            _query = query;
            _query.From<VinculoMembroVaga, IdVinculoMembroVaga, VinculoMembroVagaGraphType>()
                .Custom<VinculoMembroVagaFilterType, CustomGraphPagedListType<VinculoMembroVagaListItemGraphType, VinculoMembroVagaReadModel>>(List, ResolveList)
                .Custom<FilterVinculoMembroVagaInputType, ValidaVinculoItemVagaGraphType>(VerificaVinculoMembro, ResolveVerificaVinculoMembro);
        }

        private async Task<object> ResolveCreate(IGraphBuilderResolve resolve)
        {
            var input = _mutation.ParseArgument<VinculoMembroVaga>(resolve.Context, new[] {InputArgument});
            if (string.IsNullOrWhiteSpace(input.IdMembro))
                input.IdMembro = Situacao.DesativacaoPlanejada.ToString();
            var crudService = resolve.VinculoMembroVagaCrudService();
            await SetupCreateInputAsync(input, 
                resolve.RepositoryService(), 
                resolve.VinculoMembroVagaDomainService(), 
                crudService
               );
            await crudService.AddAsync(input);
            return input;
        }

        private async Task<object> ResolveUpdate(IGraphBuilderResolve resolve)
        {
            var input = _mutation.ParseArgument<VinculoMembroVaga>(resolve.Context, new[] {InputArgument});
            if (string.IsNullOrWhiteSpace(input.IdMembro))
                input.IdMembro = Situacao.DesativacaoPlanejada.ToString();
            await SetupInputAsync(input, 
                resolve.RepositoryService(), 
                resolve.VinculoMembroVagaDomainService());
            await resolve.VinculoMembroVagaCrudService().UpdateAsync(input);
            return input;
        }

        private async Task<object> ResolveDelete(IGraphBuilderResolve resolve)
        {
            var input = _mutation.ParseArgument<VinculoMembroVaga>(resolve.Context, new[] {InputArgument});
            await resolve.VinculoMembroVagaCrudService().DeleteAsync(input);
            return input;
        }

        private async Task<object> ResolveList(IGraphBuilderResolve resolve)
        {
            var filter = _query.ParseArgument<VinculoMembroVagaFilter>(resolve.Context, new[] {FilterArgument});
            var sorts = resolve.Context.GetArgument<ICollection<Sort>>(SortArgument);
            var response = await resolve.VinculoMembroVagaQueryService().ListAsync(filter, sorts);
            return new CustomGraphPagedList<VinculoMembroVagaReadModel>(response);
        }

        private async Task<object> ResolveVerificaVinculoMembro(IGraphBuilderResolve resolve)
        {
            var response = new ValidaVinculoItemVaga();
            var input = _query.ParseArgument<VinculoMembroVaga>(resolve.Context, new[] { FilterArgument });

            await SetupValidaFilterAsync(input,
                resolve.RepositoryService(),
                resolve.VinculoMembroVagaDomainService()
               );
                        
            var validation = await new VinculoMembroVagaSaveValidator(resolve.Provider.GetRequiredService<IPropertyNameNormalizer>(), resolve.Provider.GetRequiredService<IStringLocalizer<DomainResources>>(), resolve.VinculoMembroVagaDomainService()).ValidateAsync(input);
            
            if(validation.IsValid)
                response.Status = true;
            else
            {
                response.Status = false;
                foreach (var item in validation.Errors)
                    response.Mensagens.Add(item.ErrorMessage);
            }     
            
            return response;
        }

        private async Task SetupInputAsync(VinculoMembroVaga input, IRepositoryService<ApplicationSajDsgDbContext> repositoryService, VinculoMembroVagaService domainService)
        {
            var query = await repositoryService.GetQueryableAsync<VinculoMembroVaga>();
            var periodoVencido = await domainService.ValidacaoVinculoVencido(query, input).AnyAsync();
            if (periodoVencido) domainService.NotificarPeriodo(input.Metadata.Uuid);
            await ValidatePeriod(input, query, domainService);
        }

        private async Task SetupCreateInputAsync(VinculoMembroVaga input, IRepositoryService<ApplicationSajDsgDbContext> repositoryService, VinculoMembroVagaService domainService, ICrudService<VinculoMembroVaga, IdVinculoMembroVaga> crudService)
        {
            var query = await repositoryService.GetQueryableAsync<VinculoMembroVaga>();
            await ValidatePeriod(input, query, domainService);
            var ultimoVinculoAtivo = await domainService.VagaVinculoAtivo(query, input).FirstOrDefaultAsync();
            if (ultimoVinculoAtivo != null)
            {
                ultimoVinculoAtivo.SetDataFinalOnUpdate(input.DataInicial);
                
               await crudService.UpdateAsync(ultimoVinculoAtivo);
            }
        }

        private async Task SetupValidaFilterAsync(VinculoMembroVaga input, IRepositoryService<ApplicationSajDsgDbContext> repositoryService, VinculoMembroVagaService domainService)
        {
            var query = await repositoryService.GetQueryableAsync<VinculoMembroVaga>();
            await ValidatePeriod(input, query, domainService);            
        }

        private async Task ValidatePeriod(VinculoMembroVaga input, IQueryable<VinculoMembroVaga> query, VinculoMembroVagaService domainService)
        {
            var any = await domainService.FiltrarInformacoesJaVinculadas(query, input).AnyAsync();
            if (any) domainService.NotificarInformacoesJaVinculadas(input.Metadata.Uuid);
            var entreVigente = await domainService.ValidarPeriodoEntreVigente(query, input).AnyAsync();
            var contemVigente = await domainService.ValidarPeriodoContemVigente(query, input).AnyAsync();
            if (entreVigente || contemVigente) domainService.NotificarPeriodo(input.Metadata.Uuid);
        }
       
    }
}