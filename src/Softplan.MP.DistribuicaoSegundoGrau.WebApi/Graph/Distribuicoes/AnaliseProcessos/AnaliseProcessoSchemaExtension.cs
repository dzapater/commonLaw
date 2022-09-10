using System.Threading.Tasks;
using GraphQL.Utilities;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Graph.SchemaExtension;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.MCD;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.AnaliseProcessos.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Distribuicoes;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.AnaliseProcessos
{
    public class AnaliseProcessoSchemaExtension : SchemaExtension<DistribuicaoSegundoGrauSchema>
    {
        private IExtensibleQueryType _query;
        private IExtensibleMutationType _mutation;
        private const string InputArgument = "input";
        private const string FilterArgument = "filter";
        private const string AnalisarProcesso = "analisar_processo";
        private const string ConsultaAnaliseProcesso = "consulta_analise_processo";
        private const string AnaliseProcesso = "analise_processo";

        protected override void OnExtend(IExtensibleMutationType mutation)
        {
            _mutation = mutation;
            _mutation
                .From<AnaliseProcesso, IdAnaliseProcesso>()
                .Custom<AnalisarProcessoInputType, AnaliseProcessoFormatadoGraphType>(AnalisarProcesso, ResolveAnalisarProcesso);
        }

        protected override void OnExtend(IExtensibleQueryType query)
        {
            _query = query;
            _query.From<AnaliseProcesso, IdAnaliseProcesso, AnaliseProcessoGraphType>()
                .Custom<AnaliseProcessoFilterType, AnaliseProcessoGraphType>(AnaliseProcesso, ResolveAnaliseProcessoById)
                .Custom<AnaliseProcessoFilterType, AnaliseProcessoReadModelGraphType>(ConsultaAnaliseProcesso, ResolveConsultaAnaliseProcesso);
        }

        private async Task<object> ResolveAnaliseProcessoById(IGraphBuilderResolve resolve)
        {
            var filter = _query.ParseArgument<AnaliseProcessoFilter>(resolve.Context, new[] { FilterArgument });
            var analise = await resolve.AnaliseProcessoReadService().GetAsync(new IdAnaliseProcesso { IdProcesso = filter.IdProcesso });
            if (analise?.AreaAtuacao != default)
                analise.AreaAtuacao = await GetAreaAtuacaoById(analise.AreaAtuacao.Id, resolve);

            return analise;
        }

        private async Task<object> ResolveConsultaAnaliseProcesso(IGraphBuilderResolve resolve)
        {
            var filter = _query.ParseArgument<AnaliseProcessoFilter>(resolve.Context, new[] { FilterArgument });

            var result = await resolve.AnaliseProcessosQueryService().GetAnaliseById(filter);
            if (result?.AreaAtuacao != default)
                result.AreaAtuacao = await GetAreaAtuacaoById(result.AreaAtuacao.Id, resolve);
            
            return result;
        }

        private async Task<object> ResolveAnalisarProcesso(IGraphBuilderResolve resolve)
        {
            var input = _mutation.ParseArgument<AnaliseProcessoFormatado>(resolve.Context, new[] {InputArgument});
            var crudService = resolve.AnaliseProcessoCrudService();

            await SetupAnaliseProcesso(resolve, input);
            
            var domainModel = await crudService.GetAsync(input);
            await (domainModel == default
                ? crudService.AddAsync(input)
                : crudService.UpdateAsync(input));

            return input;
        }

        private async Task SetupAnaliseProcesso(IGraphBuilderResolve resolve, AnaliseProcessoFormatado input)
        {
            var domainService = resolve.AnaliseProcessoDomainService();
            var mcdGateway = resolve.Provider.GetRequiredService<IMcdGatewayService>();
            var processo = await mcdGateway.GetProcessoById(input.IdProcesso);
            
            if(processo == null)
                domainService.InformarProcessoInvalido(input.Metadata.Uuid);
            else if (processo.Status.Equals("READ_ONLY"))
                domainService.InformarLotacaoInvalida(input.Metadata.Uuid);
            
            if (input.AreaAtuacao != null)
                input.AreaAtuacao.Nome = mcdGateway.GetAreaAtuacaoById(input.AreaAtuacao.Id).Result?.Nome;
        }

        private async Task<AreaAtuacao> GetAreaAtuacaoById(long idAreaAtuacao, IGraphBuilderResolve resolve)
        {
            var mcdGateway = resolve.Provider.GetRequiredService<IMcdGatewayService>();
            return await mcdGateway.GetAreaAtuacaoById(idAreaAtuacao);
        }
    }
}