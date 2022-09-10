using Bogus;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers
{
    public class ExcecaoVagaFaker
    {
        public static readonly Faker<ExcecaoVaga> Entidade =
            new Faker<ExcecaoVaga>()
                .RuleFor(x => x.Id, f => f.Random.Long(1,9999))
                .RuleFor(x => x.IdVaga, f => f.Random.Int(1, 9999))
                .RuleFor(x => x.IdAssunto, f => f.Random.Int(1, 9999))
                .RuleFor(x => x.Motivo, f => f.Lorem.ToString());
        
        public static readonly Faker<ExcecaoVaga> EntidadeNullable =
            new Faker<ExcecaoVaga>()
                .RuleFor(x => x.Id, f => f.Random.Long(1,9999))
                .RuleFor(x => x.IdVaga, f => f.Random.Int(1, 9999))
                .RuleFor(x => x.Motivo, f => f.Lorem.ToString());
    }
}