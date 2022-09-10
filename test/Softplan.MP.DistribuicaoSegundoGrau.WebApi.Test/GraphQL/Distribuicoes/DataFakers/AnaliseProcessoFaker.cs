using Bogus;
using Bogus.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DataFakers
{
    class AnaliseProcessoFaker
    {
        public static readonly Faker<AnaliseProcesso> Entidade =
            new Faker<AnaliseProcesso>()
                .RuleFor(x => x.IdProcesso, f => f.Company.Bs())
                .RuleFor(x => x.TipoDistribuicao, f => f.PickRandom(TipoDistribuicao.Prevencao, TipoDistribuicao.Sorteio))
                .RuleFor(x => x.AreaAtuacao, new AreaAtuacao { Id = 1})
                .RuleFor(x => x.IdVaga, f => f.IndexFaker)
                .RuleFor(x => x.Motivo, f => f.Lorem.Sentences().ClampLength(max: 2000));
    }
}