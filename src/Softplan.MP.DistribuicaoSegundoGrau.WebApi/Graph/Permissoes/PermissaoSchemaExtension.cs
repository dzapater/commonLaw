using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Softplan.Common.Authorization.Abstractions.Services;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Graph.SchemaExtension;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Permissoes;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Permissoes.Types;
using Softplan.SAJ.Core.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Permissoes
{
    public class PermissaoSchemaExtension : SchemaExtension<DistribuicaoSegundoGrauSchema>
    {
        private const string Permissoes = "permissoes";

        protected override void OnExtend(IExtensibleMutationType mutation)
        {
        }

        protected override void OnExtend(IExtensibleQueryType query)
        {
            query.Custom<PermissoesFiltroInputType, PermissoesGraphType>(Permissoes,
                async resolve =>
                {
                    var principal = resolve.Provider.GetRequiredService<ISoftplanSAJPrincipal>();
                    var filter = query.ParseArgument<PermissoesFiltro>(resolve.Context, new[] {"filter"});
                    var result = await resolve.Provider.GetRequiredService<IAuthorizationService>()
                        .GetCurrentPermissions(filter.Universo.ToArray());

                    return new Domain.Permissoes.Permissoes
                    {
                        Usuario = principal.Identity?.Name,
                        Lotacao = principal.Lotacao,
                        Items = result.Select(x => x.Id)
                    };
                });
        }
    }
}