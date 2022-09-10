using Softplan.Common.Graph.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Permissoes.Types
{
    public class PermissoesGraphType : Common.Graph.Types.ObjectGraphType<Domain.Permissoes.Permissoes>
    {
        public PermissoesGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(f => f.Usuario);
            Field(f => f.Lotacao, true);
            Field(f => f.Items);
        }
    }
}