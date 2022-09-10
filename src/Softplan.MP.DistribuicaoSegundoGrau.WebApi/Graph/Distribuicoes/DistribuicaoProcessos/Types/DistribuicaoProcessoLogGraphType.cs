using GraphQL.Types;
using GraphQL.Utilities.Federation;
using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.DistribuicaoProcessos.Types
{
        public class DistribuicaoProcessoLogGraphType : Softplan.Common.Graph.Types.ObjectGraphType<DistribuicaoProcessoLog>
        {
            public DistribuicaoProcessoLogGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
            {
                Field(x => x.DistribuicaoId, true);
                Field(x => x.DomainEvent, true, typeof(DomainEventGraphType));
                Field(x => x.IdProcesso, true);
                Field(x => x.TransactionId, true, typeof(GuidGraphType));
                Field(x => x.PayloadType, true);
                Field(x => x.PayloadSerialization, true, typeof(PayloadSerializationGraphType));
                Field(x => x.Payload, true);
            }
        }
}