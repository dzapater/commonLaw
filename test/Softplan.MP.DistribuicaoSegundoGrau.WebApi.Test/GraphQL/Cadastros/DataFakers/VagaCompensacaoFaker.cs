using Bogus;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers
{
    class VagaCompensacaoFaker
    {
        public static readonly Faker<VagaCompensacao> Entidade =
           new Faker<VagaCompensacao>()
               .RuleFor(x => x.Motivo, f => f.Lorem.ToString())
               .RuleFor(x => x.Compensacao, f => f.IndexFaker)
               .RuleFor(x => x.IdRegraDistribuicao, f => f.IndexFaker)
               .RuleFor(x => x.IdVaga, f => f.IndexFaker);
    }
}
