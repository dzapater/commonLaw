using Bogus;
using Bogus.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DataFakers
{
    class ImpedimentoProcessoFaker
    {
        public static readonly Faker<ImpedimentoProcesso> Entidade =
            new Faker<ImpedimentoProcesso>()
                .RuleFor(x => x.IdProcesso, f => f.Company.Bs())
                .RuleFor(x => x.Motivo, f => f.Lorem.Sentences().ClampLength(max: 2000));
    }
}