using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Validation;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Graph.SchemaExtension;
using Softplan.Common.Repositories.EntityFrameworkCore;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Impedimento;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.ImpedimentoProcessos.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Cadastros;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Distribuicoes;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.ImpedimentoProcessos
{
    public class ImpedimentoProcessoSchemaExtension : SchemaExtension<DistribuicaoSegundoGrauSchema>
    {
        private IExtensibleQueryType _query;
        private IExtensibleMutationType _mutation;
        private const string InputArgument = "input";
        private const string FilterArgument = "filter";
        private const string SortArgument = "sort";
        private const string Create = "create_impedimento_processo";
        private const string Update = "update_impedimento_processo";
        private const string Delete = "delete_impedimento_processo";
        private const string List = "list_impedimentos_processos";

        protected override void OnExtend(IExtensibleMutationType mutation)
        {
            _mutation = mutation;
            _mutation
                .From<ImpedimentoProcesso, IdImpedimentoProcesso>()
                .Custom<CreateImpedimentoProcessoInputType, ImpedimentoProcessoGraphType>(Create, ResolveCreate)
                .Custom<UpdateImpedimentoProcessoInputType, ImpedimentoProcessoGraphType>(Update, ResolveUpdate)
                .Custom<DeleteImpedimentoProcessoInputType, ImpedimentoProcessoGraphType>(Delete, ResolveDelete);
        }

        protected override void OnExtend(IExtensibleQueryType query)
        {
            _query = query;
            _query.From<ImpedimentoProcesso, IdImpedimentoProcesso, ImpedimentoProcessoGraphType>()
                .Custom<ImpedimentoProcessoFilterType, CustomGraphPagedListType<ImpedimentoProcessoGraphType, ImpedimentoProcesso>>(List, ResolveList);
        }

        private async Task<object> ResolveCreate(IGraphBuilderResolve resolve)
            => await ResolveUpsert(resolve, resolve.ImpedimentoProcessoCrudService().AddAsync);

        private async Task<object> ResolveUpdate(IGraphBuilderResolve resolve)
            => await ResolveUpsert(resolve, resolve.ImpedimentoProcessoCrudService().UpdateAsync);

        private async Task<object> ResolveUpsert(IGraphBuilderResolve resolve, Func<ImpedimentoProcesso, Task> function)
        {
            var input = _mutation.ParseArgument<ImpedimentoProcesso>(resolve.Context, new[] {InputArgument});
            await SetupInputAsync(input, 
                resolve.RepositoryService(), 
                resolve.ImpedimentoProcessoDomainService(), 
                resolve.VagaReadService());
            await function(input);
            return input;
        }

        private async Task<object> ResolveDelete(IGraphBuilderResolve resolve)
        {
            var input = _mutation.ParseArgument<ImpedimentoProcesso>(resolve.Context, new[] {InputArgument});
            var result = await resolve.RepositoryService().GetAsync<ImpedimentoProcesso>(x => x.IdImpedimento == input.IdImpedimento && x.IdProcesso == input.IdProcesso);
            if (result is null)
            {
                var service = resolve.Provider.GetRequiredService<ImpedimentoProcessoService>();
                service.InformarImpedimentoCadastrado(input.Metadata.Uuid);
                var validation =
                    await new ImpedimentoProcessoDeleteValidator(resolve.Provider.GetRequiredService<IPropertyNameNormalizer>(), resolve.Provider.GetRequiredService<IStringLocalizer<DomainResources>>(), resolve.ImpedimentoProcessoDomainService()).ValidateAsync(input);
                foreach (var item in validation.Errors)
                    input.Mensagens.Add(item.ErrorMessage);
                return input;
            }
            await resolve.ImpedimentoProcessoCrudService().DeleteAsync(input);
            return input;
        }

        private async Task<object> ResolveList(IGraphBuilderResolve resolve)
        {
            var filter = _query.ParseArgument<ImpedimentoFilter>(resolve.Context, new[] {FilterArgument});
            var sorts = resolve.Context.GetArgument<ICollection<Sort>>(SortArgument);             
            var result = await resolve.ImpedimentoVagaQueryService().ListAsync(filter, sorts);
            return new CustomGraphPagedList<ImpedimentoProcesso>(result);
        }

        private async Task SetupInputAsync(ImpedimentoProcesso input, IRepositoryService<ApplicationSajDsgDbContext> repositoryService, ImpedimentoProcessoService domainService, IReadService<Vaga, IdVaga> vagaReadService)
        {
            var query = await repositoryService.GetQueryableAsync<ImpedimentoProcesso>();
            var any = await domainService.FiltrarImpedimentoJaCadastrado(query, input).AnyAsync();
            if (any) domainService.InformarImpedimentoJaCadastrado(input.Metadata.Uuid);

            var vaga = await vagaReadService.GetAsync(new IdVaga{Id = input.IdVaga});
            if(vaga != null) domainService.InformarVagaAtiva(vaga.EstaAtiva);
        }
    }
} 
