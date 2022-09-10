using Bogus;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers
{
    public class MotivoMembroVagaFaker
    {
        public static readonly Faker<MotivoMembroVagaReadModel> Entidade =
            new Faker<MotivoMembroVagaReadModel>()
                .RuleFor(x => x.Id, f => f.UniqueIndex)
                .RuleFor(x => x.Descricao, f => f.Lorem.Sentence(2))
                .RuleFor(x => x.Ativo, f => f.PickRandom("A","I"));
    }
}