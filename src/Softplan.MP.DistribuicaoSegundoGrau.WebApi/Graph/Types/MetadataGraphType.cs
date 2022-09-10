using GraphQL.Types;
using Softplan.Common.Core.Entities;
using Softplan.Common.Graph.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types
{
    public class MetadataGraphType : Softplan.Common.Graph.Types.ObjectGraphType<EntityMetadata>
    {
        public MetadataGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.Uuid, true, type: typeof(GuidGraphType));
            Field(x => x.DataAtualizacao, true, type: typeof(DateTimeOffsetGraphType));
            Field(x => x.DataInclusao, true, type: typeof(DateTimeOffsetGraphType));
            Field(x => x.UsuarioInclusao, true);
            Field(x => x.UsuarioAtualizacao, true);
        }
    }
}