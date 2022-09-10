using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Permissoes;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Permissoes.Types
{
    public class PermissoesFiltroInputType : Softplan.Common.Graph.Types.InputObjectGraphType<PermissoesFiltro>
    {
        public PermissoesFiltroInputType(IDescriptionProvider provider) : base(provider)
        {
            Field(f => f.Universo);
        }
    }
}