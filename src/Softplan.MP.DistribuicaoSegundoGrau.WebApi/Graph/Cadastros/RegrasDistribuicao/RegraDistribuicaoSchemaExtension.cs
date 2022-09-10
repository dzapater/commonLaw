using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Utilities;
using Microsoft.EntityFrameworkCore;
using Softplan.Common.Core;
using Softplan.Common.Core.Entities;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Graph.SchemaExtension;
using Softplan.Common.Repositories.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.MCD;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.TAX;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.USR;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Providers.Interfaces;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Cadastros;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao
{
    public class RegraDistribuicaoSchemaExtension : SchemaExtension<DistribuicaoSegundoGrauSchema>
    {
        private IExtensibleQueryType _query;
        private IExtensibleMutationType _mutation;
        private const string InputArgument = "input";
        private const string FilterArgument = "filter";
        private const string SortArgument = "sort";
        private const string Create = "create_regra_distribuicao";
        private const string Update = "update_regra_distribuicao";
        private const string Delete = "delete_regra_distribuicao";
        private const string List = "list_regras_distribuicao";

        protected override void OnExtend(IExtensibleMutationType mutation)
        {
            _mutation = mutation;
            _mutation
                .From<RegraDistribuicao, IdRegraDistribuicao>()
                .Custom<CreateRegraDistribuicaoInputType, RegraDistribuicaoGraphType>(Create, ResolveCreate, Claims.DSG_REGRADISTIBUICAO_CRIAR)
                .Custom<UpdateRegraDistribuicaoInputType, RegraDistribuicaoGraphType>(Update, ResolveUpdate, Claims.DSG_REGRADISTIBUICAO_ATUALIZAR)
                .Custom<DeleteRegraDistribuicaoInputType, RegraDistribuicaoGraphType>(Delete, ResolveDelete, Claims.DSG_REGRADISTIBUICAO_DELETAR);
        }

        protected override void OnExtend(IExtensibleQueryType query)
        {
            _query = query;
            _query.From<RegraDistribuicao, IdRegraDistribuicao, RegraDistribuicaoGraphType>()
                .GetById(claims: Claims.DSG_REGRADISTIBUICAO_OBTER)
                .Custom<RegraDistribuicaoFilterType, CustomGraphPagedListType<RegraDistribuicaoListItemGraphType, RegraDistribuicaoReadModel>>(List, ResolveList, Claims.DSG_REGRADISTIBUICAO_LISTAR);
        }

        private async Task<object> ResolveCreate(IGraphBuilderResolve resolve)
        => await ResolveUpsert(resolve,resolve.RegraDistribuicaoCrudService().AddAsync);

        private async Task<object> ResolveUpdate(IGraphBuilderResolve resolve)
        => await ResolveUpsert(resolve, resolve.RegraDistribuicaoCrudService().UpdateAsync);
        
        private async Task<object> ResolveUpsert(IGraphBuilderResolve resolve, Func<RegraDistribuicao, Task> function)
        {
            var input = _mutation.ParseArgument<RegraDistribuicao>(resolve.Context, new[] {InputArgument});
            await SetupInputAsync(input, 
                resolve.RepositoryService(), 
                resolve.RegraDistribuicaoDomainService(), 
                resolve.RegraDistribuicaoQueryService());
            var lotacao = await SetupConsultaLotacao(resolve);
            input.CdLocal = lotacao.IdLocal;
            await SetDescricaoCriterios(resolve, input);
            await function(input);
            return input;
        }

        private async Task SetDescricaoCriterios(IGraphBuilderResolve resolve, RegraDistribuicao input)
        {
            var mcdGateway = resolve.Provider.GetRequiredService<IMcdGatewayService>();
            var taxGateway = resolve.Provider.GetRequiredService<ITaxGatewayService>();
            var regraService = resolve.RegraDistribuicaoDomainService();
            await SetDescricaoEspecialidade(mcdGateway, input);
            await SetDescricaoAssunto(taxGateway, input);
            await SetDescricaoClasse(taxGateway, input);
            await SetDescricaoTarja(taxGateway, input);
            await SetDescricaoOrgaoJulgador(taxGateway, input, regraService);
            await SetDescricaoUnidade(taxGateway, input);
        }

        private async Task SetDescricaoEspecialidade(IMcdGatewayService mcdGateway, RegraDistribuicao regraDistribuicao)
        {
            foreach (var especialidade in regraDistribuicao.Especialidades)
            {
                var response = await mcdGateway.GetEspecialidadeById(especialidade.IdEspecialidade);
                especialidade.Descricao = response?.Descricao;
            }
        }

        private async Task SetDescricaoAssunto(ITaxGatewayService taxGatewayService,
            RegraDistribuicao regraDistribuicao)
        {
            var idsAssunto = regraDistribuicao.Assuntos.Select(x => x.IdAssunto).ToArray();
            var response = await taxGatewayService.GetAssuntosByIds(idsAssunto);
            foreach (var assunto in regraDistribuicao.Assuntos)
            {
                assunto.Descricao = response?.FirstOrDefault(x => x.Id == assunto.IdAssunto)?.Descricao;
            }
        }
        
        private async Task SetDescricaoClasse(ITaxGatewayService taxGatewayService, RegraDistribuicao regraDistribuicao)
        {
            foreach (var classe in regraDistribuicao.Classes)
            {
                var response = await taxGatewayService.GetClasseById(classe.IdClasse);
                classe.Descricao = response?.Descricao;
            }
        }
        
        private async Task SetDescricaoOrgaoJulgador(ITaxGatewayService taxGatewayService, RegraDistribuicao regraDistribuicao,
            RegraDistribuicaoService service)
        {
            foreach (var orgao in regraDistribuicao.OrgaosJulgadores)
            {
                var response = await taxGatewayService.GetOrgaoJulgadorById(orgao.IdTipoCadastro, orgao.IdUnidade, orgao.IdOrgaoJulgador);
                if (response == null)
                    service.InformarOrgaoJulgadorInvalido(regraDistribuicao.Metadata.Uuid);
                
                orgao.Descricao = response?.Descricao;
            }
        }
        
        private async Task SetDescricaoUnidade(ITaxGatewayService taxGatewayService, RegraDistribuicao regraDistribuicao)
        {
            foreach (var unidade in regraDistribuicao.Unidades)
            {
                var response = await taxGatewayService.GetUnidadeById(unidade.IdTipoCadastro, unidade.IdUnidade);
                unidade.Descricao = response?.Descricao;
            }
        }
        
        private async Task SetDescricaoTarja(ITaxGatewayService taxGatewayService, RegraDistribuicao regraDistribuicao)
        {
            foreach (var tarja in regraDistribuicao.Tarjas)
            {
                var response = await taxGatewayService.GetTarjaById(tarja.IdTarja);
                tarja.Descricao = response?.Descricao;
            }
        }

        private async Task<object> ResolveDelete(IGraphBuilderResolve resolve)
        {
            var input = _mutation.ParseArgument<RegraDistribuicao>(resolve.Context, new[] {InputArgument});
            await SetupDeleteInputAsync(input, 
                resolve.RepositoryService(), 
                resolve.RegraDistribuicaoDomainService());
            await resolve.RegraDistribuicaoCrudService().DeleteAsync(input);
            return input;
        }

        private async Task SetupInputAsync(RegraDistribuicao input, IRepositoryService<ApplicationSajDsgDbContext> repositoryService,  RegraDistribuicaoService domainService,  IRegraDistribuicaoQueryService queryService)
        {
            var query = await repositoryService.GetQueryableAsync<RegraDistribuicao>();
            var descricaoCadastrada = await domainService.FiltrarDescricaoCadastrada(query, input).AnyAsync();
            if(descricaoCadastrada) 
                domainService.InformarRegraJaCadastrada(input.Metadata.Uuid);
            var criteriosCadastrados = await ExistingCriteria(query, input, domainService, queryService);
            if(criteriosCadastrados)
                domainService.InformarRegraJaCadastrada(input.Metadata.Uuid);
            if(input.SemCriterios()) domainService.InformarRegraSemCriterio(input.Metadata.Uuid);  
        }
        
        private async Task SetupDeleteInputAsync(RegraDistribuicao input, IRepositoryService<ApplicationSajDsgDbContext> repositoryService, RegraDistribuicaoService domainService)
        {
            var query = await repositoryService.GetQueryableAsync<VinculoVagaRegraDistribuicao>();
            var any = await domainService.FiltrarVagasVinculadas(query, input).AnyAsync();
            if (any) domainService.InformarVagaComDistribuicao(input.Id);
        }

        private async Task<object> ResolveList(IGraphBuilderResolve resolve)
        {
            var filter = _query.ParseArgument<RegraDistribuicaoFilter>(resolve.Context, new[] {FilterArgument});
            var sorts = resolve.Context.GetArgument<ICollection<Sort>>(SortArgument);
            filter.CdLocal = SetupConsultaLotacao(resolve).Result.IdLocal;
            var response = await resolve.RegraDistribuicaoQueryService().ListAsync(filter, sorts);
            return new CustomGraphPagedList<RegraDistribuicaoReadModel>(response);
        }

        private async Task<bool> ExistingCriteria(IQueryable<RegraDistribuicao> query, RegraDistribuicao input, RegraDistribuicaoService domainService,  IRegraDistribuicaoQueryService queryService)
        {
            var regrasCadastradas = await domainService.FiltrarRegrasJaCadastradas(query, input).ToListAsync();
            regrasCadastradas = await queryService.ListAsync(regrasCadastradas.Select(r => r.Id).ToArray());
            return domainService.ExistingCriteria(regrasCadastradas, input);
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