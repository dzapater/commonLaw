using System.Collections;
using System.Collections.Generic;
using Bogus;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.AnaliseProcessos.Scenarios
{
    public class AnalisarProcessoAtualizadoPorSorteioData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {AnaliseProcessoFixture.EntidadeAtualizadaPorSorteio};
        }
    }
}