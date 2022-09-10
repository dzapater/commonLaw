using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using Microsoft.EntityFrameworkCore;
using Softplan.Common.Core.Entities;
using Softplan.Common.Graph.SchemaExtension;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Repositories.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Cadastros;
using GraphQL.Utilities;
using Microsoft.Extensions.Localization;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Providers.Interfaces;
using Softplan.Common.Core;
using Softplan.Common.Core.Validation;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.USR;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas
{
    public class VagaSchemaExtension : SchemaExtension<DistribuicaoSegundoGrauSchema>
    {
        private IExtensibleQueryType _query;
        private IExtensibleMutationType _mutation;
        private const string InputArgument = "input";
        private const string FilterArgument = "filter";
        private const string SortArgument = "sort";
        private const string Create = "create_vaga";
        private const string Update = "update_vaga";
        private const string Delete = "delete_vaga";
        private const string List = "list_vagas";

        protected override void OnExtend(IExtensibleMutationType mutation)
        {
            _mutation = mutation;
            _mutation
                .From<Vaga, IdVaga>()
                .Custom<CreateVagaInputType, VagaGraphType>(Create, ResolveCreate, Claims.DSG_VAGA_CRIAR)
                .Custom<UpdateVagaInputType, VagaGraphType>(Update, ResolveUpdate, Claims.DSG_VAGA_ATUALIZAR)
                .Custom<DeleteVagaGraphType, VagaGraphType>(Delete, ResolveDelete, Claims.DSG_VAGA_DELETAR);
        }
        
        protected override void OnExtend(IExtensibleQueryType query)
        {
            _query = query;
            _query.From<Vaga, IdVaga, VagaGraphType>()
                .GetById(claims: Claims.DSG_VAGA_OBTER)
                .Custom<VagaFilterType, CustomGraphPagedListType<VagaListItemGraphType, VagaReadModel>>(List, ResolveList, Claims.DSG_VAGA_LISTAR);
        }
        
        private async Task<object> ResolveCreate(IGraphBuilderResolve resolve)
        {
            var input = _mutation.ParseArgument<Vaga>(resolve.Context, new[] { InputArgument });
            await SetupInputAsync(input, resolve.RepositoryService(), resolve.VagaDomainService());            
            var lotacao = await SetupConsultaLotacao(resolve);
            input.CdLocal = lotacao.IdLocal;
            await resolve.VagaCrudService().AddAsync(input);
            return input;
        }
        
        private async Task<object> ResolveUpdate(IGraphBuilderResolve resolve)
        {
            var input = _mutation.ParseArgument<Vaga>(resolve.Context, new[] { InputArgument });
            var vagaCadastrada = await resolve.VagaReadService().GetAsync(new IdVaga { Id = input.Id });
            var vaga = SetPartialUpdate(input, vagaCadastrada);
            await SetupInputAsync(vaga, resolve.RepositoryService(), resolve.VagaDomainService());
            await SetupUpdateAsync(vaga, resolve.RepositoryService(), resolve.VagaDomainService());
            var lotacao = await SetupConsultaLotacao(resolve);
            vaga.CdLocal = lotacao.IdLocal;
            await resolve.VagaCrudService().UpdateAsync(vaga);
            return input;
        }

        private async Task<object> ResolveDelete(IGraphBuilderResolve resolve)
        {
            var input = _mutation.ParseArgument<Vaga>(resolve.Context, new[] { InputArgument });
            var result = await resolve.RepositoryService().GetAsync<Vaga>(x => x.Id == input.Id);
            if (result is null)
            {
                var service = resolve.Provider.GetRequiredService<VagaService>();
                service.InformarVagaJaCadastrada(input.Metadata.Uuid);
                var validation =
                    await new VagaDeleteRuleSet(resolve.Provider.GetRequiredService<IPropertyNameNormalizer>(), resolve.Provider.GetRequiredService<IStringLocalizer<DomainResources>>(), resolve.VagaDomainService()).ValidateAsync(input);
                foreach (var item in validation.Errors)
                    input.Mensagens.Add(item.ErrorMessage);
                return input;
            }
            await resolve.VagaCrudService().DeleteAsync(input);
            return input;
        }

        private async Task SetupInputAsync(Vaga input, IRepositoryService<ApplicationSajDsgDbContext> repositoryService, VagaService domainService)
        {
            var query = await repositoryService.GetQueryableAsync<Vaga>();
            var any = await domainService.FiltrarVagasJaCadastradas(query, input).AnyAsync();
            if (any) domainService.InformarVagaJaCadastrada(input.Metadata.Uuid);
        }

        private async Task SetupUpdateAsync(Vaga input, IRepositoryService<ApplicationSajDsgDbContext> repositoryService, VagaService domainService)
        {
            var query = await repositoryService.GetQueryableAsync<Vaga>();
            var any = await domainService.FiltrarOrgaosInvalidos(query, input).AnyAsync();
            if (any) domainService.InformarOrgaoInvalido(input.Metadata.Uuid);
        }
        
        private async Task<object> ResolveList(IGraphBuilderResolve resolve)
        {
            var filter = _query.ParseArgument<VagaFilter>(resolve.Context, new[] { FilterArgument });
            var sorts = resolve.Context.GetArgument<ICollection<Sort>>(SortArgument);
            filter.CdLocal = SetupConsultaLotacao(resolve).Result.IdLocal;
            var response = await resolve.VagaQueryService().ListAsync(filter, sorts);
            return new CustomGraphPagedList<VagaReadModel>(response);
        }

        private Vaga SetPartialUpdate(Vaga input, Vaga vagaCadastrada)
        {
            vagaCadastrada.Area = input.Area;
            vagaCadastrada.Descricao = input.Descricao;
            vagaCadastrada.EstaAtiva = input.EstaAtiva;
            vagaCadastrada.PermiteReuPreso = input.PermiteReuPreso;
            vagaCadastrada.IdInstalacao = input.IdInstalacao;
            vagaCadastrada.PermiteDistribuicaoMesmaVaga = input.PermiteDistribuicaoMesmaVaga;
            vagaCadastrada.ConsiderarConfiguracoesPrevencao = input.ConsiderarConfiguracoesPrevencao;
            if (input.Orgao?.Id != null) vagaCadastrada.Orgao.Id = input.Orgao.Id;
            if (input.Orgao?.IdTipoOrgao != null) vagaCadastrada.Orgao.IdTipoOrgao = input.Orgao.IdTipoOrgao;
            if (input.ProcuradorTitular?.Id != null) vagaCadastrada.ProcuradorTitular.Id = input.ProcuradorTitular.Id;

            return vagaCadastrada;
        }

        private async Task<LotacaoResponseMessage> SetupConsultaLotacao(IGraphBuilderResolve resolve)
        {
            var usrGateway = resolve.Provider.GetRequiredService<IUsrGatewayService>();
            var serviceLotacao = resolve.Provider.GetRequiredService<ILotacaoUsuarioLogadoProvider>();
            var lotacao = serviceLotacao.Get();
            var principal = resolve.Provider.GetRequiredService<ISoftplanPrincipal>();
            return await usrGateway.GetIdLocalByLotacaoId(int.Parse(lotacao), principal.Identity?.Name);
        }
       
    }
}