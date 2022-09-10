using GraphQL.Language.AST;
using GraphQL.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.DistribuicaoProcessos.Types
{
    public class DomainEventGraphType : ScalarGraphType
    {
        public override object ParseLiteral(IValue value) => value.Value;

        public override object ParseValue(object value) => value;
    }
}