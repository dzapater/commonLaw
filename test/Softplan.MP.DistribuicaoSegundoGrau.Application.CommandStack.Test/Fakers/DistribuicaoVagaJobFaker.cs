using Bogus;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Jobs.Distribuicoes;
using Softplan.SAJ.Audit.Extensions;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Test.Fakers
{
    public class DistribuicaoVagaJobFaker
    {
        public static readonly Faker<DistribuicaoVagaJob> CriarDistribuicaoVagaJobFaker =
            new Faker<DistribuicaoVagaJob>()
                .RuleFor(x => x.PayLoad, f => f.SerializeObject())
                .RuleFor(x => x.Id, f => nameof(DistribuicaoVagaJob))
                .RuleFor(x => x.Descricao, f => nameof(DistribuicaoVagaJob));

    }
}