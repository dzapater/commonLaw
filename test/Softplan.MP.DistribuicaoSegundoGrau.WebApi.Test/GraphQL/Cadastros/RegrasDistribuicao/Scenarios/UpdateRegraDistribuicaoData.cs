using System.Collections;
using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.RegrasDistribuicao.Scenarios
{
    public class UpdateRegraDistribuicaoData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            RegraDistribuicaoFixture.RegraAtualizada.Descricao = new Faker().Company.CompanyName().ClampLength(max: 120);
            RegraDistribuicaoFixture.RegraAtualizada.Assuntos = new List<CriterioAssunto> {new CriterioAssunto {IdAssunto = Faker.GlobalUniqueIndex}};
            RegraDistribuicaoFixture.RegraAtualizada.Classes = new List<CriterioClasse> {new CriterioClasse {IdClasse = Faker.GlobalUniqueIndex}};
            RegraDistribuicaoFixture.RegraAtualizada.Unidades = new List<CriterioUnidade> {new CriterioUnidade {IdUnidade = Faker.GlobalUniqueIndex}};
            RegraDistribuicaoFixture.RegraAtualizada.OrgaosJulgadores = new List<CriterioOrgaoJulgador> {new CriterioOrgaoJulgador {IdOrgaoJulgador = Faker.GlobalUniqueIndex}};
            yield return new object[] {RegraDistribuicaoFixture.RegraAtualizada};
        }
    }
}