using Microsoft.Extensions.DependencyInjection;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Repositories.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Cadastros
{
    public static class ResolveExtension
    {
        public static IRepositoryService<ApplicationSajDsgDbContext> RepositoryService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<IRepositoryService<ApplicationSajDsgDbContext>>();
    }
}