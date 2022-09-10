using System.Linq;
using Bogus;
using Bogus.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers
{
    class RegraDistribuicaoFaker
    {
        public static readonly Faker<RegraDistribuicao> Entidade =
            new Faker<RegraDistribuicao>()
                .RuleFor(x => x.Descricao, f => f.Company.CompanyName().ClampLength(max: 120))
                .RuleFor(x => x.Ativo, f => f.PickRandom(true, false))
                .RuleFor(x => x.TipoProcesso, f =>
                    f.PickRandom(new[] {TipoProcesso.Fisico, TipoProcesso.Eletronico}))
                .RuleFor(x => x.Area, f =>
                    f.PickRandom(new[] {Area.Civel, Area.Criminal}))
                .RuleFor(x => x.VariavelEquilibrio, f =>
                    f.PickRandom(new[] {VariavelEquilibrio.Volume, VariavelEquilibrio.Processo}))
                .RuleFor(x => x.EscopoEquilibrio, f =>
                    f.PickRandom(new[] {EscopoEquilibrio.Local, EscopoEquilibrio.Global}))
                .RuleFor(x => x.Especialidades, f => Enumerable.Range(1, 3)
                    .Select(x => new CriterioEspecialidade {IdEspecialidade = x}).ToArray())
                .RuleFor(x => x.Assuntos, f => Enumerable.Range(1, 3)
                    .Select(x => new CriterioAssunto {IdAssunto = x}).ToArray())
                .RuleFor(x => x.Classes, f => Enumerable.Range(1, 3)
                    .Select(x => new CriterioClasse {IdClasse = x}).ToArray())
                .RuleFor(x => x.Tarjas, f => Enumerable.Range(1, 3)
                    .Select(x => new CriterioTarja {IdTarja = x}).ToArray())
                .RuleFor(x => x.Unidades, f => Enumerable.Range(1, 3)
                    .Select(x => new CriterioUnidade {IdUnidade = x}).ToArray())
                .RuleFor(x => x.OrgaosJulgadores, f => Enumerable.Range(1, 3)
                    .Select(x => new CriterioOrgaoJulgador {IdOrgaoJulgador = x}).ToArray())
                .RuleFor(x => x.CdLocal, f => 2);
    }
}