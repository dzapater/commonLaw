using Bogus;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers
{
    public class CompensacaoLogFaker
    {
        public static readonly Faker<CompensacaoLog> Entidade =
            new Faker<CompensacaoLog>()
                .RuleFor(x => x.Motivo, f => f.Lorem.Word())
                .RuleFor(x => x.Valor, f => f.Random.Number());
    }
}