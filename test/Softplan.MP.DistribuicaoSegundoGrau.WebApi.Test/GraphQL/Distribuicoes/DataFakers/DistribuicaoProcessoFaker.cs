using Bogus;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DataFakers
{
    public class DistribuicaoProcessoFaker
    {
        public static readonly Faker<DistribuirProcessoRequest> RequestCriarDistribuicaoProcesso =
            new Faker<DistribuirProcessoRequest>()
                .RuleFor(x => x.IdProcesso, f => f.Company.Bs())
                .RuleFor(x => x.TipoDistribuicao, f => f.PickRandom(TipoDistribuicao.Prevencao, TipoDistribuicao.Sorteio))
                .RuleFor(x => x.IdVaga, f => f.IndexFaker + 1)
                .RuleFor(x => x.Motivo, f => f.Lorem.Sentences(1));
    }
}