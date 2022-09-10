using Bogus;
using Bogus.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers
{
    class VinculoMembroVagaFaker
    {
        public static readonly Faker<VinculoMembroVaga> Entidade =
            new Faker<VinculoMembroVaga>()
                .RuleFor(x => x.IdMembro, f => f.Company.CompanyName().ClampLength(max: 20))
                .RuleFor(x => x.IdVaga, f => f.IndexFaker)
                .RuleFor(x => x.IdMotivoMembroVaga, f => f.IndexFaker)
                .RuleFor(x => x.Observacao, f => f.Lorem.Sentence(1))
                .RuleFor(x => x.DataInicial, faker => faker.Date.Past())
                .RuleFor(x => x.DataFinal, faker => faker.Date.Future());
    }
}