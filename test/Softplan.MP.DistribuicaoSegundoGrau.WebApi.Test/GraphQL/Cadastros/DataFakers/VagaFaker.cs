using Bogus;
using Bogus.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers
{
    class VagaFaker
    {
        public static readonly Faker<Vaga> Entidade =
            new Faker<Vaga>()
                .RuleFor(x => x.Descricao, f => f.Company.CompanyName().ClampLength(max: 120))
                .RuleFor(x => x.IdInstalacao, f => f.IndexGlobal)
                .RuleFor(x => x.ProcuradorTitular,
                    f => new ProcuradorTitular {Id = f.Company.CompanyName().ClampLength(max: 20)})
                .RuleFor(x => x.Orgao, f => new Orgao {Id = 1, IdTipoOrgao = 1})
                .RuleFor(x => x.Area, f => f.PickRandom(new[] {Area.Ambas, Area.Civel, Area.Criminal}))
                .RuleFor(x => x.Motivo, f => f.Lorem.Sentence(60))
                .RuleFor(x => x.ConsiderarConfiguracoesPrevencao, f => f.PickRandom(true, false))
                .RuleFor(x => x.EstaAtiva, f => true)
                .RuleFor(x => x.PermiteReuPreso, f => f.PickRandom(true, false))
                .RuleFor(x => x.PermiteDistribuicaoMesmaVaga, f => f.PickRandom(true, false))
                .RuleFor(x => x.Distribuicoes, f => 150)
                .RuleFor(x => x.Compensacao, f => 0)
                .RuleFor(x => x.CdLocal, f => 2);
    }
}