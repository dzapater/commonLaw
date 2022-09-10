using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Graph.SchemaExtension;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas
{
    public class MotivoMembroVagaSchemaExtension : SchemaExtension<DistribuicaoSegundoGrauSchema>
    {
        private IExtensibleQueryType _query;
        private IExtensibleMutationType _mutation;
        private const string FilterArgument = "filter";
        private const string List = "list_motivo_membro_vaga";

        protected override void OnExtend(IExtensibleMutationType mutation)
        {
            _mutation = mutation;
        }

        protected override void OnExtend(IExtensibleQueryType query)
        {
            _query = query;
            _query.From<MotivoMembroVagaReadModel, IdMotivoMembroVaga, MotivoMembroVagaGraphType>()
                .Custom<MotivoMembroVagaFilterType, CustomGraphPagedListType<MotivoMembroVagaListItemGraphType, MotivoMembroVagaReadModel>>(List, ResolveList);
        }

        private async Task<object> ResolveList(IGraphBuilderResolve resolve)
        {
            var filter = _query.ParseArgument<MotivoMembroVagaFilter>(resolve.Context, new[] {FilterArgument});
            var response = await resolve.Provider.GetRequiredService<IMotivoMembroVagaQueryService>()
                .ListAsync(filter);
            return new CustomGraphPagedList<MotivoMembroVagaReadModel>(response);
        }
    }
}